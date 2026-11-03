import { configureStore, createSlice, type PayloadAction } from '@reduxjs/toolkit'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
export interface Asset { id: number; name: string; description: string | null; createdUtc: string }
export type AssetInput = Pick<Asset, 'name' | 'description'>
export const assetsApi = createApi({
 reducerPath: 'assetsApi', baseQuery: fetchBaseQuery({ baseUrl: '/api/' }), tagTypes: ['Asset'],
 endpoints: b => ({
  getAssets: b.query<Asset[], void>({ query: () => 'assets', providesTags: ['Asset'] }),
  createAsset: b.mutation<Asset, AssetInput>({ query: body => ({url:'assets',method:'POST',body}), invalidatesTags:['Asset'] }),
  updateAsset: b.mutation<void, AssetInput & {id:number}>({ query: ({id,...body}) => ({url:'assets/'+id,method:'PUT',body}), invalidatesTags:['Asset'] }),
  deleteAsset: b.mutation<void, number>({ query: id => ({url:'assets/'+id,method:'DELETE'}), invalidatesTags:['Asset'] }),
 })
})
const ui = createSlice({name:'ui',initialState:{search:''},reducers:{setSearch:(s,a:PayloadAction<string>)=>{s.search=a.payload}}})
export const {setSearch}=ui.actions
export const makeStore=()=>configureStore({reducer:{ui:ui.reducer,[assetsApi.reducerPath]:assetsApi.reducer},middleware:g=>g().concat(assetsApi.middleware)})
export type AppStore=ReturnType<typeof makeStore>
export type RootState=ReturnType<AppStore['getState']>
export const {useGetAssetsQuery,useCreateAssetMutation,useUpdateAssetMutation,useDeleteAssetMutation}=assetsApi
