<script setup>
import { Report } from '@/models/Report.js';

defineProps({ report: { type: Report, required: true } })
</script>


<template>
  {{ report.title }}

</template>


<style scoped></style>