'use client'

import { useEffect, useState } from 'react'
import { IconButton, Menu, MenuItem, Accordion, AccordionSummary, AccordionDetails, Alert, Box, Button, Chip, LinearProgress, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow, TableSortLabel, Tabs, Tab, TextField, Typography } from '@mui/material'
import MoreHorizIcon from '@mui/icons-material/MoreHoriz'
import AddIcon from '@mui/icons-material/Add'
import ExpandMoreIcon from '@mui/icons-material/ExpandMore'
import { assetsApi } from '../lib/store'
import FormLoading from '@/components/loading-ui/form-loading'
import RecordEditor, { RowActions, type RecordAction } from './record-editor'

type WellRow = { wellId: number; wellName: string; uwi: string; fieldName: string | null; isActive: boolean }
type WellPage = { rows: WellRow[]; total: number; page: number; size: number; counts: { all: number; active: number; inactive: number } }
const api = assetsApi.injectEndpoints({ endpoints: b => ({
    wellPage: b.query<WellPage, { page: number; size: number; search: string; status: string; sort: string; desc: boolean }>({
        query: params => ({ url: 'wells/page', params }), providesTags: ['Well'],
    }),
}) })
const columns = [{ key: 'wellName', label: 'Well name' }, { key: 'uwi', label: 'UWI' }, { key: 'fieldName', label: 'Field' }, { key: 'isActive', label: 'Status' }]

export default function Wells() {
    const [search, setSearch] = useState('')
    const [params, setParams] = useState({ page: 0, size: 10, search: '', status: 'All', sort: 'wellName', desc: false })
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

    return <Stack spacing={2}>
        <Stack direction={{ xs: 'column', sm: 'row' }} sx={{ justifyContent: 'space-between', gap: 2 }}>
            <Typography color="text.secondary">Manage well identification, location, and operational details.</Typography>
            <Button variant="contained" startIcon={<AddIcon />} onClick={addWell}>Add well</Button>
        </Stack>
        <Accordion disableGutters elevation={0} sx={{ border: 1, borderColor: 'divider', borderRadius: 1 }}>
            <AccordionSummary expandIcon={<ExpandMoreIcon />}><Typography component="h2">About wells</Typography></AccordionSummary>
            <AccordionDetails>A well is the location on the surface of the earth or sea bed where the drill bit is planned to penetrate or does penetrate the earth to establish or rework a well. The well will be the same with Well Origin in PPDM.</AccordionDetails>
        </Accordion>
        {saved && <Alert severity="success" onClose={() => setSaved(false)}>Well changes saved.</Alert>}
        {error && <Alert severity="error" action={<Button onClick={() => refetch()}>Retry</Button>}>Unable to refresh wells. Any previously loaded records remain below.</Alert>}
        <Stack direction={{ xs: 'column', md: 'row' }} spacing={2} sx={{ justifyContent: 'space-between' }}>
            <Tabs value={params.status} onChange={(_, status: string) => setParams(p => ({ ...p, status, page: 0 }))} aria-label="Well status">
                {(['All', 'Active', 'Inactive'] as const).map(status => <Tab key={status} value={status} label={status + (data ? ` (${data.counts[status.toLowerCase() as keyof WellPage['counts']]})` : '')} />)}
            </Tabs>
            <Stack direction="row" spacing={1}>
                <TextField size="small" label="Search wells" placeholder="Name, UWI, or field" value={search} onChange={e => setSearch(e.target.value)} />
                <Button onClick={() => refetch()} disabled={isFetching}>Refresh</Button>
            </Stack>
        </Stack>
        <Paper variant="outlined" sx={{ overflow: 'hidden', minWidth: 0 }} aria-busy={isFetching}>
            <Box sx={{ height: 3 }}>{isFetching && data && <LinearProgress aria-label="Refreshing wells" />}</Box>
            {!data && isFetching ? <FormLoading label="Loading wells…" /> : <>
                <TableContainer><Table size="small" aria-label="Wells">
                    <TableHead><TableRow>{columns.map(c => <TableCell key={c.key} sortDirection={params.sort === c.key ? params.desc ? 'desc' : 'asc' : false} sx={c.key === 'fieldName' ? { display: { xs: 'none', sm: 'table-cell' } } : {}}>
                        <TableSortLabel active={params.sort === c.key} direction={params.sort === c.key && params.desc ? 'desc' : 'asc'} onClick={() => setParams(p => ({ ...p, page: 0, sort: c.key, desc: p.sort === c.key ? !p.desc : false }))}>{c.label}</TableSortLabel>
                    </TableCell>)}<TableCell align="right">Actions</TableCell></TableRow></TableHead>
                    <TableBody>{rows.map(row => <TableRow hover key={row.wellId}>
                        <TableCell sx={{ overflowWrap: 'anywhere' }}><Button onClick={() => openWell(row, 'view')} sx={{ textAlign: 'left', minWidth: 0, p: 0 }}>{row.wellName}</Button></TableCell>
                        <TableCell sx={{ overflowWrap: 'anywhere' }}>{row.uwi}</TableCell>
                        <TableCell sx={{ display: { xs: 'none', sm: 'table-cell' } }}>{row.fieldName || '—'}</TableCell>
                        <TableCell><Chip size="small" label={row.isActive ? 'Active' : 'Inactive'} color={row.isActive ? 'success' : 'default'} /></TableCell>
                        <TableCell align="right" sx={{ whiteSpace: 'nowrap' }}><Box sx={{ display: { xs: 'none', sm: 'block' } }}><RowActions name={row.wellName}
                            onView={() => setAction({ mode: 'view', id: row.wellId, name: row.wellName })}
                            onEdit={() => setAction({ mode: 'edit', id: row.wellId, name: row.wellName })}
                            onDelete={() => openWell(row, 'delete')} /></Box>
                        <IconButton aria-label={'Actions for ' + row.wellName} aria-haspopup="menu" onClick={e => setMenu({ anchor: e.currentTarget, row })} sx={{ display: { sm: 'none' } }}><MoreHorizIcon /></IconButton></TableCell>
                    </TableRow>)}{!rows.length && !error && !isFetching && <TableRow><TableCell colSpan={5} align="center" sx={{ py: 5 }}>{data?.counts.all ? <Stack sx={{ alignItems: 'center' }} spacing={1}>No wells match your search or status filter.
                            <Button onClick={() => { setSearch(''); setParams(p => ({ ...p, page: 0, search: '', status: 'All' })) }}>Clear filters</Button>
                        </Stack> : <Stack sx={{ alignItems: 'center' }} spacing={1}>No wells yet.<Button onClick={addWell}>Add your first well</Button></Stack>}</TableCell></TableRow>}</TableBody>
                </Table></TableContainer>
                <TablePagination component="div" count={data?.total ?? 0} page={data?.page ?? 0} rowsPerPage={params.size} rowsPerPageOptions={[10, 25, 50, 100]}
                    onPageChange={(_, page) => setParams(p => ({ ...p, page }))} onRowsPerPageChange={e => setParams(p => ({ ...p, size: Number(e.target.value), page: 0 }))} />
            </>}
        </Paper>
        <Menu open={!!menu} anchorEl={menu?.anchor} onClose={() => setMenu(undefined)}>
            {(['view', 'edit', 'delete'] as const).map(mode => <MenuItem key={mode} onClick={() => { if (menu) openWell(menu.row, mode) }}>{mode[0].toUpperCase() + mode.slice(1)}</MenuItem>)}
        </Menu>
        {action && <RecordEditor key={(action.table ?? 'well-master') + ':' + action.mode + ':' + action.id} table={action.table ?? 'well-master'} action={action} onClose={() => { setAction(parentWell); setParentWell(undefined) }} onChanged={() => setSaved(true)} onRelated={(table, id, name) => { setParentWell(action); setAction({ table, id, name, mode: 'view' }) }} />}
    </Stack>
}
