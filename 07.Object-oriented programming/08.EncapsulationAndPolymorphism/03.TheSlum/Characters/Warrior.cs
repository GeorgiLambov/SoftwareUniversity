using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Warrior : Character, IAttack
    {
        private int attackPoints;

        public Warrior(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = 150;
        }
        public Warrior(string id, int x, int y, Team team)
            : this(id, x, y, 200, 100, team, 2)
        {
        }
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList
                .FirstOrDefault(character => (character.Team != this.Team) &&
                character.IsAlive == true);

            return target;
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

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }

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
