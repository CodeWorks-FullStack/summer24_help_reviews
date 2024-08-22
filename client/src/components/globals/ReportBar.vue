<script setup>
import ReportModal from './ReportModal.vue';
</script>


<template>
  <div class="p-1">
    <img class="img-fluid"
      src="https://cdn.discordapp.com/attachments/1251220896035901470/1276246026394796072/file-n34wUMmn9gH6DP0ytnxdZfXt.webp?ex=66c8d43c&is=66c782bc&hm=a7fef826de2ebd535d0e3eb54dd3c19d968525b2315d4c1b4e15519720148eaf&"
      alt="Best mouse logo ever">
    <div class="text-center">
      <p class="fs-1 text-success"><b>Help Reviews</b></p>
      <button class="btn btn-success rounded-pill text-light w-100 fs-2" data-bs-toggle="modal"
        data-bs-target="#reportModal">REPORT!</button>
    </div>
  </div>

  <ReportModal />
</template>


<style scoped></style>