'use client'
import { useState, useEffect } from 'react'
import { Accordion, AccordionSummary, AccordionDetails, Autocomplete, Dialog, DialogTitle, DialogContent, DialogActions, Alert, Box, Button, Checkbox, FormControlLabel, MenuItem, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography } from '@mui/material'
import ExpandMoreIcon from '@mui/icons-material/ExpandMore'
import { facilityFields } from './facility-fields'
import { useGetFacilitiesQuery, useGetFacilityLookupsQuery, useCreateFacilityMutation } from '../lib/store'
const sections = [
    { title: 'Essential details', names: ['facilityName', 'facilityTypeId', 'currentOperator', 'isActive', 'offshoreInd'] },
    { title: 'Additional identity & classification', names: ['facilityShortName', 'facilityLongName', 'facilityNo', 'rEquipmentCatalogueId', 'facilityFunction', 'rDataAccessCategoryId', 'uidref', 'isVirtual'] },
    { title: 'Location & dimensions', names: ['crsId', 'xCoordinate', 'yCoordinate', 'depth', 'elevation', 'facilityDiameter'] },
    { title: 'Lifecycle & production dates', names: ['constructedDate', 'activeDate', 'abandonedDate', 'onInjectionDate', 'onProductionDate', 'lastInjectionDate', 'lastProductionDate', 'lastReportedDate'] },
    { title: 'Remarks', names: ['remark'] },
]
const empty = { isActive: 'true', offshoreInd: 'false', isVirtual: '' }
const datePairs = [['constructedDate', 'activeDate', 'Activation cannot precede construction.'], ['activeDate', 'abandonedDate', 'Abandonment cannot precede activation.'], ['onProductionDate', 'lastProductionDate', 'Last production cannot precede first production.'], ['onInjectionDate', 'lastInjectionDate', 'Last injection cannot precede first injection.']]
export default function Facilities() {
    const { data: rows = [], isLoading, error, refetch } = useGetFacilitiesQuery()
    const { data: lookups = {}, isLoading: loadingLookups, error: lookupError } = useGetFacilityLookupsQuery()
    const [create, { isLoading: saving }] = useCreateFacilityMutation()
    const [values, setValues] = useState<Record<string, string>>(empty)
    const [message, setMessage] = useState(''); const [success, setSuccess] = useState('')
    const [lastSaved, setLastSaved] = useState<Record<string, unknown> | null>(null)
    const [pendingAction, setPendingAction] = useState<null | (() => void)>(null)
    const dirty = Object.entries(values).some(([k, v]) => v !== ((empty as Record<string, string>)[k] ?? ''))
    useEffect(() => {
        const unload = (e: BeforeUnloadEvent) => { if (dirty) { e.preventDefault(); e.returnValue = '' } }
        const navigate = (e: Event) => { if (dirty) { e.preventDefault(); const action = (e as CustomEvent<() => void>).detail; setPendingAction(() => action) } }
        window.addEventListener('beforeunload', unload); window.addEventListener('osdu:navigate', navigate)
        return () => { window.removeEventListener('beforeunload', unload); window.removeEventListener('osdu:navigate', navigate) }
    }, [dirty])
    const clear = () => { const action = () => { setValues(empty); setMessage('') }; if (dirty) setPendingAction(() => action); else action() }
    const set = (name: string, value: string) => setValues(v => ({ ...v, [name]: value }))
    async function submit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault(); setMessage(''); setSuccess('')
        for (const [first, last, text] of datePairs) { if (values[first] && values[last] && values[last] < values[first]) { setMessage(text); return } }
        const payload: Record<string, unknown> = {}
        for (const f of facilityFields) { const v = values[f.name] ?? ''; payload[f.name] = v === '' ? null : f.type === 'boolean' ? v === 'true' : f.type === 'number' ? Number(v) : f.type === 'date' ? v + ':00' : v.trim() }
        for (const field of ['depth', 'elevation', 'facilityDiameter']) {
            if (values[field] && !values[field + 'Uom']) { setMessage('Choose a unit for ' + field + '.'); return }
            payload[field + 'Uom'] = values[field + 'Uom'] || null
        }
        try { const result = await create(payload).unwrap(); setLastSaved(result); setSuccess('Facility “' + result.facilityName + '” saved successfully. ID: ' + result.facilityId); setValues(empty) }
        catch (e) { const err = e as { data?: { message?: string; errors?: Record<string, string[]> } }; setMessage(err.data?.message || Object.values(err.data?.errors || {}).flat().join(' ') || 'Unable to save the facility. Check your connection and try again.') }
    }
    return <Stack spacing={3}>
        <Dialog open={!!pendingAction} onClose={() => setPendingAction(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your facility details have not been saved.</DialogContent><DialogActions><Button onClick={() => setPendingAction(null)}>Keep editing</Button><Button color="error" onClick={() => { const action = pendingAction; setPendingAction(null); action?.() }}>Discard changes</Button></DialogActions></Dialog>
        {success && <Alert severity="success">{success}</Alert>}
        {error && <Alert severity="error">Unable to load facilities.<Button onClick={() => refetch()}>Retry</Button></Alert>}
        <Paper variant="outlined" sx={{ p: { xs: 2, md: 3 } }}>
            <Typography variant="h6" component="h2">Add facility</Typography><Typography variant="body2" color="text.secondary" sx={{ mb: 3 }}>Enter facility details. The ID and audit fields are assigned automatically.</Typography>
            {lookupError && <Alert severity="warning" sx={{ mb: 2 }}>Reference lists could not be loaded. Refresh before choosing classifications.</Alert>}
            <Box component="form" onSubmit={submit}>
                <Stack spacing={4}>{sections.map((section, index) => <Accordion key={section.title} defaultExpanded={index === 0} disableGutters elevation={0} sx={{ border: 1, borderColor: 'divider', '&:before': { display: 'none' } }}><AccordionSummary expandIcon={<ExpandMoreIcon />}><Typography variant="subtitle2">{section.title}</Typography></AccordionSummary><AccordionDetails>
                    <Box sx={{ display: 'grid', gridTemplateColumns: { xs: '1fr', sm: 'repeat(2,1fr)', lg: 'repeat(3,1fr)' }, gap: 2 }}>
                        {section.names.map(name => {
                            const f = facilityFields.find(x => x.name === name)!
                            const v = values[name] ?? ''
                            if (f.type === 'boolean' && name !== 'isVirtual') return <FormControlLabel key={name} control={<Checkbox checked={v === 'true'} onChange={e => set(name, String(e.target.checked))} />} label={name === 'offshoreInd' ? 'Offshore facility' : 'Active'} />
                            const options = lookups[name]
                            const reference = ['facilityTypeId', 'rEquipmentCatalogueId', 'crsId', 'rDataAccessCategoryId'].includes(name)
                            if (reference) return <Autocomplete key={name} options={options || []} getOptionLabel={o => o.label} isOptionEqualToValue={(a, b) => a.id === b.id} value={options?.find(o => String(o.id) === v) || null} loading={loadingLookups} disabled={saving || !!lookupError} onChange={(_e, o) => set(name, o ? String(o.id) : '')} renderInput={params => <TextField {...params} label={f.label.replace(' Id', '')} size="small" helperText={options?.length === 0 ? 'No reference values configured; optional.' : name === 'crsId' ? 'Coordinates use this reference system.' : undefined} />} />
                            if (['depth', 'elevation', 'facilityDiameter'].includes(name)) return <Stack key={name} direction="row" spacing={1}>
                                <TextField label={f.label} type="number" value={v} onChange={e => set(name, e.target.value)} size="small" disabled={saving} slotProps={{ htmlInput: { step: '0.000000001', min: name === 'elevation' ? undefined : 0 } }} sx={{ flex: 1 }} />
                                <TextField select label="Unit" required={!!v} size="small" value={values[name + 'Uom'] || ''} onChange={e => set(name + 'Uom', e.target.value)} sx={{ width: 100 }}><MenuItem value="">Select</MenuItem><MenuItem value="m">m</MenuItem><MenuItem value="ft">ft</MenuItem><MenuItem value="in">in</MenuItem></TextField>
                            </Stack>
                            return <TextField key={name} size="small" label={f.label} required={f.required} value={v} disabled={saving || (reference && loadingLookups)} select={reference || f.type === 'boolean'} onChange={e => { set(name, e.target.value); const copy: Record<string, string> = { facilityTypeId: 'facilityType', rEquipmentCatalogueId: 'equipmentCatalogue', crsId: 'crsName' }; if (copy[name]) set(copy[name], options?.find(o => String(o.id) === e.target.value)?.label || '') }} type={f.type === 'date' ? 'datetime-local' : f.type === 'number' ? 'number' : 'text'} multiline={name === 'remark'} rows={name === 'remark' ? 3 : undefined} sx={{ gridColumn: name === 'remark' ? '1 / -1' : undefined }} slotProps={{ inputLabel: f.type === 'date' ? { shrink: true } : undefined, htmlInput: { maxLength: f.maxLength ?? undefined, step: f.type === 'number' ? (name.endsWith('Id') || name === 'facilityNo' ? 1 : '0.000000001') : undefined } }} helperText={name === 'xCoordinate' || name === 'yCoordinate' ? 'Use the selected CRS units; no automatic conversion.' : f.type === 'date' ? 'Facility local time (no timezone conversion).' : undefined}>
                                {(reference || f.type === 'boolean') && <MenuItem value="">Not specified</MenuItem>}
                                {reference && options?.map(o => <MenuItem key={o.id} value={String(o.id)}>{o.label}</MenuItem>)}
                                {f.type === 'boolean' && [<MenuItem key="yes" value="true">Yes</MenuItem>, <MenuItem key="no" value="false">No</MenuItem>]}
                            </TextField>
                        })}
                    </Box></AccordionDetails></Accordion>)}
                    {message && <Alert severity="error">{message}</Alert>}
                    <Stack direction="row" spacing={2}><Button type="submit" variant="contained" disabled={saving}>{saving ? 'Saving…' : 'Save facility'}</Button><Button disabled={saving} onClick={clear}>Clear form</Button></Stack>
                </Stack>
            </Box>
        </Paper>
        {lastSaved && <Paper variant="outlined" sx={{ p: 3 }}><Typography variant="h6" sx={{ mb: 2 }}>Last saved facility · audit details</Typography><Box sx={{ display: 'grid', gridTemplateColumns: { xs: '1fr', sm: '1fr 1fr' }, gap: 2 }}>{['facilityId', 'rowCreatedBy', 'rowCreatedDate', 'rowChangedBy', 'rowChangedDate'].map(k => <TextField key={k} label={k.replace(/([A-Z])/g, ' $1')} value={String(lastSaved[k] ?? '—')} size="small" slotProps={{ input: { readOnly: true } }} />)}</Box></Paper>}
        <Paper variant="outlined"><Typography variant="h6" sx={{ p: 2 }}>Facilities {isLoading ? '' : '(' + rows.length + ')'}</Typography><TableContainer><Table size="small"><TableHead><TableRow>{['ID', 'Name', 'Type', 'Operator', 'Active', 'Created by'].map(h => <TableCell key={h}>{h}</TableCell>)}</TableRow></TableHead><TableBody>{rows.map(r => <TableRow key={String(r.facilityId)}>{['facilityId', 'facilityName', 'facilityType', 'currentOperator', 'isActive', 'rowCreatedBy'].map(k => <TableCell key={k}>{typeof r[k] === 'boolean' ? (r[k] ? 'Yes' : 'No') : String(r[k] ?? '—')}</TableCell>)}</TableRow>)}{!rows.length && <TableRow><TableCell colSpan={6}>{isLoading ? 'Loading facilities…' : 'No facilities yet.'}</TableCell></TableRow>}</TableBody></Table></TableContainer><Typography variant="caption" sx={{ display: 'block', p: 2 }} color="text.secondary">Up to 100 most recent facilities.</Typography></Paper>
    </Stack>
}
