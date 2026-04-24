import { useEffect, useState } from 'react'
import './Welcome.css'

export function Welcome() {
  const [content, setContent] = useState('')

  useEffect(() => {
    setContent('Welcome to Talk!')
  })

  return (
    <>
      <div className='welcomeComponent'>
        <div className='welcomeContent'>
          {content}
        </div>
      </div>
    </>
  )
}
