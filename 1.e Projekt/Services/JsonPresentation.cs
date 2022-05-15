using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class JsonPresentation : IPresentation
    {

        string filename = "./Data/JsonExhibitions.json";


        public void SaveToJson(Dictionary<int, Presentation> Presentations)
        {
            JsonFileWriter.WriteToJson()
        }
        public void AddPresentation(Presentation pre)
        {
            throw new NotImplementedException();
        }

        public void DeletePresentation(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Presentation> GetPreentations()
        {
            throw new NotImplementedException();
        }

        public Presentation readPresentation(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePresentation(Presentation pre)
        {
            throw new NotImplementedException();
        }
    }
}
