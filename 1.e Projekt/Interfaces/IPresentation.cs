using _1.e_Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.e_Projekt.Interfaces
{
    interface IPresentation
    {
        void AddPresentation(Presentation pre);
        void UpdatePresentation(Presentation pre);
        void DeletePresentation(int id);
        Presentation readPresentation(int id);
        Dictionary<int, Presentation> GetPreentations();

    }
}
