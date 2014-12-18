using System;
using System.Collections.Generic;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private MachineType machineType;
        private IPilot pilot;
        private IList<string> targets = new List<string>();    // ;

        public Machine(string name, double attackPoints, double defensePoints, double healthPoints, MachineType type)
        {
            this.Name = name;                           // this.Targets = new List<String>(Targets);
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.machineType = type;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set { this.defensePoints = value; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }             // return new List<String>(Targets);
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of targets cannot be null.");
                }

                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {

            var result = string.Format("- {0}\n *Type: {1}\n *Health: {2}\n *Attack: {3}\n *Defense: {4}\n *Targets: {5}",
                this.Name, this.GetType().Name, this.HealthPoints, this.AttackPoints, this.DefensePoints, this.Targets.Count != 0 ? string.Join(", ", this.Targets) : "None");

            return result;
        }
    }
}
