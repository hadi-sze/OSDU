'use client'

import { useEffect, useRef } from 'react'
import L from 'leaflet'
import 'leaflet/dist/leaflet.css'

import { catalogKey, type CatalogIdentity, type CatalogPoint } from '../lib/catalog-types'

const emptyPoints: CatalogPoint[] = []

export default function CatalogMap({ points = emptyPoints, selected, onSelect, height, label }: {
    height?: number; label?: string; points?: CatalogPoint[]; selected: string; onSelect: (point: CatalogIdentity) => void
}) {
    const container = useRef<HTMLDivElement>(null)
    const map = useRef<L.Map | null>(null)
    const markers = useRef<L.LayerGroup | null>(null)

    const onSelectRef = useRef(onSelect)
    useEffect(() => { onSelectRef.current = onSelect }, [onSelect])

    useEffect(() => {
        if (!container.current) return
        const instance = L.map(container.current, { scrollWheelZoom: false }).setView([25, 0], 2)
        L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
        }).addTo(instance)
        map.current = instance
        markers.current = L.layerGroup().addTo(instance)
        const observer = new ResizeObserver(() => instance.invalidateSize())
        observer.observe(container.current)
        return () => {
            observer.disconnect()
            instance.remove()
            map.current = null
            markers.current = null
        }
    }, [])

    useEffect(() => {
        const instance = map.current
        if (instance && points.length) instance.fitBounds(points.map(({ x, y }) => [y, x] as L.LatLngTuple), {
            padding: [25, 25], maxZoom: 12,
        })
    }, [points])

    useEffect(() => {
        const instance = map.current
        const layer = markers.current
        if (!instance || !layer) return
        const active = points.find(point => catalogKey(point) === selected)
        function draw() {
            if (!instance || !layer) return
            layer.clearLayers()
            const buckets = new Map<string, CatalogPoint[]>()
            for (const point of points) {
                const pixel = instance.project([point.y, point.x])
                const key = point === active ? 'selected' : Math.floor(pixel.x / 44) + ':' + Math.floor(pixel.y / 44)
                const bucket = buckets.get(key)
                if (bucket) bucket.push(point)
                else buckets.set(key, [point])
            }
            for (const bucket of buckets.values()) {
                const point = bucket[0]
                if (bucket.length > 1) {
                    const positions = bucket.map(({ x, y }) => [y, x] as L.LatLngTuple)
                    const bounds = L.latLngBounds(positions)
                    const label = document.createElement('span')
                    label.textContent = String(bucket.length)
                    const cluster = L.marker(bounds.getCenter(), {
                        title: bucket.length + ' records',
                        icon: L.divIcon({ html: label, className: 'osdu-map-cluster', iconSize: [34, 34] }),
                    }).addTo(layer)
                    cluster.on('click', () => {
                        if (instance.getZoom() < 19 && !bounds.getSouthWest().equals(bounds.getNorthEast())) {
                            instance.fitBounds(bounds, { padding: [48, 48], maxZoom: 19 })
                            return
                        }
                        const list = document.createElement('div')
                        list.style.maxHeight = '220px'
                        list.style.overflowY = 'auto'
                        for (const record of bucket) {
                            const button = document.createElement('button')
                            button.type = 'button'
                            button.style.display = 'block'
                            button.textContent = record.name + ' · ' + record.dataset
                            button.onclick = () => onSelectRef.current(record)
                            list.append(button)
                        }
                        cluster.bindPopup(list).openPopup()
                    })
                    continue
                }
                const label = document.createElement('span')
                label.textContent = point.name + ' · ' + point.dataset + ' · ' + point.y.toFixed(6) + ', ' + point.x.toFixed(6)
                const circle = L.circleMarker([point.y, point.x], {
                    radius: point === active ? 9 : 6, color: point === active ? '#d97706' : '#1676be', fillOpacity: 0.8,
                }).bindTooltip(label).on('click', () => onSelectRef.current(point)).addTo(layer)
                if (point === active) circle.bringToFront().openTooltip()
            }
        }
        draw()
        if (active) instance.panTo([active.y, active.x])
        instance.on('zoomend', draw)
        return () => { instance.off('zoomend', draw) }
    }, [points, selected])

    return <><style>{`.osdu-map-cluster { display: grid; place-items: center; border-radius: 50%;
        background: #1369a8; border: 2px solid white; color: white; font-weight: 700; }`}</style><div ref={container} role="region" aria-label={label ?? "OpenStreetMap catalog map"}
        style={{ height: height ?? 'clamp(380px, calc(100dvh - 270px), 880px)', width: '100%', position: 'relative', zIndex: 0 }} /></>
}
