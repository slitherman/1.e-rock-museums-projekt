using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Tests
{ 
    [TestClass]
    public class UnitTest1
    {
        public static Users CurrentUsers;
        public void TestMethod1()
        {
             
            Dictionary<string, string> hello = new Dictionary<string, string>();
            hello["test"] = "ing";
            Dictionary<string, string> world = new Dictionary<string, string>();
            world["foo"] = "bar";
            hello.ToList().ForEach(x => world.Add(x.Key, x.Value));
            //var CombinedCollections = hello.Concat(world.Where(kvp => hello.ContainsKey(kvp.Key)));
            Console.WriteLine("he");


        }
        public Dictionary<int, Exhibition> ExhibitionsTest { get;  set; }

        public UnitTest1()
        {
            ExhibitionsTest = new Dictionary<int, Exhibition>();
            

            ExhibitionsTest.Add(1, new Exhibition() { ExhibitionId = 1, ExhibitionName = "Rockens opstart", ImageName = "Rock.jpg" });
            ExhibitionsTest.Add(2, new Exhibition() { ExhibitionId = 2, ExhibitionName = "Musik f�r 2.Verdenskrig", ImageName = "Jazz.jpg", });
            ExhibitionsTest.Add(3, new Exhibition() { ExhibitionId = 3, ExhibitionName = "Protestmusikken i 60'erne", ImageName = "Protest.jpg", });
            ExhibitionsTest.Add(4, new Exhibition() { ExhibitionId = 4, ExhibitionName = "Stoffers indflydelse p� musik", ImageName = "Woodstock.jpg", });
       
        }


        [DataRow]
        [TestMethod]
      
        public void UpdateExhibition(Exhibition ex)
        {
            //foreach (var id in ExhibitionsTest.Values)
            //{

            //    {
            //        id.ExhibitionId = ex.ExhibitionId;
            //        id.ExhibitionName = ex.ExhibitionName;
            //        id.ImageName = ex.ImageName;

            //    }

            //}
            ExhibitionsTest[ex.ExhibitionId] = ex;
        }

        [DataRow]
        [TestMethod]

        public static void WriteToJson(Dictionary<int, Exhibition> Exhibitions, string filename)
        {
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowRange(UnicodeRanges.All);

            var Options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };


            string output = JsonSerializer.Serialize(filename, Options);

        }
       
        [DataRow]
        [TestMethod]
        private UserModel Authenticater(UserModel userLogin)
        {

            var CurrentUser = CurrentUsers.UserCollection.FirstOrDefault(o => o.Email.ToLower() ==
             userLogin.Email.ToLower() && o.Password == userLogin.Password);
            // cant use != so i had to settle with this
            // hopefully it works
            //knowing me it wont

            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;

           
        }

        [DataRow]
        [TestMethod]
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
