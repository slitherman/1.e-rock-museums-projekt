//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace _1.e_Projekt.Services
//{
//    public class Presentation: Exhibition
//    {
//        private Dictionary<int, Presentation> Presentations { get; set; }
//        private Dictionary<int, Exhibition> Exhibitions { get; set; }
//        public string PresentationName { get;  private set; }
//        public int PresentationId { get; private set; }

    

//       public Presentation()
//       {

//        }

//       //der er ikke overlap imellem de 2 klasser, skal finde ud hvordan at jeg skal fixe det

//       public void AddPresentation(Presentation pre)
//        {
//            if(!Presentations.Keys.Contains(ExhibitionId))
//           {
//                Presentations.Add(PresentationId, pre);
//            }
//        }
//       public void UpdatePresentation(Presentation pre)
//        {
//            foreach (var id in Presentations)
//            {
//               if(id.Equals(PresentationId))
//               {
//                   PresentationId = PresentationId;
//                   PresentationName = PresentationName;
//                }
//           }
//       }

//        public void DeletePresentation(int id)
//        {
//           Presentations.Remove(id);
//        }

//       public Presentation readPresentation(int id)
//        {
//            return Presentations[id];
//       }
      

//    }
////}
