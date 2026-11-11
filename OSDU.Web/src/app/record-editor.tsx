'use client'
import FormLoading from '@/components/loading-ui/form-loading'

import dynamic from 'next/dynamic'
import { useEffect, useMemo, useState } from 'react'
import { useDispatch } from 'react-redux'
import { assetsApi } from '../lib/store'
import { Alert, Button, Dialog, DialogActions, DialogContent, DialogTitle, IconButton } from '@mui/material'
import { Stack as JoyStack, Button as JoyButton, Alert as JoyAlert, Autocomplete, Box, Checkbox, FormControl, FormHelperText, FormLabel, Input, Textarea } from '@mui/joy'
import { CssVarsProvider } from '@mui/joy/styles'
import { Eye, Pencil, Trash2 } from 'lucide-react'
import { Drawer, DrawerContent, DrawerDescription, DrawerTitle } from '../components/ui/drawer'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'
import { joyTheme } from './theme'

const recordApi = assetsApi.enhanceEndpoints({ addTagTypes: ['EditableRecord', 'RecordReferences'] }).injectEndpoints({
    endpoints: builder => ({
        wellReference: builder.query<Option[], string>({
            query: key => 'wells/references/' + key,
            providesTags: ['RecordReferences', 'Field', 'Crs', 'WellStatus'],
            keepUnusedDataFor: 300,
        }),
        recordDetail: builder.query<Detail, string>({
            query: path => path,
            providesTags: (_data, _error, path) => [
                { type: 'EditableRecord', id: path }, 'RecordReferences', 'Field', 'Crs', 'WellStatus',
            ],
            keepUnusedDataFor: 300,
        }),
        changeRecord: builder.mutation<unknown, { path: string; removing: boolean; changes: Record<string, unknown> }>({
            query: ({ path, removing, changes }) => ({
                url: path, method: removing ? 'DELETE' : 'PATCH', body: removing ? undefined : changes,
            }),
            invalidatesTags: (_data, error, { path }) => error ? [] : [{ type: 'EditableRecord', id: path }, 'RecordReferences'],
        }),
    }),
})

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
type RelatedRecord = { id: number; name: string }
type Detail = { related?: { wellbores: RelatedRecord[]; completions: RelatedRecord[] }; record: Record<string, unknown>; fields: Field[]; lookups: Record<string, Option[]> }
type Value = string | boolean | null
export type RecordAction = { mode: 'view' | 'edit' | 'delete' | 'create'; id: number; name: string }

function formValues(detail: Detail) {
    return Object.fromEntries(detail.fields.map(field => {
        const value = detail.record[field.key]
        return [field.key, typeof value === 'boolean' || value == null
            ? value ?? null : field.kind === 'date' ? String(value).slice(0, 10) : String(value)]
    })) as Record<string, Value>
}

function WellReferenceInput({ field, value, disabled, onSelect }: {
    field: Field; value: Value; disabled: boolean; onSelect: (field: Field, option: Option | null) => void
}) {
    const query = recordApi.useWellReferenceQuery(field.key, { refetchOnMountOrArgChange: 300 })
    const options = query.data ?? []
    return <>
        <Autocomplete options={options} loading={query.isFetching} disabled={disabled}
            placeholder={query.isLoading ? 'Loading options…' : 'Select ' + field.label.toLowerCase()}
            getOptionLabel={option => option.label + ' (#' + option.id + ')'}
            isOptionEqualToValue={(a, b) => a.id === b.id}
            value={options.find(option => String(option.id) === value) ?? (value ? { id: Number(value), label: 'Selected record', copyValue: null } : null)}
            onChange={(_, option) => onSelect(field, option)}
            slotProps={{ listbox: { sx: { zIndex: 1400 } } }} />
        {query.isError && <FormHelperText>Could not load options. <JoyButton size="sm" onClick={() => query.refetch()}>Retry</JoyButton></FormHelperText>}
    </>
}

const LocationMap = dynamic(() => import('./catalog-map'), { ssr: false, loading: () => <FormLoading label="Loading map…" /> })
const ignoreMapSelection = () => {}

function WellLocation({ values, id, name }: { values: Record<string, Value>; id: number; name: string }) {
    const { data } = recordApi.useWellReferenceQuery('crsId', { skip: !values.crsId })
    const system = values.crsId ? data?.find(option => String(option.id) === values.crsId)?.label : values.crsName
    const latitude = Number(values.xCoordinate)
    const longitude = Number(values.yCoordinate)
    const supported = ['4326', 'EPSG4326', 'WGS84'].includes(String(system ?? '').trim().toUpperCase().replace(/[ :-]/g, ''))
    const valid = !!values.xCoordinate && !!values.yCoordinate && Math.abs(latitude) <= 90 && Math.abs(longitude) <= 180
    const points = useMemo(() => [{ id, name, dataset: 'Wells', x: longitude, y: latitude }], [id, name, longitude, latitude])
    return <Box sx={{ gridColumn: '1 / -1' }}>
        <Box sx={{ mb: 1, fontSize: 'sm' }}>Coordinate system: {system || 'Not specified'}</Box>
        {supported && valid
            ? <LocationMap points={points} selected={'Wells:' + id} onSelect={ignoreMapSelection} height={220} label="Well location preview" />
            : <Box sx={{ fontSize: 'sm' }}>Select WGS 84 and enter a valid latitude and longitude to preview the location.</Box>}
    </Box>
}

export default function RecordEditor({ table, action, onClose, onChanged, onRelated }: {
    table: string; action: RecordAction; onClose: () => void; onChanged: () => void; onRelated?: (table: string, id: number, name: string) => void
}) {
    const creating = action.mode === 'create'
    const path = creating ? 'wells/form' : 'well-records/' + table + '/' + action.id
    const query = recordApi.useRecordDetailQuery(path, { skip: action.mode === 'delete', refetchOnMountOrArgChange: creating ? 300 : 30 })
    const [mutate, { isLoading: updating }] = recordApi.useChangeRecordMutation()
    const [createWell, { isLoading: adding }] = assetsApi.useCreateWellMutation()
    const saving = updating || adding
    const dispatch = useDispatch()
    const [detail, setDetail] = useState<Detail>()
    const [values, setValues] = useState<Record<string, Value>>({})
    const loading = action.mode !== 'delete' && !detail && !query.isError
    const [error, setError] = useState('')
    const [discard, setDiscard] = useState<(() => void) | null>(null)
    const [drawerOpen, setDrawerOpen] = useState(false)

    useEffect(() => {
        if (action.mode !== 'delete') setDrawerOpen(true)
    }, [action.mode])
    const readonly = action.mode === 'view'
    const baseline = useMemo(() => detail ? formValues(detail) : {}, [detail])
    const dirty = !!detail && detail.fields.some(field => values[field.key] !== baseline[field.key])
    const [fieldErrors, setFieldErrors] = useState<Record<string, string>>({})
    const [focusKey, setFocusKey] = useState('')
    const groups = useMemo(() => {
        const fields = detail?.fields ?? []
        if (table !== 'well-master') return [{ label: '', fields }]
        const sections = [
            { label: 'Identification', keys: ['wellName', 'uwi', 'wellAliasName', 'wellOwner', 'offshoreInd', 'isActive'] },
            { label: 'Location', keys: ['fieldId', 'fieldName', 'xCoordinate', 'yCoordinate', 'crsId', 'crsName', 'bottomHoleXLon', 'bottomHoleYLat'] },
            { label: 'Lifecycle dates', keys: ['spudDate', 'spudDateTz', 'rTimezoneId', 'completionDate', 'productionStartDate', 'abandonmentDate', 'expiryDate'] },
            { label: 'Depth and measurements', keys: ['deepestDepth', 'maxTvd', 'depthDatumId', 'depthDatum', 'depthDatumElev', 'groundElev', 'logTd', 'netPay', 'plugbackDepth', 'waterAcousticVel', 'waterDepth', 'waterDepthDatum'] },
        ]
        const assigned = new Set(sections.flatMap(section => section.keys))
        return [
            ...sections.map(section => ({ label: section.label, fields: section.keys.flatMap(key => fields.filter(field => field.key === key)) })),
            { label: 'Operations and references', fields: fields.filter(field => !assigned.has(field.key)) },
        ].filter(section => section.fields.length)
    }, [detail, table])

    useEffect(() => {
        if (!focusKey) return
        const field = document.getElementById('record-field-' + focusKey)
        const section = field?.closest('details')
        if (section) section.open = true
        field?.querySelector<HTMLElement>('input, textarea')?.focus()
        setFocusKey('')
    }, [focusKey])

    useEffect(() => {
        if (!detail && query.currentData) {
            setDetail(query.currentData)
            setValues(formValues(query.currentData))
        }
    }, [detail, query.currentData])

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

    function finishClose() {
        if (action.mode === 'delete') onClose()
        else setDrawerOpen(false)
    }

    function close() {
        if (saving) return
        if (dirty) setDiscard(() => finishClose)
        else finishClose()
    }

    function setValue(key: string, value: Value) {
        setValues(current => ({ ...current, [key]: value }))
        setFieldErrors(current => ({ ...current, [key]: '' }))
    }

    function select(field: Field, option: Option | null) {
        setFieldErrors(current => ({ ...current, [field.key]: '' }))
        setValues(current => {
            const next = { ...current, [field.key]: option ? String(option.id) : null }
            if (field.copyTo) next[field.copyTo] = option?.copyValue ?? null
            return next
        })
    }

    async function persist() {
        const removing = action.mode === 'delete'
        if (saving || (!removing && (!detail || readonly || (!creating && !dirty)))) return
        if (!removing && detail) {
            const invalid = groups.flatMap(group => group.fields).filter(field => field.required && !String(values[field.key] ?? '').trim())
            if (invalid.length) {
                setFieldErrors(Object.fromEntries(invalid.map(field => [field.key, field.label + ' is required.'])))
                setFocusKey(invalid[0].key)
                return
            }
        }
        const changes = Object.fromEntries(detail?.fields.filter(field => creating ? values[field.key] != null : values[field.key] !== baseline[field.key]).map(field => {
            const value = values[field.key]
            if (typeof value !== 'string') return [field.key, value]
            const text = value.trim()
            return [field.key, !text ? null : ['lookup', 'integer', 'decimal'].includes(field.kind) ? Number(text) : text]
        }) ?? [])
        setError('')
        try {
            if (creating) await createWell(changes).unwrap()
            else await mutate({ path, removing, changes }).unwrap()
            const tags = { 'well-master': 'Well', wellbores: 'Wellbore', 'field-records': 'Field',
                facilities: 'Facility', 'coordinate-reference-systems': 'Crs' } as const
            const tag = tags[table as keyof typeof tags]
            if (tag && !creating) dispatch(assetsApi.util.invalidateTags([tag]))
            onChanged()
            finishClose()
        } catch (failure) {
            const response = failure as { status?: number; data?: { message?: string; errors?: Record<string, string[]> } }
            const mapped = Object.fromEntries(Object.entries(response.data?.errors ?? {}).flatMap(([key, messages]) => {
                const field = detail?.fields.find(item => item.key.toLowerCase() === key.replace(/^\$\./, '').toLowerCase())
                return field ? [[field.key, messages.join(' ')]] : []
            }))
            if (Object.keys(mapped).length) {
                setFieldErrors(mapped)
                setFocusKey(Object.keys(mapped)[0])
                return
            }
            setError(response.data?.message || (response.status === 404 ? 'This record no longer exists.' : 'Unable to save the change.'))
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
        <Drawer open={drawerOpen} swipeDirection="right"
            onOpenChange={open => { if (!open) close() }}
            onOpenChangeComplete={open => { if (!open) onClose() }}>
            <DrawerContent>
                <CssVarsProvider theme={joyTheme}>
                    <Box component="form" noValidate onSubmit={event => { event.preventDefault(); void persist() }}
                        sx={{ height: '100%', display: 'flex', flexDirection: 'column', bgcolor: 'background.surface' }}>
                        <Box sx={{ px: 3, py: 2, borderBottom: 1, borderColor: 'divider' }}>
                            <DrawerTitle>{creating ? 'Add' : readonly ? 'View' : 'Edit'} {action.name}</DrawerTitle>
                        </Box>
                        <JoyStack spacing={2} sx={{ flex: 1, minHeight: 0, overflowY: 'auto', p: 3 }}>
                            <DrawerDescription>{creating ? 'Enter the well details. Required fields are marked.' : 'Record ID ' + action.id}</DrawerDescription>
                            {loading && <FormLoading />}
                            {!detail && query.isError && <JoyAlert color="danger">Unable to load the form. <JoyButton onClick={() => query.refetch()}>Retry</JoyButton></JoyAlert>}
                            {error && <JoyAlert color="danger">{error}</JoyAlert>}
                            {readonly && table === 'well-master' && detail && <Box>
                                <Box component="h3" sx={{ fontWeight: 600 }}>Well summary</Box>
                                <Box component="dl" sx={{ display: 'grid', gridTemplateColumns: 'auto 1fr', gap: 1, '& dd': { m: 0, overflowWrap: 'anywhere' } }}>
                                    {Object.entries({ 'UWI': values.uwi, Field: values.fieldName, Status: values.isActive ? 'Active' : 'Inactive',
                                        Latitude: values.xCoordinate, Longitude: values.yCoordinate, 'Spud date': values.spudDate,
                                        'Completion date': values.completionDate, 'Production start': values.productionStartDate }).map(([label, value]) =>
                                        <Box key={label} sx={{ display: 'contents' }}><dt>{label}</dt><dd>{String(value || '—')}</dd></Box>)}
                                </Box>
                                {detail.related && onRelated && <Box sx={{ mt: 2 }}>
                                    <Box component="h3" sx={{ fontWeight: 600 }}>Related records</Box>
                                    {!detail.related.wellbores.length && !detail.related.completions.length && <p>No related wellbores or completions.</p>}
                                    {(['wellbores', 'completions'] as const).map(type => detail.related![type].length > 0 &&
                                        <Box key={type} sx={{ mt: 1 }}><strong>{type === 'wellbores' ? 'Wellbores' : 'Completions'}</strong>
                                            <ul>{detail.related![type].map(item => <li key={item.id}><JoyButton variant="plain" onClick={() => onRelated(type, item.id, item.name)}>{item.name || '#' + item.id}</JoyButton></li>)}</ul>
                                        </Box>)}
                                </Box>}
                            </Box>}
                            {groups.map((group, index) => <Box key={group.label} component={group.label ? 'details' : 'div'}
                                {...(group.label ? { open: index === 0 } : {})}
                                sx={group.label ? { border: '1px solid', borderColor: 'divider', borderRadius: 'sm', p: 2 } : {}}>
                                {group.label && <Box component="summary" sx={{ cursor: 'pointer', fontWeight: 600 }}>{group.label}{group.fields.some(field => fieldErrors[field.key]) && <Box component="span" sx={{ ml: 1, color: 'danger.plainColor' }}>· Check inputs</Box>}</Box>}
                                <Box sx={{ mt: group.label ? 2 : 0, display: 'grid', gap: 2,
                                    gridTemplateColumns: table === 'well-master' ? { xs: 'minmax(0,1fr)', sm: 'repeat(2,minmax(0,1fr))' } : 'minmax(0,1fr)' }}>
                            {group.fields.map(field => {
                                const options = (query.currentData ?? detail)?.lookups[field.key] ?? []
                                const value = values[field.key]
                                const copied = detail?.fields.some(source => source.copyTo === field.key && values[source.key])
                                return <FormControl key={field.key} id={'record-field-' + field.key} error={!!fieldErrors[field.key]} required={field.required && !readonly}>
                                    <FormLabel>{(table === 'well-master' || table === 'field-records') && field.key === 'xCoordinate' ? 'X Coordinate (WGS 84 latitude)'
                                        : (table === 'well-master' || table === 'field-records') && field.key === 'yCoordinate' ? 'Y Coordinate (WGS 84 longitude)'
                                        : field.label}</FormLabel>
                                    {field.kind === 'boolean' ? <Checkbox disabled={saving || readonly} checked={value === true}
                                        onChange={event => setValue(field.key, event.target.checked)} />
                                        : field.kind === 'lookup' && table === 'well-master' ? <WellReferenceInput field={field} value={value} disabled={saving || readonly} onSelect={select} />
                                        : field.kind === 'lookup' ? <Autocomplete
                                            options={options} loading={query.isFetching} disabled={saving || readonly}
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
                                    {fieldErrors[field.key] && <FormHelperText>{fieldErrors[field.key]}</FormHelperText>}
                                    {field.kind === 'lookup' && query.isError && <FormHelperText>
                                        Could not refresh options. <JoyButton size="sm" onClick={() => query.refetch()}>Retry</JoyButton>
                                    </FormHelperText>}
                                </FormControl>
                            })}
                                    {table === 'well-master' && group.label === 'Location' && <WellLocation values={values} id={action.id} name={String(values.wellName || 'Well')} />}
                                </Box>
                            </Box>)}
                        </JoyStack>
                        <JoyStack direction="row" spacing={1} sx={{ justifyContent: 'flex-end', p: 2, borderTop: 1, borderColor: 'divider' }}>
                            <JoyButton disabled={saving} onClick={close}>{readonly ? 'Close' : 'Cancel'}</JoyButton>
                            {!readonly && <JoyButton variant="solid" type="submit" disabled={saving || !detail || (!creating && !dirty)}>
                                {saving ? <><OrbitRing className="size-4" /> Saving…</> : creating ? 'Save well' : 'Save changes'}
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
