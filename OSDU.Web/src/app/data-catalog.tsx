'use client'
import dynamic from 'next/dynamic'
import { useGetCrsRecordsQuery } from '../lib/store'
import { useCallback, useEffect, useMemo, useRef, useState } from 'react'
import { Alert, Box, Button, Checkbox, Drawer, FormControlLabel, MenuItem, Paper, Stack, Tab, Tabs, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow, TextField, Typography } from '@mui/material'
import { MapPin } from 'lucide-react'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'

const CatalogMap = dynamic(() => import('./catalog-map'), {
    ssr: false,
    loading: () => <Box sx={{ height: 420, p: 2 }}>Loading map…</Box>,
})
const filterKeys = ['operator', 'field', 'status'] as const

const datasets = [
    { label: 'Wells', route: 'wells', id: 'wellId', name: 'wellName' },
    { label: 'Wellbores', route: 'well-records/wellbores', id: 'wellboreId', name: 'wellboreName' },
    { label: 'Fields', route: 'fields', id: 'fieldId', name: 'fieldName' },
    { label: 'Facilities', route: 'facilities', id: 'facilityId', name: 'facilityName' },
]
type Row = Record<string, unknown>
type Entry = { id: string; dataset: string; name: string; identifier: string; field: string; operator: string; status: string; row: Row }

function location(entry: Entry, systems: Map<number, string>) {
    const { xCoordinate: x, yCoordinate: y, crsId, crsName } = entry.row
    const crs = (typeof crsId === 'number' ? systems.get(crsId) : undefined) ?? crsName
    if (!/^(?:EPSG[: ]*)?4326$|^WGS[ -]?84$/i.test(String(crs ?? '').trim())) return
    if (typeof x !== 'number' || typeof y !== 'number') return
    // Well surface coordinates are entered as latitude (X), longitude (Y).
    const [longitude, latitude] = entry.dataset === 'Wells' ? [y, x] : [x, y]
    if (!Number.isFinite(longitude) || !Number.isFinite(latitude) ||
        Math.abs(longitude) > 180 || Math.abs(latitude) > 90) return
    return { x: longitude, y: latitude }
}

export default function DataCatalog() {
    const { data: coordinateSystems } = useGetCrsRecordsQuery()
    const systems = useMemo(() => new Map((coordinateSystems ?? []).map(row =>
        [Number(row.crsId), String(row.crsName ?? '')])), [coordinateSystems])
    const [entries, setEntries] = useState<Entry[]>()
    const [failed, setFailed] = useState<string[]>([])
    const [attempt, setAttempt] = useState(0)
    const [tab, setTab] = useState('All datasets')
    const [query, setQuery] = useState('')
    const [filters, setFilters] = useState({ operator: '', field: '', status: '' })
    const [page, setPage] = useState(0)
    const [size, setSize] = useState(25)
    const [selected, setSelected] = useState('')
    const [hasLocation, setHasLocation] = useState(false)
    const [filtersOpen, setFiltersOpen] = useState(true)
    const [mapExpanded, setMapExpanded] = useState(false)
    const [reveal, setReveal] = useState('')
    const selectedRow = useRef<HTMLTableRowElement>(null)
    const [detail, setDetail] = useState<Entry>()

    useEffect(() => {
        const controller = new AbortController()
        Promise.allSettled(datasets.map(async source => {
            const response = await fetch('/api/' + source.route, { signal: controller.signal, cache: 'no-store' })
            if (!response.ok) throw new Error(source.label)
            const payload = await response.json()
            const rows: Row[] = Array.isArray(payload) ? payload : payload.rows
            return rows.map((row): Entry => ({
                id: source.id + ':' + row[source.id], dataset: source.label,
                name: String(row[source.name] || row.wellboreUwi || row[source.id]),
                identifier: String(row.uwi || row.wellboreUwi || row[source.id]),
                field: String(row.fieldName ?? ''), operator: String(row.operator ?? row.wellOwner ?? ''),
                status: row.isActive === true ? 'Active' : 'Inactive', row,
            }))
        })).then(results => {
            if (controller.signal.aborted) return
            setEntries(results.flatMap(result => result.status === 'fulfilled' ? result.value : []))
            setFailed(datasets.filter((_, i) => results[i].status === 'rejected').map(source => source.label))
        })
        return () => controller.abort()
    }, [attempt])

    const source = useMemo(() => (entries ?? []).filter(entry => tab === 'All datasets' || entry.dataset === tab), [entries, tab])
    const matching = useMemo(() => source.filter(entry =>
        [entry.name, entry.identifier, entry.operator, entry.field, entry.dataset].join(' ').toLowerCase().includes(query.trim().toLowerCase()) &&
        filterKeys.every(key => !filters[key] || entry[key] === filters[key])), [source, query, filters])
    const points = useMemo(() => matching.flatMap(entry => {
        const point = location(entry, systems)
        return point ? [{ ...point, id: entry.id, name: entry.name, dataset: entry.dataset }] : []
    }), [matching, systems])
    const rows = useMemo(() => hasLocation ? matching.filter(entry => location(entry, systems)) : matching,
        [hasLocation, matching, systems])
    const showMarkerRow = useCallback((id: string) => {
        const index = rows.findIndex(row => row.id === id)
        if (index === -1) return
        setSelected(id)
        setPage(Math.floor(index / size))
        setReveal(id)
    }, [rows, size])
    useEffect(() => {
        if (!reveal) return
        selectedRow.current?.scrollIntoView({ block: 'nearest', inline: 'nearest' })
        setReveal('')
    }, [reveal, page])
    const columns: { label: string; value: (entry: Entry) => string }[] = [
        { label: 'Name', value: entry => entry.name },
        ...(tab === 'All datasets' ? [{ label: 'Dataset', value: (entry: Entry) => entry.dataset }] : []),
        { label: tab === 'Wells' || tab === 'Wellbores' ? 'UWI' : 'Identifier', value: entry => entry.identifier },
        ...(tab === 'Wells' ? [
            { label: 'Operator', value: (entry: Entry) => entry.operator },
            { label: 'Field', value: (entry: Entry) => entry.field },
        ] : tab === 'Wellbores' ? [
            { label: 'Parent well', value: (entry: Entry) => String(entry.row.wellUwi ?? '') },
            { label: 'Drilled depth', value: (entry: Entry) => String(entry.row.drillTd ?? '') },
        ] : []),
        { label: 'Status', value: entry => entry.status },
    ]
    const related = detail ? (entries ?? []).filter(entry => {
        if (entry.id === detail.id) return false
        const links = (from: Entry, to: Entry) =>
            (from.dataset === 'Wellbores' && to.dataset === 'Wells' && from.row.wellId != null && from.row.wellId === to.row.wellId) ||
            (from.dataset !== 'Fields' && to.dataset === 'Fields' && from.row.fieldId != null && from.row.fieldId === to.row.fieldId)
        return links(entry, detail) || links(detail, entry)
    }) : []
    const unplottedWells = matching.filter(entry => entry.dataset === 'Wells' &&
        typeof entry.row.xCoordinate === 'number' && typeof entry.row.yCoordinate === 'number' &&
        !location(entry, systems)).length
    function resetFilters() { setFilters({ operator: '', field: '', status: '' }); setHasLocation(false); setPage(0) }

    return <Stack spacing={2} sx={{ width: '100%', minWidth: 0, containerType: 'inline-size' }}>
        <Paper variant="outlined" sx={{ px: 2, pt: 2 }}>
            <TextField fullWidth size="small" label="Search catalog" placeholder="Name, identifier, field or operator" value={query}
                onChange={event => { setQuery(event.target.value); setPage(0) }} />
            <Tabs value={tab} variant="scrollable" scrollButtons="auto" aria-label="Datasets"
                sx={{ mt: 1, pb: 1, '& .MuiTabs-list': { gap: 1 },
                    '& .MuiTabs-indicator': { display: 'none' },
                    '& .MuiTab-root': { minHeight: 40, px: 2, border: 1, borderColor: 'divider', borderRadius: 1 },
                    '& .MuiTab-root.Mui-selected': { bgcolor: 'primary.main', color: 'primary.contrastText' } }} onChange={(_, value: string) => { setTab(value); resetFilters() }}>
                <Tab value="All datasets" label="All datasets" />
                {datasets.map(source => <Tab key={source.label} value={source.label} label={source.label} />)}
            </Tabs>
        </Paper>
        {failed.length > 0 && <Alert severity="warning" action={<Button onClick={() => {
            setEntries(undefined); setFailed([]); setPage(0); setAttempt(n => n + 1)
        }}>Retry</Button>}>Could not load {failed.join(', ')}.</Alert>}
        <Stack direction="row" spacing={1} sx={{ flexWrap: 'wrap' }}>
            <Button variant="outlined" size="small" aria-expanded={filtersOpen}
                onClick={() => setFiltersOpen(open => !open)}>{filtersOpen ? 'Hide filters' : 'Show filters'}</Button>
            <FormControlLabel label="Has location" control={<Checkbox checked={hasLocation}
                onChange={event => { setHasLocation(event.target.checked); setPage(0) }} />} />
        </Stack>
        <Box sx={{ display: 'grid', gap: 1.5, gridTemplateColumns: 'minmax(0, 1fr)',
            '@container (min-width: 740px)': { gridTemplateColumns: mapExpanded ? 'minmax(0, 1fr)' : filtersOpen ? '140px minmax(0, 1.15fr) minmax(0, 1fr)' : 'minmax(0, 1.15fr) minmax(0, 1fr)' },
            '@container (min-width: 1150px)': { gridTemplateColumns: mapExpanded ? 'minmax(0, 1fr)' : filtersOpen ? '180px minmax(0, 1.15fr) minmax(0, 1fr)' : 'minmax(0, 1.15fr) minmax(0, 1fr)' } }}>
            <Paper variant="outlined" component="aside" sx={{ p: 1.5, display: filtersOpen && !mapExpanded ? undefined : 'none' }}>
                <Stack spacing={2}>
                    <Typography variant="subtitle2">Filters</Typography>
                    {filterKeys.map(key => <TextField key={key} select size="small" label={key[0].toUpperCase() + key.slice(1)}
                        value={filters[key]} onChange={event => { setFilters(values => ({ ...values, [key]: event.target.value })); setPage(0) }}>
                        <MenuItem value="">All</MenuItem>
                        {[...new Set(source.map(entry => entry[key]).filter(Boolean))].sort().map(value => <MenuItem key={value} value={value}>{value}</MenuItem>)}
                    </TextField>)}
                    <Button size="small" onClick={() => { resetFilters(); setQuery('') }}>Clear all</Button>
                </Stack>
            </Paper>
            <Paper variant="outlined" sx={{ minWidth: 0, display: mapExpanded ? 'none' : 'flex', flexDirection: 'column' }}>
                <Typography variant="subtitle2" sx={{ p: 1.5 }}>Total records ({rows.length})</Typography>
                <TableContainer sx={{ flex: 1, maxHeight: 'clamp(360px, calc(100dvh - 300px), 850px)' }}>
                    <Table stickyHeader size="small" aria-label="Catalog results" sx={{ minWidth: 390 }}>
                        <TableHead><TableRow>{columns.map(column => <TableCell key={column.label}>{column.label}</TableCell>)}<TableCell>Details</TableCell></TableRow></TableHead>
                        <TableBody>
                            {!rows.length && <TableRow><TableCell colSpan={columns.length + 1}>
                                {entries ? 'No matching records.' : <Stack direction="row" spacing={1}><OrbitRing className="size-5" />Loading datasets…</Stack>}
                            </TableCell></TableRow>}
                            {rows.slice(page * size, (page + 1) * size).map(entry => <TableRow key={entry.id} hover
                                ref={selected === entry.id ? selectedRow : undefined} selected={selected === entry.id}
                                onClick={() => setSelected(entry.id)} sx={{ cursor: 'pointer' }}>
                                {columns.map((column, index) => <TableCell key={column.label}>
                                    {index === 0 && location(entry, systems) ? <Button size="small"
                                        onClick={() => setSelected(entry.id)}>{entry.name}</Button> : column.value(entry) || '—'}
                                </TableCell>)}
                                <TableCell><Button size="small" aria-label={'View ' + entry.name} onClick={event => { event.stopPropagation(); setDetail(entry) }}>View</Button></TableCell>
                            </TableRow>)}
                        </TableBody>
                    </Table>
                </TableContainer>
                <TablePagination component="div" sx={{ overflowX: 'auto', '& .MuiTablePagination-toolbar': { px: 1, minWidth: 'max-content' } }} count={rows.length} page={page} rowsPerPage={size} rowsPerPageOptions={[10, 25, 50]}
                    onPageChange={(_, next) => setPage(next)} onRowsPerPageChange={event => { setSize(Number(event.target.value)); setPage(0) }} />
            </Paper>
            <Paper variant="outlined" sx={{ minWidth: 0, overflow: 'hidden' }}>
                <Stack direction="row" spacing={1} sx={{ alignItems: 'center', p: 1.5 }}><MapPin size={17} /><Typography variant="subtitle2">Map</Typography>
                    <Button size="small" sx={{ ml: 'auto' }} aria-expanded={mapExpanded}
                        onClick={() => setMapExpanded(expanded => !expanded)}>{mapExpanded ? 'Restore split view' : 'Expand map'}</Button>
                </Stack>
                <CatalogMap points={points} selected={selected} onSelect={showMarkerRow} />
                <Typography variant="caption" color="text.secondary" role="status" sx={{ display: 'block', p: 1.5 }}>
                    {!entries ? 'Loading catalog locations…' : points.length + ' of ' + matching.length + ' matching records on map'}
                    {unplottedWells > 0 && ' ' + unplottedWells + ' well record(s) have coordinates but need a supported CRS and valid longitude and latitude.'}
                </Typography>
            </Paper>
        </Box>
        <Drawer anchor="right" open={!!detail} onClose={() => setDetail(undefined)}
            slotProps={{ paper: { sx: { width: 'min(100vw, 500px)', p: 3 } } }}>
            <Stack direction="row" sx={{ justifyContent: 'space-between', alignItems: 'center' }}>
                <Typography variant="h6" component="h2">{detail?.name}</Typography>
                <Button onClick={() => setDetail(undefined)}>Close</Button>
            </Stack>
            <Box>
                <Typography variant="overline">{detail?.dataset}</Typography>
                <Box component="dl" sx={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 1, overflowWrap: 'anywhere' }}>
                    {Object.entries(detail?.row ?? {}).filter(([, value]) => value != null && value !== '').map(([key, value]) => <Box key={key} sx={{ display: 'contents' }}>
                        <Typography component="dt" variant="body2" color="text.secondary">{key.replace(/([a-z0-9])([A-Z])/g, '$1 $2')}</Typography>
                        <Typography component="dd" variant="body2" sx={{ m: 0 }}>{String(value)}</Typography>
                    </Box>)}
                </Box>
                <Typography variant="subtitle2" component="h3">Related records</Typography>
                {!related.length && <Typography variant="body2" color="text.secondary">No related catalog records.</Typography>}
                {related.map(entry => <Box key={entry.id}><Button onClick={() => setDetail(entry)}>
                    {entry.name} · {entry.dataset}
                </Button></Box>)}
            </Box>
        </Drawer>
    </Stack>
}
