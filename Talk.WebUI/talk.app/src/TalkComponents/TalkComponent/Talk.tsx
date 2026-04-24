
import { Welcome } from '../WelcomeComponent/Welcome'

import reactLogo from './../../assets/react.svg'
import viteLogo from './../../assets/vite.svg'
import heroImg from './../../assets/hero.png'
import './Talk.css'

export function Talk() {

  return (
    <>
      <section id="center">
        <div className="hero">
          <img src={heroImg} className="base" width="170" height="179" alt="" />
          <img src={reactLogo} className="framework" alt="React logo" />
          <img src={viteLogo} className="vite" alt="Vite logo" />
        </div>          
      </section>

     
      <section id="welcomeSection">
        <div className="talklWelcomeContainer">
          <Welcome/>
        </div>
      </section>
    </>
  )
}