using System.Collections.Generic;
using System.Xml.Linq;
using XmlDataTesting.Models;

namespace XmlDataTesting.Mappings
{
  public class CategoryTitleMap
  {
    List<CategoryTitle> CTList;
    CategoryTitle CT;

    public List<CategoryTitle> MapObject(List<XElement> el)
    {
      CTList = new List<CategoryTitle>();
      foreach (var E in el.Elements())
      {
        switch (E.Name.LocalName)
        {
          case "id":
            //On the first element need to create new model 
            initializeCatalog();
            CT.Id = E.Value;
            break;
          case "title":
            CT.Title = E.Attribute("short").Value;
            break;
          case "link":           
            parseLink(E);
            break;
          case "release_year":
            CT.ReleaseYear = E.Value;
            break;
          case "category":
            CT.Category.Add(E.Attribute("label").Value);  
            break;
          case "average_rating":
            CT.AverageRating = E.Value;
            break; 
            case "updated":
            CTList.Add(CT);
            break;
        }        
      }
      return CTList;
    }

    private void parseLink(XElement E)
    {
      switch (E.Attribute("title").Value)
      {
        case "box art":
          foreach (var b in E.Element("box_art").Descendants("link"))
          {
            switch (b.Attribute("title").Value)
            {
              case "64pix width box art":
                CT.SmallCoverArt = b.Attribute("title").Value;
                break;
              case "150pix width box art":
                CT.MediumCoverArt = b.Attribute("title").Value;
                break;
              case "210pix width box art":
                CT.LargeCoverArt = b.Attribute("title").Value;
                break;
            }
          }
          break;
        case "cast":
          foreach (var p in E.Element("people").Descendants("link"))
          {
            CT.Cast.Add(p.Attribute("title").Value);            
          }
          break;
        case "directors":
          foreach (var p in E.Element("people").Descendants("link"))
          {
            CT.Directors.Add(p.Attribute("title").Value);
          }
          break;
        case "synopsis":
          CT.Synopsis = E.Element("synopsis").Value;
          break;
        case "short synopsis":
          CT.ShortSynopsis = E.Element("short_synopsis").Value;
          break;        
      }
    }

    private void initializeCatalog()
    {
      CT = new CategoryTitle();
      CT.Category = new List<string>();
      CT.Cast = new List<string>();
      CT.Directors = new List<string>();
    }
  }
}
