using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XmlDataTesting.Models;

namespace XmlDataTesting.Utilities
{
  public class LinqQuery
  {

    static IEnumerable<XElement> SimpleStreamAxis(
                       string inputUrl, string matchName)
    {
      using (XmlReader reader = XmlReader.Create(inputUrl))
      {
        reader.MoveToContent();
        while (reader.Read())
        {
          switch (reader.NodeType)
          {
            case XmlNodeType.Element:
              if (reader.Name == matchName)
              {
                XElement el = XElement.ReadFrom(reader)
                                      as XElement;
                if (el != null)
                  yield return el;
              }
              break;
          }
        }
        reader.Close();
      }
    }

    public IEnumerable<string> QueryData(string filePath, string rootElement, string queryElement, string queryAttribute)
    {
      //SEARCHES THROUGH THE ROOT ELEMENTS WHERE THE ELEMENT CONTAINS A SEARCH TERMS
      //AND RETURNS A SINGLE FIELD
      //IEnumerable<string> titles =
      //    from el in SimpleStreamAxis(filePath, rootElement)
      //    where el.Element(queryElement).Value.Contains(queryAttribute)
      //    select (string)el.Element(queryElement);

      //SEARCHES THROUGH THE ROOT ELEMENTS WHERE THE ELEMENT ATTRIBUTE CONTAINS A SEARCH TERM 
      //AND RETURNS A SINGLE FIELD RESTRICTED TO X RESULTS WITH TAKE()
      IEnumerable<string> titles =
          (from el in SimpleStreamAxis(filePath, rootElement)
          where el.Element(queryElement).Attribute(queryAttribute).Value.Contains("Action & Adventure")
          select (string)el.Element("id")).Take(2);
     
      foreach (string str in titles)
      {
        Console.WriteLine(str);
      }
      return titles;
    }


    public List<XElement> QueryData(string filePath, string rootElement, string queryElement, string queryAttribute, bool returnElement)
    {          
      //SEARCHES THROUGH THE ROOT ELEMENTS WHERE THE ELEMENT ATTRIBUTE CONTAINS A SEARCH TERM
      //AND RETURNS THE ELEMENT
      IEnumerable<XElement> titles =
         (from el in SimpleStreamAxis(filePath, rootElement)
         where el.Element(queryElement).Attribute(queryAttribute).Value.Contains("Dramas")
         select el).Take(5);
      List<XElement> movieTitles = titles.ToList();
      //foreach (string str in titles)
      //{
     //   Console.WriteLine(str);
     // }
      return movieTitles;
    }

  }
}
