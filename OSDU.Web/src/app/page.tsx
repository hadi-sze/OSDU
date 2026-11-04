import { cookies } from 'next/headers'
import { redirect } from 'next/navigation'
import Dashboard from './dashboard'
export const dynamic = 'force-dynamic'
export default async function Page() {
    const cookie = (await cookies()).toString()
    let authenticated = false
    try {
        const response = await fetch((process.env.OSDU_API_URL || 'http://localhost:5080') + '/api/auth/me', { headers: { cookie }, cache: 'no-store' })
        authenticated = response.ok
    } catch { }
    if (!authenticated) redirect('/login')
    return <Dashboard />
}
