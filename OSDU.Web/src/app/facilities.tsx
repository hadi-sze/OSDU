'use client'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'
import { useState, useEffect } from 'react'
import { Accordion, AccordionSummary, AccordionDetails, Autocomplete, Dialog, DialogTitle, DialogContent, DialogActions, Alert, Box, Button, Checkbox, FormControlLabel, MenuItem, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography } from '@mui/material'
import OrgUnitTypeGrid from './org-unit-type-grid'
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
import JoySelect from '@mui/joy/Select'
import JoyOption from '@mui/joy/Option'
import JoyAlert from '@mui/joy/Alert'
import JoyIconButton from '@mui/joy/IconButton'
import CloseIcon from '@mui/icons-material/Close'
import AddIcon from '@mui/icons-material/Add'
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
const facilityColumns=[{key:'facilityId',label:'ID'},{key:'facilityName',label:'Name'},{key:'facilityType',label:'Type'},{key:'currentOperator',label:'Operator'},{key:'isActive',label:'Status'},{key:'rowCreatedBy',label:'Created by'}]
export default function Facilities() {
    const { data: rows = [], isLoading, isFetching, error, refetch } = useGetFacilitiesQuery()
    const { data: lookups = {}, isLoading: loadingLookups, error: lookupError } = useGetFacilityLookupsQuery()
    const [create, { isLoading: saving }] = useCreateFacilityMutation()
    const [open,setOpen]=useState(false)
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
    const close = () => {if(saving)return;const action=()=>{setOpen(false);setValues(empty);setMessage('')};if(dirty)setPendingAction(()=>action);else action()}
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
        try { const result = await create(payload).unwrap(); setLastSaved(result); setSuccess('Facility “' + result.facilityName + '” saved successfully. ID: ' + result.facilityId); setValues(empty);setOpen(false) }
        catch (e) { const err = e as { data?: { message?: string; errors?: Record<string, string[]> } }; setMessage(err.data?.message || Object.values(err.data?.errors || {}).flat().join(' ') || 'Unable to save the facility. Check your connection and try again.') }
    }
    return <Stack spacing={3}>
        <Dialog open={!!pendingAction} onClose={() => setPendingAction(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your facility details have not been saved.</DialogContent><DialogActions><Button onClick={() => setPendingAction(null)}>Keep editing</Button><Button color="error" onClick={() => { const action = pendingAction; setPendingAction(null); action?.() }}>Discard changes</Button></DialogActions></Dialog>
        {success && <Alert severity="success">{success}</Alert>}
        {error && <Alert severity="error">Unable to load facilities.<Button onClick={() => refetch()}>Retry</Button></Alert>}
        <Stack direction="row" sx={{justifyContent:'space-between',alignItems:'center'}}><Typography color="text.secondary">Manage facility details, location and operations.</Typography><Button variant="contained" startIcon={<AddIcon/>} onClick={()=>{setOpen(true);setMessage('')}}>Add facility</Button></Stack>
        <OrgUnitTypeGrid recordTable="facilities" onRecordChange={()=>void refetch()} rows={rows} loading={isLoading||isFetching||saving} idKey="facilityId" nameKey="facilityName" entityLabel="Facilities" customColumns={facilityColumns}/>
        <Typography variant="caption" color="text.secondary">Up to 100 most recent facilities.</Typography>
        <ShadDrawer swipeDirection="right" open={open} onOpenChange={next=>{if(!next)close()}}><DrawerContent><CssVarsProvider theme={joyTheme}>
        <JoyBox component="form" onSubmit={submit} sx={{height:'100dvh',display:'flex',flexDirection:'column',bgcolor:'background.surface',color:'text.primary'}}>
         <JoyBox sx={{p:3,display:'flex',alignItems:'center',justifyContent:'space-between',borderBottom:'1px solid',borderColor:'divider'}}><DrawerTitle style={{margin:0,fontSize:20,fontWeight:600}}>Add facility</DrawerTitle><JoyIconButton aria-label="Close drawer" disabled={saving} onClick={close}><CloseIcon/></JoyIconButton></JoyBox>
         <JoyBox sx={{p:3,overflowY:'auto',flex:1,display:'flex',flexDirection:'column',gap:2}}>
          <DrawerDescription style={{margin:0,fontSize:14}}>Enter facility details. ID and audit fields are assigned automatically.</DrawerDescription>
          {lookupError&&<JoyAlert color="warning">Reference lists could not be loaded. Refresh before choosing classifications.</JoyAlert>}
          {sections.map((section,index)=><Accordion key={section.title} defaultExpanded={index===0} disableGutters elevation={0} sx={{border:1,borderColor:'divider','&:before':{display:'none'}}}><AccordionSummary expandIcon={<ExpandMoreIcon/>}><Typography variant="subtitle2">{section.title}</Typography></AccordionSummary><AccordionDetails><Stack spacing={2}>
           {section.names.map(name=>{
            const f=facilityFields.find(x=>x.name===name)!,v=values[name]??''
            if(f.type==='boolean'&&name!=='isVirtual')return <JoyCheckbox key={name} label={name==='offshoreInd'?'Offshore facility':'Active'} checked={v==='true'} disabled={saving} onChange={e=>set(name,String(e.target.checked))}/>
            const options=lookups[name]||[],reference=['facilityTypeId','rEquipmentCatalogueId','crsId','rDataAccessCategoryId'].includes(name)
            return <JoyFormControl key={name} required={f.required}><JoyFormLabel>{f.label.replace(' Id','')}</JoyFormLabel>
             {reference?<JoyAutocomplete options={options} getOptionLabel={o=>o.label} isOptionEqualToValue={(a,b)=>a.id===b.id} value={options.find(o=>String(o.id)===v)||null} loading={loadingLookups} disabled={saving||!!lookupError} onChange={(_e,o)=>set(name,o?String(o.id):'')} placeholder="Optional reference"/>:
             f.type==='boolean'?<JoySelect value={v} disabled={saving} onChange={(_e,value)=>set(name,value||'')}><JoyOption value="">Not specified</JoyOption><JoyOption value="true">Yes</JoyOption><JoyOption value="false">No</JoyOption></JoySelect>:
             name==='remark'?<JoyTextarea value={v} disabled={saving} onChange={e=>set(name,e.target.value)} minRows={3} slotProps={{textarea:{maxLength:f.maxLength??undefined}}}/>:
             <JoyInput required={f.required} value={v} disabled={saving} onChange={e=>set(name,e.target.value)} type={f.type==='date'?'datetime-local':f.type==='number'?'number':'text'} slotProps={{input:{maxLength:f.maxLength??undefined,step:f.type==='number'?(name.endsWith('Id')||name==='facilityNo'?1:'0.000000001'):undefined,min:['depth','facilityDiameter'].includes(name)?0:undefined}}}/>}
             {['depth','elevation','facilityDiameter'].includes(name)&&<JoyFormControl required={!!v} sx={{mt:1}}><JoyFormLabel>Unit</JoyFormLabel><JoySelect value={values[name+'Uom']||''} disabled={saving} onChange={(_e,unit)=>set(name+'Uom',unit||'')}><JoyOption value="">Select unit</JoyOption>{['m','ft','in'].map(unit=><JoyOption key={unit} value={unit}>{unit}</JoyOption>)}</JoySelect></JoyFormControl>}
            </JoyFormControl>
           })}
          </Stack></AccordionDetails></Accordion>)}
          {message&&<JoyAlert color="danger">{message}</JoyAlert>}
         </JoyBox>
         <JoyBox sx={{p:3,display:'flex',gap:1,justifyContent:'flex-end',borderTop:'1px solid',borderColor:'divider'}}><JoyButton variant="plain" color="neutral" disabled={saving} onClick={clear}>Clear</JoyButton><JoyButton variant="outlined" color="neutral" disabled={saving} onClick={close}>Cancel</JoyButton><JoyButton type="submit" loading={saving} loadingIndicator={<OrbitRing className="size-4"/>} disabled={!values.facilityName?.trim()}>Save facility</JoyButton></JoyBox>
        </JoyBox></CssVarsProvider></DrawerContent></ShadDrawer>
        {lastSaved && <Paper variant="outlined" sx={{ p: 3 }}><Typography variant="h6" sx={{ mb: 2 }}>Last saved facility · audit details</Typography><Box sx={{ display: 'grid', gridTemplateColumns: { xs: '1fr', sm: '1fr 1fr' }, gap: 2 }}>{['facilityId', 'rowCreatedBy', 'rowCreatedDate', 'rowChangedBy', 'rowChangedDate'].map(k => <TextField key={k} label={k.replace(/([A-Z])/g, ' $1')} value={String(lastSaved[k] ?? '—')} size="small" slotProps={{ input: { readOnly: true } }} />)}</Box></Paper>}

    </Stack>
}
