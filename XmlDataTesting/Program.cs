using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataTesting.Utilities;
using XmlDataTesting.Mappings;

namespace XmlDataTesting
{
  class Program
  {
    static void Main(string[] args)
    {

      LinqQuery linqQuery = new LinqQuery();

      //Returns a single or a few attributes
     // var queryResults = linqQuery.QueryData(Directory.GetCurrentDirectory() + "\\SampleData\\netflixStreamingCatalogSampleData.xml", "catalog_title", "id", "744645","id");
                                                                                                                                                                        
      //Returns the entire element
      var queryResults = linqQuery.QueryData(Directory.GetCurrentDirectory() + "\\SampleData\\netflixStreamingCatalogSampleData.xml", "catalog_title",  "category", "label", "Dramas", 5);

      //Call CategoryMapper to map results to object
      CategoryTitleMap CTM = new CategoryTitleMap();
      CTM.MapObject(queryResults);      

      //By converting IEnumerable ToList() you have to call a specific index vs leaving as IEnumerable in LinqQuery class
      //and getting everything in generic collection without referring to index
    //  Console.WriteLine(queryResults);
      Console.ReadKey();
    }
  }
}
