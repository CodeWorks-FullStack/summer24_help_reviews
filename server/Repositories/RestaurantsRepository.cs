
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


    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, JoinCreator, restaurantData).FirstOrDefault();

    return restaurant;
  }

  public void Delete(int restaurantId)
  {
    string sql = "DELETE FROM restaurants WHERE id = @restaurantId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { restaurantId });

    switch (rowsAffected)
    {
      case 1:
        break;
      case 0:
        throw new Exception("DELETE FAILED");
      default:
        throw new Exception("PROBABLY DELETED EVERYTHING");
    }
  }

  public List<Restaurant> GetAll()
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId
    WHERE restaurants.isShutdown = false;";

    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql, JoinCreator).ToList();

    return restaurants;
  }

  public Restaurant GetById(int restaurantId)
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId
    WHERE restaurants.id = @restaurantId;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, JoinCreator, new { restaurantId }).FirstOrDefault();

    return restaurant;
  }

  public Restaurant Update(Restaurant restaurantData)
  {
    string sql = @"
    UPDATE restaurants
    SET
    name = @Name,
    description = @Description,
    imgUrl = @ImgUrl,
    isShutDown = @IsShutDown
    WHERE id = @Id LIMIT 1;
    
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId
    WHERE restaurants.id = @Id;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, JoinCreator, restaurantData).FirstOrDefault();

    return restaurant;
  }

  private Restaurant JoinCreator(Restaurant restaurant, Profile profile)
  {
    restaurant.Creator = profile;
    return restaurant;
  }
}

