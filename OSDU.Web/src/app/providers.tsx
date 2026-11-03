'use client'
import { useRef } from 'react'
import { Provider } from 'react-redux'
import { CssBaseline, ThemeProvider, createTheme } from '@mui/material'
import { makeStore, type AppStore } from '../lib/store'
const theme=createTheme({colorSchemes:{light:true,dark:true},palette:{primary:{main:'#087f8c'}},shape:{borderRadius:12},typography:{fontFamily:'Roboto, Arial, sans-serif'}})
export default function Providers({children}:{children:React.ReactNode}) {
 const store=useRef<AppStore|null>(null)
 if(!store.current) store.current=makeStore()
 return <Provider store={store.current}><ThemeProvider theme={theme}><CssBaseline />{children}</ThemeProvider></Provider>
}
