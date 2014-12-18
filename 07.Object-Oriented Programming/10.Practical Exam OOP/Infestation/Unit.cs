using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    abstract public class Unit
    {
        public string Id { get; private set; }

        public UnitClassification UnitClassification { get; private set; }

        private int baseHealth;
        private int basePower;
        private int baseAggression;

        public virtual int Health 
        {
            get
            {
                int supplementsBonus = 0;
                foreach (var supplement in this.supplements)
                {
                    supplementsBonus += supplement.HealthEffect;
                }

                return this.baseHealth + supplementsBonus;
            }
        }
        public virtual int Power
        {
            get
            {
                int supplementsBonus = 0;
                foreach (var supplement in this.supplements)
                {
                    supplementsBonus += supplement.PowerEffect;
                }

                return this.basePower + supplementsBonus;
            }
        }
        public virtual int Aggression
        {
            get
            {
                int supplementsBonus = 0;
                foreach (var supplement in this.supplements)
                {
                    supplementsBonus += supplement.AggressionEffect;
                }

                return this.baseAggression + supplementsBonus;
            }
        }

        private ICollection<ISupplement> supplements;
        //public ICollection<ISupplement> Supplements
        //{
        //    get
        //    {
        //        if (this.supplements == null)
        //        {
        //            this.supplements = new List<ISupplement>();
        //        }
        //        return this.supplements;
        //    }

        //    private set
        //    {
        //        this.supplements = value;
        //    }
        //}

        public Unit(string id, UnitClassification unitType, int health, int power, int aggression)
        {
            this.Id = id;
            this.UnitClassification = unitType;

            this.baseHealth = health;
            this.basePower = power;
            this.baseAggression = aggression;

            this.supplements = new List<ISupplement>();
        }

        public void DecreaseBaseHealth(int quantity)
        {
            this.baseHealth -= quantity;
        }

        public virtual void AddSupplement(ISupplement newSupplement)
        {
            foreach (var supplement in this.supplements)
            {
                newSupplement.ReactTo(supplement);
            }

            this.supplements.Add(newSupplement);
        }

        public override string ToString()
        {
            StringBuilder supplementsBuilder = new StringBuilder();
            foreach (var supplement in this.supplements)
            {
                supplementsBuilder.Append(supplement.GetType().Name + ", ");
            }

            if (supplementsBuilder.Length != 0)
            {
                supplementsBuilder.Remove(supplementsBuilder.Length - ", ".Length, ", ".Length); //removing the excess comma-space, coming from the foreach loop above (", ")
            }
            string unitSignature = this.GetType().Name + " " + this.Id + " (" + this.UnitClassification + ")";

            return String.Format("{0} [Health: {1}, Power: {2}, Aggression: {3}, Supplements: [{4}]]",
                unitSignature, this.Health, this.Power, this.Aggression, supplementsBuilder.ToString());
        }

        public virtual Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Attack);
            }

            return Interaction.PassiveInteraction;
        }

        protected virtual UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the least power and attacks it
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Power < optimalAttackableUnit.Power)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }

        protected virtual bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;
            if (this.Id != unit.Id)
            {
                if (this.Aggression >= unit.Power)
                {
                    attackUnit = true;
                }
            }
            return attackUnit;
        }

        public UnitInfo Info
        {
            get { return new UnitInfo(this); }
        }

        public virtual bool IsDestroyed
        {
            get
            {
                return this.Health <= 0;
            }
        }
    }
}
