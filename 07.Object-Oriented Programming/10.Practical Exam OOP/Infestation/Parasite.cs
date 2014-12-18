using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Parasite : InfestingUnit
    {
        const int ParasitePower = 1;
        const int ParasiteHealth = 1;
        const int ParasiteAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.ParasiteHealth, Parasite.ParasitePower, Parasite.ParasiteAggression)
        {
        }
    }
}
