import useSWR from 'swr';
import { fetcher } from './fetcher';

export function useCoins(categoryId: string) {
  const { data, error, isLoading } = useSWR(
    categoryId
      ? `${process.env.NEXT_PUBLIC_APIURL}/categories/${categoryId}/coins`
      : null,
    fetcher
  );

  return {
    coins: data,
    isLoading,
    isError: error,
  };
}
