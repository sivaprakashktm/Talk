import { useEffect, useState } from 'react'
import './Welcome.css'

export function Welcome() {
  const [content, setContent] = useState<string>('')
  const [welcomeNamePrefix, setWelcomeNamePrefix] = useState<string>('')
  const [welcomeName, setWelcomeName] = useState<string>('')
  const [welcomeNamePlaceHoder, setWelcomeNamePlaceHolder] = useState<string>('')

  const changeWelcomeName = (event : React.ChangeEvent<HTMLInputElement, HTMLInputElement>) : void => {
    setWelcomeName(event.target.value)
  }

  useEffect(() => {
    setContent('Welcome to Talk!')
    setWelcomeNamePrefix('Hi! ')
    setWelcomeNamePlaceHolder('Your Name!')
  })

  return (
    <>
      <div className='welcomeComponent'>
        <div className='welcomeContent'>
          {content}
        </div>
        <div className='welcomeNameContainer'>
          <div className='welcomeNameContent'>
            {welcomeNamePrefix + ' ' + welcomeName}
          </div>
          <div className='welcomeNameInput'>
            <input className='welcomeInput form-control shadow' onChange={(event) => changeWelcomeName(event)} placeholder={welcomeNamePlaceHoder}>
            </input>
          </div>
        </div>
      </div>
    </>
  )
}
