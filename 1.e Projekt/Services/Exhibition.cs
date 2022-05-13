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

        // er ikk helt sikker på hvad at dette gør
        //public Dictionary<int, Exhibition> GetExhibitions()
        //{
        //    return Exhibitions;
        //}

        public Exhibition GetExhibition(int id)
        {
            return Exhibitions[id];
        }

        public void DeleteExhibition ()
        {
            Exhibitions.Remove(ExhibitionId);
        }

        public void AddExhibition(Exhibition ex)
        {
            if(!Exhibitions.Keys.Contains(ExhibitionId))
            {
                Exhibitions.Add(ExhibitionId, ex);
            }
        }
        public void UpdateExhibition ()
        {
            foreach (var id in Exhibitions)
            {
                if(id.Equals(ExhibitionId))
                {
                    ExhibitionId = ExhibitionId;
                    ExhibitionName = ExhibitionName;
                }
            }
        }

    }
}

