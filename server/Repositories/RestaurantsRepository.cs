
using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class RestaurantsRepository : IRepository<Restaurant>
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Restaurant Create()
  {
    throw new NotImplementedException();
  }

  public void Delete()
  {
    throw new NotImplementedException();
  }


  public Restaurant GetById()
  {
    throw new NotImplementedException();
  }

  public Restaurant Update()
  {
    throw new NotImplementedException();
  }

  public List<Restaurant> GetAll()
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

