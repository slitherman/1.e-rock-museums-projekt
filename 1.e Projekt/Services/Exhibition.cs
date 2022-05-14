using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _1.e_Projekt.Services
{
    public class Exhibition
    {
        private Dictionary<int, Exhibition> Exhibitions { get; set; }
        public int ExhibitionId { get; set; }
        public string ExhibitionName { get; set; }

        public string ImageName { get; set; }

        public Exhibition()
        {

            {
                Exhibitions = new Dictionary<int, Exhibition>();
                Exhibitions.Add(1, new Exhibition() { ExhibitionId = 1, ExhibitionName = "Rockens opstart", ImageName="Rock.jpg" });
                Exhibitions.Add(2, new Exhibition() { ExhibitionId = 2, ExhibitionName = "Musik før 2.Verdenskrig", ImageName="Jazz.jpg"});
                Exhibitions.Add(3, new Exhibition() { ExhibitionId = 3, ExhibitionName = "Protestmusikken i 60'erne", ImageName="Protest.jpg" });
                Exhibitions.Add(4, new Exhibition() { ExhibitionId = 4, ExhibitionName = "Stoffers indflydelse på musik" , ImageName="Woodstock.jpg"});


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

