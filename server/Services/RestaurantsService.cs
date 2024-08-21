
namespace help_reviews.Services;

public class RestaurantsService
{

  private readonly RestaurantsRepository _repository;

  public RestaurantsService(RestaurantsRepository repository)
  {
    _repository = repository;
  }

  internal List<Restaurant> GetAllRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetAll();
    return restaurants;
  }
}
