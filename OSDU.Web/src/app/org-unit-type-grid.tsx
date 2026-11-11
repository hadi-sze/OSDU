'use client'
import FormLoading from '@/components/loading-ui/form-loading'
// Adapted from the local port-4174 table: tab filters, sorting, column visibility, pagination.
import { OrbitRing } from '@/components/loading-ui/orbit-ring'
import { useMemo, useState, useRef, useEffect } from 'react'
import { Box, Button, Checkbox, Chip, Divider, FormControlLabel, IconButton, InputAdornment, Menu, MenuItem, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography, LinearProgress } from '@mui/material'
import RecordEditor, { RowActions, type RecordAction } from './record-editor'
import SearchIcon from '@mui/icons-material/Search'
import FilterIcon from '@mui/icons-material/Tune'
import SortIcon from '@mui/icons-material/UnfoldMore'
import FirstIcon from '@mui/icons-material/FirstPage'
import LastIcon from '@mui/icons-material/LastPage'
import PrevIcon from '@mui/icons-material/ChevronLeft'
import NextIcon from '@mui/icons-material/ChevronRight'
const defaultColumns=[{key:'rOrgUnitTypeId',label:'ID'},{key:'orgUnitType',label:'Name'},{key:'shortName',label:'Short name'},{key:'longName',label:'Long name'},{key:'isActive',label:'Status'},{key:'rowCreatedBy',label:'Created by'}]
export default function OrgUnitTypeGrid({rows,loading,idKey='rOrgUnitTypeId',nameKey='orgUnitType',entityLabel='Organization unit types',customColumns,onView,onEdit,onDelete,recordTable,onRecordChange}:{rows:Record<string,unknown>[];loading:boolean;idKey?:string;nameKey?:string;entityLabel?:string;customColumns?:{key:string;label:string}[];onView?:(row:Record<string,unknown>)=>void;onEdit?:(row:Record<string,unknown>)=>void;onDelete?:(row:Record<string,unknown>)=>void;recordTable?:string;onRecordChange?:()=>void}) {
 const [transitioning,setTransitioning]=useState(false)
 const activityTimer=useRef<ReturnType<typeof setTimeout>|null>(null)
 useEffect(()=>()=>{if(activityTimer.current)clearTimeout(activityTimer.current)},[])
 function showActivity(){setTransitioning(true);if(activityTimer.current)clearTimeout(activityTimer.current);activityTimer.current=setTimeout(()=>setTransitioning(false),350)}
 const busy=loading||transitioning
 const [recordAction,setRecordAction]=useState<RecordAction>()
 const hasActions=!!(onView||onEdit||onDelete||recordTable)
 const showRecord=(mode:RecordAction['mode'],row:Record<string,unknown>)=>{
  setRecordAction({mode,id:Number(row[idKey]),name:String(row[nameKey]??row[idKey])})
 }
 const columns=useMemo(()=>customColumns??defaultColumns.map(c=>({...c,key:c.key==='rOrgUnitTypeId'?idKey:c.key==='orgUnitType'?nameKey:c.key})),[idKey,nameKey,customColumns])

 const [status,setStatus]=useState('All'),[query,setQuery]=useState(''),[hidden,setHidden]=useState<string[]>([])
 const [anchor,setAnchor]=useState<HTMLElement|null>(null),[creator,setCreator]=useState('')
 const [page,setPage]=useState(0),[size,setSize]=useState(10)
 const [sort,setSort]=useState<{key:string;direction:1|-1}>({key:nameKey,direction:1})
 const filtered=useMemo(()=>rows.filter(r=>(status==='All'||r.isActive===(status==='Active'))&&(!creator||r.rowCreatedBy===creator)&&columns.map(c=>String(r[c.key]??'')).join(' ').toLowerCase().includes(query.toLowerCase())).sort((a,b)=>{
 const av=a[sort.key],bv=b[sort.key]
 return (typeof av==='number'&&typeof bv==='number'?av-bv:String(av??'').localeCompare(String(bv??'')))*sort.direction
 }),[rows,status,creator,query,sort,columns])
 const pages=Math.max(1,Math.ceil(filtered.length/size)),current=Math.min(page,pages-1)
 const visible=columns.filter(c=>!hidden.includes(c.key))
 const creators=Array.from(new Set(rows.map(r=>String(r.rowCreatedBy??'')).filter(Boolean)))
 function reset(){setStatus('All');setQuery('');setCreator('');setHidden([]);setPage(0)}
 return <Box onClickCapture={e=>{if((e.target as Element).closest('button,[role="menuitem"],[role="option"]'))showActivity()}} onChangeCapture={showActivity} component="section" aria-label={entityLabel+" grid"}>
  <Stack direction={{xs:'column',lg:'row'}} spacing={2} sx={{justifyContent:'space-between',alignItems:{lg:'center'},mb:2}}>
   <Box role="tablist" aria-label={entityLabel+" status"} sx={{display:'flex',p:.5,bgcolor:'action.hover',borderRadius:8,alignSelf:'flex-start'}}>
    {['All','Active','Inactive'].map(s=><Button key={s} role="tab" aria-selected={status===s} onClick={()=>{setStatus(s);setPage(0)}} color="inherit" sx={{borderRadius:8,minWidth:0,px:1.5,fontWeight:400,fontSize:12,bgcolor:status===s?'background.paper':'transparent',boxShadow:status===s?'0 2px 8px #0001':'none',transition:'background-color 180ms ease'}}>{s}<Box component="span" sx={{ml:1,color:'text.secondary'}}>{s==='All'?rows.length:rows.filter(r=>r.isActive===(s==='Active')).length}</Box></Button>)}
   </Box>
   <Stack direction="row" spacing={1}><TextField size="small" placeholder={"Search "+entityLabel.toLowerCase()} value={query} onChange={e=>{setQuery(e.target.value);setPage(0)}} slotProps={{htmlInput:{'aria-label':'Search '+entityLabel.toLowerCase()},input:{startAdornment:<InputAdornment position="start"><SearchIcon fontSize="small"/></InputAdornment>}}} sx={{'& .MuiInputBase-root':{borderRadius:8,fontSize:13},minWidth:200}}/><Button variant="outlined" color="inherit" startIcon={<FilterIcon/>} aria-haspopup="menu" aria-expanded={!!anchor} onClick={e=>setAnchor(e.currentTarget)} sx={{borderRadius:8}}>Filter{(creator||hidden.length>0)?' ('+(Number(!!creator)+hidden.length)+')':''}</Button></Stack>
  </Stack>
  <Menu open={!!anchor} anchorEl={anchor} onClose={()=>setAnchor(null)} slotProps={{paper:{sx:{width:260,borderRadius:2,p:1}}}}>
   <Typography variant="overline" sx={{px:1}}>Created by</Typography>
   <MenuItem onClick={()=>{setCreator('');setPage(0)}} selected={!creator}>All users</MenuItem>
   {creators.map(c=><MenuItem key={c} selected={creator===c} onClick={()=>{setCreator(c);setPage(0)}} sx={{fontSize:13}}>{c}</MenuItem>)}
   <Divider/><Typography variant="overline" sx={{px:1}}>Visible columns</Typography>
   {columns.map(c=><MenuItem key={c.key} disabled={visible.length===1&&!hidden.includes(c.key)} onClick={()=>setHidden(h=>h.includes(c.key)?h.filter(k=>k!==c.key):[...h,c.key])}><Checkbox checked={!hidden.includes(c.key)} size="small" tabIndex={-1}/>{c.label}</MenuItem>)}
   <Divider/><MenuItem onClick={()=>{reset();setAnchor(null)}}>Reset filters and columns</MenuItem>
  </Menu>
  <Paper variant="outlined" sx={{borderRadius:3,overflow:'hidden',position:'relative',minHeight:100}} role="region" aria-label={entityLabel+" table"} aria-busy={busy}>
   {busy&&<Box sx={{position:'absolute',inset:0,zIndex:2,display:'flex',alignItems:'center',justifyContent:'center',bgcolor:'background.paper',opacity:.92,pointerEvents:'none'}}><FormLoading label={'Loading ' + entityLabel.toLowerCase() + '…'} /></Box>}
   <TableContainer><Table size="small" sx={{minWidth:650}}><TableHead><TableRow>{visible.map(c=><TableCell key={c.key} aria-sort={sort.key===c.key?(sort.direction===1?'ascending':'descending'):'none'} sx={{fontWeight:400,py:.5,whiteSpace:'nowrap'}}><Button color="inherit" size="small" endIcon={<SortIcon sx={{fontSize:14}}/>} onClick={()=>setSort(s=>({key:c.key,direction:s.key===c.key&&s.direction===1?-1:1}))} sx={{fontWeight:400,fontSize:13,px:0}}>{c.label}</Button></TableCell>)}{hasActions&&<TableCell align="center">Actions</TableCell>}</TableRow></TableHead>
   <TableBody key={JSON.stringify([status,query,creator,current,size,sort,hidden])} sx={{animation:'osdu-grid-in 180ms ease','@keyframes osdu-grid-in':{from:{opacity:0,transform:'translateY(4px)'},to:{opacity:1,transform:'translateY(0)'}},'@media(prefers-reduced-motion:reduce)':{animation:'none'}}}>
    {filtered.slice(current*size,(current+1)*size).map(r=><TableRow hover key={String(r[idKey])}>{visible.map(c=><TableCell key={c.key} sx={{fontSize:13,py:1.25}}>{c.key==='isActive'?<Chip size="small" variant={r.isActive?'filled':'outlined'} color={r.isActive?'success':'neutral'} label={r.isActive?'Active':'Inactive'} sx={{height:23,fontSize:11}}/>:String(r[c.key]??'—')}</TableCell>)}{hasActions&&<TableCell align="center" sx={{whiteSpace:'nowrap'}}><RowActions name={String(r[nameKey]??r[idKey])}
     onDelete={onDelete ? ()=>onDelete(r) : recordTable ? ()=>showRecord('delete',r) : undefined}
     onView={onView ? ()=>onView(r) : recordTable ? ()=>showRecord('view',r) : undefined}
     onEdit={onEdit ? ()=>onEdit(r) : recordTable ? ()=>showRecord('edit',r) : undefined}
    /></TableCell>}</TableRow>)}
    {!filtered.length&&<TableRow><TableCell colSpan={visible.length+Number(hasActions)} align="center" sx={{py:6}}>{loading?'Loading '+entityLabel.toLowerCase()+'…':'No records found. Try changing your search or filters.'}</TableCell></TableRow>}
   </TableBody></Table></TableContainer>
  </Paper>
  <Stack direction={{xs:'column',md:'row'}} spacing={2} sx={{justifyContent:'space-between',alignItems:{md:'center'},mt:2,px:1}}>
   <Typography variant="caption" color="text.secondary" role="status">Showing {filtered.length?current*size+1:0} to {Math.min((current+1)*size,filtered.length)} of {filtered.length} rows.</Typography>
   <Stack direction="row" spacing={2} sx={{alignItems:'center',flexWrap:'wrap'}}><Typography variant="caption">Rows per page</Typography><TextField select size="small" value={size} onChange={e=>{setSize(Number(e.target.value));setPage(0)}} slotProps={{select:{inputProps:{'aria-label':'Rows per page'}}}} sx={{'& .MuiInputBase-root':{borderRadius:8,fontSize:12}}}>{[5,10,20,50].map(n=><MenuItem key={n} value={n}>{n}</MenuItem>)}</TextField><Typography variant="caption">Page {current+1} of {pages}</Typography>
    <Stack direction="row" spacing={.5}>{[{label:'First page',Icon:FirstIcon,target:0,disabled:current===0},{label:'Previous page',Icon:PrevIcon,target:current-1,disabled:current===0},{label:'Next page',Icon:NextIcon,target:current+1,disabled:current===pages-1},{label:'Last page',Icon:LastIcon,target:pages-1,disabled:current===pages-1}].map(({label,Icon,target,disabled})=><IconButton key={label} aria-label={label} disabled={disabled||loading} onClick={()=>setPage(target)} size="small" sx={{border:1,borderColor:'divider'}}><Icon fontSize="small"/></IconButton>)}</Stack>
   </Stack>
  </Stack>
  {recordTable&&recordAction&&<RecordEditor table={recordTable} action={recordAction}
   onClose={()=>setRecordAction(undefined)} onChanged={()=>onRecordChange?.()} />}
 </Box>
}

