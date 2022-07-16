using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    internal class Bar : Herbivore, IPoisson
    {
        // Sexualité: Hermaphrodite avec l'âge

        public string Nom { get; set; }
        public Sexe Sexe { get; set; }

        // Ctor
        public Bar()
        {
            PV = 10;
        }
        public Bar(string nom, int age, Sexe sexe) : this()
        {
            Nom = nom;
            Age = age;
            Sexe = sexe;
        }
        public Bar(string nom, int age, int pv, Sexe sexe) : this(nom, age, sexe)
        {
            PV = pv;
        }

        // Méthodes
        public string GetRace()
        {
            return "Bar";
        }
        public bool SeReproduire(IPoisson p)
        {
            if (p == this) return false;
            if (p is Bar && this.Sexe != p.Sexe)
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
