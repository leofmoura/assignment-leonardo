import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  Stack,
  Typography,
} from '@mui/material';
import Link from 'next/link';

export interface CoinInfoProps {
  provider: String;
  symbol: String;
}

export default function CoinInfo({ provider, symbol }: CoinInfoProps) {
  return (
    <>
      <Stack
        direction='row'
        spacing={2}
      >
        <Link href='/'>
          <Button>Back</Button>
        </Link>
      </Stack>

      <Box
        component='span'
        sx={{ m: 1, border: '1px dashed grey' }}
      >
        {provider} - {symbol}
      </Box>
    </>
  );
}
