using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private bool isEnhaced;
        private int attackPoints;
        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.isEnhaced = false;
            this.HitPoints = 200;
            this.attackPoints = 150;
        }
        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!isEnhaced)
                {
                    this.isEnhaced = true;
                    this.attackPoints += 100;
                }

                return true;
            }

            return false; ;
        }
    }
}
