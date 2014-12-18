using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }
        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            WorldObject target = availableTargets
                .OrderByDescending(t => t.HitPoints)
                .FirstOrDefault(t => t.Owner != 0 &&
                                     t.Owner != this.Owner);

            return availableTargets.IndexOf(target);
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
