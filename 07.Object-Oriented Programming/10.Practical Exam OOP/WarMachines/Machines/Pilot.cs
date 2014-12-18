using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines = new List<IMachine>();
        public Pilot(string initialName)
        {
            this.Name = initialName;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot's name cannot be empty or null!");
                }

                this.name = value;
            }
        }

        public IList<IMachine> Machines
        {
            get
            {
                return this.machines;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of machines cannot be null.");
                }

                this.machines = value;
            }
        }
        public void AddMachine(IMachine machine)
        {
            this.Machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("{0} - {1} {2}",
                this.Name,
                this.Machines.Count != 0 ? this.Machines.Count.ToString() : "no",
                this.Machines.Count != 1 ? "machines" : "machine"));

            var sortedMachines = this.Machines
                                     .OrderBy(mach => mach.HealthPoints)
                                     .ThenBy(mach => mach.Name);

            foreach (var machine in sortedMachines)
            {
                result.AppendLine(machine.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
