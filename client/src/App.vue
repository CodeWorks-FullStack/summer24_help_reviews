<script setup>
import { AppState } from './AppState.js';
import ReportBar from './components/globals/ReportBar.vue';
import Navbar from './components/Navbar.vue'
</script>

<template>
  <header>
    <Navbar />
  </header>
  <main class="container-fluid">
    <div class="row">
      <div class="col-md-2">
        <ReportBar />
      </div>
      <div class="col-md-10">
        <router-view />
      </div>
    </div>
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
