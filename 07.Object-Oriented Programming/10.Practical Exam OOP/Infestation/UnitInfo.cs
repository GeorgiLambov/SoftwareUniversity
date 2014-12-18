using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public struct UnitInfo
    {
        public string Id { get; private set; }

        public int Health { get; private set; }

        public int Power { get; private set; }

        public int Aggression { get; private set; }

        public UnitClassification UnitClassification { get; private set; }

        public UnitInfo(string id, UnitClassification unitType, int health, int power, int aggression) : this()
        {
            this.Id = id;
            this.Health = health;
            this.UnitClassification = unitType;
            this.Power = power;
            this.Aggression = aggression;
        }

        public UnitInfo(Unit unit) 
            : this(unit.Id, unit.UnitClassification, unit.Health, unit.Power, unit.Aggression)
        {
        }
    }
}
