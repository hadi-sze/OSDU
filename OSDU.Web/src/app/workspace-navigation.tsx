'use client'
import { useState } from 'react'
import { Box, Collapse, Divider, IconButton, InputAdornment, ListItemButton, TextField, Tooltip, Typography } from '@mui/material'
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
import ChevronRight from '@mui/icons-material/ChevronRight'
import type { SvgIconComponent } from '@mui/icons-material'
import { masterDataGroups } from './master-data-catalog'
const groupIcons:Record<string,SvgIconComponent>={organization:BusinessOutlined,geography:PublicOutlined,wells:AccountTreeOutlined,infrastructure:FactoryOutlined,flow:AccountTreeOutlined,monitoring:SettingsOutlined,reference:LayersOutlined}
const groups=masterDataGroups.map(group=>({...group,icon:groupIcons[group.id],items:group.items.map(item=>({...item,icon:groupIcons[group.id]}))}))
export default function WorkspaceNavigation({ view, onNavigate, collapsed = false, onExpand }: { view: string; onNavigate: (value: string) => void; collapsed?: boolean; onExpand?: () => void }) {
    const [search, setSearch] = useState('')
    const [expanded, setExpanded] = useState<string[]>([])
    const row = { minHeight: 38, flexGrow: 0, gap: 1.25, borderRadius: 1, px: 1.25, py: .8, fontSize: 13, whiteSpace: 'normal', transition: 'background-color 160ms ease, color 160ms ease', '&.Mui-selected': { bgcolor: 'action.selected', color: 'text.primary', '&::before': { content: '""', position: 'absolute', left: 0, top: 8, bottom: 8, width: 3, bgcolor: 'primary.main', borderRadius: 2 } }, '@media(prefers-reduced-motion: reduce)': { transition: 'none' } }
    const leaf = (label: string, Icon: SvgIconComponent) => <Tooltip key={label} title={collapsed ? label : ''} placement="right"><ListItemButton aria-label={label} selected={view === label || (label === 'Account home' && view === 'Overview')} onClick={() => onNavigate(label === 'Account home' ? 'Overview' : label)} sx={{ ...row, justifyContent: collapsed ? 'center' : 'flex-start' }}><Icon sx={{ fontSize: 18, color: 'text.secondary', flexShrink: 0 }} />{!collapsed && label}</ListItemButton></Tooltip>
    return <Box component="nav" aria-label="Workspace navigation" sx={{ display: 'flex', flexDirection: 'column', height: '100%', minHeight: 0, p: 1, overflowY: 'auto', overflowX: 'hidden' }}>
        {collapsed ? <Tooltip title="Search navigation" placement="right"><IconButton aria-label="Search navigation" onClick={onExpand} sx={{ mb: 1 }}><SearchOutlined fontSize="small" /></IconButton></Tooltip> : <TextField size="small" placeholder="Quick search…" value={search} onChange={e => setSearch(e.target.value)} slotProps={{ htmlInput: { 'aria-label': 'Search navigation' }, input: { startAdornment: <InputAdornment position="start"><SearchOutlined sx={{ fontSize: 16 }} /></InputAdornment> } }} sx={{ mb: 1.5, '& .MuiInputBase-root': { fontSize: 12, height: 34 } }} />}
        {leaf('Organization View', BusinessOutlined)}{leaf('Account home', HomeOutlined)}{leaf('Assets', StorageOutlined)}
        <Divider sx={{ my: 1.5 }} />
        {!collapsed && <Typography variant="caption" color="text.secondary" sx={{ px: 1.25, mb: 1, fontSize: 11 }}>Production & reservoir</Typography>}
        {groups.map(group => {
            const items = group.items.filter(item => (item.label+' '+item.table+' '+group.label).toLowerCase().includes(search.toLowerCase()))
            const open = !!search || expanded.includes(group.id)
            const active = group.items.some(item => item.label === view)
            const Icon = group.icon
            if (search && !items.length) return null
            return <Box key={group.id} sx={{ mb: .5 }}>
                <Tooltip title={collapsed ? group.label : ''} placement="right"><ListItemButton aria-label={group.label} aria-expanded={!collapsed && open} aria-controls={'nav-' + group.id} onClick={() => { if (collapsed) { onExpand?.(); setExpanded(e => e.includes(group.id) ? e : [...e, group.id]) } else setExpanded(e => e.includes(group.id) ? e.filter(id => id !== group.id) : [...e, group.id]) }} sx={{ ...row, bgcolor: active ? 'action.hover' : undefined, justifyContent: collapsed ? 'center' : 'flex-start' }}>
                    <Icon sx={{ fontSize: 18, color: 'text.secondary', flexShrink: 0 }} />
                    {!collapsed && <><Box component="span" sx={{ flex: 1, fontSize: 12 }}>{group.label}</Box><ChevronRight sx={{ fontSize: 16, color: 'text.secondary', transform: open ? 'rotate(90deg)' : 'rotate(0)', transition: 'transform 220ms ease', '@media(prefers-reduced-motion: reduce)': { transition: 'none' } }} /></>}
                </ListItemButton></Tooltip>
                <Collapse in={!collapsed && open} timeout="auto" sx={{ '@media(prefers-reduced-motion: reduce)': { transition: 'none !important', '& *': { transition: 'none !important' } } }}>
                    <Box id={'nav-' + group.id} sx={{ ml: 2.25, pl: 1, borderLeft: 1, borderColor: 'divider', mt: .5, mb: 1 }}>{items.map(item => leaf(item.label, item.icon))}</Box>
                </Collapse>
            </Box>
        })}
        <Box sx={{ flex: 1, minHeight: 24 }} /><Divider sx={{ my: 1 }} />
        {!collapsed && <Typography variant="caption" color="text.secondary" sx={{ px: 1.25, py: 1 }}>OSDU workspace</Typography>}
    </Box>
}

