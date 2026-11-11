'use client'
import dynamic from 'next/dynamic'
import { assetsApi } from '../lib/store'
import { catalogKey, filterKeys, type CatalogFilters, type CatalogIdentity, type CatalogRow } from '../lib/catalog-types'
import { useCallback, useEffect, useMemo, useRef, useState } from 'react'
import { Accordion, AccordionDetails, AccordionSummary, Alert, Autocomplete, Box, Button, Checkbox, Chip, Drawer, FormControlLabel, LinearProgress, Paper, Stack, Tab, Tabs, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow, TableSortLabel, TextField, Typography } from '@mui/material'
import { ChevronDown, Filter, Globe, MapPin, Factory, Layers, Drill } from 'lucide-react'
import { OrbitRing } from '@/components/loading-ui/orbit-ring'

const CatalogMap = dynamic(() => import('./catalog-map'), {
    ssr: false,
    loading: () => <Box sx={{ height: 420, p: 2 }}>Loading map…</Box>,
})
const filterSections = ['search', ...filterKeys] as const
type FilterSection = (typeof filterSections)[number]

const datasets = [
    { label: 'Wells', icon: Drill },
    { label: 'Wellbores', icon: Layers },
    { label: 'Fields', icon: Globe },
    { label: 'Facilities', icon: Factory },
]
const emptyFilters = { operator: '', field: '', status: '' }
type Detail = Record<string, unknown>

function ResizeHandle({ label, value, min, max, onChange, step = 10, scale = 1 }: {
    label: string; value: number; min: number; max: number; onChange: (value: number) => void; step?: number; scale?: number
}) {
    const drag = useRef<{ x: number; start: number }>(null)
    const update = (next: number) => onChange(Math.round(Math.max(min, Math.min(max, next))))
    return <Box role="separator" aria-label={label} aria-orientation="vertical" aria-valuenow={value}
        aria-valuemin={min} aria-valuemax={max} tabIndex={0}
        onClick={event => event.stopPropagation()}
        onKeyDown={event => {
            if (event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') return
            event.preventDefault()
            update(value + (event.key === 'ArrowRight' ? step : -step))
        }}
        onPointerDown={event => {
            if (event.button !== 0) return
            drag.current = { x: event.clientX, start: value }
            event.currentTarget.setPointerCapture(event.pointerId)
        }}
        onLostPointerCapture={() => { drag.current = null }}
        onPointerMove={event => {
            if (drag.current) update(drag.current.start + (event.clientX - drag.current.x) * scale)
        }}
        sx={{ position: 'absolute', zIndex: 3, width: 9, right: -5, top: 0, bottom: 0,
            cursor: 'col-resize', touchAction: 'none', '&:hover, &:focus-visible': { bgcolor: 'primary.light' } }} />
}

export default function DataCatalog() {
    const [tab, setTab] = useState('All datasets')
    const [query, setQuery] = useState('')
    const [search, setSearch] = useState('')
    const [filters, setFilters] = useState<CatalogFilters>(emptyFilters)
    const [page, setPage] = useState(0)
    const [size, setSize] = useState(25)
    const [sort, setSort] = useState({ key: 'Name', desc: false })
    const [selected, setSelected] = useState('')
    const [hasLocation, setHasLocation] = useState(false)
    const [expandedFilters, setExpandedFilters] = useState<FilterSection[]>([])
    const [filtersOpen, setFiltersOpen] = useState(true)
    const [mapExpanded, setMapExpanded] = useState(false)
    const [mapOpen, setMapOpen] = useState(true)
    const [mapVisible, setMapVisible] = useState(false)
    const [filterWidth, setFilterWidth] = useState(175)
    const [resultsShare, setResultsShare] = useState(54)
    const [columnWidths, setColumnWidths] = useState<Record<string, number>>({})
    const [detail, setDetail] = useState<CatalogIdentity>()
    const [detailData, setDetailData] = useState<{ key: string; data?: Detail; related: CatalogIdentity[]; error?: string }>()
    const grid = useRef<HTMLDivElement>(null)
    const mapPanel = useRef<HTMLDivElement>(null)
    const selectedRow = useRef<HTMLTableRowElement>(null)
    useEffect(() => {
        const timeout = setTimeout(() => { setSearch(query.trim()); setPage(0) }, 250)
        return () => clearTimeout(timeout)
    }, [query])
    
    const params = useMemo(() => ({ ...filters, dataset: tab === 'All datasets' ? '' : tab, search }),
        [filters, tab, search])
    const [loadPage, result] = assetsApi.useLazyGetCatalogPageQuery()
    const activeRequest = useRef<ReturnType<typeof loadPage>>(null)
    useEffect(() => {
        activeRequest.current = loadPage({ ...params, hasLocation, page, size, sort: sort.key, desc: sort.desc }, true)
        return () => activeRequest.current?.abort()
    }, [params, hasLocation, page, size, sort, loadPage])
    const facets = assetsApi.useGetCatalogFacetsQuery({ ...params, hasLocation }, { skip: !filtersOpen || mapExpanded })
    useEffect(() => {
        if (!mapOpen || mapVisible || !mapPanel.current) return
        const observer = new IntersectionObserver(([entry]) => {
            if (entry.isIntersecting) setMapVisible(true)
        }, { rootMargin: '200px' })
        observer.observe(mapPanel.current)
        return () => observer.disconnect()
    }, [mapOpen, mapVisible])
    const map = assetsApi.useGetCatalogMapQuery(params, { skip: !mapOpen || !mapVisible })
    const rows = result.data?.rows ?? []
    const points = map.data?.points
    const showMarkerRow = useCallback((point: CatalogIdentity) => {
        const key = catalogKey(point)
        setSelected(key)
        if (result.data?.rows.some(row => catalogKey(row) === key) && !mapExpanded) {
            requestAnimationFrame(() => selectedRow.current?.scrollIntoView({ block: 'nearest' }))
        } else setDetail(point)
    }, [result.data, mapExpanded])
    const detailKey = detail ? catalogKey(detail) : ''
    useEffect(() => {
        if (!detail) return
        const controller = new AbortController()
        async function read<T>(url: string): Promise<T> {
            const response = await fetch(url, { signal: controller.signal })
            if (!response.ok) throw new Error()
            return response.json()
        }
        Promise.all([
            read<Detail>('/api/catalog/detail/' + detail.dataset + '/' + detail.id),
            read<CatalogIdentity[]>('/api/catalog/related/' + detail.dataset + '/' + detail.id),
        ]).then(([data, related]) => {
            if (!controller.signal.aborted) setDetailData({ key: detailKey, data, related })
        }).catch(() => {
            if (!controller.signal.aborted) setDetailData({ key: detailKey, related: [], error: 'Unable to load record details.' })
        })
        return () => controller.abort()
    }, [detail, detailKey])
    const currentDetail = detailData?.key === detailKey ? detailData : undefined
    const setFilter = (key: keyof CatalogFilters, value: string) => {
        setFilters(current => ({ ...current, [key]: value }))
        setPage(0)
    }
    const columns: { label: string; value: (entry: CatalogRow) => string }[] = [
        { label: 'Name', value: entry => entry.name },
        ...(tab === 'All datasets' ? [{ label: 'Dataset', value: (entry: CatalogRow) => entry.dataset }] : []),
        { label: tab === 'Wells' || tab === 'Wellbores' ? 'UWI' : 'Identifier', value: entry => entry.identifier },
        ...(tab === 'Wells' ? [
            { label: 'Operator', value: (entry: CatalogRow) => entry.operator },
            { label: 'Field', value: (entry: CatalogRow) => entry.field },
        ] : tab === 'Wellbores' ? [
            { label: 'Parent well', value: (entry: CatalogRow) => String(entry.wellUwi ?? '') },
            { label: 'Drilled depth', value: (entry: CatalogRow) => String(entry.drillTd ?? '') },
        ] : []),
        { label: 'Status', value: entry => entry.isActive ? 'Active' : 'Inactive' },
    ]
    function resetFilters() { setFilters(emptyFilters); setHasLocation(false); setPage(0) }
    const showSplit = mapOpen && !mapExpanded
    const showFilters = filtersOpen && !mapExpanded
    const mainColumns = mapExpanded ? 'minmax(0, 1fr)' :
        `minmax(0, ${showSplit ? resultsShare : 100}fr) minmax(0, ${showSplit ? 100 - resultsShare : 0}fr)`
    const gridColumns = `${showFilters ? filterWidth + 12 : 0}px ${mainColumns}`
    const filterMotion = '240ms cubic-bezier(.2, 0, 0, 1)'
    return <Stack spacing={2} sx={{ width: '100%', minWidth: 0, containerType: 'inline-size' }}>
        <Alert severity="info" variant="outlined" role="note" sx={{ '& .MuiAlert-message': { py: .5 } }}>
            <Typography variant="subtitle2" component="h2" sx={{ mb: .5 }}>How to use the Data Catalog</Typography>
            <Typography variant="body2">
                Browse wells, wellbores, fields, and facilities in one place. Choose a dataset tab, then search by name,
                identifier, field, or operator. Use <strong>Filters</strong> to narrow the results and select <strong>View</strong> to
                open a record and follow links to related records.
            </Typography>
            <Typography variant="body2" sx={{ mt: .5 }}>
                Use <strong>Show map</strong> to plot matching records with valid coordinates. Select a marker to find
                its record, or check <strong>Has location</strong> to limit results to records that can be plotted.
            </Typography>
        </Alert>
        <Paper variant="outlined" sx={{ px: 2, pt: 2 }}>
            <TextField fullWidth size="small" label="Search catalog" placeholder="Name, identifier, field or operator" value={query}
                onChange={event => { setQuery(event.target.value); setPage(0) }} />
            <Tabs value={tab} variant="scrollable" scrollButtons="auto" aria-label="Datasets"
                sx={{ mt: 1, pb: 1, '& .MuiTabs-list': { gap: 1 },
                    '& .MuiTabs-indicator': { display: 'none' },
                    '& .MuiTab-root': { minHeight: 40, px: 2, border: 1, borderColor: 'divider', borderRadius: 1 },
                    '& .MuiTab-root.Mui-selected': { bgcolor: 'primary.main', color: 'primary.contrastText' } }} onChange={(_, value: string) => { setTab(value); setSort({ key: 'Name', desc: false }); setSelected(''); resetFilters() }}>
                <Tab value="All datasets" label="All datasets" />
                {datasets.map(source => <Tab key={source.label} value={source.label} label={source.label} icon={<source.icon size={15} />} iconPosition="start" />)}
            </Tabs>
        </Paper>
        {result.isError && <Alert severity="error" action={<Button onClick={() => {
            if (result.originalArgs) activeRequest.current = loadPage(result.originalArgs)
        }}>Retry</Button>}>Could not load catalog results.</Alert>}
        <Stack direction="row" spacing={1} sx={{ flexWrap: 'wrap' }}>
            <Button variant="outlined" size="small" aria-expanded={showFilters} aria-controls="catalog-filters" disabled={mapExpanded}
                onClick={() => setFiltersOpen(open => !open)}>{filtersOpen ? 'Hide filters' : 'Show filters'}</Button>
            <FormControlLabel label="Has location" control={<Checkbox checked={hasLocation}
                onChange={event => { setHasLocation(event.target.checked); setPage(0) }} />} />
            <Button variant="outlined" size="small" aria-expanded={mapOpen} aria-controls="catalog-map"
                onClick={() => { setMapOpen(open => !open); setMapExpanded(false) }}>{mapOpen ? 'Hide map' : 'Show map'}</Button>
            {filterKeys.filter(key => filters[key]).map(key => <Chip key={key} size="small"
                label={key[0].toUpperCase() + key.slice(1) + ': ' + filters[key]} onDelete={() => setFilter(key, '')} />)}
            {hasLocation && <Chip size="small" label="Has location" onDelete={() => { setHasLocation(false); setPage(0) }} />}
        </Stack>
        <Box ref={grid} sx={{ display: 'grid', gridTemplateColumns: 'minmax(0, 1fr)',
            '& .catalog-panel-resizer': { display: 'none' },
            '@container (min-width: 740px)': {
                gridTemplateColumns: gridColumns, transition: `grid-template-columns ${filterMotion}`,
                '& .catalog-panel-resizer': { display: 'contents' },
                '&:has([role="separator"]:active)': { transition: 'none' },
            },
            '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }}>
            <Box id="catalog-filters" inert={!showFilters} aria-hidden={!showFilters}
                sx={{ display: 'grid', minWidth: 0, gridTemplateRows: showFilters ? '1fr' : '0fr',
                    transition: `grid-template-rows ${filterMotion}`,
                    '@container (min-width: 740px)': { gridTemplateRows: '1fr', overflow: 'hidden' },
                    '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }}>
                <Box sx={{ display: 'flex', minHeight: 0, minWidth: 0, overflow: 'hidden' }}>
            <Paper variant="outlined" component="aside" aria-label="Catalog filters"
                sx={{ width: '100%', mb: 1.5, position: 'relative', flexShrink: 0,
                    opacity: showFilters ? 1 : 0, transform: showFilters ? 'none' : 'translateY(-12px)',
                    transition: `opacity ${filterMotion}, transform ${filterMotion}`,
                    '@container (min-width: 740px)': { width: filterWidth, mb: 0,
                        transform: showFilters ? 'none' : 'translateX(-24px)' },
                    '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }}>
                <Box className="catalog-panel-resizer"><ResizeHandle label="Resize filters" value={filterWidth}
                    min={125} max={300} onChange={setFilterWidth} /></Box>
                {facets.isError && <Alert severity="warning" action={<Button onClick={() => facets.refetch()}>Retry</Button>}>Filter options unavailable.</Alert>}
                <Stack sx={{ p: 1, borderBottom: 1, borderColor: 'divider' }}>
                    <Typography variant="subtitle2">Filters</Typography>
                    <Stack direction="row" sx={{ flexWrap: 'wrap' }}>
                        <Button size="small" sx={{ px: .5, minWidth: 0 }}
                            onClick={() => setExpandedFilters(expandedFilters.length === filterSections.length ? [] : [...filterSections])}>
                            {expandedFilters.length === filterSections.length ? 'Collapse all' : 'Expand all'}
                        </Button>
                        <Button size="small" sx={{ px: .5, minWidth: 0 }}
                            disabled={!query && !hasLocation && !filterKeys.some(key => filters[key])}
                            onClick={() => { resetFilters(); setQuery('') }}>Clear all</Button>
                    </Stack>
                </Stack>
                {filterSections.map(key => {
                    const label = key === 'search' ? 'Find in dataset' : key[0].toUpperCase() + key.slice(1)
                    const value = key === 'search' ? query : filters[key]
                    return <Accordion key={key} disableGutters elevation={0} square expanded={expandedFilters.includes(key)}
                        onChange={(_, open) => setExpandedFilters(sections => open ? [...sections, key] : sections.filter(section => section !== key))}
                        sx={{ borderBottom: 1, borderColor: 'divider', '&::before': { display: 'none' } }}>
                        <AccordionSummary id={'catalog-filter-' + key} aria-controls={'catalog-filter-panel-' + key}
                            expandIcon={<ChevronDown size={15} />} sx={{ px: 1, minHeight: 40 }}>
                            <Stack direction="row" spacing={.75} sx={{ alignItems: 'center' }}>
                                <Filter size={14} />
                                <Typography variant="body2" color={value ? 'primary.main' : 'text.primary'}>{label}</Typography>
                            </Stack>
                        </AccordionSummary>
                        <AccordionDetails sx={{ px: 1, pt: 0 }}>
                            {key === 'search' ? <TextField fullWidth size="small" label="Find in dataset" value={query}
                                onChange={event => { setQuery(event.target.value); setPage(0) }} />
                                : <Autocomplete size="small" value={filters[key] || null}
                                    options={[...new Set([...(facets.data?.[key] ?? []).map(option => option.value), ...(filters[key] ? [filters[key]] : [])])]}
                                    loading={facets.isFetching} onChange={(_, option) => setFilter(key, option ?? '')}
                                    renderOption={(props, option) => {
                                        const { key: optionKey, ...li } = props
                                        const count = facets.data?.[key].find(item => item.value === option)?.count ?? 0
                                        return <li key={optionKey} {...li}>{option} ({count})</li>
                                    }}
                                    renderInput={props => <TextField {...props} label={label} />} />}
                        </AccordionDetails>
                    </Accordion>
                })}
            </Paper>
                </Box>
            </Box>
            <Paper variant="outlined" aria-busy={result.isFetching} sx={{ minWidth: 0, position: 'relative',
                display: mapExpanded ? 'none' : 'flex', flexDirection: 'column',
                '@container (min-width: 740px)': { mr: showSplit ? 1.5 : 0, transition: `margin-right ${filterMotion}` },
                '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }}>
                {showSplit && <Box className="catalog-panel-resizer"><ResizeHandle label="Resize results and map"
                    value={resultsShare} min={32} max={70} step={2}
                    scale={100 / Math.max(1, (grid.current?.clientWidth ?? 740) - (filtersOpen ? filterWidth + 24 : 12))}
                    onChange={setResultsShare} /></Box>}
                <Typography variant="subtitle2" sx={{ p: 1.5 }}>Total records ({result.data?.total ?? '…'})</Typography>
                <Box sx={{ height: 3 }}>{(result.isFetching || query.trim() !== search) && <LinearProgress aria-label="Updating results" />}</Box>
                <TableContainer sx={{ flex: 1, maxHeight: 'clamp(360px, calc(100dvh - 300px), 850px)' }}>
                    <Table stickyHeader size="small" aria-label="Catalog results" sx={{ width: '100%', tableLayout: 'fixed',
                        minWidth: Math.max(390, 80 + columns.reduce((sum, column) => sum + (columnWidths[column.label] ?? 120), 0)) }}>
                        <colgroup>{columns.map(column => <col key={column.label} style={{ width: columnWidths[column.label] ?? 120 }} />)}<col style={{ width: 80 }} /></colgroup>
                        <TableHead><TableRow>{columns.map(column => <TableCell key={column.label}
                            sortDirection={sort.key === column.label ? (sort.desc ? 'desc' : 'asc') : false}>
                            <TableSortLabel active={sort.key === column.label} direction={sort.key === column.label && sort.desc ? 'desc' : 'asc'}
                                onClick={() => { setSort({ key: column.label, desc: sort.key === column.label && !sort.desc }); setPage(0) }}>
                                {column.label}
                            </TableSortLabel>
                            <ResizeHandle label={'Resize ' + column.label + ' column'} value={columnWidths[column.label] ?? 120}
                                min={90} max={420} onChange={width => setColumnWidths(current => ({ ...current, [column.label]: width }))} />
                        </TableCell>)}<TableCell>Details</TableCell></TableRow></TableHead>
                        <TableBody>
                            {!rows.length && <TableRow><TableCell colSpan={columns.length + 1}>
                                {result.isError ? 'Results unavailable.' : result.data ? 'No matching records.' :
                                    <Stack direction="row" spacing={1}><OrbitRing className="size-5" />Loading datasets…</Stack>}
                            </TableCell></TableRow>}
                            {rows.map(entry => <TableRow key={catalogKey(entry)} hover
                                ref={selected === catalogKey(entry) ? selectedRow : undefined} selected={selected === catalogKey(entry)}
                                onClick={() => setSelected(catalogKey(entry))} sx={{ cursor: 'pointer' }}>
                                {columns.map((column, index) => <TableCell key={column.label} sx={{ overflowWrap: 'anywhere' }}>
                                    {index === 0 ? <Button size="small" onClick={() => setSelected(catalogKey(entry))}>
                                        {entry.name}
                                    </Button> : column.value(entry) || '—'}
                                </TableCell>)}
                                <TableCell><Button size="small" aria-label={'View ' + entry.name} onClick={event => { event.stopPropagation(); setDetail(entry) }}>View</Button></TableCell>
                            </TableRow>)}
                        </TableBody>
                    </Table>
                </TableContainer>
                <TablePagination component="div" sx={{ overflowX: 'auto', '& .MuiTablePagination-toolbar': { px: 1, minWidth: 'max-content' } }} count={result.data?.total ?? 0} page={result.data?.page ?? 0} rowsPerPage={result.data?.size ?? size} rowsPerPageOptions={[10, 25, 50]}
                    onPageChange={(_, next) => setPage(next)} onRowsPerPageChange={event => { setSize(Number(event.target.value)); setPage(0) }} />
            </Paper>
            <Box id="catalog-map" inert={!mapOpen} aria-hidden={!mapOpen}
                sx={{ display: 'grid', minWidth: 0, gridTemplateRows: mapOpen ? '1fr' : '0fr',
                    transition: `grid-template-rows ${filterMotion}`,
                    '@container (min-width: 740px)': { gridTemplateRows: '1fr', overflow: 'hidden',
                        contain: mapOpen ? 'none' : 'size' },
                    '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }}>
                <Box sx={{ minHeight: 0, minWidth: 0, overflow: 'hidden', display: 'flex' }}>
            <Paper ref={mapPanel} variant="outlined"
                sx={{ width: '100%', minWidth: 0, overflow: 'hidden', mt: mapExpanded ? 0 : 1.5,
                    opacity: mapOpen ? 1 : 0, transform: mapOpen ? 'none' : 'translateY(-12px)',
                    transition: `opacity ${filterMotion}, transform ${filterMotion}`,
                    '@container (min-width: 740px)': { mt: 0, transform: mapOpen ? 'none' : 'translateX(24px)' },
                    '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }}>
                <Stack direction="row" spacing={1} sx={{ alignItems: 'center', p: 1.5 }}><MapPin size={17} /><Typography variant="subtitle2">Map</Typography>
                    <Button size="small" sx={{ ml: 'auto' }} aria-expanded={mapExpanded}
                        onClick={() => setMapExpanded(expanded => !expanded)}>{mapExpanded ? 'Restore split view' : 'Expand map'}</Button>
                </Stack>
                {map.isError && <Alert severity="warning" action={<Button onClick={() => map.refetch()}>Retry</Button>}>Map locations unavailable.</Alert>}
                {mapVisible ? <CatalogMap points={points} selected={selected} onSelect={showMarkerRow} /> :
                    <Box sx={{ height: 380 }} />}
                <Typography variant="caption" color="text.secondary" role="status" sx={{ display: 'block', p: 1.5 }}>
                    {map.isFetching ? 'Updating map locations…' : map.data &&
                        `${map.data.mapped} of ${map.data.total} matching records have map locations.`}
                    {map.data && map.data.mapped > map.data.points.length &&
                        ` Showing the first ${map.data.points.length.toLocaleString()} markers. Narrow the filters to see more.`}
                </Typography>
            </Paper>
                </Box>
            </Box>
        </Box>
        <Drawer anchor="right" open={!!detail} onClose={() => setDetail(undefined)}
            slotProps={{ paper: { sx: { width: 'min(100vw, 500px)', p: 3 } } }}>
            <Stack direction="row" sx={{ justifyContent: 'space-between', alignItems: 'center' }}>
                <Typography variant="h6" component="h2">{detail?.name}</Typography>
                <Button onClick={() => setDetail(undefined)}>Close</Button>
            </Stack>
            <Box>
                <Typography variant="overline">{detail?.dataset}</Typography>
                {detail && !currentDetail && <LinearProgress aria-label="Loading record details" />}
                {currentDetail?.error && <Alert severity="error">{currentDetail.error}</Alert>}
                {currentDetail?.data && <Box component="dl" sx={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 1, overflowWrap: 'anywhere' }}>
                    {Object.entries(currentDetail.data).map(([key, value]) => {
                        if (value == null || value === '') return null
                        const label = key.replace(/([a-z0-9])([A-Z])|([A-Z])([A-Z][a-z])/g, '$1$3 $2$4')
                        return <Box key={key} sx={{ display: 'contents' }}>
                            <Typography component="dt" variant="body2" color="text.secondary" sx={{ textTransform: 'capitalize' }}>{label}</Typography>
                            <Typography component="dd" variant="body2" sx={{ m: 0 }}>
                                {typeof value === 'boolean' ? (value ? 'Yes' : 'No') : String(value)}
                            </Typography>
                        </Box>
                    })}
                </Box>}
                {currentDetail && !currentDetail.error && <>
                    <Typography variant="subtitle2" component="h3">Related records</Typography>
                    {!currentDetail.related.length && <Typography variant="body2" color="text.secondary">No related catalog records.</Typography>}
                    {currentDetail.related.map(entry => <Box key={catalogKey(entry)}><Button onClick={() => setDetail(entry)}>
                        {entry.name} · {entry.dataset}
                    </Button></Box>)}
                </>}
            </Box>
        </Drawer>
    </Stack>
}
