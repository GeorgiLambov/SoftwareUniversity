using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum
{
    public class Pill : Bonus
    {
        public Pill(string id, int healthEffect = 0, int defenseEffect = 0, int attackEffect = 100)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = 1;
            this.Timeout = 1;
            this.HasTimedOut = false;
        }
    }
}
