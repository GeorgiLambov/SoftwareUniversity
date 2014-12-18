using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Mage : Character, IAttack
    {
        private int attackPoints;   // idva ot interface i shte se promenia

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, 0, 0, team, 0)       // podavam na base 0,0,0 i posle s defaut stoinosti
        {
            this.AttackPoints = 300;
            this.DefensePoints = 50;
            this.HealthPoints = 150;
            this.Range = 5;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            //var target = targetsList
            //    .LastOrDefault(character => (character.Team != this.Team) &&
            //    character.IsAlive);

            var targets = from target in targetsList
                          where (target.IsAlive == true) &&
                          (target.Team != this.Team) &&
                          (target != this)
                          select target;

            return targets.LastOrDefault() as Character;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);

        }

        public override void RemoveFromInventory(Item item)
        {
            if (!Inventory.Contains(item))
            {
                throw new ArgumentException("There not have this item!");
            }

            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }
        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }
        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Attack: {0}", this.AttackPoints);
        }
    }
}
