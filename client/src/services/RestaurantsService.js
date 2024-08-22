import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Restaurant } from "@/models/Restaurant.js"

class RestaurantsService {
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