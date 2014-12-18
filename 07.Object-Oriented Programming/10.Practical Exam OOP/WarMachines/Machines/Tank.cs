using System.IO;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank, IMachine
    {
        private const double InHealthPoints = 100;
        private const int AttakPointsModifier = 40;
        private const int DefenceModifier = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InHealthPoints, MachineType.Tank)
        {
            // this.DefenseMode = true;   // turn ON
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get;
            private set;
        }
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= AttakPointsModifier;
                this.DefensePoints += DefenceModifier;
            }
            else
            {
                this.AttackPoints += AttakPointsModifier;
                this.DefensePoints -= DefenceModifier;
            }

            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n *Defense: {0}", this.DefenseMode ? "ON" : "OFF");
        }
    }
}
