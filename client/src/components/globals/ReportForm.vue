<script setup>
import { AppState } from '@/AppState.js';
import { computed, ref } from 'vue';

const restaurants = computed(() => AppState.restaurants)

const editableReportData = ref({
  title: '',
  body: '',
  pictureOfDisgust: '',
  restaurantId: 0
})
</script>


<template>
  <form>
    <select v-model="editableReportData.restaurantId" class="form-select mb-3" aria-label="Choose A Restaurant"
      required>
      <option selected value="0" disabled>Choose a restaurant</option>
      <option v-for="restaurant in restaurants" :key="restaurant.id" :value="restaurant.id">
        {{ restaurant.name }}
      </option>
    </select>

    <div class="mb-3">
      <label for="title" class="form-label">Report Title</label>
      <input v-model="editableReportData.title" type="text" class="form-control" id="title" aria-describedby="titleHelp"
        required maxlength="255">
      <div id="titleHelp" class="form-text">make it eye catching...</div>
    </div>

    <div class="mb-3">
      <label for="body" class="form-label">Report Body</label>
      <textarea v-model="editableReportData.body" class="form-control" id="body" aria-describedby="bodyHelp" required
        maxlength="65535"></textarea>
      <div id="bodyHelp" class="form-text">make it juicy...</div>
    </div>

    <div class="mb-3">
      <label for="pictureOfDisgust" class="form-label">Report Picture Of Disgust</label>
      <input v-model="editableReportData.pictureOfDisgust" type="url" class="form-control" id="pictureOfDisgust"
        aria-describedby="pictureOfDisgustHelp" maxlength="3000">
      <div id="pictureOfDisgustHelp" class="form-text">make it disgusting...</div>
    </div>

    <div class="text-end">
      <button class="btn btn-success" type="submit">Submit</button>
    </div>
  </form>
</template>


<style scoped></style>