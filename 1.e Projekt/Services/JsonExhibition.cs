using _1.e_Projekt.Helpers;
using _1.e_Projekt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.e_Projekt.Models;

namespace _1.e_Projekt.Services
{
    public class JsonExhibition: IExhibitionRepo
    {

         readonly string filename = "Data/JsonExhibitions.json";

        readonly string filename2 = "Data/JsonPresentations.json";



        public void SaveToJson(Dictionary<int, Exhibition> Exhibitions)
        {
            JsonFileWriter.WriteToJson(Exhibitions , filename);

        }

        public Dictionary<int, Exhibition> ReadToJson() 
        {
            return JsonFileReader.ReadJson(filename);

        }

        public Dictionary<int, Exhibition> ReadToJson2()
        {
            return JsonFileReader.ReadJson(filename2);

        }
        public void SaveToJson2(Dictionary<int, Exhibition> Presentations)
        {
            JsonFileWriter.WriteToJson(Presentations, filename2);

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
            foreach (var ids in Exhibitions.Values.ToList())
            {
                 if(!ids.ExhibitionId.Equals(ex.ExhibitionId))
                {
                    Exhibitions.Add(ex.ExhibitionId, ex);
                    JsonFileWriter.WriteToJson(Exhibitions, filename);
                }
            }
         
         
        }
       
        public void UpdateExhibition(Exhibition ex)
        {
            Dictionary<int, Exhibition> Exhibitions = GetExhibitions();

            //foreach (var id in Exhibitions.Values)
            //{

            //  {
            //    id.ExhibitionId = ex.ExhibitionId;
            //    id.ExhibitionName = ex.ExhibitionName;
            //    id.ImageName = ex.ImageName;
            //     JsonFileWriter.WriteToJson(Exhibitions, filename);
            //  }

            //}

            Exhibitions[ex.ExhibitionId] = ex;
            JsonFileWriter.WriteToJson(Exhibitions, filename);

        }
        public void AddPresentation(Exhibition pre)
        {
            Dictionary<int, Exhibition> Presentations = GetPresentations();
            foreach (var ids in Presentations.Values.ToList())
            {
                if (!ids.PresentationId.Equals(pre.PresentationId))
                {
                    Presentations.Add(pre.PresentationId, pre);
                    JsonFileWriter.WriteToJson2(Presentations, filename2);
                }
            }

        }

        public void DeletePresentation(int id)
        {
            Dictionary<int, Exhibition> Presentations = GetPresentations();
            Presentations.Remove(id);
            JsonFileWriter.WriteToJson2(Presentations, filename2);
        }

        public Dictionary<int, Exhibition> GetPresentations()
        {
            return ReadToJson2();
        }

        public Exhibition ReadPresentation(int id)
        {
            Dictionary<int, Exhibition> Presentations = GetPresentations();
            Exhibition FoundPresentations = Presentations[id];
            return FoundPresentations;
          

        }

        public void UpdatePresentation(Exhibition pre)
        {
            Dictionary<int,Exhibition> Presentations = GetPresentations();
            //foreach (var id in Presentations.Values)
            //{

            //  {
            //       id.PresentationId = pre.ExhibitionId;
            //        id.PresentationName = pre.PresentationName;
            //     id.ImageName = pre.ImageName;
            //        JsonFileWriter.WriteToJson2(Presentations, filename);
            // }

            //}



            Presentations[pre.PresentationId] = pre;
            JsonFileWriter.WriteToJson2(Presentations, filename2);


        }
    }


}

