import { Talk } from './TalkComponents/TalkComponent/Talk'

import './../node_modules/bootstrap/dist/css/bootstrap.min.css'
import './../node_modules/bootstrap/dist/js/bootstrap.bundle.min.js'

import './App.css'

function App() {

  return (
    <>
      <section id='appTalkSection'>
        <div className='appTalkContainer'>
          <Talk />
        </div>
      </section>
    </>
  )
}

export default App
