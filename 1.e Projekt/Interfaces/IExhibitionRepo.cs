using _1.e_Projekt.Models;
using _1.e_Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Interfaces
{
    public interface IExhibitionRepo
    {
        Exhibition GetExhibition(int id);
        void DeleteExhibition(int id);
        void AddExhibition(Exhibition ex);
        void UpdateExhibition(Exhibition ex);
        Dictionary<int, Exhibition> GetExhibitions();
        void AddPresentation(Exhibition pre);
        void UpdatePresentation(Exhibition pre);
        void DeletePresentation(int id);
        Exhibition ReadPresentation(int id);
        Dictionary<int, Exhibition> GetPreentations();



    }
}
