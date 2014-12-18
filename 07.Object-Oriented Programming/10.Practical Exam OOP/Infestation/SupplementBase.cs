using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class SupplementBase : ISupplement
    {
        public SupplementBase(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
