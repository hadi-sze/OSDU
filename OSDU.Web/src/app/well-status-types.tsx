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
import {useGetWellStatusTypesQuery,useCreateWellStatusTypeMutation,useGetWellStatusSourcesQuery} from '../lib/store'
const initial={wellStatusType:'',longName:'',shortName:'',remark:'',isActive:true,rSourceId:null as number|null}
export default function WellStatusTypes() {
 const {data:rows=[],error:loadError,isLoading,isFetching,refetch}=useGetWellStatusTypesQuery()
 const {data:sources=[],error:sourceError}=useGetWellStatusSourcesQuery()
 const [create,{isLoading:saving}]=useCreateWellStatusTypeMutation()
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
  const result=await create({...values,wellStatusType:values.wellStatusType.trim(),longName:values.longName.trim()||null,shortName:values.shortName.trim()||null,remark:values.remark.trim()||null}).unwrap()
  setSuccess('Saved '+result.wellStatusType+' successfully.');setValues(initial);setOpen(false)
 }catch(e){const err=e as {data?:{message?:string;errors?:Record<string,string[]>}};setError(err.data?.message||Object.values(err.data?.errors||{}).flat().join(' ')||'Unable to save. Please try again.')}}
 return <Stack spacing={2}>
  <Stack direction="row" sx={{justifyContent:'space-between',alignItems:'center'}}><Typography color="text.secondary">Manage the categories used to classify well statuses.</Typography><Button variant="contained" startIcon={<AddIcon/>} onClick={()=>{setOpen(true);setError('')}}>Add well status type</Button></Stack>
  {success&&<Alert severity="success" onClose={()=>setSuccess('')}>{success}</Alert>}
  {loadError&&<Alert severity="error">Unable to load records.<Button onClick={()=>refetch()}>Retry</Button></Alert>}
  <OrgUnitTypeGrid recordTable="well-status-types" onRecordChange={()=>void refetch()} rows={rows} loading={isLoading||isFetching||saving} idKey="rWellStatusTypeId" nameKey="wellStatusType" entityLabel="Well status types"/>
  <ShadDrawer swipeDirection="right" open={open} onOpenChange={next=>{if(!next)close()}}>
   <DrawerContent>
    <CssVarsProvider theme={joyTheme}>
     <JoyBox component="form" onSubmit={save} sx={{height:'100dvh',display:'flex',flexDirection:'column',bgcolor:'background.surface',color:'text.primary'}}>
      <JoyBox sx={{p:3,display:'flex',alignItems:'center',justifyContent:'space-between',borderBottom:'1px solid',borderColor:'divider'}}>
       <DrawerTitle style={{margin:0,fontSize:20,fontWeight:600}}>Add well status type</DrawerTitle>
       <JoyIconButton aria-label="Close drawer" disabled={saving} onClick={close}><CloseIcon/></JoyIconButton>
      </JoyBox>
      <JoyBox sx={{p:3,display:'flex',flexDirection:'column',gap:2.5,overflowY:'auto',flex:1}}>
       <DrawerDescription style={{margin:0,fontSize:14}}>Create a well status type such as Operating or Producing. ID and audit fields are assigned automatically.</DrawerDescription>
       {error&&<JoyAlert color="danger">{error}</JoyAlert>}
       <JoyFormControl required><JoyFormLabel>Well status type</JoyFormLabel><JoyInput autoFocus required disabled={saving} value={values.wellStatusType} onChange={e=>setValues(v=>({...v,wellStatusType:e.target.value}))} slotProps={{input:{maxLength:60}}}/></JoyFormControl>
       <JoyFormControl><JoyFormLabel>Short name</JoyFormLabel><JoyInput disabled={saving} value={values.shortName} onChange={e=>setValues(v=>({...v,shortName:e.target.value}))} slotProps={{input:{maxLength:30}}}/></JoyFormControl>
       <JoyFormControl><JoyFormLabel>Long name</JoyFormLabel><JoyInput disabled={saving} value={values.longName} onChange={e=>setValues(v=>({...v,longName:e.target.value}))} slotProps={{input:{maxLength:255}}}/></JoyFormControl>
       <JoyFormControl><JoyFormLabel>Source</JoyFormLabel><JoyAutocomplete options={sources} getOptionLabel={o=>o.label} isOptionEqualToValue={(a,b)=>a.id===b.id} value={sources.find(o=>o.id===values.rSourceId)||null} disabled={saving||!!sourceError} onChange={(_e,o)=>setValues(v=>({...v,rSourceId:o?.id??null}))} placeholder="Optional source"/>{sourceError&&<JoyTypography level="body-xs" color="danger">Sources could not be loaded.</JoyTypography>}</JoyFormControl>
       <JoyFormControl><JoyFormLabel>Remarks</JoyFormLabel><JoyTextarea minRows={3} disabled={saving} value={values.remark} onChange={e=>setValues(v=>({...v,remark:e.target.value}))} slotProps={{textarea:{maxLength:2000}}}/></JoyFormControl>
       <JoyCheckbox label="Active" checked={values.isActive} disabled={saving} onChange={e=>setValues(v=>({...v,isActive:e.target.checked}))}/>
      </JoyBox>
      <JoyBox sx={{p:3,display:'flex',gap:2,justifyContent:'flex-end',borderTop:'1px solid',borderColor:'divider'}}><JoyButton variant="outlined" color="neutral" disabled={saving} onClick={close}>Cancel</JoyButton><JoyButton type="submit" loading={saving} loadingIndicator={<OrbitRing className="size-4"/>} disabled={!values.wellStatusType.trim()}>Save well status type</JoyButton></JoyBox>
     </JoyBox>
    </CssVarsProvider>
   </DrawerContent>
  </ShadDrawer>
  <Dialog open={!!pending} onClose={()=>setPending(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your well status type has not been saved.</DialogContent><DialogActions><Button onClick={()=>setPending(null)}>Keep editing</Button><Button color="error" onClick={()=>{const action=pending;setPending(null);action?.()}}>Discard changes</Button></DialogActions></Dialog>
 </Stack>
}



