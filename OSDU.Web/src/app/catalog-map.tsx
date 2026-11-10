'use client'

import { useEffect, useRef } from 'react'
import L from 'leaflet'
import 'leaflet/dist/leaflet.css'

export type CatalogPoint = { id: string; name: string; dataset: string; x: number; y: number }

export default function CatalogMap({ points, selected, onSelect }: {
    points: CatalogPoint[]; selected: string; onSelect: (id: string) => void
}) {
    const container = useRef<HTMLDivElement>(null)
    const map = useRef<L.Map | null>(null)
    const markers = useRef<L.LayerGroup | null>(null)

    const circles = useRef(new Map<string, L.CircleMarker>())

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
        const layer = markers.current
        if (!instance || !layer) return
        layer.clearLayers()
        circles.current.clear()
        for (const point of points) {
            const label = document.createElement('span')
            label.textContent = point.name + ' · ' + point.dataset + ' · ' + point.y.toFixed(6) + ', ' + point.x.toFixed(6)
            const circle = L.circleMarker([point.y, point.x], { radius: 6, fillOpacity: 0.8 })
                .bindTooltip(label).on('click', () => onSelect(point.id)).addTo(layer)
            circles.current.set(point.id, circle)
        }
        if (points.length) instance.fitBounds(points.map(({x, y}) => [y, x] as L.LatLngTuple), {
            padding: [25, 25], maxZoom: 12,
        })
    }, [points, onSelect])

    useEffect(() => {
        const point = points.find(point => point.id === selected)
        circles.current.forEach((circle, id) => {
            circle.setStyle({ color: id === selected ? '#d97706' : '#1676be' })
            circle.setRadius(id === selected ? 9 : 6)
        })
        if (point && map.current) {
            map.current.panTo([point.y, point.x])
            circles.current.get(point.id)?.bringToFront().openTooltip()
        }
    }, [points, selected])

    return <div ref={container} role="region" aria-label="OpenStreetMap catalog map"
        style={{ height: 'clamp(380px, calc(100dvh - 270px), 880px)', width: '100%', position: 'relative', zIndex: 0 }} />
}
