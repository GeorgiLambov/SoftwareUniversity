using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;
        private bool hasElevator;

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("BuildingEstate rooms should be in range [0…20]!");
                }

                this.rooms = value;
            }
        }
        public bool HasElevator
        {
            get { return this.hasElevator; }
            set { this.hasElevator = value; }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Rooms: {0}, Elevator: {1}",
                this.Rooms,
                this.HasElevator ? "Yes" : "No");
        }
    }
}
