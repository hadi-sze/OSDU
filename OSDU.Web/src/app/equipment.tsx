'use client'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'
import { useEffect, useState } from 'react'
import OrgUnitTypeGrid from './org-unit-type-grid'
import { Alert, Autocomplete, Box, Button, Checkbox, Dialog, DialogActions, DialogContent, DialogTitle, Divider, Drawer, FormControlLabel, IconButton, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography } from '@mui/material'
import { Drawer as ShadDrawer, DrawerContent, DrawerTitle, DrawerDescription } from '../components/ui/drawer'
import { CssVarsProvider } from '@mui/joy/styles'
import { joyTheme } from './theme'
import JoyBox from '@mui/joy/Box'
import JoyButton from '@mui/joy/Button'
import JoyInput from '@mui/joy/Input'
import JoyTextarea from '@mui/joy/Textarea'
import JoyFormControl from '@mui/joy/FormControl'
import JoyFormLabel from '@mui/joy/FormLabel'
import JoyCheckbox from '@mui/joy/Checkbox'
import JoyAutocomplete from '@mui/joy/Autocomplete'
import JoyAlert from '@mui/joy/Alert'
import JoyTypography from '@mui/joy/Typography'
import JoyIconButton from '@mui/joy/IconButton'
import CloseIcon from '@mui/icons-material/Close'
import AddIcon from '@mui/icons-material/Add'
import { useGetEquipmentRecordsQuery, useCreateEquipmentMutation, useGetEquipmentLookupsQuery } from '../lib/store'
const fields = [{ "key": "commissionDate", "label": "Commission Date", "kind": "date", "required": false, "max": 0 }, { "key": "decommissionDate", "label": "Decommission Date", "kind": "date", "required": false, "max": 0 }, { "key": "equipmentName", "label": "Equipment Name", "kind": "text", "required": true, "max": 40 }, { "key": "equipmentSubType", "label": "Equipment Sub Type", "kind": "text", "required": false, "max": 40 }, { "key": "equipmentType", "label": "Equipment Type", "kind": "text", "required": false, "max": 40 }, { "key": "isActive", "label": "Active", "kind": "boolean", "required": false, "max": 0 }, { "key": "rEquipmentSubTypeId", "label": "Equipment subtype", "kind": "lookup", "required": false, "max": 0 }, { "key": "rEquipmentTypeId", "label": "Equipment type", "kind": "lookup", "required": false, "max": 0 }, { "key": "remark", "label": "Remark", "kind": "text", "required": false, "max": 2000 }, { "key": "equipmentAliasName", "label": "Equipment Alias Name", "kind": "text", "required": false, "max": 40 }, { "key": "serialNum", "label": "Serial number", "kind": "number", "required": false, "max": 0 }, { "key": "manufacturerBaId", "label": "Manufacturer organization", "kind": "lookup", "required": false, "max": 0 }, { "key": "rDataAccessCategoryId", "label": "Data access category", "kind": "lookup", "required": false, "max": 0 }]
const initial: Record<string, string | boolean> = Object.fromEntries(fields.map(f => [f.key, f.kind === 'boolean' ? f.key === 'isActive' : '']))
const recordColumns = [{ "key": "equipmentId", "label": "ID" }, { "key": "equipmentName", "label": "Name" }, { "key": "equipmentType", "label": "Type" }, { "key": "equipmentSubType", "label": "Subtype" }, { "key": "serialNum", "label": "Serial number" }, { "key": "isActive", "label": "Status" }, { "key": "rowCreatedBy", "label": "Created by" }]
export default function EquipmentRecords() {
    const { data: rows = [], error: loadError, isLoading, isFetching, refetch } = useGetEquipmentRecordsQuery()
    const { data: lookups = {}, error: lookupError } = useGetEquipmentLookupsQuery()
    const [create, { isLoading: saving }] = useCreateEquipmentMutation()
    const [open, setOpen] = useState(false), [values, setValues] = useState(initial), [error, setError] = useState(''), [success, setSuccess] = useState('')
    const [pending, setPending] = useState<null | (() => void)>(null)
    const dirty = JSON.stringify(values) !== JSON.stringify(initial)
    function close() { if (saving) return; if (dirty) setPending(() => () => { setOpen(false); setValues(initial); setError('') }); else setOpen(false) }
    useEffect(() => {
        const before = (e: BeforeUnloadEvent) => { if (dirty) { e.preventDefault(); e.returnValue = '' } }
        const nav = (e: Event) => { if (dirty) { e.preventDefault(); setPending(() => (e as CustomEvent<() => void>).detail) } }
        window.addEventListener('beforeunload', before); window.addEventListener('osdu:navigate', nav)
        return () => { window.removeEventListener('beforeunload', before); window.removeEventListener('osdu:navigate', nav) }
    }, [dirty])
    async function save(e: React.FormEvent) {
        e.preventDefault(); setError(''); if (values.commissionDate && values.decommissionDate && String(values.decommissionDate) < String(values.commissionDate)) { setError('Decommission date must be on or after commission date.'); return } try {
            const result = await create(Object.fromEntries(fields.map(f => [f.key, f.kind === 'boolean' ? values[f.key] : values[f.key] === '' ? null : f.kind === 'number' || f.kind === 'lookup' ? Number(values[f.key]) : String(values[f.key]).trim()]))).unwrap()
            setSuccess('Saved ' + result.equipmentName + ' successfully.'); setValues(initial); setOpen(false)
        } catch (e) { const err = e as { data?: { message?: string; errors?: Record<string, string[]> } }; setError(err.data?.message || Object.values(err.data?.errors || {}).flat().join(' ') || 'Unable to save. Please try again.') }
    }
    return <Stack spacing={2}>
        <Stack direction="row" sx={{ justifyContent: 'space-between', alignItems: 'center' }}><Typography color="text.secondary">Manage equipment master data.</Typography><Button variant="contained" startIcon={<AddIcon />} onClick={() => { setOpen(true); setError('') }}>Add equipment</Button></Stack>
        {success && <Alert severity="success" onClose={() => setSuccess('')}>{success}</Alert>}
        {loadError && <Alert severity="error">Unable to load records.<Button onClick={() => refetch()}>Retry</Button></Alert>}
        <OrgUnitTypeGrid recordTable="equipment-master" onRecordChange={() => void refetch()} rows={rows} loading={isLoading || isFetching || saving} idKey="equipmentId" nameKey="equipmentName" entityLabel="Equipment" customColumns={recordColumns} />
        <ShadDrawer swipeDirection="right" open={open} onOpenChange={next => { if (!next) close() }}>
            <DrawerContent>
                <CssVarsProvider theme={joyTheme}>
                    <JoyBox component="form" onSubmit={save} sx={{ height: '100dvh', display: 'flex', flexDirection: 'column', bgcolor: 'background.surface', color: 'text.primary' }}>
                        <JoyBox sx={{ p: 3, display: 'flex', alignItems: 'center', justifyContent: 'space-between', borderBottom: '1px solid', borderColor: 'divider' }}>
                            <DrawerTitle style={{ margin: 0, fontSize: 20, fontWeight: 600 }}>Add equipment</DrawerTitle>
                            <JoyIconButton aria-label="Close drawer" disabled={saving} onClick={close}><CloseIcon /></JoyIconButton>
                        </JoyBox>
                        <JoyBox sx={{ p: 3, display: 'flex', flexDirection: 'column', gap: 2.5, overflowY: 'auto', flex: 1 }}>
                            <DrawerDescription style={{ margin: 0, fontSize: 14 }}>Enter equipment details. ID and audit fields are assigned automatically.</DrawerDescription>
                            {error && <JoyAlert color="danger">{error}</JoyAlert>}
                            {fields.map(f => <JoyFormControl key={f.key} required={f.required}><JoyFormLabel>{f.label}</JoyFormLabel>{f.kind === 'boolean' ? <JoyCheckbox checked={!!values[f.key]} disabled={saving} onChange={e => setValues(v => ({ ...v, [f.key]: e.target.checked }))} /> : f.kind === 'lookup' ? <JoyAutocomplete options={lookups[f.key] || []} getOptionLabel={o => o.label} isOptionEqualToValue={(a, b) => a.id === b.id} value={(lookups[f.key] || []).find(o => String(o.id) === String(values[f.key])) || null} disabled={saving || !!lookupError} onChange={(_e, o) => setValues(v => ({ ...v, [f.key]: o ? String(o.id) : '' }))} placeholder={f.required ? "Select " + f.label.toLowerCase() : "Optional reference"} /> : f.key === 'remark' ? <JoyTextarea minRows={3} disabled={saving} value={String(values[f.key])} onChange={e => setValues(v => ({ ...v, [f.key]: e.target.value }))} slotProps={{ textarea: { maxLength: f.max } }} /> : <JoyInput required={f.required} disabled={saving} type={f.kind === 'date' ? 'date' : f.kind === 'number' ? 'number' : 'text'} value={String(values[f.key])} onChange={e => setValues(v => ({ ...v, [f.key]: e.target.value }))} slotProps={{ input: { maxLength: f.max || undefined, step: f.kind === 'number' ? 'any' : undefined } }} />}</JoyFormControl>)}
                            {lookupError && <JoyAlert color="danger">Reference options could not be loaded. Try reopening this page.</JoyAlert>}
                        </JoyBox>
                        <JoyBox sx={{ p: 3, display: 'flex', gap: 2, justifyContent: 'flex-end', borderTop: '1px solid', borderColor: 'divider' }}><JoyButton variant="outlined" color="neutral" disabled={saving} onClick={close}>Cancel</JoyButton><JoyButton type="submit" loading={saving} loadingIndicator={<OrbitRing className="size-4" />} disabled={!String(values.equipmentName).trim()}>Save record</JoyButton></JoyBox>
                    </JoyBox>
                </CssVarsProvider>
            </DrawerContent>
        </ShadDrawer>
        <Dialog open={!!pending} onClose={() => setPending(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your record has not been saved.</DialogContent><DialogActions><Button onClick={() => setPending(null)}>Keep editing</Button><Button color="error" onClick={() => { const action = pending; setPending(null); action?.() }}>Discard changes</Button></DialogActions></Dialog>
    </Stack>
}



