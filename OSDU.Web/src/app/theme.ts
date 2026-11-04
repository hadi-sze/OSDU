'use client'
import { alpha, createTheme, type PaletteOptions } from '@mui/material/styles'
import { extendTheme, type PaletteRange } from '@mui/joy/styles'
import { projectColors } from './palette'

function joyPalette(mode:'light'|'dark') {
 const dark=mode==='dark'
 const result:Record<string,Partial<PaletteRange>>={}
 for(const [name,c] of Object.entries(projectColors)) {
  result[name]={
   ...c,
   solidBg:c[dark?400:500],solidColor:dark?'#0B0D0E':'#FFFFFF',
   solidHoverBg:c[dark?300:600],solidActiveBg:c[dark?200:700],
   softBg:c[dark?900:100],softColor:c[dark?200:700],softHoverBg:c[dark?800:200],
   softActiveBg:c[dark?700:300],outlinedColor:c[dark?200:600],
   outlinedBorder:c[dark?700:300],outlinedHoverBg:c[dark?900:50],
   outlinedActiveBg:c[dark?800:100],plainColor:c[dark?300:600],
   plainHoverBg:c[dark?900:50],plainActiveBg:c[dark?800:100],
  }
 }
 return {...result,danger:result.error}
}
export const joyTheme=extendTheme({
 colorSchemes:{light:{palette:joyPalette('light')},dark:{palette:joyPalette('dark')}},
 components:{
  JoyButton:{defaultProps:{color:'primary'}},
  JoyInput:{defaultProps:{color:'neutral',variant:'outlined'}},
  JoyCheckbox:{defaultProps:{color:'primary'}},
 }
})
function materialPalette(mode:'light'|'dark'):PaletteOptions {
 const dark=mode==='dark'
 const colors=Object.fromEntries(Object.entries(projectColors).map(([name,c])=>[name,{
  main:c[dark?300:500],light:c[dark?200:300],dark:c[dark?500:700],contrastText:dark?'#0B0D0E':'#FFFFFF',
 }]))
 return {
  ...colors,
  background:{default:dark?'#0B0D0E':'#FBFCFE',paper:dark?'#171A1C':'#FFFFFF'},
  text:{primary:dark?'#F0F4F8':'#171A1C',secondary:dark?'#CDD7E1':'#555E68'},
  divider:dark?'#32383E':'#DDE7EE',
  action:{hover:alpha(projectColors.neutral[500],dark?.16:.06),selected:alpha(projectColors.primary[500],dark?.25:.10)},
 }
}
export const materialTheme=createTheme({
 colorSchemes:{light:{palette:materialPalette('light')},dark:{palette:materialPalette('dark')}},
 shape:{borderRadius:8},
 typography:{fontFamily:'Roboto, Arial, sans-serif'},
 components:{
  MuiButton:{defaultProps:{color:'primary',disableElevation:true},styleOverrides:{root:{textTransform:'none',fontWeight:600}}},
  MuiIconButton:{defaultProps:{color:'primary'}},
  MuiTextField:{defaultProps:{color:'primary',variant:'outlined'}},
  MuiCheckbox:{defaultProps:{color:'primary'}},
  MuiRadio:{defaultProps:{color:'primary'}},
  MuiSwitch:{defaultProps:{color:'primary'}},
  MuiLinearProgress:{defaultProps:{color:'primary'}},
  MuiCircularProgress:{defaultProps:{color:'primary'}},
  MuiChip:{defaultProps:{color:'primary'}},
  MuiPaper:{styleOverrides:{root:({theme})=>({backgroundImage:'none',borderColor:theme.palette.divider})}},
  MuiTableCell:{styleOverrides:{head:({theme})=>({backgroundColor:theme.palette.action.hover,fontWeight:600}),root:({theme})=>({borderColor:theme.palette.divider})}},
  MuiOutlinedInput:{styleOverrides:{root:({theme})=>({'& .MuiOutlinedInput-notchedOutline':{borderColor:theme.palette.divider}})}},
 }
})

