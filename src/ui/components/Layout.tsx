import { Box, Container } from '@mui/material';

export default function Layout({ children }) {
  return (
    <Container maxWidth='lg'>
      <Box sx={{ bgcolor: '#cfe8fc', height: '100vh', p: 2 }}>{children}</Box>
    </Container>
  );
}
