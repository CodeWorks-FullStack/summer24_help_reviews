import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Report } from "@/models/Report.js"

class ReportsService {
  async getReportsByRestaurantId(restaurantId) {
    AppState.reports.length = 0
    const response = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('GOT REPORTS 🍔🍔🍔🍔🍔🍔🍔', response.data)
    AppState.reports = response.data.map(reportPOJO => new Report(reportPOJO))
  }
  async createReport(reportData) {
    const response = await api.post('api/reports', reportData)
    logger.log('CREATED REPORT 🍕🍕🍕🍕', response.data)
    const report = new Report(response.data)

    if (report.restaurantId == AppState.activeRestaurant?.id) {
      AppState.reports.push(report)
    }

    const restaurantThatReceivedReport = AppState.restaurants.find(restaurant => restaurant.id == report.restaurantId)

    if (restaurantThatReceivedReport) {
      restaurantThatReceivedReport.reportCount++
    }

  }
}

export const reportsService = new ReportsService()