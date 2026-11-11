'use client'

import { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import { assetsApi } from '../lib/store'
import { Alert, Button, Dialog, DialogActions, DialogTitle, Stack, Typography } from '@mui/material'
import { Alert as JoyAlert, Autocomplete, Box, Button as JoyButton, Checkbox, FormControl, FormLabel, Input, Stack as JoyStack, Textarea } from '@mui/joy'
import { CssVarsProvider } from '@mui/joy/styles'
import { Drawer, DrawerContent, DrawerDescription, DrawerTitle } from '../components/ui/drawer'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'
import OrgUnitTypeGrid from './org-unit-type-grid'
import { joyTheme } from './theme'

export const wellRecordPages: Record<string, string> = {
    Wellbore: 'wellbores',
    'Well Completion': 'completions',
    'Well Dir Srvy': 'directional-surveys',
    'Well Equipment': 'equipment',
    Perforation: 'perforations',
    'Well Pool': 'pools',
    'Well Prod Method History': 'production-method-history',
    'Well Status': 'statuses',
    'Well Tubing Tally': 'tubing-tallies',
    'Well Tubular': 'tubulars',
    'Well Zone': 'zones',
}

type Field = {
    key: string
    label: string
    kind: 'lookup' | 'boolean' | 'date' | 'text' | 'integer' | 'decimal'
    required: boolean
    maxLength?: number
    scale?: number
    copyTo?: string
}
type Option = { id: number; label: string; copyValue: string | null }
type Row = Record<string, unknown>
type Data = { idKey: string; fields: Field[]; lookups: Record<string, Option[]>; rows: Row[] }
type Values = Record<string, string | boolean>

function initialValues(fields: Field[]): Values {
    return Object.fromEntries(fields.map(field => [field.key, field.kind === 'boolean' ? field.key === 'isActive' : '']))
}

export default function WellRecords({ title, table }: { title: string; table: string }) {
    const url = '/api/well-records/' + table
    const dispatch = useDispatch()
    const [data, setData] = useState<Data>()
    const [loading, setLoading] = useState(true)
    const [loadError, setLoadError] = useState('')
    const [saving, setSaving] = useState(false)
    const [error, setError] = useState('')
    const [success, setSuccess] = useState(false)
    const [values, setValues] = useState<Values>()
    const [pending, setPending] = useState<(() => void) | null>(null)
    const dirty = !!values && !!data && JSON.stringify(values) !== JSON.stringify(initialValues(data.fields))

    async function load(signal?: AbortSignal) {
        setLoading(true)
        setLoadError('')
        try {
            const response = await fetch(url, { signal, cache: 'no-store' })
            if (!response.ok) throw new Error()
            setData(await response.json())
        } catch {
            if (!signal?.aborted) setLoadError('Unable to load records and reference options.')
        } finally {
            if (!signal?.aborted) setLoading(false)
        }
    }

    useEffect(() => {
        const controller = new AbortController()
        void load(controller.signal)
        return () => controller.abort()
    }, [url])

    useEffect(() => {
        const unload = (event: BeforeUnloadEvent) => {
            if (dirty || saving) event.preventDefault()
        }
        const navigate = (event: Event) => {
            if (!dirty && !saving) return
            event.preventDefault()
            if (!saving) setPending(() => (event as CustomEvent<() => void>).detail)
        }
        window.addEventListener('beforeunload', unload)
        window.addEventListener('osdu:navigate', navigate)
        return () => {
            window.removeEventListener('beforeunload', unload)
            window.removeEventListener('osdu:navigate', navigate)
        }
    }, [dirty, saving])

    function close() {
        if (saving) return
        if (dirty) setPending(() => () => setValues(undefined))
        else setValues(undefined)
    }

    function setValue(key: string, value: string | boolean) {
        setValues(current => current && { ...current, [key]: value })
    }

    function select(field: Field, option: Option | null) {
        setValues(current => {
            if (!current) return current
            const next = { ...current, [field.key]: option ? String(option.id) : '' }
            if (field.copyTo) next[field.copyTo] = option?.copyValue ?? ''
            return next
        })
    }

    const canSave = !!values && !!data && !saving &&
        data.fields.every(field => !field.required || String(values[field.key]).trim())

    async function save(event: React.FormEvent) {
        event.preventDefault()
        if (!data || !values || !canSave) return
        setSaving(true)
        setError('')
        const body = Object.fromEntries(data.fields.map(field => {
            const value = values[field.key]
            if (typeof value === 'boolean') return [field.key, value]
            const text = value.trim()
            const numeric = ['integer', 'decimal', 'lookup'].includes(field.kind)
            return [field.key, text ? numeric ? Number(text) : text : null]
        }))
        try {
            const response = await fetch(url, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(body),
            })
            if (!response.ok) {
                const result = await response.json().catch(() => null)
                throw new Error(result?.message || 'Unable to save the record.')
            }
            if (table === 'wellbores') dispatch(assetsApi.util.invalidateTags(['Wellbore']))
            setValues(undefined)
            setSuccess(true)
            await load()
        } catch (failure) {
            setError(failure instanceof Error ? failure.message : 'Unable to save the record.')
        } finally {
            setSaving(false)
        }
    }

    const columns = data ? [
        { key: data.idKey, label: 'ID' },
        ...data.fields.filter(field => field.key !== 'isActive').slice(0, 5),
        { key: 'isActive', label: 'Status' },
    ] : []
    const rows = data?.rows.map(row => {
        const display = { ...row }
        for (const field of columns) {
            const value = row[field.key]
            const option = data.lookups[field.key]?.find(item => item.id === value)
            if (option?.label) display[field.key] = option.label
            if ('kind' in field && field.kind === 'date' && typeof value === 'string')
                display[field.key] = value.slice(0, 10)
        }
        return display
    }) ?? []

    return <Stack spacing={2}>
        <Stack direction="row" sx={{ alignItems: 'center', justifyContent: 'space-between', gap: 2 }}>
            <Typography color="text.secondary">Browse and add records for {title}.</Typography>
            <Button variant="contained" disabled={!data || loading || saving} onClick={() => {
                if (!data) return
                setError('')
                setSuccess(false)
                setValues(initialValues(data.fields))
                void load()
            }}>Add record</Button>
        </Stack>
        {success && <Alert severity="success" onClose={() => setSuccess(false)}>Record saved.</Alert>}
        {loadError && <Alert severity="error" action={<Button onClick={() => void load()}>Retry</Button>}>{loadError}</Alert>}
        <OrgUnitTypeGrid recordTable={table} onRecordChange={()=>void load()} rows={rows} loading={loading || saving} idKey={data?.idKey}
            nameKey={columns[1]?.key ?? data?.idKey} entityLabel={title} customColumns={columns} />
        <Drawer swipeDirection="right" open={!!values} onOpenChange={open => { if (!open) close() }}>
            <DrawerContent>
                <CssVarsProvider theme={joyTheme}>
                    {data && values && <Box component="form" onSubmit={save}
                        sx={{ height: '100%', display: 'flex', flexDirection: 'column', bgcolor: 'background.surface' }}>
                        <Box sx={{ px: 3, py: 2, borderBottom: 1, borderColor: 'divider' }}>
                            <DrawerTitle>Add {title}</DrawerTitle>
                        </Box>
                        <JoyStack spacing={2} sx={{ flex: 1, minHeight: 0, overflowY: 'auto', p: 3 }}>
                            <DrawerDescription>Enter record details. The ID and audit fields are assigned automatically.</DrawerDescription>
                            {error && <JoyAlert color="danger">{error}</JoyAlert>}
                            {loadError && <JoyAlert color="danger">{loadError}</JoyAlert>}
                            {data.fields.map(field => {
                                const options = data.lookups[field.key] ?? []
                                const copied = data.fields.some(source => source.copyTo === field.key && values[source.key])
                                return <FormControl key={field.key} required={field.required}>
                                    <FormLabel>{field.label}</FormLabel>
                                    {field.kind === 'boolean' ? <Checkbox disabled={saving} checked={!!values[field.key]}
                                        onChange={event => setValue(field.key, event.target.checked)} />
                                        : field.kind === 'lookup' ? <Autocomplete
                                            options={options} loading={loading} disabled={saving}
                                            getOptionLabel={option => option.label ? option.label + ' (#' + option.id + ')' : '#' + option.id}
                                            isOptionEqualToValue={(a, b) => a.id === b.id}
                                            value={options.find(option => String(option.id) === values[field.key]) ?? null}
                                            onChange={(_, option) => select(field, option)}
                                            slotProps={{ listbox: { sx: { zIndex: 1400 } } }}
                                            noOptionsText="No matching records. Add a record in the related table first."
                                        /> : field.key === 'remark' ? <Textarea disabled={saving} minRows={3}
                                            value={String(values[field.key])} onChange={event => setValue(field.key, event.target.value)}
                                            slotProps={{ textarea: { maxLength: field.maxLength ?? undefined } }} />
                                            : <Input disabled={saving} readOnly={copied} required={field.required}
                                                type={field.kind === 'date' ? 'date' : field.kind === 'text' ? 'text' : 'number'}
                                                value={String(values[field.key])} onChange={event => setValue(field.key, event.target.value)}
                                                slotProps={{ input: { maxLength: field.maxLength ?? undefined,
                                                    step: field.kind === 'integer' ? 1 : field.kind === 'decimal' ? 'any' : undefined } }} />}
                                </FormControl>
                            })}
                        </JoyStack>
                        <JoyStack direction="row" spacing={1} sx={{ justifyContent: 'flex-end', p: 2, borderTop: 1, borderColor: 'divider' }}>
                            <JoyButton variant="plain" disabled={saving} onClick={close}>Cancel</JoyButton>
                            <JoyButton variant="solid" type="submit" disabled={!canSave}>
                                {saving ? <OrbitRing className="size-5" /> : 'Save record'}
                            </JoyButton>
                        </JoyStack>
                    </Box>}
                </CssVarsProvider>
            </DrawerContent>
        </Drawer>
        <Dialog open={!!pending} onClose={() => setPending(null)}>
            <DialogTitle>Discard unsaved changes?</DialogTitle>
            <DialogActions>
                <Button onClick={() => setPending(null)}>Keep editing</Button>
                <Button color="error" onClick={() => { const action = pending; setPending(null); action?.() }}>Discard</Button>
            </DialogActions>
        </Dialog>
    </Stack>
}
