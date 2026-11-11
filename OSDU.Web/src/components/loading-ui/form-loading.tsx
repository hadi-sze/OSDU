'use client'

import { OrbitRing } from './orbit-ring'
import styles from './form-loading.module.css'

export default function FormLoading({ label = 'Loading form…' }: { label?: string }) {
    return <div role="status" className={styles.loading}>
        <div className={styles.caption}>
            <OrbitRing className="size-6" aria-hidden="true" />
            <span>{label}</span>
        </div>
        <div aria-hidden="true" className={styles.fields}>
            {[0, 1, 2, 3].map(index => <div key={index}>
                <div className={styles.label} />
                <div className={styles.input} />
            </div>)}
        </div>
    </div>
}
