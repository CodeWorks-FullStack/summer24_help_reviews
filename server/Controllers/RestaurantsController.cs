namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
  private readonly RestaurantsService _restaurantsService;
  private readonly Auth0Provider _auth0Provider;

  public RestaurantsController(RestaurantsService restaurantsService, Auth0Provider auth0Provider)
  {
    _restaurantsService = restaurantsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<Restaurant>> GetAllRestaurants()
  {
    try
    {
      List<Restaurant> restaurants = _restaurantsService.GetAllRestaurants();
      return Ok(restaurants);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
