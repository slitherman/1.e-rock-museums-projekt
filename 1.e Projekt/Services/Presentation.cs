using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace _1.e_Projekt.Services
{
   public class Presentation: Exhibition
    {
    public Dictionary<int, Presentation> Presentations { get; set; }
     
       public string PresentationName { get;  private set; }
       public int PresentationId { get; private set; }
       public string ImageName { get; set; }





        public Presentation( int ConstructorId)
            : base(ConstructorId)
       {
            Presentations = new Dictionary<int, Presentation>();
            Presentations.Add(1, new Presentation(11) { PresentationId = 1, PresentationName = " Oplæg Om Rockens Opstart", ImageName = "Rock.jpg" });
            Presentations.Add(2, new Presentation(21) { PresentationId = 1, PresentationName = " Oplæg Om Musik Før 2.Verdenskrig", ImageName = "Jazz.jpg" });
            Presentations.Add(3, new Presentation(31) { PresentationId = 1, PresentationName = " Oplæg Om Protestmusikken i 60'erne", ImageName = "Protest.jpg" });
            Presentations.Add(4, new Presentation(41) { PresentationId = 1, PresentationName = " Oplæg Om Stoffers Indflydelse På Musik", ImageName = "Woodstock.jpg" });



       

            //foreach (var ids in Presentations.Values)
            //{
            //    if(ids.ExhibitionId.Equals(PresentationId))
            //    {

            //        var CombinedCollections = Presentations.Concat(Exhibitions.Where(kvp => !Presentations.ContainsKey(kvp.Key)));


            //    }
            //}
        }

        //der er ikke overlap imellem de 2 klasser, skal finde ud hvordan at jeg skal fixe det
        [Authorize]
        public void AddPresentation(Presentation pre)
       {
           if(!Presentations.Keys.Contains(ExhibitionId))
          {
               Presentations.Add(PresentationId, pre);
           }
       }
        [Authorize]
        public void UpdatePresentation(Presentation pre)
       {
          foreach (var id in Presentations.Values)
            {
             if(id.ExhibitionId.Equals(PresentationId))
             {
                  PresentationId = PresentationId;
                  PresentationName = PresentationName;
               }
          }       }
        [Authorize]
        public void DeletePresentation(int id)
        {
           Presentations.Remove(id);        }

       public Presentation readPresentation(int id)       {
            return Presentations[id];
       }
      
    }
    public Dictionary<int, Presentation> GetPreentations()
    {
        return Presentations;
    }

    
}
