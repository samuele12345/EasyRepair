import react, { reactCompilerPreset } from '@vitejs/plugin-react'
import babel from '@rolldown/plugin-babel'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
    plugins: [
        react(),
        babel({ presets: [reactCompilerPreset()] }) // abilita il React Compiler, che può ottimizzare automaticamente il rendering dei componenti e la gestione delle dipendenze.
    ],
    server: {
        proxy: {
            '/api': { // utilizzando /api nelle nelle api request, queste vengono inviate direttamente al backend
                target: 'https://localhost:7099', // indirizzo server backend
                secure: false
            }
        }
    }
})


/*
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
    plugins: [react()],
    server: {
        proxy: {
            '/api': {
                target: 'https://localhost:7099',
                secure: false
            }
        }
    }
})



*/