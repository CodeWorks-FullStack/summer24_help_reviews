<script setup>
import ReportForm from './ReportForm.vue';
</script>


<template>
  <div class="modal fade" id="reportModal" tabindex="-1" aria-labelledby="reportModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="reportModalLabel">Create Report</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <ReportForm />
        </div>
      </div>
    </div>
  </div>
</template>


<style scoped></style>