using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class House : Estate, IHouse
    {
        private int numOfFloors;

        public House()
        {
            this.Type = EstateType.House;
        }

        public int Floors
        {
            get { return this.numOfFloors; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("House floors should be in range [0…10]!");
                }

                this.numOfFloors = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Floors: {0}", this.Floors);
        }
    }
}
