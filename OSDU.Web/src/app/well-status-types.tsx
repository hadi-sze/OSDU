'use client'
import { useEffect, useState } from 'react'
import { Alert, Autocomplete, Box, Button, Checkbox, Dialog, DialogActions, DialogContent, DialogTitle, Divider, Drawer, FormControlLabel, IconButton, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography } from '@mui/material'
import CloseIcon from '@mui/icons-material/Close'
import AddIcon from '@mui/icons-material/Add'
import {useGetWellStatusTypesQuery,useGetWellStatusSourcesQuery,useCreateWellStatusTypeMutation} from '../lib/store'
const initial={wellStatusType:'',longName:'',shortName:'',remark:'',rSourceId:null as number|null,isActive:true}
export default function WellStatusTypes() {
 const {data:rows=[],error:loadError,isLoading,refetch}=useGetWellStatusTypesQuery()
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
  <Paper variant="outlined"><TableContainer><Table><TableHead><TableRow>{['Name','Short name','Long name','Active','Created by'].map(h=><TableCell key={h}>{h}</TableCell>)}</TableRow></TableHead><TableBody>{rows.map(r=><TableRow key={String(r.rWellStatusTypeId)}>{['wellStatusType','shortName','longName','isActive','rowCreatedBy'].map(k=><TableCell key={k}>{typeof r[k]==='boolean'?(r[k]?'Yes':'No'):String(r[k]??'—')}</TableCell>)}</TableRow>)}{!rows.length&&<TableRow><TableCell colSpan={5}>{isLoading?'Loading…':'No well status types yet.'}</TableCell></TableRow>}</TableBody></Table></TableContainer></Paper>
  <Drawer sx={{zIndex:1300}} anchor="right" open={open} onClose={close} slotProps={{paper:{sx:{width:{xs:'100%',sm:480}}}}}>
   <Box component="form" onSubmit={save} sx={{height:'100%',display:'flex',flexDirection:'column'}} aria-labelledby="well-status-title">
    <Stack direction="row" sx={{p:3,alignItems:'center',justifyContent:'space-between'}}><Typography id="well-status-title" variant="h6" component="h2">Add well status type</Typography><IconButton aria-label="Close drawer" disabled={saving} onClick={close}><CloseIcon/></IconButton></Stack><Divider/>
    <Stack spacing={3} sx={{p:3,overflowY:'auto',flex:1}}>
     <Typography variant="body2" color="text.secondary">ID and audit fields are assigned automatically when saved.</Typography>
     {error&&<Alert severity="error">{error}</Alert>}
     <TextField autoFocus label="Well status type" required value={values.wellStatusType} disabled={saving} onChange={e=>setValues(v=>({...v,wellStatusType:e.target.value}))} slotProps={{htmlInput:{maxLength:60}}} helperText="Required · up to 60 characters"/>
     <TextField label="Short name" value={values.shortName} disabled={saving} onChange={e=>setValues(v=>({...v,shortName:e.target.value}))} slotProps={{htmlInput:{maxLength:30}}}/>
     <TextField label="Long name" value={values.longName} disabled={saving} onChange={e=>setValues(v=>({...v,longName:e.target.value}))} slotProps={{htmlInput:{maxLength:255}}}/>
     <Autocomplete options={sources} getOptionLabel={o=>o.label} isOptionEqualToValue={(a,b)=>a.id===b.id} value={sources.find(o=>o.id===values.rSourceId)||null} disabled={saving||!!sourceError} onChange={(_e,o)=>setValues(v=>({...v,rSourceId:o?.id??null}))} renderInput={params=><TextField {...params} label="Source" helperText={sourceError?'Source list unavailable; optional.':'Optional reference source'}/>}/>
     <TextField label="Remarks" multiline rows={4} value={values.remark} disabled={saving} onChange={e=>setValues(v=>({...v,remark:e.target.value}))} slotProps={{htmlInput:{maxLength:2000}}}/>
     <FormControlLabel control={<Checkbox checked={values.isActive} disabled={saving} onChange={e=>setValues(v=>({...v,isActive:e.target.checked}))}/>} label="Active"/>
    </Stack><Divider/><Stack direction="row" spacing={2} sx={{p:3,justifyContent:'flex-end'}}><Button onClick={close} disabled={saving}>Cancel</Button><Button variant="contained" type="submit" disabled={saving||!values.wellStatusType.trim()}>{saving?'Saving…':'Save status type'}</Button></Stack>
   </Box>
  </Drawer>
  <Dialog open={!!pending} onClose={()=>setPending(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogContent>Your well status type has not been saved.</DialogContent><DialogActions><Button onClick={()=>setPending(null)}>Keep editing</Button><Button color="error" onClick={()=>{const action=pending;setPending(null);action?.()}}>Discard changes</Button></DialogActions></Dialog>
 </Stack>
}

