import { Button, Stack } from '@mui/material';
import Link from 'next/link';
import { Category } from '@/models/category';
import { useState } from 'react';

const CategoryList = (props) => {
  const onCategorySelected = (e) => {
    const selectedId = e.target.dataset.id;
    props.onCategorySelected(selectedId);
  };

  return (
    <Stack
      direction='row'
      spacing={2}
      flex
      justifyContent={'center'}
    >
      {props?.categories?.map((category) => (
        <Button
          variant={
            props.selectedCategory === category.id ? 'contained' : 'outlined'
          }
          data-id={category.id}
          onClick={onCategorySelected}
          key={category.id}
        >
          {category.name}
        </Button>
      ))}
    </Stack>
  );
};

export default CategoryList;
