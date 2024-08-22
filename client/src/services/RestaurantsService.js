import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Restaurant } from "@/models/Restaurant.js"

class RestaurantsService {
  async getRestaurantsForReports() {
    const response = await api.get('api/restaurants')
    logger.log('GOT RESTAURANTS 🍽️🍽️🍽️🍽️🍽️📡', response.data)
    AppState.restaurantsForReports = response.data
      .filter(restaurant => restaurant.creatorId != AppState.account.id)
      .map(restaurantPOJO => new Restaurant(restaurantPOJO))
  }
  async updateRestaurant(restaurantId, restaurantData) {
    const response = await api.put(`api/restaurants/${restaurantId}`, restaurantData)
    logger.log('UPDATED RESTAURANT ✨🍴', response.data)
    AppState.activeRestaurant = new Restaurant(response.data)
  }
  async destroyRestaurant(restaurantId) {
    const response = await api.delete(`api/restaurants/${restaurantId}`)
    logger.log('DESTROYED RESTAURANT 🥪💥', response.data)
    AppState.activeRestaurant = null
  }
  async getRestaurantById(restaurantId) {
    AppState.activeRestaurant = null
    const response = await api.get(`api/restaurants/${restaurantId}`)
    logger.log('GOT RESTAURANT BY ID 🍽️📡🥪', response.data)
    AppState.activeRestaurant = new Restaurant(response.data)
  }
  async getRestaurants() {
    const response = await api.get('api/restaurants')
    logger.log('GOT RESTAURANTS 🍽️🍽️🍽️🍽️🍽️📡', response.data)
    AppState.restaurants = response.data.map(restaurantPOJO => new Restaurant(restaurantPOJO))
  }
}

export const restaurantsService = new RestaurantsService()