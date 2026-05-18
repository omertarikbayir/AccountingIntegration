import { useState } from 'react'
import './App.css'

interface Job {
  id: string
  name: string
  status: 'Queued' | 'Processing' | 'Succeeded' | 'Failed'
  progress: number
}

function App() {
  const [jobs, setJobs] = useState<Job[]>([
    { id: '1', name: 'Excel Import - 2026-05', status: 'Succeeded', progress: 100 },
    { id: '2', name: 'KDV Declaration Generation', status: 'Processing', progress: 65 },
    { id: '3', name: 'PDF OCR Invoice Batch', status: 'Queued', progress: 0 },
  ])

  const [kdvPreview, setKdvPreview] = useState('')

  const fetchKdvPreview = async () => {
    // In real app call backend API
    setKdvPreview(`<?xml version="1.0"?>
<KdvBeyanname>
  <Donem>2026-05</Donem>
  <ToplamTutar>125000</ToplamTutar>
  <Kdv18>22500</Kdv18>
</KdvBeyanname>`)
  }

  return (
    <div className="app">
      <header>
        <h1>Accounting Integration Dashboard</h1>
        <nav>
          <a href="http://localhost:5000/hangfire" target="_blank">Hangfire Dashboard</a>
          <a href="http://localhost:5000/swagger" target="_blank">API Docs</a>
        </nav>
      </header>

      <main>
        <section className="jobs">
          <h2>Background Jobs</h2>
          <table>
            <thead>
              <tr>
                <th>Job</th>
                <th>Status</th>
                <th>Progress</th>
              </tr>
            </thead>
            <tbody>
              {jobs.map(job => (
                <tr key={job.id}>
                  <td>{job.name}</td>
                  <td className={job.status.toLowerCase()}>{job.status}</td>
                  <td>
                    <div className="progress-bar">
                      <div style={{ width: `${job.progress}%` }}></div>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </section>

        <section className="kdv">
          <h2>KDV Declaration Preview</h2>
          <button onClick={fetchKdvPreview}>Generate Preview</button>
          {kdvPreview && (
            <pre className="xml-preview">{kdvPreview}</pre>
          )}
        </section>
      </main>

      <footer>
        <p>Accounting Integration • React + .NET 8 • 2026</p>
      </footer>
    </div>
  )
}

export default App
