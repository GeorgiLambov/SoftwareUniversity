using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Garage : Estate, IGarage
    {
        private int height;
        private int width;

        public Garage()
        {
            this.Type = EstateType.Garage;
        }

        public int Width
        {
            get
            {
                return this.width;

            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentException("Garage width should be in range [0…500].");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;

            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentException("Garage height should be in range [0…500].");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}
