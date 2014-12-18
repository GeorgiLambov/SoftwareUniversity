using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Healer : Character, IHeal
    {
        private int healingPoints;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.healingPoints = 60;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {

            var targets = from target in targetsList
                          where (target.IsAlive == true) &&
                          (target.Team == this.Team) &&
                          (target != this)
                          orderby target.HealthPoints
                          select target;

            return targets.FirstOrDefault() as Character;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            if (!this.Inventory.Contains(item))
            {
                throw new ArgumentException("There not have this item!");
            }

            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }


        public int HealingPoints
        {
            get { return this.healingPoints; }
            set { this.healingPoints = value; }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}
