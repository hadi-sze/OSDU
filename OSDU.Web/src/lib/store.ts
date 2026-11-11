import { configureStore, createSlice, type PayloadAction } from '@reduxjs/toolkit'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import type { CatalogFacets, CatalogMapData, CatalogPage, CatalogParams } from './catalog-types'
export interface Asset { id: number; name: string; description: string | null; createdUtc: string }
export type AssetInput = Pick<Asset, 'name' | 'description'>
function catalogTags(dataset: string) {
    const tags = { Wells: 'Well', Wellbores: 'Wellbore', Fields: 'Field', Facilities: 'Facility' } as const
    const tag = tags[dataset as keyof typeof tags]
    return tag ? [tag] : Object.values(tags)
}
export const assetsApi = createApi({
    reducerPath: 'assetsApi', baseQuery: fetchBaseQuery({ baseUrl: '/api/' }), tagTypes: ['PoolType','PoolStatus','FieldType','Equipment', 'Pool', 'OrganizationUnit', 'Crs', 'FacilityField', 'Field', 'Well', 'Wellbore', 'OrgUnitType', 'Asset', 'Facility', 'WellStatusType', 'WellStatus'],
    endpoints: b => ({
        getCatalogPage: b.query<CatalogPage, CatalogParams & { page: number; size: number; sort: string; desc: boolean }>({
            query: params => ({ url: 'catalog', params }), providesTags: (_result, _error, { dataset, hasLocation }) =>
                [...catalogTags(dataset), ...(hasLocation ? ['Crs' as const] : [])],
        }),
        getCatalogFacets: b.query<CatalogFacets, CatalogParams>({
            query: params => ({ url: 'catalog/facets', params }), providesTags: (_result, _error, { dataset, hasLocation }) =>
                [...catalogTags(dataset), ...(hasLocation ? ['Crs' as const] : [])],
        }),
        getCatalogMap: b.query<CatalogMapData, Omit<CatalogParams, 'hasLocation'>>({
            query: params => ({ url: 'catalog/map', params }),
            providesTags: (_result, _error, { dataset }) => [...catalogTags(dataset), 'Crs'],
        }),
 updateOrganizationUnit:b.mutation<Record<string,unknown>,{id:number;body:Record<string,unknown>}>({query:({id,body})=>({url:'organization-units/'+id,method:'PUT',body}),invalidatesTags:['OrganizationUnit']}),
 deleteOrganizationUnit:b.mutation<void,number>({query:id=>({url:'organization-units/'+id,method:'DELETE'}),invalidatesTags:['OrganizationUnit']}),
 getFieldTypeRecords:b.query<Record<string,unknown>[],void>({query:()=>'reference/field-types',providesTags:['FieldType']}),
 getFieldTypeLookups:b.query<Record<string,{id:number;label:string}[]>,void>({query:()=>'reference/field-types/lookups'}),
 createFieldType:b.mutation<Record<string,unknown>,Record<string,unknown>>({query:body=>({url:'reference/field-types',method:'POST',body}),invalidatesTags:['FieldType']}),
        getEquipmentRecords: b.query<Record<string, unknown>[], void>({ query: () => 'equipment', providesTags: ['Equipment'] }),
        getEquipmentLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'equipment/lookups' }),
        createEquipment: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'equipment', method: 'POST', body }), invalidatesTags: ['Equipment'] }),
        getPoolRecords: b.query<Record<string, unknown>[], void>({ query: () => 'pools', providesTags: ['Pool'] }),
        getPoolStatusRecords: b.query<Record<string,unknown>[],void>({query:()=>'reference/pool-statuses',providesTags:['PoolStatus']}),
        getPoolTypeRecords: b.query<Record<string,unknown>[],void>({query:()=>'reference/pool-types',providesTags:['PoolType']}),
        createPoolStatus: b.mutation<Record<string,unknown>,Record<string,unknown>>({query:body=>({url:'reference/pool-statuses',method:'POST',body}),invalidatesTags:['PoolStatus']}),
        createPoolType: b.mutation<Record<string,unknown>,Record<string,unknown>>({query:body=>({url:'reference/pool-types',method:'POST',body}),invalidatesTags:['PoolType']}),
        getPoolLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'pools/lookups', providesTags: ['Field','PoolStatus','PoolType'] }),
        createPool: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'pools', method: 'POST', body }), invalidatesTags: ['Pool'] }),
        getOrganizationUnitRecords: b.query<Record<string, unknown>[], void>({ query: () => 'organization-units', providesTags: ['OrganizationUnit'] }),
        getOrganizationUnitLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'organization-units/lookups', providesTags: ['OrgUnitType'] }),
        createOrganizationUnit: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'organization-units', method: 'POST', body }), invalidatesTags: ['OrganizationUnit'] }),
        getCrsRecords: b.query<Record<string, unknown>[], void>({ query: () => 'coordinate-reference-systems', providesTags: ['Crs'], keepUnusedDataFor: 300 }),
        getCrsLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'coordinate-reference-systems/lookups' }),
        createCrs: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'coordinate-reference-systems', method: 'POST', body }), invalidatesTags: ['Crs'] }),
        getFacilityFields: b.query<Record<string, unknown>[], void>({ query: () => 'facility-fields', providesTags: ['FacilityField'] }),
        getFacilityFieldLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'facility-fields/lookups', providesTags: ['Facility', 'Field'] }),
        createFacilityField: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'facility-fields', method: 'POST', body }), invalidatesTags: ['FacilityField'] }),
        getFields: b.query<Record<string, unknown>[], void>({ query: () => 'fields', providesTags: ['Field'] }),
        getFieldLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'fields/lookups', providesTags: ['Crs', 'FieldType'] }),
        createField: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'fields', method: 'POST', body }), invalidatesTags: ['Field'] }),
        getWells: b.query<Record<string, unknown>[], void>({ query: () => 'wells', providesTags: ['Well'] }),
        getWellLookups: b.query<Record<string, { id: number; label: string }[]>, void>({ query: () => 'wells/lookups' }),
        createWell: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'wells', method: 'POST', body }), invalidatesTags: ['Well'] }),
        getOrgUnitTypes: b.query<Record<string, unknown>[], void>({ query: () => 'reference/org-unit-types', providesTags: ['OrgUnitType'] }),
        createOrgUnitType: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'reference/org-unit-types', method: 'POST', body }), invalidatesTags: ['OrgUnitType'] }),

        getWellStatuses: b.query<Record<string, unknown>[], void>({ query: () => 'reference/well-statuses', providesTags: ['WellStatus'] }),
        getWellStatusTypeOptions: b.query<{ id: number; label: string }[], void>({ query: () => 'reference/well-statuses/types' }),
        createWellStatus: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'reference/well-statuses', method: 'POST', body }), invalidatesTags: ['WellStatus'] }),

        getWellStatusTypes: b.query<Record<string, unknown>[], void>({ query: () => 'reference/well-status-types', providesTags: ['WellStatusType', 'WellStatus'] }),
        getWellStatusSources: b.query<{ id: number; label: string }[], void>({ query: () => 'reference/well-status-types/sources' }),
        createWellStatusType: b.mutation<Record<string, unknown>, Record<string, unknown>>({ query: body => ({ url: 'reference/well-status-types', method: 'POST', body }), invalidatesTags: ['WellStatusType', 'WellStatus'] }),

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

export const { useGetWellStatusTypesQuery, useGetWellStatusSourcesQuery, useCreateWellStatusTypeMutation } = assetsApi


export const { useGetWellStatusesQuery, useGetWellStatusTypeOptionsQuery, useCreateWellStatusMutation } = assetsApi

export const { useGetOrgUnitTypesQuery, useCreateOrgUnitTypeMutation } = assetsApi

export const { useGetWellsQuery, useGetWellLookupsQuery, useCreateWellMutation } = assetsApi

export const { useGetFieldsQuery, useGetFieldLookupsQuery, useCreateFieldMutation } = assetsApi

export const { useGetFacilityFieldsQuery, useGetFacilityFieldLookupsQuery, useCreateFacilityFieldMutation } = assetsApi

export const { useGetCrsRecordsQuery, useGetCrsLookupsQuery, useCreateCrsMutation } = assetsApi

export const { useGetOrganizationUnitRecordsQuery, useGetOrganizationUnitLookupsQuery, useCreateOrganizationUnitMutation } = assetsApi

export const { useGetPoolRecordsQuery, useGetPoolLookupsQuery, useCreatePoolMutation } = assetsApi

export const { useGetEquipmentRecordsQuery, useGetEquipmentLookupsQuery, useCreateEquipmentMutation } = assetsApi

export const {useGetFieldTypeRecordsQuery,useGetFieldTypeLookupsQuery,useCreateFieldTypeMutation}=assetsApi

export const {useUpdateOrganizationUnitMutation,useDeleteOrganizationUnitMutation}=assetsApi

export const {useGetPoolStatusRecordsQuery,useCreatePoolStatusMutation}=assetsApi
export const {useGetPoolTypeRecordsQuery,useCreatePoolTypeMutation}=assetsApi
