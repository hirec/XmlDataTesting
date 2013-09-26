using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlDataTesting.Models;

namespace XmlDataTesting.Mappings
{
  public class CategoryTitleMap
  {
    CategoryTitle CT;
    public void MapObject(List<XElement> el)
    {      
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
        }        
      }
    }

    private void parseLink(XElement E)
    {
      switch (E.Attribute("title").Value)
      {
        case "box art":
          foreach (var b in E.Element("box_art").Descendants("link"))
          {
            Console.WriteLine(b.Attribute("title").Value);
          }
          break;
        case "synopsis":
          Console.WriteLine(E.Element("synopsis").Value);
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
