using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : InfestingUnit
    {
        const int QueenPower = 1;
        const int QueenHealth = 30;
        const int QueenAggression = 1;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.QueenHealth, Queen.QueenPower, Queen.QueenAggression)
        {
        }
    }
}
    