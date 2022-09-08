import Navbar from '../components/Navbar'
import '../styles/globals.css'
import Head from 'next/head'
import { Footer } from '../components/Footer'

function MyApp({ Component, pageProps }) {
  return (
  <>
  <div>
    <Head>
      <link rel="preconnect" href="https://fonts.googleapis.com"/>
      <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
      <link href="https://fonts.googleapis.com/css2?family=Inter&display=swap" rel="stylesheet"/>
    </Head>
  </div>
  <Navbar/>
  <Component {...pageProps} />
  <Footer/>
  </>
  )
}

export default MyApp
