using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlDataTesting.Models;

namespace XmlDataTesting.Mappings
{
  public class WeatherMap
  {
    List<WeatherData> WDList;
    WeatherData WD;

    public List<WeatherData> MapObject(List<XElement> el)
    {
      WDList = new List<WeatherData>();
      foreach (var E in el.Elements())
      {
        switch (E.Name.LocalName)
        {
          case "yweather:location":
            Console.WriteLine(E.Attribute("city").Value);
            break;
          case "yweather:wind":
            break;
          case "yweather:atmosphere":
            break;
          case "yweather:astronomy":
            break;
          case "pubDate":
            break;
          case "yweather:condition":
            break;
          case "yweather:forecast":
            break;
        }
      }
      return WDList;
    }

  }
}
