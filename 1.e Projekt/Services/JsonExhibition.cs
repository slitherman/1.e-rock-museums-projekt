using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Services
{
    public class JsonExhibition: IExhibition
    {

        string filename = "./Data/JsonExhibitions.json";

        public int Exhibitionid { get; private set; }

        public void SaveToJson(Dictionary<int, Exhibition> Exhibitions)
        {
            JsonFileWriter.WriteToJson(Exhibitions, filename);

        }

        public Dictionary<int, Exhibition> ReadToJson()
        {
            return JsonFileReader.ReadJson(filename);

        }
        public Dictionary<int, Exhibition> GetExhibitions()
        {
            return ReadToJson();
        }
        public Exhibition GetExhibition(int id)
        {
            Dictionary<int, Exhibition> Exhibitions = GetExhibitions();
            Exhibition FoundExhibitions = Exhibitions[id];
            return FoundExhibitions;
        }

        public void DeleteExhibition(int id)
        {
            Dictionary<int, Exhibition> Exhibitions = GetExhibitions();
            Exhibitions.Remove(id);
            JsonFileWriter.WriteToJson(Exhibitions, filename);
        }

        public void AddExhibition(Exhibition ex)
        {
            Dictionary<int, Exhibition> Exhibitions = GetExhibitions();
            Exhibitions.Add(Exhibitionid, ex);
            JsonFileWriter.WriteToJson(Exhibitions,filename);
        }

        public void UpdateExhibition(Exhibition ex)
        {
            Dictionary<int, Exhibition> Exhibitions = GetExhibitions();
        
            foreach (var id in Exhibitions.Values)
            {
                if(id.ExhibitionId.Equals(ex.ExhibitionId))
                {
                    id.ExhibitionId = ex.ExhibitionId;
                    id.ExhibitionName = ex.ExhibitionName;
                    id.ImageName = ex.ImageName;
                    JsonFileWriter.WriteToJson(Exhibitions, filename);
                }
            }

        }

       
    }
}
