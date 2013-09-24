using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XmlDataTesting.Utilities
{
  public class LinqQuery
  {
    static IEnumerable<XElement> StreamRootChildDoc(string uri, string rootElement)
    {
      using (XmlReader reader = XmlReader.Create(uri))
      {        
        reader.MoveToContent();
        // Parse the file and display each of the nodes.
        while (reader.Read())
        {
          switch (reader.NodeType)
          {
            case XmlNodeType.Element:
              if (reader.Name == rootElement)
              {
                XElement el = XElement.ReadFrom(reader) as XElement;
                if (el != null)
                  yield return el;
              }
              break;
            case XmlNodeType.CDATA:              
              break;
          }
        }
      }
    }

    public object QueryData(string filePath, string rootElement, string queryElement, string queryAttribute)
    {
      IEnumerable<string> queriedData =
              from el in StreamRootChildDoc(filePath, rootElement)
              where (string)el.Attribute(queryElement) == queryElement
              select (string)el.Element(queryAttribute);
      return queriedData;
    }

  }
}
