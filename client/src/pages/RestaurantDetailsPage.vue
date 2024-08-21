<script setup>
import { restaurantsService } from '@/services/RestaurantsService.js';
import Pop from '@/utils/Pop.js';
import { watch } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

watch(() => route.params.restaurantId, () => {
  getRestaurantById(route.params.restaurantId)
}, { immediate: true })


async function getRestaurantById(restaurantId) {
  try {
    await restaurantsService.getRestaurantById(restaurantId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <h1>Restaurant details page</h1>
</template>


<style scoped></style>