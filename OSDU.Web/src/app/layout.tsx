import './globals.css'
import type { Metadata } from 'next'
import { AppRouterCacheProvider } from '@mui/material-nextjs/v16-appRouter'
import Providers from './providers'
import '@fontsource/roboto/400.css'
import '@fontsource/roboto/500.css'
import '@fontsource/roboto/700.css'
export const metadata: Metadata = { title: 'OSDU | Data workspace', description: 'Production and reservoir master data workspace' }
export default function Layout({ children }: { children: React.ReactNode }) {
    return <html lang="en"><body><AppRouterCacheProvider><Providers>{children}</Providers></AppRouterCacheProvider></body></html>
}

