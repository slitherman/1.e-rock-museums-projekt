using _1.e_Projekt.Interfaces;
using _1.e_Projekt.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using _1.e_Projekt.Helpers;

namespace _1.e_Projekt.Services
{
    public class ExhibitionRepo: IExhibitionRepo
    {
       public Dictionary<int, Exhibition> Exhibitions { get; set; }
       public Dictionary<int, Exhibition> Presentations { get; set; }
        
 
        public ExhibitionRepo()
        {


           
                Exhibitions = new Dictionary<int, Exhibition>();
                Exhibitions.Add(1, new Exhibition() { ExhibitionId = 1, ExhibitionName = "Rockens opstart", ImageName="Rock" });
                Exhibitions.Add(2, new Exhibition() { ExhibitionId = 2, ExhibitionName = "Musik før 2.Verdenskrig", ImageName="Jazz",  });
                Exhibitions.Add(3, new Exhibition() { ExhibitionId = 3, ExhibitionName = "Protestmusikken i 60'erne", ImageName="Protest",  });
                Exhibitions.Add(4, new Exhibition() { ExhibitionId = 4, ExhibitionName = "Stoffers indflydelse på musik" , ImageName="Woodstock", });
            
            Presentations = new Dictionary<int, Exhibition>();
                Presentations.Add(1, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Rockens Opstart", ImageName = "Pictures/Rock.jpg", AudioFile = "09 genome.mp3" });
                Presentations.Add(2, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Musik Før 2.Verdenskrig", ImageName = "Pictures/Jazz.jpg", AudioFile = "11 tsurugi no mai.mp3" });
                Presentations.Add(3, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Protestmusikken i 60'erne", ImageName = "Pictures/Protest.jpg", AudioFile = "13 chambers.mp3" });
                Presentations.Add(4, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Stoffers Indflydelse På Musik", ImageName = "Pictures/Woodstock.jpg", AudioFile = "15 how you feel.mp3" });
            foreach (var ids in Presentations.Values)
            {
                if(ids.PresentationId.Equals(ids.ExhibitionId))
               {

                    //var CombinedCollections = Presentations.Concat(Exhibitions.Where(kvp => Presentations.ContainsKey(kvp.Key)));
                    Presentations.ToList().ForEach(x => Exhibitions.Add(x.Key, x.Value));


               }
                if (Presentations.Keys.Contains(ids.PresentationId))
                {
                    if (!ids.PresentationId.Equals(ids.ExhibitionId))
                   {
                        throw new Exception(" error presentation doesnt have an exhibition assigned to it");
                    }
                }
                         
            }

        }


        public Dictionary<int, Exhibition> GetExhibitions()
        {
           return Exhibitions;
        }

        public Exhibition GetExhibition(int id)
        {
            return Exhibitions[id];
        }
        
        public void DeleteExhibition (int id)
        {
            Exhibitions.Remove(id);
        }
      //???
        public void AddExhibition(Exhibition ex)
        {
            if(!Exhibitions.Keys.ToList().Contains(ex.ExhibitionId))
            {
                Exhibitions.Add(ex.ExhibitionId, ex);
            }
          
        }
      
        public void UpdateExhibition (Exhibition ex)
        {
            //foreach (var id in Exhibitions.Values)
            //{

            //    {
            //       id.ExhibitionId = ex.ExhibitionId;
            //       id.ExhibitionName = ex.ExhibitionName;
            //       id.ImageName = ex.ImageName;
              
            //    }

            //}
            Exhibitions[ex.ExhibitionId] = ex;
        }


      
        public void AddPresentation(Exhibition pre)
        {
            if (!Presentations.Keys.ToList().Contains(pre.ExhibitionId))
            {
                Presentations.Add(pre.ExhibitionId, pre);
            }
        }
      
        public void UpdatePresentation(Exhibition pre)
        {
            //foreach (var id in Presentations.Values)
            //{
            //    id.PresentationId = pre.PresentationId;
            //    id.PresentationName = pre.PresentationName;
            //    id.ImageName = pre.ImageName;
            //}
            Presentations[pre.PresentationId] = pre;
        }


        public void DeletePresentation(int id)
        {
            Presentations.Remove(id);
        }

        public Exhibition ReadPresentation(int id)
        {
            return Presentations[id];
        }
        public Dictionary<int, Exhibition> GetPresentations()
        {
            return Presentations;
        }

    }


    
}

