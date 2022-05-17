using _1.e_Projekt.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Helpers
{
    public static class JsonFileWriter
    {

        public static void WriteToJson(Dictionary<int, Exhibition> Exhibitions , string filename)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Exhibitions, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filename, output);

        }

        public static void WriteToJson2(Dictionary<int, Exhibition> Presentations, string filename)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Presentations, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filename, output);

        }

        public static void WriteToJson3(Dictionary<int, Users> Presentations, string filename)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Presentations, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filename, output);

        }
    }
}
