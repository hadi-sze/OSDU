'use client'
import dynamic from 'next/dynamic'
import FormLoading from '@/components/loading-ui/form-loading'
const DataCatalog = dynamic(() => import('./data-catalog'), { loading: () => <FormLoading /> })
import WellRecords, { wellRecordPages } from './well-records'
import { useState } from 'react'
const PoolStatusRecords = dynamic(() => import('./pool-statuses'), { loading: () => <FormLoading /> })
const PoolTypeRecords = dynamic(() => import('./pool-types'), { loading: () => <FormLoading /> })
import OrganizationView, { FacilityOrgUnits, FieldOrgUnits, WellOrgUnits } from './organization-view'
const Facilities = dynamic(() => import('./facilities'), { loading: () => <FormLoading /> })
const FacilityFields = dynamic(() => import('./facility-field-associations'), { loading: () => <FormLoading /> })
const CrsRecords = dynamic(() => import('./coordinate-reference-systems'), { loading: () => <FormLoading /> })
const OrganizationUnitRecords = dynamic(() => import('./organization-units'), { loading: () => <FormLoading /> })
const PoolRecords = dynamic(() => import('./pools'), { loading: () => <FormLoading /> })
const EquipmentRecords = dynamic(() => import('./equipment'), { loading: () => <FormLoading /> })
const FieldTypeRecords = dynamic(() => import('./field-types'), { loading: () => <FormLoading /> })
const Fields = dynamic(() => import('./fields'), { loading: () => <FormLoading /> })
const Wells = dynamic(() => import('./wells'), { loading: () => <FormLoading /> })
const WellStatusTypes = dynamic(() => import('./well-status-types'), { loading: () => <FormLoading /> })
const WellStatuses = dynamic(() => import('./well-statuses'), { loading: () => <FormLoading /> })
const OrgUnitTypes = dynamic(() => import('./org-unit-types'), { loading: () => <FormLoading /> })
import { masterDataItems } from './master-data-catalog'
import Image from 'next/image'
import AccountCircleOutlinedIcon from '@mui/icons-material/AccountCircleOutlined'
import LogoutIcon from '@mui/icons-material/Logout'
import { useDispatch, useSelector } from 'react-redux'
import { Alert, AppBar, Box, Button, Chip, Container, Drawer, InputAdornment, Menu, MenuItem, ListItemIcon, Dialog, DialogActions, DialogContent, DialogTitle, Divider, IconButton, LinearProgress, ListItemButton, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Toolbar, Typography, useColorScheme } from '@mui/material'
import { RowActions } from './record-editor'
import WorkspaceNavigation from './workspace-navigation'

import MenuIcon from '@mui/icons-material/Menu'
import StorageIcon from '@mui/icons-material/StorageOutlined'
import AccountTreeIcon from '@mui/icons-material/AccountTreeOutlined'
import LayersIcon from '@mui/icons-material/LayersOutlined'
import SearchIcon from '@mui/icons-material/Search'
import HomeIcon from '@mui/icons-material/HomeOutlined'
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft'
import AddIcon from '@mui/icons-material/Add'
import RefreshIcon from '@mui/icons-material/Refresh'
import DarkModeIcon from '@mui/icons-material/DarkMode'
import { setSearch, type RootState, type Asset, useGetOrganizationUnitRecordsQuery, useGetAssetsQuery, useCreateAssetMutation, useUpdateAssetMutation, useDeleteAssetMutation } from '../lib/store'
const domains = masterDataItems.map(item => item.label)
const masterDataPages: Record<string, React.ComponentType> = {
  "Organization Relationships": OrganizationView,
  "All Organizations": OrganizationUnitRecords,
  "Reference · Pool Status": PoolStatusRecords,
  "Reference · Pool Type": PoolTypeRecords,
  "Facility Org Unit": FacilityOrgUnits,
  "Field Org Unit": FieldOrgUnits,
  "Well Org Unit": WellOrgUnits,
  "Facility Field": FacilityFields,
  "Coordinate Reference Systems": CrsRecords,
  "Organization Unit": OrganizationUnitRecords,
  "Pool / Reservoir": PoolRecords,
  "Equipment": EquipmentRecords,
  "Reference \u00b7 Field Type": FieldTypeRecords,
  "Field": Fields,
  "Well": Wells,
  "Reference \u00b7 Org Unit Type": OrgUnitTypes,
  "Reference \u00b7 Well Status": WellStatuses,
  "Reference \u00b7 Well Status Type": WellStatusTypes,
  "Facilities": Facilities
}
export default function Dashboard() {
  const { data: assets = [], isLoading, isFetching, error, refetch } = useGetAssetsQuery()
  const [create, { isLoading: creating }] = useCreateAssetMutation()
  const [update, { isLoading: updating }] = useUpdateAssetMutation()
  const [remove, { isLoading: deleting }] = useDeleteAssetMutation()
  const search = useSelector((s: RootState) => s.ui.search); const dispatch = useDispatch()
  const [editing, setEditing] = useState<Asset | null | undefined>(undefined)
  const [name, setName] = useState(''); const [description, setDescription] = useState('')
  const [viewAsset, setViewAsset] = useState<Asset | null>(null)
  const [failure, setFailure] = useState(''); const [target, setTarget] = useState<Asset | null>(null)
  const [view, setView] = useState('Overview')
  const organizationId = view.startsWith('organization:') ? Number(view.slice('organization:'.length)) : undefined
  const { data: organizations = [] } = useGetOrganizationUnitRecordsQuery(undefined, { skip: organizationId === undefined })
  const organization = organizations.find(row => row.orgUnitId === organizationId)
  const viewTitle = organizationId === undefined ? view : String(organization?.orgUnitName ?? 'Organization')
  const { mode, setMode } = useColorScheme()
  const [mobileOpen, setMobileOpen] = useState(false)
  const [accountAnchor, setAccountAnchor] = useState<HTMLElement | null>(null)
  const [logoutError, setLogoutError] = useState('')
  const [signingOut, setSigningOut] = useState(false)
  const signOut = async () => { setSigningOut(true); setLogoutError(''); try { const response = await fetch('/api/auth/logout', { method: 'POST' }); if (!response.ok) throw new Error(); window.location.assign('/login') } catch { setLogoutError('Unable to sign out. Please try again.'); setSigningOut(false) } }
  const [collapsed, setCollapsed] = useState(false)
  const navigate = (value: string) => { const action = () => { setView(value); setMobileOpen(false) }; if (window.dispatchEvent(new CustomEvent('osdu:navigate', { cancelable: true, detail: action }))) action() }
  const navigation = <WorkspaceNavigation view={view} onNavigate={navigate} />
  const busy = creating || updating
  function open(asset: Asset | null) { setEditing(asset); setName(asset?.name || ''); setDescription(asset?.description || ''); setFailure('') }
  async function save() { try { const input = { name: name.trim(), description: description.trim() || null }; if (editing) await update({ id: editing.id, ...input }).unwrap(); else await create(input).unwrap(); setEditing(undefined) } catch { setFailure('Could not save. Check the API connection and try again.') } }
  const filtered = assets.filter(a => (a.name + ' ' + (a.description || '')).toLowerCase().includes(search.toLowerCase()))
  const MasterDataPage = masterDataPages[view]
  return <Box sx={{ minHeight: '100vh', bgcolor: 'background.default' }}>
    <AppBar position="fixed" elevation={0} color="inherit" sx={{ borderBottom: 1, borderColor: 'divider', zIndex: 1201 }}>
      <Toolbar variant="dense" sx={{ minHeight: 58, gap: 1 }}>
        <IconButton aria-label="Open navigation" onClick={() => setMobileOpen(true)} sx={{ display: { md: 'none' } }}><MenuIcon /></IconButton>
        <Box sx={{ display: "flex", alignItems: "center", gap: 1.25, mr: 1, flexShrink: 0 }}><Image src="/nioclogo.png" alt="NIOC logo" width={32} height={36} style={{ objectFit: "contain" }} priority /><Box component="span" sx={{ color: "primary.main", fontWeight: 900, fontSize: 22, letterSpacing: -1 }}>OSDU</Box></Box>
        <Divider orientation="vertical" flexItem sx={{ my: 1.5, mx: 1 }} />
        <Typography variant="body2" sx={{ flex: 1 }}>Production & reservoir workspace</Typography>
        <Chip label="SQL Server" size="small" variant="outlined" sx={{ display: { xs: 'none', sm: 'flex' } }} />
        <IconButton aria-label="Toggle color theme" onClick={() => setMode(mode === 'dark' ? 'light' : 'dark')}><DarkModeIcon fontSize="small" /></IconButton>
        <IconButton id="account-menu-button" aria-label="Account menu" aria-haspopup="menu" aria-controls={accountAnchor ? 'account-menu' : undefined} aria-expanded={!!accountAnchor} onClick={e => setAccountAnchor(e.currentTarget)}><AccountCircleOutlinedIcon /></IconButton>
        <Menu id="account-menu" anchorEl={accountAnchor} open={!!accountAnchor} onClose={() => setAccountAnchor(null)} anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }} transformOrigin={{ vertical: 'top', horizontal: 'right' }} slotProps={{ list: { 'aria-labelledby': 'account-menu-button' }, paper: { sx: { minWidth: 200, mt: 1 } } }}>
          <MenuItem disabled sx={{ fontSize: 12 }}>OSDU account</MenuItem>
          <Divider />
          <MenuItem disabled={signingOut} onClick={() => { setAccountAnchor(null); const action = () => { void signOut() }; if (window.dispatchEvent(new CustomEvent('osdu:navigate', { cancelable: true, detail: action }))) action() }}><ListItemIcon><LogoutIcon fontSize="small" /></ListItemIcon>{signingOut ? 'Signing out…' : 'Sign out'}</MenuItem>
        </Menu>

      </Toolbar>
    </AppBar>
    <Drawer variant="temporary" open={mobileOpen} onClose={() => setMobileOpen(false)} sx={{ display: { md: 'none' }, '& .MuiDrawer-paper': { width: 268, pt: '58px' } }}>{navigation}</Drawer>
    <Box component="aside" sx={{ display: { xs: 'none', md: 'flex' }, position: 'fixed', top: 58, left: 0, bottom: 0, width: collapsed ? 56 : 260, overflow: 'hidden', transition: 'width 240ms cubic-bezier(.2,0,0,1)', '@media(prefers-reduced-motion: reduce)': { transition: 'none' }, borderRight: 1, borderColor: 'divider', bgcolor: 'background.paper', flexDirection: 'column' }}>
      <WorkspaceNavigation view={view} onNavigate={navigate} collapsed={collapsed} onExpand={() => setCollapsed(false)} />
      <Box sx={{ mt: 'auto', borderTop: 1, borderColor: 'divider', p: 1 }}><IconButton aria-label={collapsed ? 'Expand sidebar' : 'Collapse sidebar'} onClick={() => setCollapsed(!collapsed)}>{collapsed ? <MenuIcon fontSize="small" /> : <ChevronLeftIcon fontSize="small" />}</IconButton></Box>
    </Box>
    <Box component="main" sx={{ ml: { md: collapsed ? '56px' : '260px' }, transition: 'margin-left 240ms cubic-bezier(.2,0,0,1)', '@media(prefers-reduced-motion: reduce)': { transition: 'none' }, pt: '58px', minHeight: '100vh', display: 'flex', flexDirection: 'column' }}>
      <Container maxWidth={view === 'Data Catalog' ? false : 'lg'}
        sx={{ py: view === 'Data Catalog' ? 2 : { xs: 3, md: 6 }, flex: 1, minWidth: 0 }}>{logoutError && <Alert severity="error" onClose={() => setLogoutError('')}>{logoutError}</Alert>}
        {view === 'Overview' ? <>
          <Box sx={{ textAlign: 'center', mt: 1, mb: 4 }}>
            <Chip size="small" label="Production & reservoir data management" variant="outlined" sx={{ mb: 3 }} />
            <Typography component="h1" variant="h4" sx={{ fontWeight: 700, letterSpacing: -.7 }}>Your data. Ready to work.</Typography>
            <Typography color="text.secondary" sx={{ mt: 1 }}>A single workspace for your production operations.</Typography>
          </Box>
          <TextField fullWidth placeholder="Search assets by name or description…" value={search} onChange={e => dispatch(setSearch(e.target.value))} onKeyDown={e => { if (e.key === 'Enter') navigate('Assets') }} slotProps={{ input: { startAdornment: <InputAdornment position="start"><SearchIcon /></InputAdornment>, endAdornment: <Button onClick={() => navigate('Assets')}>Search</Button> } }} sx={{ mb: 4, '& .MuiOutlinedInput-root': { bgcolor: 'background.paper', boxShadow: '0 0 0 5px rgba(128,128,128,.05)' } }} />
          <Box sx={{ display: 'grid', gridTemplateColumns: { xs: '1fr', md: 'repeat(3,1fr)' }, gap: 2 }}>
            {[{ title: 'Manage your assets', description: 'Browse, create, and maintain operational assets in your workspace.', action: 'Open assets', view: 'Assets', icon: <StorageIcon sx={{ fontSize: 62 }} />, detail: isLoading ? 'Loading records…' : assets.length + ' assets loaded' },
            { title: 'Explore master data', description: 'Navigate organizations, fields, reservoirs, wells, and completions.', action: 'Explore domains', view: 'Organization Unit', icon: <AccountTreeIcon sx={{ fontSize: 62 }} />, detail: domains.length + ' data models' },
            { title: 'Facilities & equipment', description: 'Organize the physical infrastructure behind production operations.', action: 'View facilities', view: 'Facilities', icon: <LayersIcon sx={{ fontSize: 62 }} />, detail: 'Connected domain structure' }].map(card => <Paper key={card.title} variant="outlined" sx={{ p: 1, display: 'flex', flexDirection: 'column' }}>
              <Box sx={{ height: 180, border: 1, borderColor: 'divider', borderRadius: 1, display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', gap: 2, color: 'primary.main', bgcolor: 'action.hover' }}>{card.icon}<Typography variant="caption" color="text.secondary">{card.detail}</Typography></Box>
              <Box sx={{ p: 1.5, flex: 1, display: 'flex', flexDirection: 'column' }}><Typography variant="subtitle1" sx={{ fontWeight: 600, mb: 1 }}>{card.title}</Typography><Typography variant="body2" color="text.secondary" sx={{ mb: 3, flex: 1 }}>{card.description}</Typography><Button variant="outlined" color="inherit" onClick={() => navigate(card.view)} sx={{ alignSelf: 'flex-start' }}>{card.action}</Button></Box>
            </Paper>)}
          </Box>
          <Paper variant="outlined" sx={{ mt: 3, p: 2.5 }}><Stack direction={{ xs: 'column', sm: 'row' }} spacing={2} sx={{ justifyContent: 'space-between', alignItems: { sm: 'center' } }}><Box><Typography variant="subtitle2">Continue with your data</Typography><Typography variant="body2" color="text.secondary">Asset changes are saved to the OSDU SQL Server database.</Typography></Box><Button startIcon={<AddIcon />} onClick={() => { navigate('Assets'); open(null) }}>Add an asset</Button></Stack></Paper>
        </> : <>
          <Typography variant="caption" color="text.secondary">OSDU / {view === 'Assets' || view === 'Data Catalog' ? view : 'Master data / ' + (organizationId === undefined ? viewTitle : 'All Organizations / ' + viewTitle)}</Typography>
          <Stack direction="row" sx={{ justifyContent: 'space-between', alignItems: 'center', mt: 2, mb: 1 }}><Typography variant="h4" component="h1" sx={{ fontWeight: 600 }}>{viewTitle}</Typography>{view === 'Assets' && <Button variant="contained" startIcon={<AddIcon />} onClick={() => open(null)}>Add asset</Button>}</Stack>
          {view !== 'Data Catalog' && <Typography color="text.secondary" sx={{ mb: 4 }}>Manage the data behind your production operations.</Typography>}
          {view === 'Data Catalog' ? <DataCatalog /> : organizationId !== undefined ? <OrganizationView key={view} organizationId={organizationId} /> : MasterDataPage ? <MasterDataPage /> : wellRecordPages[view] ? <WellRecords key={view} title={view} table={wellRecordPages[view]} /> : view !== 'Assets' ? <Paper variant="outlined" sx={{ p: 4 }}><Chip label="Database model ready" color="primary" variant="outlined" /><Typography variant="h5" sx={{ mt: 3, mb: 1 }}>{view} master data</Typography><Typography variant="body2" color="primary" sx={{ mb: 2 }}>Table: {masterDataItems.find(item => item.label === view)?.table}</Typography><Typography color="text.secondary">The SQL Server model and table have been created. Browsing and editing this domain will be available after its backend API endpoints are added.</Typography><Button sx={{ mt: 3 }} onClick={() => setView('Assets')}>Return to assets</Button></Paper> : <>
            <Stack direction={{ xs: 'column', sm: 'row' }} spacing={2} sx={{ mb: 3 }}>{[['Loaded assets', isLoading ? '—' : assets.length], ['Data models', domains.length], ['Backend', '.NET 10']].map(([label, value]) => <Paper key={label} variant="outlined" sx={{ p: 3, flex: 1 }}><Typography color="text.secondary" variant="body2">{label}</Typography><Typography variant="h4" sx={{ mt: 1, fontWeight: 600 }}>{value}</Typography></Paper>)}</Stack>
            <Paper variant="outlined"><Stack direction="row" spacing={2} sx={{ alignItems: "center", p: 2 }}><TextField size="small" label="Search loaded assets" value={search} onChange={e => dispatch(setSearch(e.target.value))} sx={{ flex: 1, maxWidth: 400 }} /><IconButton aria-label="Refresh assets" onClick={() => refetch()} disabled={isFetching}><RefreshIcon /></IconButton></Stack>{isFetching && <LinearProgress />}{error && <Alert severity="error" sx={{ mx: 2, mb: 2 }}>Unable to load assets. Ensure the .NET API is running on port 5080.<Button onClick={() => refetch()}>Retry</Button></Alert>}
              <TableContainer><Table><TableHead><TableRow><TableCell>Name</TableCell><TableCell>Description</TableCell><TableCell>Created (UTC)</TableCell><TableCell align="right">Actions</TableCell></TableRow></TableHead><TableBody>{filtered.map(a => <TableRow key={a.id} hover><TableCell sx={{ fontWeight: 500 }}>{a.name}<Typography variant="caption" sx={{ display: "block" }} color="text.secondary">ID {a.id}</Typography></TableCell><TableCell>{a.description || '—'}</TableCell><TableCell>{a.createdUtc.slice(0, 10)}</TableCell><TableCell align="right"><RowActions name={a.name} onEdit={() => open(a)} onView={() => setViewAsset(a)} onDelete={() => { setTarget(a); setFailure('') }} /></TableCell></TableRow>)}{!isLoading && !error && filtered.length === 0 && <TableRow><TableCell colSpan={4} align="center" sx={{ py: 6 }}>{search ? 'No matching assets.' : 'No assets yet. Add your first asset to get started.'}</TableCell></TableRow>}</TableBody></Table></TableContainer><Typography variant="caption" color="text.secondary" sx={{ display: 'block', p: 2 }}>Showing {filtered.length} of {assets.length} loaded records. API returns up to 100 assets.</Typography></Paper></>}
        </>}
      </Container>
      <Box component="footer" sx={{ borderTop: 1, borderColor: 'divider', py: 2, px: 3, display: 'flex', gap: 3, flexWrap: 'wrap' }}><Typography variant="caption" color="text.secondary">OSDU · Production data workspace</Typography><Typography variant="caption" color="text.secondary">.NET 10 + SQL Server</Typography><Typography variant="caption" color="text.secondary" sx={{ ml: 'auto' }}>© {new Date().getFullYear()} OSDU</Typography></Box>
    </Box>
    <Dialog open={!!viewAsset} onClose={() => setViewAsset(null)} fullWidth maxWidth="sm">
      <DialogTitle>{viewAsset?.name}</DialogTitle>
      <DialogContent>
        <Typography variant="body2" color="text.secondary">ID {viewAsset?.id} · Created {viewAsset?.createdUtc.slice(0, 10)} UTC</Typography>
        <Typography sx={{ mt: 2, whiteSpace: 'pre-wrap' }}>{viewAsset?.description || 'No description.'}</Typography>
      </DialogContent>
      <DialogActions><Button onClick={() => setViewAsset(null)}>Close</Button></DialogActions>
    </Dialog>
    <Dialog open={editing !== undefined} onClose={() => !busy && setEditing(undefined)} fullWidth maxWidth="sm"><DialogTitle>{editing ? 'Edit asset' : 'Add asset'}</DialogTitle><DialogContent><Stack spacing={3} sx={{ pt: 1 }}>{failure && <Alert severity="error">{failure}</Alert>}<TextField autoFocus label="Name" value={name} onChange={e => setName(e.target.value)} required slotProps={{ htmlInput: { maxLength: 200 } }} /><TextField label="Description" value={description} onChange={e => setDescription(e.target.value)} multiline rows={3} slotProps={{ htmlInput: { maxLength: 2000 } }} /></Stack></DialogContent><DialogActions sx={{ p: 3 }}><Button disabled={busy} onClick={() => setEditing(undefined)}>Cancel</Button><Button variant="contained" disabled={busy || !name.trim()} onClick={save}>{busy ? 'Saving…' : 'Save asset'}</Button></DialogActions></Dialog>
    <Dialog open={!!target} onClose={() => !deleting && setTarget(null)}><DialogTitle>Delete asset?</DialogTitle><DialogContent>{failure && <Alert severity="error">{failure}</Alert>}<Typography>Delete “{target?.name}”? This removes the record from SQL Server.</Typography></DialogContent><DialogActions><Button disabled={deleting} onClick={() => setTarget(null)}>Cancel</Button><Button color="error" disabled={deleting} onClick={async () => { try { await remove(target!.id).unwrap(); setTarget(null) } catch { setFailure('Could not delete the asset. Try again.') } }}>Delete</Button></DialogActions></Dialog>
  </Box>
}








