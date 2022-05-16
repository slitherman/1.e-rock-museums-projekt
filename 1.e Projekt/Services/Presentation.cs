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
        private static Presentation _Instance;

        public string PresentationName { get;  set; }
       public int PresentationId { get;  set; }
       public string ImageName { get; set; }





        public Presentation( )
            
       {
            
            //foreach (var ids in Presentations.Values)
            //{
            //    if(ids.ExhibitionId.Equals(PresentationId))
            //    {

            //        var CombinedCollections = Presentations.Concat(Exhibitions.Where(kvp => !Presentations.ContainsKey(kvp.Key)));


            //    }
            //}
        }
        public static Presentation Instance
        {
            get
            {
                if(_Instance ==null)
                {
                    _Instance = new Presentation();
                }
                return Instance;
            }
        }


        //der er ikke overlap imellem de 2 klasser, skal finde ud hvordan at jeg skal fixe det
        [Authorize]
        public void AddPresentation(Presentation pre)
       {
           if(!Presentations.Keys.Contains(pre.ExhibitionId))
          {
               Presentations.Add(PresentationId, pre);
           }
       }
        [Authorize]
        public void UpdatePresentation(Presentation pre)
       {
          foreach (var id in Presentations.Values)
            {
                if (id.PresentationId.Equals(pre.ExhibitionId))
             {
                    id.PresentationId = pre.ExhibitionId;
                    id.PresentationName = pre.PresentationName;
                    id.ImageName = pre.ImageName;

                }

          }       }

        [Authorize]
        public void DeletePresentation(int id)
        {
           Presentations.Remove(id);        }

       public Presentation readPresentation(int id)      
       {
            return Presentations[id];
       }
        public Dictionary<int, Presentation> GetPreentations()
        {
            return Presentations;
        }

    }
        
}
