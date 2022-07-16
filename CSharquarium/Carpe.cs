using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    internal class Carpe : Herbivore, IPoisson
    {
        // Sexualité: Monosexué

        public string Nom { get; set; }
        public Sexe Sexe { get; set; }

        public Carpe()
        {
            PV = 10;
        }
        public Carpe(string nom, int age, Sexe sexe) : this()
        {
            Nom = nom;
            Age = age;
            Sexe = sexe;
        }
        public Carpe(string nom, int age, int pv, Sexe sexe) : this(nom, age, sexe)
        {
            PV = pv;
        }
        public string GetRace()
        {
            return "Carpe";
        }
        public bool SeReproduire(IPoisson p)
        {
            if (p == this) return false;
            if (p is Carpe && this.Sexe != p.Sexe)
            {
                return true;
            }
            else return false;
        }
        public void Manger(IEtreVivant a)
        {
            if (a is IPoisson) return;
            this.PV += 3;
            a.PV -= 2;
        }
    }
}
