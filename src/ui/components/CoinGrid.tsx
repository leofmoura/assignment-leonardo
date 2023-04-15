import { ApiProviders } from '@/models/api-providers';
import { Avatar, Grid, Link, Stack, Typography } from '@mui/material';
import CoinLink from './CoinLink';

const CoinGrid = (props) => {
  const coins = props.coins;

  const GridHeader = () => {
    return (
      coins && (
        <Grid
          container
          marginTop={2}
          display='flex'
          justifyContent='center'
          alignItems='center'
        >
          <Grid
            item
            xs={4}
          >
            Price Increase (24h)
          </Grid>
          <Grid
            item
            xs={2}
          >
            <Stack direction={'column'}>
              <span>(Primary)</span>
              <span>KuCoin</span>
            </Stack>
          </Grid>
          <Grid
            item
            xs={2}
          >
            <Stack direction={'column'}>
              <span>Gate.io</span>
            </Stack>
          </Grid>
        </Grid>
      )
    );
  };

  const GridDetails = () => {
    return coins.map((coin) => (
      <Grid
        key={coin.symbol}
        container
        display='flex'
        justifyContent='center'
        alignItems='center'
      >
        <Grid
          item
          xs={1}
        >
          <Avatar
            sx={{ width: 32, height: 32 }}
            src={coin.urlImage}
          />
        </Grid>
        <Grid
          item
          xs={3}
        >
          <Stack direction={'column'}>
            <Typography
              variant='overline'
              sx={{ fontWeight: 700, fontSize: 20 }}
            >
              {coin.symbolDisplay}
            </Typography>
            <Typography>{coin.name}</Typography>
          </Stack>
        </Grid>
        <Grid
          item
          xs={2}
        >
          <CoinLink
            coin={coin}
            provider={ApiProviders.Primary}
          />
        </Grid>
        <Grid
          item
          xs={2}
        >
          <CoinLink
            coin={coin}
            provider={ApiProviders.Secondary}
          />
        </Grid>
      </Grid>
    ));
  };

  return (
    <>
      {coins && <GridHeader />}
      {coins && <GridDetails />}
    </>
  );
};

export default CoinGrid;
