import type { PaletteColor, PaletteColorOptions } from '@mui/material/styles'
import type { PaletteRange } from '@mui/joy/styles'
declare module '@mui/material/styles' {
 interface Palette {
  neutral: PaletteColor;
  violet: PaletteColor;
  cyan: PaletteColor;
  pink: PaletteColor;
 }
 interface PaletteOptions {
  neutral?: PaletteColorOptions;
  violet?: PaletteColorOptions;
  cyan?: PaletteColorOptions;
  pink?: PaletteColorOptions;
 }
}
declare module '@mui/material/Button' { interface ButtonPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/IconButton' { interface IconButtonPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Chip' { interface ChipPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Alert' { interface AlertPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Checkbox' { interface CheckboxPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Radio' { interface RadioPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Switch' { interface SwitchPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/TextField' { interface TextFieldPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/InputBase' { interface InputBasePropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/FormControl' { interface FormControlPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/CircularProgress' { interface CircularProgressPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/LinearProgress' { interface LinearProgressPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Badge' { interface BadgePropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Slider' { interface SliderPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/ToggleButton' { interface ToggleButtonPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Fab' { interface FabPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/AppBar' { interface AppBarPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/material/Typography' { interface TypographyPropsColorOverrides { neutral: true; violet: true; cyan: true; pink: true; } }
declare module '@mui/joy/styles' {
 interface ColorPalettePropOverrides { secondary:true; error:true; info:true; violet:true; cyan:true; pink:true; }
 interface Palette { secondary:PaletteRange; error:PaletteRange; info:PaletteRange; violet:PaletteRange; cyan:PaletteRange; pink:PaletteRange; }
}
