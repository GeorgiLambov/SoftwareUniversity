using System;
using System.Threading;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;
        private decimal originalHeight;
        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
        }

        public bool IsConverted { get; private set; }
        public void Convert()
        {
            this.IsConverted = !this.IsConverted;

            if (IsConverted == false)  // Initial state is normal.              
            {
                this.Height = originalHeight;
            }
            else
            {
                this.originalHeight = this.Height;   // Converted Height
                this.Height = ConvertedHeight;
            }


        }
        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
