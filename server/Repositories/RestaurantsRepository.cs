
namespace help_reviews.Repositories;

public class RestaurantsRepository
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Restaurant> GetAllRestaurants()
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId;";

    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql,
    (restaurant, profile) =>
    {
      restaurant.Creator = profile;
      return restaurant;
    }).ToList();

    return restaurants;
  }
}

