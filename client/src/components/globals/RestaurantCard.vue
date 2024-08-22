<script setup>
import { Restaurant } from '@/models/Restaurant.js';

defineProps({ restaurant: { type: Restaurant, required: true } })
</script>


<template>
  <RouterLink :to="{ name: 'Restaurant Details', params: { restaurantId: restaurant.id } }">
    <div class="shadow position-relative">
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
            {{ restaurant.reportCount }} reports
          </p>
        </div>
      </div>
      <i v-if="restaurant.isShutdown" class="mdi mdi-close display-1 text-danger" title="CURRENTLY CLOSED"></i>
    </div>
  </RouterLink>
</template>


<style scoped>
img {
  height: 28dvh;
  width: 100%;
  object-fit: cover;
}

a {
  text-decoration: unset;
  color: unset;
}

.mdi-close {
  position: absolute;
  top: 0;
  right: 0;
}
</style>