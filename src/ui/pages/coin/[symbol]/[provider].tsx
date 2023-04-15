import Head from 'next/head';
import { Button, Container, LinearProgress } from '@mui/material';
import CoinInfo from '@/components/CoinInfo';
import { useRouter } from 'next/router';
import { useCoin } from '@/hooks/useCoin';

export default function CoinPage() {
  const router = useRouter();
  const { symbol, provider } = router.query;

  const { coin, isLoading, isError } = useCoin(symbol, provider);

  if (isLoading) {
    return <LinearProgress />;
  }

  return (
    <>
      {coin && (
        <CoinInfo
          provider={provider}
          coin={coin}
        />
      )}
    </>
  );
}
