import type { NextConfig } from 'next'
const config: NextConfig = {
  async rewrites() {
    return [{ source: '/api/:path*', destination: (process.env.OSDU_API_URL || 'http://localhost:5080') + '/api/:path*' }]
  },
}
export default config
