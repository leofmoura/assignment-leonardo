import { ApiProviders } from '@/models/api-providers';
import { Link, Stack, Typography } from '@mui/material';

export default function CoinLink({ provider, coin, renderLink }) {
  const isPrimary = provider === ApiProviders.Primary;
  console.log(provider);
  console.log(isPrimary);
  const fields = {
    provider: provider,
    symbol: isPrimary ? coin.principalSymbolCode : coin.secondarySymbolCode,
    price: isPrimary ? coin.principalPrice : coin.secondaryPrice,
    priceChange: isPrimary
      ? coin.principalPriceChange
      : coin.secondaryPriceChange,
  };

  return (
    <Link
      underline='none'
      href={`/coin/${fields.symbol}/${ApiProviders.Primary}`}
    >
      <Stack direction={'column'}>
        <Typography>{fields.price}</Typography>
        <Typography
          sx={{
            textDecoration: 'none',
            ...(fields.priceChange < 0 && {
              color: 'red',
            }),
            ...(fields.priceChange > 0 && {
              color: 'green',
            }),
          }}
        >
          {fields.priceChange} {fields.priceChange && '%'}
        </Typography>
      </Stack>
    </Link>
  );
}
