'use client'
import { useRef } from 'react'
import { Provider } from 'react-redux'
import { CssBaseline, ThemeProvider } from '@mui/material'
import { makeStore, type AppStore } from '../lib/store'
import { materialTheme } from './theme'
export default function Providers({ children }: { children: React.ReactNode }) {
    const store = useRef<AppStore | null>(null)
    if (!store.current) store.current = makeStore()
    return <Provider store={store.current}><ThemeProvider theme={materialTheme}><CssBaseline />{children}</ThemeProvider></Provider>
}
