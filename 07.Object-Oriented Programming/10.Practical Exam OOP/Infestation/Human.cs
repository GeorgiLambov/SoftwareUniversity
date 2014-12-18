using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Human : Unit
    {
        public const int HumanPower = 4;
        public const int HumanAggression = 1;
        public const int HumanHealth = 10;

        public Human(string id)
            : base(id, UnitClassification.Biological, Human.HumanHealth, Human.HumanPower, Human.HumanAggression)
        {
        }
    }
}
