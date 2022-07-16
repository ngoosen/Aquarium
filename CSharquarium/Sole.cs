using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    internal class Sole : Herbivore, IPoisson
    {
        // Sexualité: Hermaphrodite opportuniste

        public string Nom { get; set; }
        public Sexe Sexe { get; set; }

        public Sole()
        {
            PV = 10;
        }
        public Sole(string nom, int age, Sexe sexe) : this()
        {
            Nom = nom;
            Age = age;
            Sexe = sexe;
        }
        public Sole(string nom, int age, int pv, Sexe sexe) : this(nom, age, sexe)
        {
            PV = pv;
        }
        public string GetRace()
        {
            return "Sole";
        }
        public bool SeReproduire(IPoisson p)
        {
            if (p == this) return false;
            if (p is Sole)
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
        public void Manger(IEtreVivant a)
        {
            if (a is IPoisson) return;
            this.PV += 3;
            a.PV -= 2;
        }
    }
}
