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
import {useGetCrsRecordsQuery,useCreateCrsMutation,useGetCrsLookupsQuery} from '../lib/store'
const fields=[{"key": "crsName", "label": "CRS name", "kind": "text", "required": true, "max": 50}, {"key": "crsType", "label": "CRS type", "kind": "text", "required": false, "max": 50}, {"key": "geodeticSource", "label": "Geodetic Source", "kind": "text", "required": false, "max": 50}, {"key": "projectionType", "label": "Projection Type", "kind": "text", "required": false, "max": 50}, {"key": "isActive", "label": "Active", "kind": "boolean", "required": false, "max": 0}, {"key": "longName", "label": "Long Name", "kind": "text", "required": false, "max": 255}, {"key": "shortName", "label": "Short Name", "kind": "text", "required": false, "max": 30}, {"key": "remark", "label": "Remark", "kind": "text", "required": false, "max": 2000}]
const initial:Record<string,string|boolean>=Object.fromEntries(fields.map(f=>[f.key,f.kind==='boolean'?f.key==='isActive':'']))
const recordColumns=[{"key": "crsId", "label": "ID"}, {"key": "crsName", "label": "Name"}, {"key": "crsType", "label": "Type"}, {"key": "projectionType", "label": "Projection"}, {"key": "isActive", "label": "Status"}, {"key": "rowCreatedBy", "label": "Created by"}]
export default function CrsRecords() {
 const {data:rows=[],error:loadError,isLoading,isFetching,refetch}=useGetCrsRecordsQuery()
 const {data:lookups={},error:lookupError}=useGetCrsLookupsQuery()
 const [create,{isLoading:saving}]=useCreateCrsMutation()
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
  setSuccess('Saved '+result.crsName+' successfully.');setValues(initial);setOpen(false)
 }catch(e){const err=e as {data?:{message?:string;errors?:Record<string,string[]>}};setError(err.data?.message||Object.values(err.data?.errors||{}).flat().join(' ')||'Unable to save. Please try again.')}}
 return <Stack spacing={2}>
  <Stack direction="row" sx={{justifyContent:'space-between',alignItems:'center'}}><Typography color="text.secondary">Manage coordinate reference systems master data.</Typography><Button variant="contained" startIcon={<AddIcon/>} onClick={()=>{setOpen(true);setError('')}}>Add coordinate reference systems</Button></Stack>
  {success&&<Alert severity="success" onClose={()=>setSuccess('')}>{success}</Alert>}
  {loadError&&<Alert severity="error">Unable to load records.<Button onClick={()=>refetch()}>Retry</Button></Alert>}
  <OrgUnitTypeGrid recordTable="coordinate-reference-systems" onRecordChange={()=>void refetch()} rows={rows} loading={isLoading||isFetching||saving} idKey="crsId" nameKey="crsName" entityLabel="Coordinate Reference Systems" customColumns={recordColumns}/>
  <ShadDrawer swipeDirection="right" open={open} onOpenChange={next=>{if(!next)close()}}>
   <DrawerContent>
    <CssVarsProvider theme={joyTheme}>
     <JoyBox component="form" onSubmit={save} sx={{height:'100dvh',display:'flex',flexDirection:'column',bgcolor:'background.surface',color:'text.primary'}}>
      <JoyBox sx={{p:3,display:'flex',alignItems:'center',justifyContent:'space-between',borderBottom:'1px solid',borderColor:'divider'}}>
       <DrawerTitle style={{margin:0,fontSize:20,fontWeight:600}}>Add coordinate reference systems</DrawerTitle>
       <JoyIconButton aria-label="Close drawer" disabled={saving} onClick={close}><CloseIcon/></JoyIconButton>
      </JoyBox>
      <JoyBox sx={{p:3,display:'flex',flexDirection:'column',gap:2.5,overflowY:'auto',flex:1}}>
       <DrawerDescription style={{margin:0,fontSize:14}}>Enter coordinate reference systems details. ID and audit fields are assigned automatically.</DrawerDescription>
       {error&&<JoyAlert color="danger">{error}</JoyAlert>}
       {fields.map(f=><JoyFormControl key={f.key} required={f.required}><JoyFormLabel>{f.label}</JoyFormLabel>{f.kind==='boolean'?<JoyCheckbox checked={!!values[f.key]} disabled={saving} onChange={e=>setValues(v=>({...v,[f.key]:e.target.checked}))}/>:f.kind==='lookup'?<JoyAutocomplete options={lookups[f.key]||[]} getOptionLabel={o=>o.label} isOptionEqualToValue={(a,b)=>a.id===b.id} value={(lookups[f.key]||[]).find(o=>String(o.id)===String(values[f.key]))||null} disabled={saving||!!lookupError} onChange={(_e,o)=>setValues(v=>({...v,[f.key]:o?String(o.id):''}))} placeholder={f.required?"Select "+f.label.toLowerCase():"Optional reference"}/>:f.key==='remark'?<JoyTextarea minRows={3} disabled={saving} value={String(values[f.key])} onChange={e=>setValues(v=>({...v,[f.key]:e.target.value}))} slotProps={{textarea:{maxLength:f.max}}}/>:<JoyInput required={f.required} disabled={saving} type={f.kind==='date'?'date':f.kind==='number'?'number':'text'} value={String(values[f.key])} onChange={e=>setValues(v=>({...v,[f.key]:e.target.value}))} slotProps={{input:{maxLength:f.max||undefined,step:f.kind==='number'?'any':undefined}}}/>}</JoyFormControl>)}
       {lookupError&&<JoyAlert color="danger">Reference options could not be loaded. Try reopening this page.</JoyAlert>}
      </JoyBox>
      <JoyBox sx={{p:3,display:'flex',gap:2,justifyContent:'flex-end',borderTop:'1px solid',borderColor:'divider'}}><JoyButton variant="outlined" color="neutral" disabled={saving} onClick={close}>Cancel</JoyButton><JoyButton type="submit" loading={saving} loadingIndicator={<OrbitRing className="size-4"/>} disabled={!String(values.crsName).trim()}>Save record</JoyButton></JoyBox>
     </JoyBox>
    </CssVarsProvider>
   </DrawerContent>
  </ShadDrawer>
  <Dialog open={!!pending} onClose={()=>setPending(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your record has not been saved.</DialogContent><DialogActions><Button onClick={()=>setPending(null)}>Keep editing</Button><Button color="error" onClick={()=>{const action=pending;setPending(null);action?.()}}>Discard changes</Button></DialogActions></Dialog>
 </Stack>
}



