


namespace help_reviews.Services;

public class RestaurantsService
{

  private readonly RestaurantsRepository _repository;

  public RestaurantsService(RestaurantsRepository repository)
  {
    _repository = repository;
  }

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    Restaurant restaurant = _repository.Create(restaurantData);
    return restaurant;
  }

  internal string DestroyRestaurant(int restaurantId, string userId)
  {
    Restaurant restaurantToDestroy = GetRestaurantById(restaurantId);
    if (restaurantToDestroy.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT, BUD");
    }
    _repository.Delete(restaurantId);

    return $"{restaurantToDestroy.Name} has been deleted!";
  }

  public List<Restaurant> GetAllRestaurants(string userId)
  {
    List<Restaurant> restaurants = _repository.GetAll(userId);
    return restaurants;
  }


  private Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);

    if (restaurant == null)
    {
      throw new Exception($"No restaurant found with the id of {restaurantId}");
    }

    return restaurant;
  }

  internal Restaurant UpdateRestaurant(int restaurantId, string userId, Restaurant restaurantData)
  {
    Restaurant restaurantToUpdate = GetRestaurantById(restaurantId);

    if (restaurantToUpdate.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT, PAL");
    }

    restaurantToUpdate.Name = restaurantData.Name ?? restaurantToUpdate.Name;
    restaurantToUpdate.Description = restaurantData.Description ?? restaurantToUpdate.Description;
    restaurantToUpdate.ImgUrl = restaurantData.ImgUrl ?? restaurantToUpdate.ImgUrl;
    // Don't forget to make the property nullable in your model
    restaurantToUpdate.IsShutdown = restaurantData.IsShutdown ?? restaurantToUpdate.IsShutdown;

    Restaurant updatedRestaurant = _repository.Update(restaurantToUpdate);
    return updatedRestaurant;
  }

  internal Restaurant GetRestaurantById(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId);
    // If you aren't the owner of the restaurant and it is shut down
    if (restaurant.CreatorId != userId && restaurant.IsShutdown == true)
    {
      throw new Exception($"No restaurant found with the id of {restaurantId} 😉");
    }

    return restaurant;
  }

  internal Restaurant IncrementVisits(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId, userId);

    if (restaurant.IsShutdown == true)
    {
      return restaurant;
    }

    restaurant.Visits++;

    _repository.Update(restaurant);

    return restaurant;
  }
}
