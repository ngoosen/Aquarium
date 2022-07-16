using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    interface IPoisson : IEtreVivant
    {
        string Nom { get; set; }
        Sexe Sexe { get; set; }
        string GetRace();
        bool SeReproduire(IPoisson p);
        void Manger(IEtreVivant e);
    }
}
