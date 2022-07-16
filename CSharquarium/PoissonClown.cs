using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    internal class PoissonClown : Carnivore, IPoisson
    {
        // Sexualité: Hermaphrodite opportuniste
        public string Nom { get; set; }
        public Sexe Sexe { get; set; }
        public PoissonClown()
        {
            PV = 10;
        }
        public PoissonClown(string nom, int age, Sexe sexe) : this()
        {
            Nom = nom;
            Age = age;
            Sexe = sexe;
        }
        public PoissonClown(string nom, int age, int pv, Sexe sexe) : this(nom, age, sexe)
        {
            PV = pv;
        }
        public string GetRace()
        {
            return "Poisson-clown";
        }
        public bool SeReproduire(IPoisson p)
        {
            if (p == this) return false;
            if (p is PoissonClown)
            {
                if (this.Sexe != p.Sexe)
                {
                    return true;
                }
                else
                {
                    this.Sexe = (this.Sexe == Sexe.Mâle) ? Sexe.Femelle : Sexe.Mâle;
                    return true;
                }
            }
            else return false;
        }
        public void Manger(IEtreVivant p)
        {
            if (p is Algue) return;
            if (p == this) return;
            this.PV += 5;
            p.PV = 0;
        }
    }
}
