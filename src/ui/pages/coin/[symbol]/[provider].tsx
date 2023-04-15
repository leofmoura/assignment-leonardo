import Head from 'next/head';
import { Button, Container } from '@mui/material';
import CoinInfo from '@/components/CoinInfo';
import { useRouter } from 'next/router';

export default function CoinPage() {
  const router = useRouter();
  const { symbol, provider } = router.query;
  return (
    <>
      <main>
        <CoinInfo
          provider={provider}
          symbol={symbol}
        />
      </main>
    </>
  );
}
