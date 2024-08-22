<script setup>
import { AppState } from '@/AppState.js';
import { reportsService } from '@/services/ReportsService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { computed, ref } from 'vue';

const restaurants = computed(() => AppState.restaurants)

const editableReportData = ref({
  title: '',
  body: '',
  pictureOfDisgust: '',
  restaurantId: 0
})

async function createReport() {
  try {
    await reportsService.createReport(editableReportData.value)
    editableReportData.value = {
      title: '',
      body: '',
      pictureOfDisgust: '',
      restaurantId: 0
    }
    Modal.getOrCreateInstance('#reportModal').hide()
    Pop.success('Report submitted!')
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <form @submit.prevent="createReport()">
    <div class="mb-3">
      <label for="restaurantId">Choose A Restaurant</label>
      <select id="restaurantId" v-model="editableReportData.restaurantId" class="form-select "
        aria-label="Choose A Restaurant" required>
        <option selected value="0" disabled>Choose a restaurant</option>
        <option v-for="restaurant in restaurants" :key="restaurant.id" :value="restaurant.id">
          {{ restaurant.name }}
        </option>
      </select>
    </div>

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