<script setup>
import { AppState } from '@/AppState.js';
import ReportCard from '@/components/globals/ReportCard.vue';
import { reportsService } from '@/services/ReportsService.js';
import { restaurantsService } from '@/services/RestaurantsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute()

const router = useRouter()

const restaurant = computed(() => AppState.activeRestaurant)

const account = computed(() => AppState.account)

const reports = computed(() => AppState.reports)

watch(() => route.params.restaurantId, () => {

  getRestaurantById(route.params.restaurantId)
  getReportsByRestaurantId(route.params.restaurantId)

}, { immediate: true })


async function getRestaurantById(restaurantId) {
  try {
    await restaurantsService.getRestaurantById(restaurantId)
  }
  catch (error) {
    Pop.meow(error)
    if (error.response.data.includes('😉')) {
      router.push({ name: 'Home' })
    }
  }
}

async function getReportsByRestaurantId(restaurantId) {
  try {
    await reportsService.getReportsByRestaurantId(restaurantId)
  }
  catch (error) {
    Pop.meow(error);
  }
}

async function destroyRestaurant(restaurantId) {
  try {
    const wantsToDestroy = await Pop.confirm(`Are you sure that you want to close down ${restaurant.value.name}?`)
    if (!wantsToDestroy) return
    await restaurantsService.destroyRestaurant(restaurantId)
    router.push({ name: 'Home' })
  } catch (error) {
    Pop.error(error)
  }
}

async function updateRestaurant(restaurantId) {
  try {
    const wantsToUpdate = await Pop.confirm(`Are you sure that you want to ${restaurant.value.isShutdown ? 'open' : 'shut down'} the ${restaurant.value.name}?`, 'ARE YOU REALLY SURE????', 'Yes I am really sure.', 'question')

    if (!wantsToUpdate) return

    const restaurantData = { isShutdown: !restaurant.value.isShutdown }

    await restaurantsService.updateRestaurant(restaurantId, restaurantData)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div v-if="restaurant" class="container-fluid">
    <section class="row">
      <div class="col-12">
        <div class="p-5">
          <div class="d-flex justify-content-between">
            <h1 class="text-success">{{ restaurant.name }}</h1>
            <div v-if="restaurant.isShutdown" class="bg-danger text-light fs-2 px-3">
              <p class="mb-0"><i class="mdi mdi-close-circle"></i> CURRENTLY SHUTDOWN</p>
            </div>
          </div>
          <div class="bg-light shadow">
            <img :src="restaurant.imgUrl" alt="Picture of the restaurant" class="cover-img">
            <div class="p-3">
              <p class="mb-5">{{ restaurant.description }}</p>
              <div class="d-block d-md-flex justify-content-between">
                <div class="d-flex gap-5">
                  <p class="d-flex align-items-center gap-3">
                    <i class="mdi mdi-account-multiple fs-2 text-success"></i>
                    <b>{{ restaurant.visits }}</b>
                    <span>recent visits</span>
                  </p>
                  <p class="d-flex align-items-center gap-3">
                    <i class="mdi mdi-file-multiple fs-2 text-success"></i>
                    <!-- NOTE easier to do this here rather than another sql count -->
                    <b>{{ reports.length }}</b>
                    <span>reports</span>
                  </p>
                </div>

                <div v-if="restaurant.creatorId == account?.id" class="d-flex gap-3 align-items-center">
                  <button @click="updateRestaurant(restaurant.id)" class="btn fs-4"
                    :class="restaurant.isShutdown ? 'btn-success' : 'btn-warning'">
                    <i class="mdi" :class="restaurant.isShutdown ? 'mdi-door-open' : 'mdi-door-closed'"></i> {{
                      restaurant.isShutdown ? 'Open' : 'Close' }}
                  </button>
                  <button @click="destroyRestaurant(restaurant.id)" class="btn btn-danger fs-4">
                    <i class="mdi mdi-delete-forever"></i> Delete
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="row">
      <div class="col-12 mb-3">
        <h2>Reports for <span class="text-success">{{ restaurant.name }}</span></h2>
      </div>
      <div v-for="report in reports" :key="report.id" class="col-12 mb-3">
        <ReportCard :report="report" />
      </div>
    </section>
  </div>
  <div v-else class="container-fluid">
    <section class="row">
      <div class="col-12">
        <div class="p-2 text-center">
          <h1>Loading...
            <i v-for="icon in 7" :key="icon" class="mdi mdi-silverware-spoon mdi-spin"></i>
          </h1>
        </div>
      </div>
    </section>
  </div>
</template>


<style scoped>
.cover-img {
  width: 100%;
  height: 50dvh;
  object-fit: cover;
}
</style>