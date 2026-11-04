'use client'
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
import {useGetWellsQuery,useCreateWellMutation,useGetWellLookupsQuery} from '../lib/store'
const fields=[{"key": "uwi", "label": "UWI", "kind": "text", "required": true, "max": 50}, {"key": "wellName", "label": "Well Name", "kind": "text", "required": true, "max": 50}, {"key": "wellAliasName", "label": "Well Alias Name", "kind": "text", "required": false, "max": 255}, {"key": "fieldId", "label": "Field", "kind": "lookup", "required": false, "max": 0}, {"key": "fieldName", "label": "Field Name", "kind": "text", "required": false, "max": 100}, {"key": "offshoreInd", "label": "Offshore", "kind": "boolean", "required": false, "max": 0}, {"key": "isActive", "label": "Active", "kind": "boolean", "required": false, "max": 0}, {"key": "wellOwner", "label": "Well Owner", "kind": "text", "required": false, "max": 255}, {"key": "spudDate", "label": "Spud Date", "kind": "date", "required": false, "max": 0}, {"key": "spudDateTz", "label": "Spud date timezone text", "kind": "text", "required": false, "max": 40}, {"key": "rTimezoneId", "label": "Timezone", "kind": "lookup", "required": false, "max": 0}, {"key": "completionDate", "label": "Completion Date", "kind": "date", "required": false, "max": 0}, {"key": "productionStartDate", "label": "Production Start Date", "kind": "date", "required": false, "max": 0}, {"key": "xCoordinate", "label": "X Coordinate", "kind": "number", "required": false, "max": 0}, {"key": "yCoordinate", "label": "Y Coordinate", "kind": "number", "required": false, "max": 0}, {"key": "crsId", "label": "Coordinate reference system", "kind": "lookup", "required": false, "max": 0}, {"key": "crsName", "label": "CRS name", "kind": "text", "required": false, "max": 50}, {"key": "currentClassId", "label": "Current well class", "kind": "lookup", "required": false, "max": 0}, {"key": "wellClass", "label": "Well Class", "kind": "text", "required": false, "max": 50}, {"key": "deepestDepth", "label": "Deepest Depth", "kind": "number", "required": false, "max": 0}, {"key": "maxTvd", "label": "Maximum true vertical depth", "kind": "number", "required": false, "max": 0}, {"key": "depthDatumId", "label": "Depth datum type", "kind": "lookup", "required": false, "max": 0}, {"key": "depthDatum", "label": "Depth Datum", "kind": "text", "required": false, "max": 50}, {"key": "depthDatumElev", "label": "Depth datum elevation", "kind": "number", "required": false, "max": 0}, {"key": "groundElev", "label": "Ground elevation", "kind": "number", "required": false, "max": 0}, {"key": "bottomHoleXLon", "label": "Bottom hole X / longitude", "kind": "number", "required": false, "max": 0}, {"key": "bottomHoleYLat", "label": "Bottom hole Y / latitude", "kind": "number", "required": false, "max": 0}, {"key": "abandonmentDate", "label": "Abandonment Date", "kind": "date", "required": false, "max": 0}, {"key": "expiryDate", "label": "Expiry Date", "kind": "date", "required": false, "max": 0}, {"key": "faultedInd", "label": "Faulted", "kind": "boolean", "required": false, "max": 0}, {"key": "finalDrillDate", "label": "Final Drill Date", "kind": "date", "required": false, "max": 0}, {"key": "logTd", "label": "Log total depth", "kind": "number", "required": false, "max": 0}, {"key": "netPay", "label": "Net Pay", "kind": "number", "required": false, "max": 0}, {"key": "operator", "label": "Operator", "kind": "text", "required": false, "max": 40}, {"key": "plotName", "label": "Plot Name", "kind": "text", "required": false, "max": 40}, {"key": "plugbackDepth", "label": "Plugback Depth", "kind": "number", "required": false, "max": 0}, {"key": "rWellProfileId", "label": "Well profile status", "kind": "lookup", "required": false, "max": 0}, {"key": "wellProfile", "label": "Well Profile", "kind": "text", "required": false, "max": 60}, {"key": "waterAcousticVel", "label": "Water acoustic velocity", "kind": "number", "required": false, "max": 0}, {"key": "waterDepth", "label": "Water Depth", "kind": "number", "required": false, "max": 0}, {"key": "waterDepthDatum", "label": "Water Depth Datum", "kind": "text", "required": false, "max": 40}, {"key": "isVirtual", "label": "Virtual well", "kind": "boolean", "required": false, "max": 0}, {"key": "rPlotSymbolId", "label": "Plot symbol", "kind": "lookup", "required": false, "max": 0}, {"key": "uidref", "label": "External UID reference", "kind": "text", "required": false, "max": 64}, {"key": "rDataAccessCategoryId", "label": "Data access category", "kind": "lookup", "required": false, "max": 0}]
const initial:Record<string,string|boolean>=Object.fromEntries(fields.map(f=>[f.key,f.kind==='boolean'?f.key==='isActive':'']))
const wellColumns=[{key:"wellId",label:"ID"},{key:"uwi",label:"UWI"},{key:"wellName",label:"Well name"},{key:"fieldName",label:"Field"},{key:"isActive",label:"Status"},{key:"rowCreatedBy",label:"Created by"}]
export default function Wells() {
 const {data:rows=[],error:loadError,isLoading,refetch}=useGetWellsQuery()
 const {data:lookups={},error:lookupError}=useGetWellLookupsQuery()
 const [create,{isLoading:saving}]=useCreateWellMutation()
 const [open,setOpen]=useState(false),[values,setValues]=useState(initial),[error,setError]=useState(''),[success,setSuccess]=useState('')
 const [pending,setPending]=useState<null|(()=>void)>(null)
 const dirty=JSON.stringify(values)!==JSON.stringify(initial)
 function close(){if(saving)return;if(dirty)setPending(()=>()=>{setOpen(false);setValues(initial);setError('')});else setOpen(false)}
 useEffect(()=>{
  const before=(e:BeforeUnloadEvent)=>{if(dirty){e.preventDefault();e.returnValue=''}}
  const nav=(e:Event)=>{if(dirty){e.preventDefault();setPending(()=>(e as CustomEvent<()=>void>).detail)}}
  window.addEventListener('beforeunload',before);window.addEventListener('osdu:navigate',nav)
  return()=>{window.removeEventListener('beforeunload',before);window.removeEventListener('osdu:navigate',nav)}
 },[dirty])
 async function save(e:React.FormEvent){e.preventDefault();setError('');try{
  const result=await create(Object.fromEntries(fields.map(f=>[f.key,f.kind==='boolean'?values[f.key]:values[f.key]===''?null:f.kind==='number'||f.kind==='lookup'?Number(values[f.key]):String(values[f.key]).trim()]))).unwrap()
  setSuccess('Saved '+result.wellName+' successfully.');setValues(initial);setOpen(false)
 }catch(e){const err=e as {data?:{message?:string;errors?:Record<string,string[]>}};setError(err.data?.message||Object.values(err.data?.errors||{}).flat().join(' ')||'Unable to save. Please try again.')}}
 return <Stack spacing={2}>
  <Stack direction="row" sx={{justifyContent:'space-between',alignItems:'center'}}><Typography color="text.secondary">Manage well master data and operational details.</Typography><Button variant="contained" startIcon={<AddIcon/>} onClick={()=>{setOpen(true);setError('')}}>Add well</Button></Stack>
  {success&&<Alert severity="success" onClose={()=>setSuccess('')}>{success}</Alert>}
  {loadError&&<Alert severity="error">Unable to load records.<Button onClick={()=>refetch()}>Retry</Button></Alert>}
  <OrgUnitTypeGrid rows={rows} loading={isLoading} idKey="wellId" nameKey="wellName" entityLabel="Wells" customColumns={wellColumns}/>
  <ShadDrawer swipeDirection="right" open={open} onOpenChange={next=>{if(!next)close()}}>
   <DrawerContent>
    <CssVarsProvider theme={joyTheme}>
     <JoyBox component="form" onSubmit={save} sx={{height:'100dvh',display:'flex',flexDirection:'column',bgcolor:'background.surface',color:'text.primary'}}>
      <JoyBox sx={{p:3,display:'flex',alignItems:'center',justifyContent:'space-between',borderBottom:'1px solid',borderColor:'divider'}}>
       <DrawerTitle style={{margin:0,fontSize:20,fontWeight:600}}>Add well</DrawerTitle>
       <JoyIconButton aria-label="Close drawer" disabled={saving} onClick={close}><CloseIcon/></JoyIconButton>
      </JoyBox>
      <JoyBox sx={{p:3,display:'flex',flexDirection:'column',gap:2.5,overflowY:'auto',flex:1}}>
       <DrawerDescription style={{margin:0,fontSize:14}}>Enter well identification, references, dates and measurements. ID and audit fields are assigned automatically.</DrawerDescription>
       {error&&<JoyAlert color="danger">{error}</JoyAlert>}
       {fields.map(f=><JoyFormControl key={f.key} required={f.required}>{["uwi","spudDate","xCoordinate","deepestDepth","abandonmentDate","operator"].includes(f.key)&&<JoyTypography level="title-md" sx={{mt:1,mb:1}}>{({uwi:"Identification",spudDate:"Lifecycle dates",xCoordinate:"Location",deepestDepth:"Depth and elevation",abandonmentDate:"Additional lifecycle details",operator:"Operations and references"} as Record<string,string>)[f.key]}</JoyTypography>}<JoyFormLabel>{f.label}</JoyFormLabel>{f.kind==='boolean'?<JoyCheckbox checked={!!values[f.key]} disabled={saving} onChange={e=>setValues(v=>({...v,[f.key]:e.target.checked}))}/>:f.kind==='lookup'?<JoyAutocomplete options={lookups[f.key]||[]} getOptionLabel={o=>o.label} isOptionEqualToValue={(a,b)=>a.id===b.id} value={(lookups[f.key]||[]).find(o=>String(o.id)===String(values[f.key]))||null} disabled={saving||!!lookupError} onChange={(_e,o)=>setValues(v=>({...v,[f.key]:o?String(o.id):''}))} placeholder="Select an optional reference"/>:<JoyInput required={f.required} disabled={saving} type={f.kind==='date'?'date':f.kind==='number'?'number':'text'} value={String(values[f.key])} onChange={e=>setValues(v=>({...v,[f.key]:e.target.value}))} slotProps={{input:{maxLength:f.max||undefined,step:f.kind==='number'?'any':undefined}}}/>}</JoyFormControl>)}
       {lookupError&&<JoyAlert color="danger">Reference options could not be loaded. Try reopening this page.</JoyAlert>}
      </JoyBox>
      <JoyBox sx={{p:3,display:'flex',gap:2,justifyContent:'flex-end',borderTop:'1px solid',borderColor:'divider'}}><JoyButton variant="outlined" color="neutral" disabled={saving} onClick={close}>Cancel</JoyButton><JoyButton type="submit" loading={saving} disabled={!String(values.wellName).trim()||!String(values.uwi).trim()}>Save well</JoyButton></JoyBox>
     </JoyBox>
    </CssVarsProvider>
   </DrawerContent>
  </ShadDrawer>
  <Dialog open={!!pending} onClose={()=>setPending(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your well has not been saved.</DialogContent><DialogActions><Button onClick={()=>setPending(null)}>Keep editing</Button><Button color="error" onClick={()=>{const action=pending;setPending(null);action?.()}}>Discard changes</Button></DialogActions></Dialog>
 </Stack>
}



