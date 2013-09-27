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
    bool firstDay;

    public List<WeatherData> MapObject(List<XElement> el)
    {
      WDList = new List<WeatherData>();
      firstDay = true;
      foreach (var E in el.Elements("channel").Descendants())
      {       
        switch (E.Name.LocalName)
        {
          case "location":
            WD = new WeatherData();
            WD.City = E.Attribute("city").Value;
            WD.Region = E.Attribute("region").Value;
            break;
          case "wind":
            WD.WindChill = E.Attribute("chill").Value;
            WD.WindDirection = E.Attribute("direction").Value;
            WD.WindSpeed = E.Attribute("speed").Value;
            break;
          case "atmosphere":
            WD.Humidity = E.Attribute("humidity").Value;
            WD.Visibility = E.Attribute("visibility").Value;
            WD.Pressure = E.Attribute("pressure").Value;
            break;
          case "astronomy":
            WD.Sunrise = E.Attribute("sunrise").Value;
            WD.Sunset = E.Attribute("sunset").Value;
            break;         
          case "condition":
            WDList = new List<WeatherData>();
            WDList.Add(WD);
            WD.Text = E.Attribute("text").Value;
            WD.Code = E.Attribute("code").Value;
            WD.Temp = E.Attribute("temp").Value;
            WD.Date = E.Attribute("date").Value;
            break;
          case "forecast":
            WD = new WeatherData();
            if (firstDay)
            {
              WDList[0].Day = E.Attribute("day").Value;
              WDList[0].High = E.Attribute("high").Value;
              WDList[0].Low = E.Attribute("low").Value;
            }
            WD.Day = E.Attribute("day").Value;
            WD.Date = E.Attribute("date").Value;
            WD.Low = E.Attribute("low").Value;
            WD.High = E.Attribute("high").Value;
            WD.Text = E.Attribute("text").Value;
            WD.Code = E.Attribute("code").Value;
            WDList.Add(WD);
            firstDay = false;
            break;
        }
      }
      return WDList;
    }
  }
}
