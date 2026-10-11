// ClientApp/src/App.jsx
import { useState, useEffect } from 'react';

function App() {
    const [devices, setDevices] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const ac = new AbortController();
        //setLoading(true);

        fetch('/api/device', { signal: ac.signal })
            .then(res => {
                if (!res.ok) throw new Error(`HTTP ${res.status}`);
                return res.headers.get('content-type')?.includes('application/json')
                    ? res.json()
                    : res.text().then(t => { throw new Error('Non-JSON response: ' + t); });
            })
            .then(data => setDevices(data))
            .catch(err => {
                if (err.name !== 'AbortError') setError(err);
            })
            .finally(() => setLoading(false));

        return () => ac.abort();
    }, []);

    if (loading) return <div>Caricamento…</div>;
    if (error) return <div>Errore API: {String(error)}</div>;
    return (
        <div>
            {/* render devices */}
            {devices ? JSON.stringify(devices) : 'Nessun device'}
        </div>
    );
}

export default App;
