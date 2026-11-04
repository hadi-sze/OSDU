import { configureStore, createSlice, type PayloadAction } from '@reduxjs/toolkit'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
export interface Asset { id: number; name: string; description: string | null; createdUtc: string }
export type AssetInput = Pick<Asset, 'name' | 'description'>
export const assetsApi = createApi({
    reducerPath: 'assetsApi', baseQuery: fetchBaseQuery({ baseUrl: '/api/' }), tagTypes: ['OrgUnitType','Asset', 'Facility', 'WellStatusType','WellStatus'],
    endpoints: b => ({
  getOrgUnitTypes:b.query<Record<string,unknown>[],void>({query:()=>'reference/org-unit-types',providesTags:['OrgUnitType']}),
  createOrgUnitType:b.mutation<Record<string,unknown>,Record<string,unknown>>({query:body=>({url:'reference/org-unit-types',method:'POST',body}),invalidatesTags:['OrgUnitType']}),

  getWellStatuses:b.query<Record<string,unknown>[],void>({query:()=>'reference/well-statuses',providesTags:['WellStatus']}),
  getWellStatusTypeOptions:b.query<{id:number;label:string}[],void>({query:()=>'reference/well-statuses/types'}),
  createWellStatus:b.mutation<Record<string,unknown>,Record<string,unknown>>({query:body=>({url:'reference/well-statuses',method:'POST',body}),invalidatesTags:['WellStatus']}),

  getWellStatusTypes:b.query<Record<string,unknown>[],void>({query:()=>'reference/well-status-types',providesTags:['WellStatusType','WellStatus']}),
  getWellStatusSources:b.query<{id:number;label:string}[],void>({query:()=>'reference/well-status-types/sources'}),
  createWellStatusType:b.mutation<Record<string,unknown>,Record<string,unknown>>({query:body=>({url:'reference/well-status-types',method:'POST',body}),invalidatesTags:['WellStatusType','WellStatus']}),

        getFacilities: b.query<Record<string, unknown>[], void>({ query: () => 'facilities', providesTags: ['Facility'] }),
        getFacilityLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'facilities/lookups' }),
        createFacility: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'facilities', method: 'POST', body }), invalidatesTags: ['Facility'] }),

        getAssets: b.query<Asset[], void>({ query: () => 'assets', providesTags: ['Asset'] }),
        createAsset: b.mutation<Asset, AssetInput>({ query: body => ({ url: 'assets', method: 'POST', body }), invalidatesTags: ['Asset'] }),
        updateAsset: b.mutation<void, AssetInput & { id: number }>({ query: ({ id, ...body }) => ({ url: 'assets/' + id, method: 'PUT', body }), invalidatesTags: ['Asset'] }),
        deleteAsset: b.mutation<void, number>({ query: id => ({ url: 'assets/' + id, method: 'DELETE' }), invalidatesTags: ['Asset'] }),
    })
})
const ui = createSlice({ name: 'ui', initialState: { search: '' }, reducers: { setSearch: (s, a: PayloadAction<string>) => { s.search = a.payload } } })
export const { setSearch } = ui.actions
export const makeStore = () => configureStore({ reducer: { ui: ui.reducer, [assetsApi.reducerPath]: assetsApi.reducer }, middleware: g => g().concat(assetsApi.middleware) })
export type AppStore = ReturnType<typeof makeStore>
export type RootState = ReturnType<AppStore['getState']>
export const { useGetAssetsQuery, useCreateAssetMutation, useUpdateAssetMutation, useDeleteAssetMutation } = assetsApi

export const { useGetFacilitiesQuery, useGetFacilityLookupsQuery, useCreateFacilityMutation } = assetsApi

export const {useGetWellStatusTypesQuery,useGetWellStatusSourcesQuery,useCreateWellStatusTypeMutation}=assetsApi


export const {useGetWellStatusesQuery,useGetWellStatusTypeOptionsQuery,useCreateWellStatusMutation}=assetsApi

export const {useGetOrgUnitTypesQuery,useCreateOrgUnitTypeMutation}=assetsApi
