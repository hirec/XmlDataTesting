using System.Collections.Generic;

namespace XmlDataTesting.Models
{
  public class CategoryTitle
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public string ShortSynopsis { get; set; }
    public string ReleaseYear { get; set; }
    public string AverageRating { get; set; }
    public string Similars { get; set; }
    public string SmallCoverArt { get; set; }
    public string MediumCoverArt { get; set; }
    public string LargeCoverArt { get; set; }
    public List<string> Category { get; set; }
    public List<string> Cast { get; set; }
    public List<string> Directors { get; set; }   
  }
}
