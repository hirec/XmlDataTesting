using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataTesting.Utilities;

namespace XmlDataTesting
{
  class Program
  {
    static void Main(string[] args)
    {

      LinqQuery linqQuery = new LinqQuery();
      var queryResults = linqQuery.QueryData(Directory.GetCurrentDirectory() + "\\SampleData\\netflixStreamingCatalogSampleData.xml", "catalog_title", "title", "short");
      Console.WriteLine(queryResults);
      Console.ReadKey();
    }
  }
}
