using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private const double InHealthPoints = 200;
        private bool stealthMode;
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints, InHealthPoints, MachineType.Fighter)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
            set { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n *Stealth: {0}", this.StealthMode ? "ON" : "OFF");
        }
    }
}
