
using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class RestaurantsRepository : IRepository<Restaurant>
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Restaurant Create(Restaurant restaurantData)
  {
    string sql = @"
    INSERT INTO
    restaurants(name, description, imgUrl, isShutdown, creatorId)
    VALUES(@Name, @Description, @ImgUrl, @IsShutdown, @CreatorId);

    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId
    WHERE restaurants.id = LAST_INSERT_ID();";


    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql,
    (restaurant, profile) =>
    {
      restaurant.Creator = profile;
      return restaurant;
    }, restaurantData).FirstOrDefault();

    return restaurant;
  }

  public void Delete(int restaurantId)
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

  public Restaurant GetById(int restaurantId)
  {
    throw new NotImplementedException();
  }

  public Restaurant Update(Restaurant restaurantData)
  {
    throw new NotImplementedException();
  }
}

