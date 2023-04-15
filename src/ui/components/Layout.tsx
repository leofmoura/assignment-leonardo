import { Box, Container } from '@mui/material';

export default function Layout({ children }) {
  return (
    <Container maxWidth='md'>
      <Box sx={{ p: 2 }}>{children}</Box>
    </Container>
  );
}
