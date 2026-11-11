'use client'
import FormLoading from '@/components/loading-ui/form-loading'

import { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import { assetsApi } from '../lib/store'
import { Alert, Button, Dialog, DialogActions, DialogContent, DialogTitle, IconButton } from '@mui/material'
import { Stack as JoyStack, Button as JoyButton, Alert as JoyAlert, Autocomplete, Box, Checkbox, FormControl, FormLabel, Input, Textarea } from '@mui/joy'
import { CssVarsProvider } from '@mui/joy/styles'
import { Eye, Pencil, Trash2 } from 'lucide-react'
import { Drawer, DrawerContent, DrawerDescription, DrawerTitle } from '../components/ui/drawer'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'
import { joyTheme } from './theme'

export function RowActions({ name, onDelete, onView, onEdit }: {
    name: string; onDelete?: () => void; onView?: () => void; onEdit?: () => void
}) {
    const actions = [
        { label: 'Delete', icon: Trash2, run: onDelete },
        { label: 'View', icon: Eye, run: onView },
        { label: 'Edit', icon: Pencil, run: onEdit },
    ]
    return <>{actions.map(({ label, icon: Icon, run }) => run && <IconButton key={label}
        color="primary" size="small" aria-label={label + ' ' + name} title={label} onClick={run}>
        <Icon size={17} strokeWidth={1.6} />
    </IconButton>)}</>
}

type Option = { id: number; label: string; copyValue: string | null }
type Field = { key: string; label: string; kind: string; required: boolean; maxLength: number | null; copyTo: string | null }
type Detail = { record: Record<string, unknown>; fields: Field[]; lookups: Record<string, Option[]> }
type Value = string | boolean | null
export type RecordAction = { mode: 'view' | 'edit' | 'delete'; id: number; name: string }

function formValues(detail: Detail) {
    return Object.fromEntries(detail.fields.map(field => {
        const value = detail.record[field.key]
        return [field.key, typeof value === 'boolean' || value == null
            ? value ?? null : field.kind === 'date' ? String(value).slice(0, 10) : String(value)]
    })) as Record<string, Value>
}

export default function RecordEditor({ table, action, onClose, onChanged }: {
    table: string; action: RecordAction; onClose: () => void; onChanged: () => void
}) {
    const url = '/api/well-records/' + table + '/' + action.id
    const dispatch = useDispatch()
    const [detail, setDetail] = useState<Detail>()
    const [values, setValues] = useState<Record<string, Value>>({})
    const [saving, setSaving] = useState(false)
    const [loading, setLoading] = useState(action.mode !== 'delete')
    const [error, setError] = useState('')
    const [discard, setDiscard] = useState<(() => void) | null>(null)
    const readonly = action.mode === 'view'
    const baseline = detail ? formValues(detail) : {}
    const dirty = !!detail && detail.fields.some(field => values[field.key] !== baseline[field.key])
    const complete = !!detail && detail.fields.every(field => !field.required || String(values[field.key] ?? '').trim())

    useEffect(() => {
        if (action.mode === 'delete') return
        const controller = new AbortController()
        async function load() {
            try {
                const response = await fetch(url, { signal: controller.signal, cache: 'no-store' })
                if (!response.ok) throw new Error()
                const result: Detail = await response.json()
                setDetail(result)
                setValues(formValues(result))
            } catch {
                if (!controller.signal.aborted) setError('Unable to load this record.')
            } finally {
                if (!controller.signal.aborted) setLoading(false)
            }
        }
        void load()
        return () => controller.abort()
    }, [action.mode, url])

    useEffect(() => {
        const navigate = (event: Event) => {
            if (!dirty && !saving) return
            event.preventDefault()
            if (!saving) setDiscard(() => (event as CustomEvent<() => void>).detail)
        }
        const unload = (event: BeforeUnloadEvent) => { if (dirty || saving) event.preventDefault() }
        window.addEventListener('osdu:navigate', navigate)
        window.addEventListener('beforeunload', unload)
        return () => {
            window.removeEventListener('osdu:navigate', navigate)
            window.removeEventListener('beforeunload', unload)
        }
    }, [dirty, saving])

    function close() {
        if (saving) return
        if (dirty) setDiscard(() => onClose)
        else onClose()
    }

    function setValue(key: string, value: Value) {
        setValues(current => ({ ...current, [key]: value }))
    }

    function select(field: Field, option: Option | null) {
        setValues(current => {
            const next = { ...current, [field.key]: option ? String(option.id) : null }
            if (field.copyTo) next[field.copyTo] = option?.copyValue ?? null
            return next
        })
    }

    async function persist() {
        const removing = action.mode === 'delete'
        if (saving || (!removing && (!dirty || !complete || readonly))) return
        const changes = Object.fromEntries(detail?.fields.filter(field => values[field.key] !== baseline[field.key]).map(field => {
            const value = values[field.key]
            if (typeof value !== 'string') return [field.key, value]
            const text = value.trim()
            return [field.key, !text ? null : ['lookup', 'integer', 'decimal'].includes(field.kind) ? Number(text) : text]
        }) ?? [])
        setSaving(true)
        setError('')
        try {
            const response = await fetch(url, removing ? { method: 'DELETE' } : {
                method: 'PATCH', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(changes),
            })
            if (!response.ok) {
                const result = await response.json().catch(() => null)
                throw new Error(result?.message || (response.status === 404 ? 'This record no longer exists.' : 'Unable to save the change.'))
            }
            const tags = { 'well-master': 'Well', wellbores: 'Wellbore', 'field-records': 'Field',
                facilities: 'Facility', 'coordinate-reference-systems': 'Crs' } as const
            const tag = tags[table as keyof typeof tags]
            if (tag) dispatch(assetsApi.util.invalidateTags([tag]))
            onChanged()
            onClose()
        } catch (failure) {
            setError(failure instanceof Error ? failure.message : 'Unable to save the change.')
            setSaving(false)
        }
    }

    if (action.mode === 'delete') return <Dialog open onClose={close}>
        <DialogTitle>Delete record?</DialogTitle>
        <DialogContent>{error && <Alert severity="error">{error}</Alert>}Delete “{action.name}”?</DialogContent>
        <DialogActions>
            <Button disabled={saving} onClick={close}>Cancel</Button>
            <Button color="error" disabled={saving} onClick={() => void persist()}>{saving ? 'Deleting…' : 'Delete'}</Button>
        </DialogActions>
    </Dialog>

    return <>
        <Drawer open swipeDirection="right" onOpenChange={open => { if (!open) close() }}>
            <DrawerContent>
                <CssVarsProvider theme={joyTheme}>
                    <Box component="form" onSubmit={event => { event.preventDefault(); void persist() }}
                        sx={{ height: '100%', display: 'flex', flexDirection: 'column', bgcolor: 'background.surface' }}>
                        <Box sx={{ px: 3, py: 2, borderBottom: 1, borderColor: 'divider' }}>
                            <DrawerTitle>{readonly ? 'View' : 'Edit'} {action.name}</DrawerTitle>
                        </Box>
                        <JoyStack spacing={2} sx={{ flex: 1, minHeight: 0, overflowY: 'auto', p: 3 }}>
                            <DrawerDescription>Record ID {action.id}</DrawerDescription>
                            {loading && <FormLoading />}
                            {error && <JoyAlert color="danger">{error}</JoyAlert>}
                            {detail?.fields.map(field => {
                                const options = detail.lookups[field.key] ?? []
                                const value = values[field.key]
                                const copied = detail.fields.some(source => source.copyTo === field.key && values[source.key])
                                return <FormControl key={field.key} required={field.required && !readonly}>
                                    <FormLabel>{(table === 'well-master' || table === 'field-records') && field.key === 'xCoordinate' ? 'X Coordinate (WGS 84 latitude)'
                                        : (table === 'well-master' || table === 'field-records') && field.key === 'yCoordinate' ? 'Y Coordinate (WGS 84 longitude)'
                                        : field.label}</FormLabel>
                                    {field.kind === 'boolean' ? <Checkbox disabled={saving || readonly} checked={value === true}
                                        onChange={event => setValue(field.key, event.target.checked)} />
                                        : field.kind === 'lookup' ? <Autocomplete
                                            options={options} disabled={saving || readonly}
                                            getOptionLabel={option => option.label ? option.label + ' (#' + option.id + ')' : '#' + option.id}
                                            isOptionEqualToValue={(a, b) => a.id === b.id}
                                            value={options.find(option => String(option.id) === value) ?? null}
                                            onChange={(_, option) => select(field, option)}
                                            slotProps={{ listbox: { sx: { zIndex: 1400 } } }}
                                        /> : field.key === 'remark' || (field.maxLength ?? 0) >= 1000 ? <Textarea
                                            disabled={saving} readOnly={readonly || copied} minRows={3}
                                            value={String(value ?? '')} onChange={event => setValue(field.key, event.target.value)}
                                            slotProps={{ textarea: { maxLength: field.maxLength ?? undefined } }} />
                                            : <Input disabled={saving} readOnly={readonly || copied}
                                                type={field.kind === 'date' ? 'date' : field.kind === 'text' ? 'text' : 'number'}
                                                value={String(value ?? '')} onChange={event => setValue(field.key, event.target.value)}
                                                slotProps={{ input: { maxLength: field.maxLength ?? undefined,
                                                    step: field.kind === 'integer' ? 1 : field.kind === 'decimal' ? 'any' : undefined } }} />}
                                </FormControl>
                            })}
                        </JoyStack>
                        <JoyStack direction="row" spacing={1} sx={{ justifyContent: 'flex-end', p: 2, borderTop: 1, borderColor: 'divider' }}>
                            <JoyButton disabled={saving} onClick={close}>{readonly ? 'Close' : 'Cancel'}</JoyButton>
                            {!readonly && <JoyButton variant="solid" type="submit" disabled={saving || !dirty || !complete}>
                                {saving ? 'Saving…' : 'Save changes'}
                            </JoyButton>}
                        </JoyStack>
                    </Box>
                </CssVarsProvider>
            </DrawerContent>
        </Drawer>
        <Dialog open={!!discard} onClose={() => setDiscard(null)}>
            <DialogTitle>Discard unsaved changes?</DialogTitle>
            <DialogActions>
                <Button onClick={() => setDiscard(null)}>Keep editing</Button>
                <Button color="error" onClick={() => { const next = discard; setDiscard(null); next?.() }}>Discard</Button>
            </DialogActions>
        </Dialog>
    </>
}
