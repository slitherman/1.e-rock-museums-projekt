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
            JsonFileWriter.WriteToJson2(Presentations, filename);
        }

        public Dictionary<int, Presentation> ReadToJson()
        {
            return JsonFileReader.ReadJson2(filename);
        }
        public void AddPresentation(Presentation pre)
        {
            Dictionary<int, Presentation> Presentations = GetPreentations();
            foreach (var ids in Presentations.Values)
            {
                if (ids.PresentationId.Equals(pre.PresentationId))
                {
                    Presentations.Add(pre.PresentationId, pre);
                    JsonFileWriter.WriteToJson2(Presentations,filename);
                }
            }
           

        }

        public void DeletePresentation(int id)
        {
            Dictionary<int, Presentation> Presentations = GetPreentations();
            Presentations.Remove(id);
            JsonFileWriter.WriteToJson2(Presentations, filename);
        }

        public Dictionary<int, Presentation> GetPreentations()
        {
            return ReadToJson();
        }

        public Presentation readPresentation(int id)
        {
            Dictionary<int, Presentation> Presentations = GetPreentations();
            Presentation FoundPresentations = Presentations[id];
            return FoundPresentations;

        }

        public void UpdatePresentation(Presentation pre)
        {
            Dictionary<int, Presentation> Presentations = GetPreentations();
            foreach (var id in Presentations.Values)
            {
                if (id.PresentationId.Equals(pre.PresentationId))
                {
                    id.PresentationId = pre.PresentationId;
                    id.PresentationName = pre.PresentationName;
                    id.ImageName = pre.ImageName;
                    JsonFileWriter.WriteToJson2(Presentations, filename);
                }
            }
        }
    }
}
