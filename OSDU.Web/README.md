# OSDU frontend

Next.js App Router, TypeScript, Material UI, Redux Toolkit and RTK Query.

Run npm install, npm run dev; open http://localhost:3000. Run the .NET API on port 5080. Set OSDU_API_URL in .env.local to override the server-side API proxy target.

Production: npm run build then npm start. Assets support list, search, create, edit and confirmed deletion. Master data screens identify pending backend endpoints. Redux stores are created per provider instance; RTK Query manages API caching and invalidation.

## Project color theme
Shared palette: src/app/palette.ts. Theme configuration: src/app/theme.ts.
Ten semantic colors: primary, secondary, success, warning, error, info, neutral, violet, cyan, pink.
Every palette includes shades 50 through 900. Both Material UI and Joy UI use this source.
Joy's built-in danger color is an alias of error.
Use color="violet", color="cyan", color="pink", or color="neutral" on supported Material components.
Use sx={{ color: 'violet.main' }} on Material layout components, or theme.vars.palette.violet[500] for Joy.
Components without a color prop use theme tokens through sx.
Light and dark mappings and component defaults are centralized in theme.ts.
