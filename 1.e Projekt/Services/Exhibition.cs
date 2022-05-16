﻿using _1.e_Projekt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _1.e_Projekt.Services
{
    public class Exhibition: IExhibition
    {
       public Dictionary<int, Exhibition> Exhibitions { get; set; }
        public Dictionary<int, Exhibition> Presentations { get; set; }
        public int ExhibitionId { get; set; }
        public string ExhibitionName { get; set; }
        public string PresentationName { get; set; }
        public int PresentationId { get; set; }

        public string ImageName { get; set; }
        public int CtorId { get; set; }
        //bruger et ctorid pga inheritance. Det ville se dumt ud af skulle bruge de andre variabler.
        public Exhibition(int ConstructorId)
        {

            
                CtorId = ConstructorId;
                Exhibitions = new Dictionary<int, Exhibition>();
                Exhibitions.Add(1, new Exhibition(1) { ExhibitionId = 1, ExhibitionName = "Rockens opstart", ImageName="Rock.jpg" });
                Exhibitions.Add(2, new Exhibition(2) { ExhibitionId = 2, ExhibitionName = "Musik før 2.Verdenskrig", ImageName="Jazz.jpg"});
                Exhibitions.Add(3, new Exhibition(3) { ExhibitionId = 3, ExhibitionName = "Protestmusikken i 60'erne", ImageName="Protest.jpg" });
                Exhibitions.Add(4, new Exhibition(4) { ExhibitionId = 4, ExhibitionName = "Stoffers indflydelse på musik" , ImageName="Woodstock.jpg"});
                Presentations = new Dictionary<int, Exhibition>();
                Presentations.Add(1, new Presentation(11) { PresentationId = 1, PresentationName = " Oplæg Om Rockens Opstart", ImageName = "Rock.jpg" });
                Presentations.Add(2, new Presentation(21) { PresentationId = 1, PresentationName = " Oplæg Om Musik Før 2.Verdenskrig", ImageName = "Jazz.jpg" });
                Presentations.Add(3, new Presentation(31) { PresentationId = 1, PresentationName = " Oplæg Om Protestmusikken i 60'erne", ImageName = "Protest.jpg" });
                Presentations.Add(4, new Presentation(41) { PresentationId = 1, PresentationName = " Oplæg Om Stoffers Indflydelse På Musik", ImageName = "Woodstock.jpg" });
            foreach (var ids in Presentations.Values)
            {
                if(ids.ExhibitionId.Equals(PresentationId))
               {

                  var CombinedCollections = Presentations.Concat(Exhibitions.Where(kvp => !Presentations.ContainsKey(kvp.Key)));


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
        [Authorize]
        public void DeleteExhibition (int id)
        {
            Exhibitions.Remove(id);
        }
        [Authorize]
        public void AddExhibition(Exhibition ex)
        {
            if(!Exhibitions.Keys.Contains(ExhibitionId))
            {
                Exhibitions.Add(ExhibitionId, ex);
            }
        }
        [Authorize]
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
            }
        }



    }
}

