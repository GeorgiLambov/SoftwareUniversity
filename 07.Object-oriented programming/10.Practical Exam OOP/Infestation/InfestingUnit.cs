using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class InfestingUnit : Unit
    {
        public InfestingUnit(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var candidateUnits = units.Where((unit) => unit.Id != this.Id && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification));

            UnitInfo optimalInfestableUnit = new UnitInfo(null, Infestation.UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in candidateUnits)
            {
                if (unit.Health < optimalInfestableUnit.Health)
                {
                    optimalInfestableUnit = unit;
                }
            }

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
