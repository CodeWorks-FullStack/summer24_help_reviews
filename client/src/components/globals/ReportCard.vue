<script setup>
import { Report } from '@/models/Report.js';

defineProps({ report: { type: Report, required: true } })
</script>


<template>
  <div class="container bg-light shadow p-3">
    <div class="row justify-content-end mb-3">
      <div v-if="report.pictureOfDisgust" class="col-12 col-md-4 text-center order-3 order-md-0">
        <a :href="report.pictureOfDisgust" target="_blank">
          <img class="img-of-disgust" :src="report.pictureOfDisgust" alt="Probably some gross looking food">
        </a>
      </div>
      <div class="col-6 col-md-4">
        <p class="text-success text-center fs-4"><b>"{{ report.title }}"</b></p>
      </div>
      <div class="col-6 col-md-4 d-flex justify-content-end">
        <div class="d-flex gap-2">
          <div class="text-end">
            <p class="mb-1"><b>{{ report.creator.name }}</b></p>
            <p>{{ report.createdAt.toLocaleDateString() }}</p>
          </div>
          <img :src="report.creator.picture" :alt="report.creator.name" class="creator-img">
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <p>{{ report.body }}</p>
      </div>
    </div>
  </div>
</template>


<style scoped>
.creator-img {
  height: 10dvh;
  aspect-ratio: 1/1;
  border-radius: 50%;
  object-fit: cover;
}

.img-of-disgust {
  height: 15dvh;
  object-fit: cover;
}
</style>