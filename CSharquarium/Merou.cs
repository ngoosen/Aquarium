using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    internal class Merou : Carnivore, IPoisson
    {
        // Sexualité : Hermaphrodite avec l'âge

        public string Nom { get; set; }
        public Sexe Sexe { get; set; }

        public Merou()
        {
            PV = 10;
        }
        public Merou(string nom, int age, Sexe sexe) : this()
        {
            Nom = nom;
            Age = age;
            Sexe = sexe;
        }
        public Merou(string nom, int age, int pv, Sexe sexe) : this(nom, age, sexe)
        {
            PV = pv;
        }
        public string GetRace()
        {
            return "Mérou";
        }
        public bool SeReproduire(IPoisson p)
        {
            if (p == this) return false;
            if (p is Merou && this.Sexe != p.Sexe)
            {
                return true;
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
