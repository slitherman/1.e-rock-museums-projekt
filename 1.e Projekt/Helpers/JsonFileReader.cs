using _1.e_Projekt.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Helpers
{
    static public class JsonFileReader
    {
      public static Dictionary<int, Exhibition> ReadJson (string filename)
        {
            string jsonstring = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Dictionary<int, Exhibition>>(filename);
        }


    }
}
