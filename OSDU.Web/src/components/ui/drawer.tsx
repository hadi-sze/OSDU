'use client'
// Composition adapted from shadcn/ui Base Drawer; styled with project Joy tokens.
// https://ui.shadcn.com/docs/components/base/drawer
import { Drawer as Primitive } from '@base-ui/react/drawer'
import type { ComponentProps } from 'react'
import './drawer.css'
export const Drawer=Primitive.Root
export const DrawerTrigger=Primitive.Trigger
export const DrawerClose=Primitive.Close
export const DrawerTitle=Primitive.Title
export const DrawerDescription=Primitive.Description
export function DrawerContent({children,...props}:Primitive.Popup.Props) {
 return <Primitive.Portal><Primitive.Backdrop className="osdu-drawer-overlay"/><Primitive.Viewport className="osdu-drawer-viewport"><Primitive.Popup {...props} className="osdu-drawer-popup"><Primitive.Content className="osdu-drawer-content">{children}</Primitive.Content></Primitive.Popup></Primitive.Viewport></Primitive.Portal>
}
export function DrawerHeader(props:ComponentProps<'div'>){return <div {...props}/>}
export function DrawerFooter(props:ComponentProps<'div'>){return <div {...props}/>}
