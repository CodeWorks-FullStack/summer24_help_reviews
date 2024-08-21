<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({ restaurant: { type: Restaurant, required: true } })
</script>


<template>
  <h1>{{ restaurant.name }}</h1>
</template>


<style scoped></style>