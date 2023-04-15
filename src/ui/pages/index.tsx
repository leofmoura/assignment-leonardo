import { Icon, LinearProgress, Stack, Typography } from '@mui/material';
import { Category } from '@/models/category';
import CategoryList from '@/components/CategoryList';
import { useCoins } from '@/hooks/useCoins';
import { useEffect, useState } from 'react';
import CoinGrid from '@/components/CoinGrid';

export default function Home({ categories }: { categories: Category[] }) {
  const [selectedCategory, setSelectedCategory] = useState('');

  const { coins, isLoading, isError } = useCoins(selectedCategory);

  useEffect(() => {
    setSelectedCategory(categories[0].id);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <>
      <Stack
        direction='row'
        justifyContent={'center'}
        sx={{ mb: 1 }}
      >
        <Typography variant='h3'>Coin Manager</Typography>
      </Stack>
      <Stack sx={{ minHeight: 15 }}>{isLoading && <LinearProgress />}</Stack>

      <CategoryList
        selectedCategory={selectedCategory}
        onCategorySelected={setSelectedCategory}
        categories={categories}
      />

      <CoinGrid coins={coins} />

      {isError && <Stack>Oh No! Something went wront!</Stack>}
    </>
  );
}

export async function getServerSideProps() {
  // Using the power of server to load data and avoid networking to transfer data
  // I like remix js very much because this patter is so natural and relies on web fundamentals
  const url = `${process.env.APIURL}/categories`;
  const res = await fetch(url);
  const data = await res.json();
  return { props: { categories: data } };
}
