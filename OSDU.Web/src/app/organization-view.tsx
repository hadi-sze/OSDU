'use client'
import { useEffect, useState } from 'react'
import { Box, Stack, Button, Alert, Paper, Typography, Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material'
import { SimpleTreeView } from '@mui/x-tree-view/SimpleTreeView'
import { TreeItem } from '@mui/x-tree-view/TreeItem'
import { CssVarsProvider } from '@mui/joy/styles'
import Input from '@mui/joy/Input'
import Autocomplete from '@mui/joy/Autocomplete'
import Checkbox from '@mui/joy/Checkbox'
import FormControl from '@mui/joy/FormControl'
import FormLabel from '@mui/joy/FormLabel'
import Textarea from '@mui/joy/Textarea'
import { joyTheme } from './theme'
import { Drawer, DrawerContent, DrawerTitle, DrawerDescription } from '../components/ui/drawer'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'

type Row = Record<string, unknown>
type Kind = 'fields' | 'wells' | 'facilities'
type Link = { id:number; kind:Kind; orgUnitId:number; targetId:number; effectiveDate:string|null; expiryDate:string|null; remark:string|null; isActive:boolean }
type Data = { organizations:Row[]; fields:Row[]; wells:Row[]; facilities:Row[]; links:Link[] }
const kinds:Kind[] = ['fields','wells','facilities']
const keys = {fields:['fieldId','fieldName'],wells:['wellId','wellName'],facilities:['facilityId','facilityName']}
const blank:Data = {organizations:[],fields:[],wells:[],facilities:[],links:[]}

export default function OrganizationView() {
    const [data,setData] = useState<Data>(blank)
    const [loading,setLoading] = useState(true)
    const [error,setError] = useState('')
    const [selected,setSelected] = useState<{org:Row;link?:Link}>()
    const [draft,setDraft] = useState<Link>()
    const [baseline,setBaseline] = useState('')
    const [saving,setSaving] = useState(false)
    const [remove,setRemove] = useState<Link>()
    const [pending,setPending] = useState<(()=>void)|null>(null)
    const dirty = !!draft && JSON.stringify(draft)!==baseline
    async function load() {
        setLoading(true)
        try {
            const response = await fetch('/api/organization-view')
            if(!response.ok) throw new Error('Unable to load organization relationships.')
            setData(await response.json())
        } catch(e) { setError((e as Error).message) }
        finally { setLoading(false) }
    }
    useEffect(()=>{void load()},[])
    useEffect(()=>{
        const unload=(e:BeforeUnloadEvent)=>{if(dirty){e.preventDefault();e.returnValue=''}}
        const navigate=(e:Event)=>{if(dirty||saving){e.preventDefault();if(!saving)setPending(()=>(e as CustomEvent<()=>void>).detail)}}
        window.addEventListener('beforeunload',unload)
        window.addEventListener('osdu:navigate',navigate)
        return()=>{window.removeEventListener('beforeunload',unload);window.removeEventListener('osdu:navigate',navigate)}
    },[dirty,saving])
    function edit(link:Link) {
        const value={...link,effectiveDate:link.effectiveDate?.slice(0,10)||null,expiryDate:link.expiryDate?.slice(0,10)||null}
        setDraft(value)
        setBaseline(JSON.stringify(value))
        setError('')
    }
    function close() {
        if(saving)return
        if(dirty)setPending(()=>()=>setDraft(undefined))
        else setDraft(undefined)
    }
    async function submit() {
        if(!draft)return
        setSaving(true);setError('')
        try {
            const response=await fetch('/api/organization-view/links',{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify(draft)})
            if(!response.ok){const body=await response.json();throw new Error(body.message||'Unable to save relationship.')}
            setDraft(undefined);setSelected(selected?{org:selected.org}:undefined)
            await load()
        } catch(e){setError((e as Error).message)}
        finally{setSaving(false)}
    }
    async function deleteLink() {
        if(!remove)return
        setSaving(true);setError('')
        try {
            const response=await fetch('/api/organization-view/'+remove.orgUnitId+'/'+remove.kind+'/'+remove.id,{method:'DELETE'})
            if(!response.ok)throw new Error('Unable to remove relationship.')
            setRemove(undefined);setSelected(selected?{org:selected.org}:undefined)
            await load()
        }catch(e){setError((e as Error).message)}
        finally{setSaving(false)}
    }
    const link=selected?.link
    const target=link?data[link.kind].find(row=>Number(row[keys[link.kind][0]])===link.targetId):selected?.org
    return <Stack spacing={2}>
        {error&&<Alert severity="error" onClose={()=>setError('')}>{error}</Alert>}
        <Stack direction="row" spacing={2} sx={{alignItems:"center"}}><Typography>Explore organizations and their dated relationships.</Typography><Button disabled={loading} onClick={()=>{setError('');void load()}}>Refresh</Button>{loading&&<OrbitRing className="size-5"/>}</Stack>
        <Box sx={{display:'grid',gridTemplateColumns:{xs:'1fr',md:'minmax(260px,1fr) 2fr'},gap:2}}>
            <Paper variant="outlined" sx={{p:2}}>
                {!loading&&!data.organizations.length&&<Typography>No organization units yet. Add one in Master data / Organization Unit.</Typography>}
                <SimpleTreeView>
                    {data.organizations.map(org=><TreeItem key={String(org.orgUnitId)} itemId={'org-'+org.orgUnitId} label={String(org.orgUnitName)} onClick={()=>setSelected({org})}>
                        {kinds.map(kind=>{
                            const links=data.links.filter(item=>item.orgUnitId===org.orgUnitId&&item.kind===kind)
                            return <TreeItem key={kind} itemId={'org-'+org.orgUnitId+'-'+kind} label={kind[0].toUpperCase()+kind.slice(1)+' ('+links.length+')'}>
                                {links.map(item=>{
                                    const row=data[kind].find(row=>Number(row[keys[kind][0]])===item.targetId)
                                    return <TreeItem key={item.id} itemId={kind+'-'+item.id} label={String(row?.[keys[kind][1]]??item.targetId)+(item.isActive?'':' (inactive)')} onClick={e=>{e.stopPropagation();setSelected({org,link:item})}}/>
                                })}
                            </TreeItem>
                        })}
                    </TreeItem>)}
                </SimpleTreeView>
            </Paper>
            <Paper variant="outlined" sx={{p:3}}>
                {!selected?<Typography>Select an organization or a linked record.</Typography>:<Stack spacing={2}>
                    <Typography variant="h6">{String(selected.org.orgUnitName)}</Typography>
                    <Stack direction="row" spacing={1} sx={{flexWrap:"wrap"}}>{kinds.map(kind=><Button key={kind} onClick={()=>edit({id:0,orgUnitId:Number(selected.org.orgUnitId),kind,targetId:0,effectiveDate:null,expiryDate:null,remark:null,isActive:true})}>Link {kind}</Button>)}</Stack>
                    {link&&<><Typography variant="subtitle1">{link.kind} relationship</Typography><Typography>Effective {link.effectiveDate?.slice(0,10)||'Not specified'} · Expires {link.expiryDate?.slice(0,10)||'Not specified'} · {link.isActive?'Active':'Inactive'}</Typography><Typography>{link.remark}</Typography><Stack direction="row"><Button onClick={()=>edit(link)}>Edit relationship</Button><Button color="error" onClick={()=>{setError('');setRemove(link)}}>Remove relationship</Button></Stack></>}
                    <Box component="dl" sx={{m:0,display:'grid',gridTemplateColumns:'minmax(120px,1fr) 2fr',gap:1,overflowWrap:'anywhere'}}>
                        {Object.entries(target||{}).map(([key,value])=><Box key={key} sx={{display:'contents'}}><Typography component="dt" color="text.secondary">{key.replace(/([A-Z])/g,' $1')}</Typography><Typography component="dd" sx={{m:0}}>{value==null?'—':String(value)}</Typography></Box>)}
                    </Box>
                </Stack>}
            </Paper>
        </Box>
        <Drawer swipeDirection="right" open={!!draft} onOpenChange={open=>{if(!open)close()}}><DrawerContent><CssVarsProvider theme={joyTheme}>
            {draft&&<Box component="form" onSubmit={e=>{e.preventDefault();void submit()}} sx={{p:3,height:'100dvh',overflowY:'auto',bgcolor:'background.paper'}}>
                <DrawerTitle>{draft.id?'Edit':'Add'} {draft.kind} relationship</DrawerTitle>
                <DrawerDescription>Choose a record and the dates this association applies.</DrawerDescription>
                <Stack spacing={2} sx={{mt:3}}>
                    {error&&<Alert severity="error">{error}</Alert>}
                    <FormControl required><FormLabel>Related record</FormLabel><Autocomplete<Row> disabled={saving} options={data[draft.kind]} getOptionLabel={row=>String(row[keys[draft.kind][1]])} isOptionEqualToValue={(a,b)=>a[keys[draft.kind][0]]===b[keys[draft.kind][0]]} value={data[draft.kind].find(row=>Number(row[keys[draft.kind][0]])===draft.targetId)||null} onChange={(_e,row)=>setDraft({...draft,targetId:Number(row?.[keys[draft.kind][0]]||0)})} slotProps={{listbox:{sx:{zIndex:1400}}}}/></FormControl>
                    <FormControl><FormLabel>Effective date</FormLabel><Input type="date" disabled={saving} value={draft.effectiveDate||''} onChange={e=>setDraft({...draft,effectiveDate:e.target.value||null})}/></FormControl>
                    <FormControl><FormLabel>Expiry date</FormLabel><Input type="date" disabled={saving} value={draft.expiryDate||''} onChange={e=>setDraft({...draft,expiryDate:e.target.value||null})} slotProps={{input:{min:draft.effectiveDate||undefined}}}/></FormControl>
                    <FormControl><FormLabel>Remarks</FormLabel><Textarea disabled={saving} minRows={3} value={draft.remark||''} onChange={e=>setDraft({...draft,remark:e.target.value||null})} slotProps={{textarea:{maxLength:2000}}}/></FormControl>
                    <Checkbox disabled={saving} label="Active" checked={draft.isActive} onChange={e=>setDraft({...draft,isActive:e.target.checked})}/>
                    <Stack direction="row" spacing={2}><Button disabled={saving} onClick={close}>Cancel</Button><Button type="submit" variant="contained" disabled={saving||!draft.targetId}>{saving?<OrbitRing className="size-5"/>:'Save relationship'}</Button></Stack>
                </Stack>
            </Box>}
        </CssVarsProvider></DrawerContent></Drawer>
        <Dialog open={!!remove} onClose={()=>{if(!saving)setRemove(undefined)}}><DialogTitle>Remove relationship?</DialogTitle><DialogContent>{error&&<Alert severity="error">{error}</Alert>}Remove this association from the organization? The related field, well, or facility remains available.</DialogContent><DialogActions><Button disabled={saving} onClick={()=>setRemove(undefined)}>Cancel</Button><Button color="error" disabled={saving} onClick={()=>void deleteLink()}>{saving?'Removing…':'Remove'}</Button></DialogActions></Dialog>
        <Dialog open={!!pending} onClose={()=>setPending(null)}><DialogTitle>Discard unsaved changes?</DialogTitle><DialogActions><Button onClick={()=>setPending(null)}>Keep editing</Button><Button color="error" onClick={()=>{const action=pending;setPending(null);action?.()}}>Discard</Button></DialogActions></Dialog>
    </Stack>
}

