import { useCoin } from '@/hooks/useCoin';
import {
  Avatar,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  Divider,
  Grid,
  LinearProgress,
  Link,
  Stack,
  Typography,
} from '@mui/material';

export interface CoinInfoProps {
  provider: String;
  coin: import('@/models/coin').Coin;
}

export default function CoinInfo({ coin, provider }: CoinInfoProps) {
  return (
    <>
      <Stack
        direction='row'
        spacing={2}
      >
        <Link
          href='/'
          underline='none'
        >
          <Button variant='outlined'>Back</Button>
        </Link>
      </Stack>
      <Typography
        variant='h4'
        sx={{ mb: 2, mt: 2 }}
      >
        Coin Details
      </Typography>
      <Divider />
      <Grid
        spacing={10}
        container
        display='flex'
        justifyContent='center'
        alignItems='center'
      >
        <Grid item>
          <Avatar
            sx={{ width: 32, height: 32 }}
            src={coin.urlImage}
          />
        </Grid>
        <Grid item>
          <Stack direction={'column'}>
            <Typography
              variant='overline'
              sx={{ fontWeight: 700, fontSize: 20 }}
            >
              {coin.symbolDisplay}
            </Typography>
            <Typography>-</Typography>
          </Stack>
        </Grid>
        <Grid item>
          <Stack direction={'column'}>
            <Typography
              variant='overline'
              sx={{ fontWeight: 700 }}
            >
              Provider
            </Typography>
            <Typography>{provider}</Typography>
          </Stack>
        </Grid>
        <Grid item>
          <Stack direction={'column'}>
            <Typography>Price</Typography>
            <Typography>{coin.price}</Typography>
          </Stack>
        </Grid>
        <Grid item>
          <Stack direction={'column'}>
            <Typography>Price Change</Typography>
            <Typography
              sx={{
                textDecoration: 'none',
                ...(coin.priceChange < 0 && {
                  color: 'red',
                }),
                ...(coin.priceChange > 0 && {
                  color: 'green',
                }),
              }}
            >
              {coin.priceChange} {coin.priceChange && '%'}
            </Typography>
          </Stack>
        </Grid>
        <Grid item>
          <Stack direction={'column'}>
            <Typography>Market Cap.</Typography>
            <Typography>{coin.marketCap}</Typography>
          </Stack>
        </Grid>
        <Grid item>
          <Stack direction={'column'}>
            <Typography>Price Difference</Typography>
            <Typography>{coin.priceDiff}</Typography>
          </Stack>
        </Grid>
      </Grid>
    </>
  );
}
