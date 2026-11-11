'use client'
import { useState } from 'react'
import { Box, Button, Collapse, Divider, IconButton, InputAdornment, ListItemButton, TextField, Tooltip, Typography } from '@mui/material'
import HomeOutlined from '@mui/icons-material/HomeOutlined'
import StorageOutlined from '@mui/icons-material/StorageOutlined'
import BusinessOutlined from '@mui/icons-material/BusinessOutlined'
import PublicOutlined from '@mui/icons-material/PublicOutlined'
import AccountTreeOutlined from '@mui/icons-material/AccountTreeOutlined'
import FactoryOutlined from '@mui/icons-material/FactoryOutlined'
import TerrainOutlined from '@mui/icons-material/TerrainOutlined'
import LayersOutlined from '@mui/icons-material/LayersOutlined'
import WaterOutlined from '@mui/icons-material/WaterOutlined'
import SettingsOutlined from '@mui/icons-material/SettingsOutlined'
import SearchOutlined from '@mui/icons-material/SearchOutlined'
import UnfoldLess from '@mui/icons-material/UnfoldLess'
import ChevronRight from '@mui/icons-material/ChevronRight'
import type { SvgIconComponent } from '@mui/icons-material'
import { useGetOrganizationUnitRecordsQuery } from '../lib/store'
import { masterDataGroups } from './master-data-catalog'
const groupIcons:Record<string,SvgIconComponent>={organization:BusinessOutlined,geography:PublicOutlined,wells:AccountTreeOutlined,infrastructure:FactoryOutlined,flow:AccountTreeOutlined,monitoring:SettingsOutlined,reference:LayersOutlined}
const groups=masterDataGroups.map(group=>({...group,icon:groupIcons[group.id],items:group.items.map(item=>({...item,icon:groupIcons[group.id]}))}))
export default function WorkspaceNavigation({ view, onNavigate, collapsed = false, onExpand }: { view: string; onNavigate: (value: string) => void; collapsed?: boolean; onExpand?: () => void }) {
    const [search, setSearch] = useState('')
    const [organizationsOpen, setOrganizationsOpen] = useState(false)
    const { data: organizations = [], isLoading: loadingOrganizations, isError: organizationsError } =
        useGetOrganizationUnitRecordsQuery()
    const matchingOrganizations = organizations.filter(organization =>
        String(organization.orgUnitName).toLowerCase().includes(search.trim().toLowerCase()))
    const query = search.trim().toLowerCase()
    const showOrganizations = organizationsOpen || !!query
    const [expanded, setExpanded] = useState<string[]>([])
    const row = { minHeight: 38, flexGrow: 0, gap: 1.25, borderRadius: 1, px: 1.25, py: .8, fontSize: 13, whiteSpace: 'normal', transition: 'background-color 160ms ease, color 160ms ease', '&.Mui-selected': { bgcolor: 'action.selected', color: 'text.primary', '&::before': { content: '""', position: 'absolute', left: 0, top: 8, bottom: 8, width: 3, bgcolor: 'primary.main', borderRadius: 2 } }, '@media(prefers-reduced-motion: reduce)': { transition: 'none' } }
    const leaf = (label: string, Icon: SvgIconComponent, destination = label === 'Account home' ? 'Overview' : label) => <Tooltip key={destination} title={collapsed ? label : ''} placement="right"><ListItemButton aria-label={label} selected={view === destination} aria-current={view === destination ? 'page' : undefined} onClick={() => onNavigate(destination)} sx={{ ...row, justifyContent: collapsed ? 'center' : 'flex-start' }}><Icon sx={{ fontSize: 18, color: 'text.secondary', flexShrink: 0 }} />{!collapsed && label}</ListItemButton></Tooltip>
    const renderOrganizations = () => <Box key="all-organizations">
        <Box sx={{ display: 'flex', alignItems: 'center' }}>
            <Box sx={{ flex: 1, minWidth: 0 }}>{leaf('All Organizations', BusinessOutlined)}</Box>
            <IconButton size="small" aria-label={showOrganizations ? 'Collapse organization names' : 'Expand organization names'}
                aria-expanded={showOrganizations} aria-controls="nav-organization-names"
                onClick={() => setOrganizationsOpen(open => !open)} disabled={!!query}>
                <ChevronRight sx={{ fontSize: 16, transform: showOrganizations ? 'rotate(90deg)' : undefined, transition: 'transform 220ms ease', '@media (prefers-reduced-motion: reduce)': { transition: 'none' } }} />
            </IconButton>
        </Box>
        <Collapse in={showOrganizations} timeout="auto" sx={{ '@media (prefers-reduced-motion: reduce)': { transition: 'none !important' } }}>
            <Box id="nav-organization-names" sx={{ ml: 2.25, pl: 1, borderLeft: 1, borderColor: 'divider' }}>
                {matchingOrganizations.map(organization =>
                    leaf(String(organization.orgUnitName), BusinessOutlined, 'organization:' + organization.orgUnitId))}
                {!matchingOrganizations.length && <Typography variant="caption" color="text.secondary" sx={{ px: 1.25 }}>
                    {loadingOrganizations ? 'Loading organizations…' : organizationsError ? 'Unable to load organizations' : 'No organizations found'}
                </Typography>}
            </Box>
        </Collapse>
    </Box>
    const renderGroup = (group: { id: string; label: string; icon: SvgIconComponent; items: { label: string; table: string; icon: SvgIconComponent }[] }) => {
            const items = group.items.filter(item => (item.label+' '+item.table+' '+group.label).toLowerCase().includes(query) || (item.label === 'All Organizations' && matchingOrganizations.length > 0))
            const open = !!query || expanded.includes(group.id)
            const active = group.items.some(item => item.label === view) || (group.id === 'organization-view' && view.startsWith('organization:'))
            const Icon = group.icon
            if (query && !items.length) return null
            return <Box key={group.id} sx={{ mb: .5 }}>
                <Tooltip title={collapsed ? group.label : ''} placement="right"><ListItemButton aria-label={group.label} aria-expanded={!collapsed && open} aria-controls={'nav-' + group.id} onClick={() => { if (collapsed) { onExpand?.(); setExpanded(e => e.includes(group.id) ? e : [...e, group.id]) } else setExpanded(e => e.includes(group.id) ? e.filter(id => id !== group.id) : [...e, group.id]) }} sx={{ ...row, bgcolor: active || open ? 'action.hover' : undefined, justifyContent: collapsed ? 'center' : 'flex-start' }}>
                    <Icon sx={{ fontSize: 18, color: 'text.secondary', flexShrink: 0 }} />
                    {!collapsed && <><Box component="span" sx={{ flex: 1, fontWeight: 600 }}>{group.label}</Box><ChevronRight sx={{ fontSize: 16, color: 'text.secondary', transform: open ? 'rotate(90deg)' : 'rotate(0)', transition: 'transform 220ms ease', '@media(prefers-reduced-motion: reduce)': { transition: 'none' } }} /></>}
                </ListItemButton></Tooltip>
                <Collapse in={!collapsed && open} timeout="auto" sx={{ '@media(prefers-reduced-motion: reduce)': { transition: 'none !important', '& *': { transition: 'none !important' } } }}>
                    <Box id={'nav-' + group.id} sx={{ ml: 2.25, pl: 1, borderLeft: 1, borderColor: 'divider', mt: .5, mb: 1 }}>{items.map(item => item.label === 'All Organizations' ? renderOrganizations() : leaf(item.label, item.icon))}</Box>
                </Collapse>
            </Box>
    }
    return <Box component="nav" aria-label="Workspace navigation" sx={{ display: 'flex', flexDirection: 'column', height: '100%', minHeight: 0, p: 1, overflowY: 'auto', overflowX: 'hidden' }}>
        {collapsed ? <Tooltip title="Search navigation" placement="right"><IconButton aria-label="Search navigation" onClick={onExpand} sx={{ mb: 1 }}><SearchOutlined fontSize="small" /></IconButton></Tooltip> : <TextField size="small" placeholder="Quick search…" value={search} onChange={e => setSearch(e.target.value)} slotProps={{ htmlInput: { 'aria-label': 'Search navigation' }, input: { startAdornment: <InputAdornment position="start"><SearchOutlined sx={{ fontSize: 16 }} /></InputAdornment> } }} sx={{ mb: 1.5, '& .MuiInputBase-root': { fontSize: 12, height: 34 } }} />}
        {!collapsed && <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', pl: 1.25, mb: .75 }}>
            <Typography variant="overline" color="text.secondary" sx={{ fontWeight: 700, lineHeight: 1.5 }}>Workspace</Typography>
            <Button size="small" startIcon={<UnfoldLess />} disabled={!expanded.length && !organizationsOpen && !query}
                onClick={() => { setExpanded([]); setOrganizationsOpen(false); setSearch('') }}
                sx={{ textTransform: 'none', whiteSpace: 'nowrap' }}>Collapse all</Button>
        </Box>}
        <Box sx={{ display: 'flex', flexDirection: 'column', gap: .25 }}>
            {leaf('Account home', HomeOutlined)}
            {leaf('Assets', StorageOutlined)}
            {leaf('Work sheet', SearchOutlined, 'Data Catalog')}
            {renderGroup({
            id: 'organization-view',
            label: 'Organization View',
            icon: BusinessOutlined,
            items: [
                { label: 'All Organizations', table: 'ORG_UNIT', icon: BusinessOutlined },
                { label: 'Organization Relationships', table: '', icon: AccountTreeOutlined },
            ],
            })}
        </Box>
        <Divider sx={{ my: 1.5 }} />
        {!collapsed && <Typography variant="overline" color="text.secondary" sx={{ px: 1.25, mb: 1, fontWeight: 700, lineHeight: 1.5 }}>Production & reservoir</Typography>}
        {groups.map(renderGroup)}
        <Box sx={{ flex: 1, minHeight: 24 }} /><Divider sx={{ my: 1 }} />
        {!collapsed && <Typography variant="caption" color="text.secondary" sx={{ px: 1.25, py: 1 }}>OSDU workspace</Typography>}
    </Box>
}


