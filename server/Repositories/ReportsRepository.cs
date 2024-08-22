using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class ReportsRepository : IRepository<Report>
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Report Create(Report reportData)
  {
    string sql = @"
    INSERT INTO
    reports(title, body, pictureOfDisgust, creatorId, restaurantId)
    VALUES(@Title, @Body, @PictureOfDisgust, @CreatorId, @RestaurantId);
    
    SELECT
    reports.*,
    accounts.*
    FROM reports
    JOIN accounts ON accounts.id = reports.creatorId
    WHERE reports.id = LAST_INSERT_ID();";

    Report report = _db.Query<Report, Profile, Report>(sql, (report, profile) =>
    {
      report.Creator = profile;
      return report;
    }, reportData).FirstOrDefault();

    return report;
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

