namespace help_reviews.Models;

public class Report : RepoItem<int>
{
  public string Title { get; set; }
  public string Body { get; set; }
  public string PictureOfDisgust { get; set; }
  public string CreatorId { get; set; }
  public int RestaurantId { get; set; }
  public Profile Creator { get; set; }
}