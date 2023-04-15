import Head from 'next/head';
import { Button, Container } from '@mui/material';
import Link from 'next/link';

export default function Home() {
  return (
    <>
      <main>
        <Link href='/coin/1/primary'>
          <Button variant='outlined'>Primary - 1</Button>
        </Link>
        <Link href='/coin/1/secondary'>
          <Button variant='outlined'>Secondary - 2</Button>
        </Link>
        <Link href='/coin/2/primary'>
          <Button variant='outlined'>Primary - 2</Button>
        </Link>
      </main>
    </>
  );
}
