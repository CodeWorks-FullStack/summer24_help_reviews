using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class ReportsRepository : IRepository<Report>
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Report Create(Report data)
  {
    throw new NotImplementedException();
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<Report> GetAll()
  {
    throw new NotImplementedException();
  }

  public Report GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Report Update(Report data)
  {
    throw new NotImplementedException();
  }
}

