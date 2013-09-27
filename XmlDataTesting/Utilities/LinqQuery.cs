using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XmlDataTesting.Utilities
{
  public class LinqQuery
  {
    static IEnumerable<XElement> ElementParser(string inputUrl, string matchName)
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

    public IEnumerable<string> QueryData(string filePath, string rootElement, string queryElement, string queryAttribute, string queryString, string returnElement)
    {
      //SEARCHES THROUGH THE ROOT ELEMENTS WHERE THE ELEMENT CONTAINS A SEARCH TERMS
      //AND RETURNS A SINGLE FIELD
      //IEnumerable<string> titles =
      //    from el in SimpleStreamAxis(filePath, rootElement)
      //    where el.Element(queryElement).Value.Contains(queryAttribute)
      //    select (string)el.Element(queryElement);

      //SEARCHES THROUGH THE ROOT ELEMENTS WHERE THE ELEMENT ATTRIBUTE CONTAINS A SEARCH TERM 
      //AND RETURNS A SINGLE FIELD RESTRICTED TO X RESULTS WITH TAKE()
      IEnumerable<string> queryResult =
          (from el in ElementParser(filePath, rootElement)
           where el.Element(queryElement).Attribute(queryAttribute).Value.Contains(queryString)
           select (string)el.Element(returnElement)).Take(2);
      List<string> queryResults = queryResult.ToList();
      return queryResults;
    }

    public List<XElement> QueryData(string filePath, string rootElement, string queryElement, string queryAttribute, string queryString, int requestedResults)
    {          
      //SEARCHES THROUGH THE ROOT ELEMENTS WHERE THE ELEMENT ATTRIBUTE CONTAINS A SEARCH TERM
      //AND RETURNS THE ELEMENT
      IEnumerable<XElement> queryResult =
         (from el in ElementParser(filePath, rootElement)
          where el.Element(queryElement).Attribute(queryAttribute).Value.Contains(queryString)
          select el).Take(requestedResults);
      List<XElement> queryResults = queryResult.ToList();
      return queryResults;
    }

    public List<XElement> QueryData(string docPath)
    {
      XDocument doc = XDocument.Load(docPath);      
      IEnumerable<XElement> queryResult =
        from el in doc.Elements()
        select el;
      List<XElement> queryResults = queryResult.ToList();
      return queryResults;
    }

    public List<XElement> QueryData(XDocument doc)
    {
      IEnumerable<XElement> queryResult =
        from el in doc.Elements()
        select el;
      List<XElement> queryResults = queryResult.ToList();
      return queryResults;
    }   
  }
}
