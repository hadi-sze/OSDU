export const filterKeys = ['operator', 'status', 'field'] as const
export type CatalogFilters = Record<(typeof filterKeys)[number], string>
export type CatalogParams = CatalogFilters & { dataset: string; search: string; hasLocation: boolean }
export type CatalogIdentity = { id: number; name: string; dataset: string }
export type CatalogRow = CatalogIdentity & {
    identifier: string; field: string; operator: string; isActive: boolean
    wellUwi?: string; drillTd?: number
}
export type CatalogPage = { total: number; page: number; size: number; rows: CatalogRow[] }
export type CatalogPoint = CatalogIdentity & { x: number; y: number }
export type CatalogMapData = { total: number; mapped: number; points: CatalogPoint[] }
export type CatalogFacets = Record<keyof CatalogFilters, { value: string; count: number }[]>
export const catalogKey = ({ dataset, id }: CatalogIdentity) => dataset + ':' + id
