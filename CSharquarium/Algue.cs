using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium
{
    internal class Algue : IEtreVivant
    {
        public int Age { get; set; }
        public int PV { get; set; }

        // Ctor
        public Algue()
        {
            Age = 0;
            PV = 10;
        }
        public Algue(int pv) : this()
        {
            PV = pv;
        }
        public Algue(int age, int pv) : this(pv)
        {
            Age = age;
        }
    }
}
