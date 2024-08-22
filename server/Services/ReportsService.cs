




namespace help_reviews.Services;

public class ReportsService
{
  private readonly ReportsRepository _repository;
  private readonly RestaurantsService _restaurantsService;

  public ReportsService(ReportsRepository repository, RestaurantsService restaurantsService)
  {
    _repository = repository;
    _restaurantsService = restaurantsService;
  }

  internal Report CreateReport(Report reportData)
  {
    Restaurant restaurant = _restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId);

    if (restaurant.CreatorId == reportData.CreatorId)
    {
      throw new Exception($"You are the owner of {restaurant.Name}, and you are not allowed to leave reviews for your own restaurant.");
    }

    Report report = _repository.Create(reportData);
    return report;
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId, string userId)
  {
    // Just need the checks to run in the other service
    _restaurantsService.GetRestaurantById(restaurantId, userId);

    List<Report> reports = _repository.GetReportsByRestaurantId(restaurantId);
    return reports;
  }

}
