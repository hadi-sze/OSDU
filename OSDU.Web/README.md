# OSDU frontend

Next.js App Router, TypeScript, Material UI, Redux Toolkit and RTK Query.

Run npm install, npm run dev; open http://localhost:3000. Run the .NET API on port 5080. Set OSDU_API_URL in .env.local to override the server-side API proxy target.

Production: npm run build then npm start. Assets support list, search, create, edit and confirmed deletion. Master data screens identify pending backend endpoints. Redux stores are created per provider instance; RTK Query manages API caching and invalidation.
