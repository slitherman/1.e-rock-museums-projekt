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


            //Giver op. Dette er den letteste måde at kunne få de 2 collections til at kommunikere med hinanden + dependency injection er også blevet muligt.
                Exhibitions = new Dictionary<int, Exhibition>();
                Exhibitions.Add(1, new Exhibition() { ExhibitionId = 1, ExhibitionName = "Rockens opstart", ImageName="Rock.jpg" });
                Exhibitions.Add(2, new Exhibition() { ExhibitionId = 2, ExhibitionName = "Musik før 2.Verdenskrig", ImageName="Jazz.jpg"});
                Exhibitions.Add(3, new Exhibition() { ExhibitionId = 3, ExhibitionName = "Protestmusikken i 60'erne", ImageName="Protest.jpg" });
                Exhibitions.Add(4, new Exhibition() { ExhibitionId = 4, ExhibitionName = "Stoffers indflydelse på musik" , ImageName="Woodstock.jpg"});
            //Har fjernet presentation klassen, alle presentations er nu exhibitions
            Presentations = new Dictionary<int, Exhibition>();
                Presentations.Add(1, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Rockens Opstart", ImageName = "Rock.jpg" });
                Presentations.Add(2, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Musik Før 2.Verdenskrig", ImageName = "Jazz.jpg" });
                Presentations.Add(3, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Protestmusikken i 60'erne", ImageName = "Protest.jpg" });
                Presentations.Add(4, new Exhibition() { PresentationId = 1, PresentationName = " Oplæg Om Stoffers Indflydelse På Musik", ImageName = "Woodstock.jpg" });
            foreach (var ids in Presentations.Values)
            {
                if(ids.PresentationId.Equals(ids.ExhibitionId))
               {

                  var CombinedCollections = Presentations.Concat(Exhibitions.Where(kvp => !Presentations.ContainsKey(kvp.Key)));


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
      
        public void AddExhibition(Exhibition ex)
        {
            if(!Exhibitions.Keys.Contains(ex.ExhibitionId))
            {
                Exhibitions.Add(ex.ExhibitionId, ex);
            }
          
        }
      
        public void UpdateExhibition (Exhibition ex)
        {
            foreach (var id in Exhibitions.Values)
            {
                if(id.ExhibitionId.Equals(ex.ExhibitionId))
                {
                    id.ExhibitionId = ex.ExhibitionId;
                    id.ExhibitionName = ex.ExhibitionName;
                    id.ImageName = ex.ImageName;
                }
                if (!id.ExhibitionId.Equals(ex.ExhibitionId))
                {
                    throw new Exception("error");
                }
            }
        }


      
        public void AddPresentation(Exhibition pre)
        {
            if (!Presentations.Keys.Contains(pre.ExhibitionId))
            {
                Presentations.Add(pre.ExhibitionId, pre);
            }
        }
      
        public void UpdatePresentation(Exhibition pre)
        {
            foreach (var id in Presentations.Values)
            {
                if (id.PresentationId.Equals(pre.ExhibitionId))
                {
                    id.PresentationId = pre.ExhibitionId;
                    id.PresentationName = pre.PresentationName;
                    id.ImageName = pre.ImageName;

                }
                if(!id.PresentationId.Equals(pre.ExhibitionId))
                {
                    throw new Exception("error");
                }

            }
        }


        public void DeletePresentation(int id)
        {
            Presentations.Remove(id);
        }

        public Exhibition ReadPresentation(int id)
        {
            return Presentations[id];
        }
        public Dictionary<int, Exhibition> GetPreentations()
        {
            return Presentations;
        }

    }

    
}

