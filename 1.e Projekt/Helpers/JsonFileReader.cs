using _1.e_Projekt.Models;
using _1.e_Projekt.Services;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace _1.e_Projekt.Helpers
{
    static public class JsonFileReader
    {
        public static Dictionary<int, Exhibition> ReadJson(string filename)
        {
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);
            encoderSettings.AllowCharacters('\u0305', '\u0330', '\u0306');

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };

           string jsonstring = File.ReadAllText(filename);
          return  JsonSerializer.Deserialize<Dictionary<int, Exhibition>>(jsonstring, Options);
          }

        public static Dictionary<int, Exhibition> ReadJson2(string filename)
        {
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);
            encoderSettings.AllowCharacters('\u0305', '\u0330', '\u0306');

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };

            //string jsonstring = File.ReadAllText(filename);
            //return JsonConvert.DeserializeObject<Dictionary<int, Exhibition>>(jsonstring);
            string jsonstring = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<Dictionary<int, Exhibition>>(jsonstring, Options);
        }

        public static List<UserModel> ReadJson3(string filename)
        {
            //string jsonstring = File.ReadAllText(filename);
            //return JsonConvert.DeserializeObject< List < UserModel>> (jsonstring);
          
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);
            encoderSettings.AllowCharacters('\u0305', '\u0330', '\u0306');

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };
            string jsonstring = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<UserModel>>(jsonstring, Options);
        }

    }
}
