<script setup>
import { AppState } from '@/AppState.js';
import RestaurantCard from '@/components/globals/RestaurantCard.vue';
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
  <div class="container">
    <section class="row my-3">
      <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-12 col-md-4 mb-3">
        <RestaurantCard :restaurant="restaurant" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss"></style>
