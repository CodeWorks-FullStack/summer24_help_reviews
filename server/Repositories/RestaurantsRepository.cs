
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
    throw new NotImplementedException();
  }

  internal List<Restaurant> GetAll(string userId)
  {
    // NOTE COUNT is a sql function that can count rows/columns
    // NOTE AS creates a virtual column on the returned rows, and it adds it to the end of each restaurant row because of the placement in the sql statement
    // NOTE LEFT JOIN will join rows from another table irregardless of wether there is a match on the JOIN statement (not every restaurant has reports)
    // NOTE GROUP BY will summarize the LEFT JOINED rows
    string sql = @"
    SELECT
    restaurants.*,
    COUNT(reports.id) AS reportCount,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creatorId
    LEFT JOIN reports ON reports.restaurantId = restaurants.id
    WHERE restaurants.isShutdown = false OR restaurants.creatorId = @userId
    GROUP BY (restaurants.id);";

    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql, JoinCreator, new { userId }).ToList();

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
    isShutDown = @IsShutDown,
    visits = @Visits
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

