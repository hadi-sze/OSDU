'use client'

import { useEffect, useState } from 'react'
import { IconButton, Menu, MenuItem, Accordion, AccordionSummary, AccordionDetails, Alert, Box, Button, Chip, LinearProgress, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow, TableSortLabel, Checkbox, TextField, Typography } from '@mui/material'
import MoreVertIcon from '@mui/icons-material/MoreVert'
import AddIcon from '@mui/icons-material/Add'
import ExpandMoreIcon from '@mui/icons-material/ExpandMore'
import RestartIcon from '@mui/icons-material/Refresh'
import ColumnsIcon from '@mui/icons-material/ViewColumn'
import DownloadIcon from '@mui/icons-material/Download'
import FilterIcon from '@mui/icons-material/FilterAltOutlined'
import { useGetWellLookupsQuery, assetsApi } from '@/lib/store'
import FormLoading from '@/components/loading-ui/form-loading'
import RecordEditor, { type RecordAction } from '@/features/master-data/record-editor'

type WellRow = { wellId: number; wellAliasName: string | null; fieldId: number | null; wellOwner: string | null; maxTvd: number | null; wellName: string; uwi: string; fieldName: string | null; operator: string | null; wellClass: string | null; spudDate: string | null; isActive: boolean }
type WellPage = { rows: WellRow[]; total: number; page: number; size: number; counts: { all: number; active: number; inactive: number } }
const api = assetsApi.injectEndpoints({ endpoints: b => ({
    wellPage: b.query<WellPage, { page: number; size: number; search: string; status: string; sort: string; desc: boolean }>({
        query: params => ({ url: 'wells/page', params }), providesTags: ['Well'],
    }),
}) })
const columns = [
    ['wellName', 'Well'], ['fieldName', 'Field'], ['wellAliasName', 'Well Alias Name'],
    ['fieldId', 'Field Identifier'], ['remark', 'Remark'], ['uwi', 'UWI'], ['wellOwner', 'Well Owner'],
    ['spudDate', 'Spud Date'], ['maxTvd', 'Max TVD'], ['operator', 'Operator'],
    ['wellClass', 'Well Class'], ['isActive', 'Status'],
] as const
const initialFilters = { fieldId: '', classId: '', profileId: '', operator: '', owner: '', offshore: '', virtual: '', status: '' }
function display(row: WellRow, key: typeof columns[number][0]) {
    if (key === 'remark') return ''
    if (key === 'isActive') return row.isActive ? 'Active' : 'Inactive'
    if (key === 'spudDate') return row.spudDate?.replace('T', ' ').slice(0, 16) || ''
    return String(row[key] ?? '')
}
export default function Wells() {
    const [search, setSearch] = useState('')
    const [draft, setDraft] = useState(initialFilters)
    const [params, setParams] = useState({ ...initialFilters, page: 0, size: 10, search: '', sort: 'wellName', desc: false })
    const [columnMenu, setColumnMenu] = useState<HTMLElement | null>(null)
    const [hidden, setHidden] = useState<string[]>(['wellClass', 'isActive'])
    const visible = columns.filter(([key]) => !hidden.includes(key))
    const { data: lookups, isError: lookupError, refetch: retryLookups } = useGetWellLookupsQuery()
    function reset() {
        setDraft(initialFilters)
        setSearch('')
        setParams(p => ({ ...p, ...initialFilters, search: '', page: 0 }))
    }
    function choices(key: keyof typeof draft, label: string, options: {id: string | number; label: string}[], all: string) {
        return <TextField select size="small" label={label} value={draft[key]} onChange={e => setDraft({ ...draft, [key]: e.target.value })}
            slotProps={{ select: { displayEmpty: true }, inputLabel: { shrink: true } }}>
            <MenuItem value="">{all}</MenuItem>
            {options.map(option => <MenuItem key={option.id} value={String(option.id)}>{option.label}</MenuItem>)}
        </TextField>
    }
    useEffect(() => {
        const timer = setTimeout(() => setParams(p => p.search === search.trim() ? p : { ...p, search: search.trim(), page: 0 }), 250)
        return () => clearTimeout(timer)
    }, [search])
    const { data, error, isFetching, refetch } = api.useWellPageQuery(params)
    const [action, setAction] = useState<RecordAction & { table?: string }>()
    const [menu, setMenu] = useState<{ anchor: HTMLElement; row: WellRow }>()
    const [parentWell, setParentWell] = useState<RecordAction>()
    const [saved, setSaved] = useState(false)
    const rows = data?.rows ?? []
    function openWell(row: WellRow, mode: RecordAction['mode']) {
        setMenu(undefined)
        setAction({ mode, id: row.wellId, name: row.wellName })
    }

    function addWell() {
        setSaved(false)
        setAction({ mode: 'create', id: 0, name: 'well' })
    }

    return <Stack spacing={0.5}>
        {saved && <Alert severity="success" onClose={() => setSaved(false)}>Well changes saved.</Alert>}
        {error && <Alert severity="error" action={<Button onClick={() => refetch()}>Retry</Button>}>Unable to refresh wells. Any previously loaded records remain below.</Alert>}
          
        <Paper component="section" aria-label="Well filters" variant="outlined" sx={{ p:1 }}>
            <Stack direction="row" sx={{ alignItems: 'center', flexWrap: 'wrap', gap: 1, mb: 1 }}>
                <Typography variant="h6">Wells</Typography><Chip size="small" label={data?.total ?? '...'} />
                <TextField size="small" label="Search wells" value={search} onChange={e => setSearch(e.target.value)} sx={{ ml: 'auto' }} />
                <IconButton size='small' title="Refresh wells" onClick={refetch}><RestartIcon /></IconButton>
                <IconButton title="Choose columns" onClick={e => setColumnMenu(e.currentTarget)}><ColumnsIcon /></IconButton>
                <IconButton title="Download current page as CSV" size="small"  disabled={!rows.length || isFetching} onClick={() => {
                    const csv = [visible.map(c => c[1]), ...rows.map(row => visible.map(([key]) => display(row, key)))]
                        .map(line => line.map(cell => '"' + (/^[=+@\-\t\r]/.test(cell) ? "'" : '') + cell.replaceAll('"', '""') + '"').join(',')).join('\r\n')
                    const link = document.createElement('a')
                    link.href = URL.createObjectURL(new Blob([csv], { type: 'text/csv;charset=utf-8' }))
                    link.download = 'wells-page.csv'
                    link.click()
                    setTimeout(() => URL.revokeObjectURL(link.href), 1000)
                }}><DownloadIcon /></IconButton>
                <IconButton title="Add well" onClick={addWell} size="small" sx={{ bgcolor: 'primary.main', color: 'primary.contrastText', '&:hover': { bgcolor: 'primary.dark' }  }}><AddIcon /></IconButton>
            </Stack>
            <Menu anchorEl={columnMenu} open={!!columnMenu} onClose={() => setColumnMenu(null)}>
                {columns.map(([key,label]) => <MenuItem key={key} disabled={visible.length === 1 && !hidden.includes(key)} onClick={() => setHidden(h => h.includes(key) ? h.filter(k => k !== key) : [...h,key])}><Checkbox checked={!hidden.includes(key)} />{label}</MenuItem>)}
            </Menu>
            <Accordion disableGutters elevation={0}>
                <AccordionSummary expandIcon={<ExpandMoreIcon />}><FilterIcon fontSize="small" sx={{ mr: 1 }} />Filter Panel</AccordionSummary>
                <AccordionDetails>
                    {lookupError && <Alert severity="error" action={<Button onClick={retryLookups}>Retry</Button>}>Unable to load filter options.</Alert>}
                    <Box component="form" onSubmit={e => { e.preventDefault(); setParams(p => ({ ...p, ...draft, page: 0 })) }} sx={{ display: 'grid', gridTemplateColumns: { xs: '1fr', sm: 'repeat(2,1fr)', lg: 'repeat(4,1fr)' }, gap: 1.2 }}>
                        {choices('fieldId', 'Field', lookups?.fieldId ?? [], 'All fields')}
                        {choices('classId', 'Well Class', lookups?.currentClassId ?? [], 'All classes')}
                        {choices('profileId', 'Well Profile', lookups?.rWellProfileId ?? [], 'All profiles')}
                        {(['operator', 'owner'] as const).map(key => <TextField key={key} size="small" label={key === 'operator' ? 'Operator' : 'Owner'} placeholder="Contains..." value={draft[key]} onChange={e => setDraft({ ...draft, [key]: e.target.value })} />)}
                        {choices('offshore', 'Environment', [{id:'true',label:'Offshore'},{id:'false',label:'Onshore'}], 'All')}
                        {choices('virtual', 'Virtual', [{id:'true',label:'Yes'},{id:'false',label:'No'}], 'All')}
                        {choices('status', 'Status', ['Active','Inactive'].map(id => ({id,label:id})), 'All statuses')}
                        <Stack direction="row" spacing={1} sx={{ gridColumn: '1 / -1', justifyContent: 'flex-end' }}><Button onClick={reset}>Reset</Button><Button type="submit" variant="contained">Apply</Button></Stack>
                    </Box>
                </AccordionDetails>
            </Accordion>
        </Paper>
          
        
        <Paper variant="outlined" sx={{ overflow: 'hidden', minWidth: 0 }} aria-busy={isFetching}>
            <Box sx={{ height: 3 }}>{isFetching && data && <LinearProgress aria-label="Refreshing wells" />}</Box>
            {!data && isFetching ? <FormLoading label="Loading wells…" /> : <>
                <TableContainer sx={{ maxHeight: '65vh' }}><Table stickyHeader size="small" aria-label="Wells" sx={{ minWidth: 1000 }}>
                    <TableHead><TableRow>{visible.map(([key,label]) => <TableCell key={key}>
                        {key === 'remark' ? label : <TableSortLabel active={params.sort === key} direction={params.sort === key && params.desc ? 'desc' : 'asc'} onClick={() => setParams(p => ({ ...p, page: 0, sort: key, desc: p.sort === key && !p.desc }))}>{label}</TableSortLabel>}
                    </TableCell>)}<TableCell align="right">Actions</TableCell></TableRow></TableHead>
                    <TableBody>{rows.map(row => <TableRow hover key={row.wellId}>
                        {visible.map(([key]) => <TableCell key={key}>{key === 'wellName' ? <Button onClick={() => openWell(row, 'view')}>{row.wellName}</Button> : display(row,key) || '—'}</TableCell>)}
                        <TableCell align="right"><IconButton aria-label={'Actions for ' + row.wellName} onClick={e => setMenu({ anchor: e.currentTarget, row })}><MoreVertIcon /></IconButton></TableCell>
                    </TableRow>)}{!rows.length && !error && !isFetching && <TableRow><TableCell colSpan={visible.length + 1} align="center" sx={{ py: 5 }}>{data?.counts.all ? <Stack sx={{ alignItems: 'center' }} spacing={1}>No wells match your filters.
                            <Button onClick={reset}>Clear filters</Button>
                        </Stack> : <Stack sx={{ alignItems: 'center' }} spacing={1}>No wells yet.<Button onClick={addWell}>Add your first well</Button></Stack>}</TableCell></TableRow>}</TableBody>
                </Table></TableContainer>
                <TablePagination component="div" count={data?.total ?? 0} page={data?.page ?? 0} rowsPerPage={params.size} rowsPerPageOptions={[10, 25, 50, 100]}
                    onPageChange={(_, page) => setParams(p => ({ ...p, page }))} onRowsPerPageChange={e => setParams(p => ({ ...p, size: Number(e.target.value), page: 0 }))} />
            </>}
        </Paper>
        <Menu open={!!menu} anchorEl={menu?.anchor} onClose={() => setMenu(undefined)}>
            {(['view', 'edit', 'delete'] as const).map(mode => <MenuItem key={mode} onClick={() => { if (menu) openWell(menu.row, mode) }}>{mode[0].toUpperCase() + mode.slice(1)}</MenuItem>)}
        </Menu>
        <Accordion disableGutters elevation={0} sx={{ border: 1, borderColor: 'divider', borderRadius: 1 }}>
            <AccordionSummary expandIcon={<ExpandMoreIcon />}><Typography component="h2">About wells</Typography></AccordionSummary>
            <AccordionDetails>A well is the location on the surface of the earth or sea bed where the drill bit is planned to penetrate or does penetrate the earth to establish or rework a well. The well will be the same with Well Origin in PPDM.</AccordionDetails>
        </Accordion>
        {action && <RecordEditor key={(action.table ?? 'well-master') + ':' + action.mode + ':' + action.id} table={action.table ?? 'well-master'} action={action} onClose={() => { setAction(parentWell); setParentWell(undefined) }} onChanged={() => setSaved(true)} onRelated={(table, id, name) => { setParentWell(action); setAction({ table, id, name, mode: 'view' }) }} />}
    </Stack>
}
