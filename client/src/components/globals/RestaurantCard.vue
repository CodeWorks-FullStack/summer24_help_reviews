<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({ restaurant: { type: Restaurant, required: true } })
</script>


<template>
  <div class="shadow">
    <img :src="restaurant.imgUrl" alt="Picture of the restaurant">
    <div class="p-3">
      <p class="text-success fs-4"><b>{{ restaurant.name }}</b></p>
      <p>{{ restaurant.description }}</p>
      <div class="d-flex justify-content-between">
        <p class="mb-0 d-flex align-items-center">
          <Icon name="account-multiple" class="fs-1 text-success" />
          {{ restaurant.visits }} recent visits
        </p>
        <p class="mb-0 d-flex align-items-center">
          <Icon name="file" class="fs-1 text-success" />
          0 reports
        </p>
      </div>
    </div>
  </div>
</template>


<style scoped>
img {
  height: 28dvh;
  width: 100%;
  object-fit: cover;
}
</style>