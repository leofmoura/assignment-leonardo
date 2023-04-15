import useSWR from 'swr';
import { fetcher } from './fetcher';

export function useCoin(symbol: string, provider: string) {
  const { data, error, isLoading } = useSWR(
    symbol || provider ? `${process.env.NEXT_PUBLIC_APIURL}/coins/${symbol}/${provider}` : null,
    fetcher
  );

  return {
    coin: data,
    isLoading,
    isError: error,
  };
}
