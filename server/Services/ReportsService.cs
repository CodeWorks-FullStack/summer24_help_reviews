


namespace help_reviews.Services;

public class ReportsService
{
  private readonly ReportsRepository _repository;

  public ReportsService(ReportsRepository repository)
  {
    _repository = repository;
  }
}
