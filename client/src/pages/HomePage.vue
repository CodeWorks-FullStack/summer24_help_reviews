<script setup>
import { AppState } from '@/AppState.js';
import { restaurantsService } from '@/services/RestaurantsService.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const restaurants = computed(() => AppState.restaurants)

onMounted(getRestaurants)

async function getRestaurants() {
  try {
    await restaurantsService.getRestaurants()
  } catch (error) {
    Pop.error(error)
  }
}

</script>

<template>
  <h1>Restaurants</h1>
</template>

<style scoped lang="scss"></style>
