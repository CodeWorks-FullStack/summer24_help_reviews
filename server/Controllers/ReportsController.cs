namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
  private readonly ReportsService _reportsService;
  private readonly Auth0Provider _auth0Provider;

  public ReportsController(ReportsService reportsService, Auth0Provider auth0Provider)
  {
    _reportsService = reportsService;
    _auth0Provider = auth0Provider;
  }
}
