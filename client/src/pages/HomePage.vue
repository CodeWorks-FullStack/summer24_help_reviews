<script setup>
import { restaurantsService } from '@/services/RestaurantsService.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';


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
