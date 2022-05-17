using _1.e_Projekt.Helpers;using _1.e_Projekt.Interfaces;using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class JsonPresentation : IPresentation
    {

        string filename = "./Data/Presentations.json";


        public void SaveToJson(Dictionary<int, Exhibition> Presentations)
        {
            JsonFileWriter.WriteToJson2(Presentations, filename);
       }

        public Dictionary<int, Exhibition> ReadToJson()
        {
            return JsonFileReader.ReadJson2(filename);
        }
        public void AddPresentation(Exhibition pre)
        {
            Dictionary<int, Exhibition> Presentations = GetPreentations();
            foreach (var ids in Presentations.Values)
           {                if (ids.PresentationId.Equals(pre.PresentationId))                {
                   Presentations.Add(pre.PresentationId, pre);
                    JsonFileWriter.WriteToJson2(Presentations,filename);
                }
            }
           

        }

       public void DeletePresentation(int id)
        {
            Dictionary<int, Exhibition> Presentations = GetPreentations();
            Presentations.Remove(id);
            JsonFileWriter.WriteToJson2(Presentations, filename);
        }

        public Dictionary<int, Exhibition> GetPreentations()        {
            return ReadToJson();
       }

       public Exhibition readPresentation(int id)        {
            Dictionary<int, Exhibition> Presentations = GetPreentations();
            Exhibition FoundPresentations = Presentations[id];
            return FoundPresentations;

        }

        public void UpdatePresentation(Exhibition pre)
        {
           Dictionary<int, Exhibition> Presentations = GetPreentations();
            foreach (var id in Presentations.Values)
            {
                if (id.PresentationId.Equals(pre.ExhibitionId))
                {
                   id.PresentationId = pre.ExhibitionId;
                   id.PresentationName = pre.PresentationName;
                   id.ImageName = pre.ImageName;
                    JsonFileWriter.WriteToJson2(Presentations, filename);
                }
                if(!id.PresentationId.Equals(pre.ExhibitionId))
                {
                    throw new Exception("error");
                }
            }
        }
    }
}
