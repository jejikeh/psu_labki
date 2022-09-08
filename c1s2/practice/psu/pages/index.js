import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import { Button } from '../components/Button'
import { Card } from '../components/Card'

export default function Home() {
  return (
    <><div className='welcome'>
      <h1 className="_wt">
      Добро пожаловать в
      </h1>
      <h1 className='_wb'>
      Паучий Государственный Университет
имени Ефросинии Полоцкой 
      </h1>
    <div>
        <Button>Университет</Button>
    </div>
    </div>
    <div className='Cards'>
    <div className='navbar'>
      <Card>Состоялось заседание комисси по предоставление скидок</Card>
      <Card>Просветительско-патриотическая акция</Card>
      <Card>Просветительско-патриотическая акция</Card>
    </div>
    </div>
      </>
  )
}
