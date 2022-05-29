using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace _1.e_Projekt.Helpers
{
    public static class JsonFileWriter
    {

        public static void WriteToJson(Dictionary<int, Exhibition> Exhibitions, string filename)
        {
          
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);
            encoderSettings.AllowCharacters('\u0305', '\u0330', '\u0306');

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };

           
            string output = JsonSerializer.Serialize( Exhibitions, Options);


            File.WriteAllText(filename, output);


        

        }

        public static void WriteToJson2(Dictionary<int, Exhibition> Presentations, string filename)
        {
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };


            string output = JsonSerializer.Serialize(Presentations, Options);


            File.WriteAllText(filename, output);


        }

        public static void WriteToJson3(List<User> UserCollection, string filename)
        {
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };


            string output = JsonSerializer.Serialize(UserCollection, Options);


            File.WriteAllText(filename, output);




        }
    }
}
