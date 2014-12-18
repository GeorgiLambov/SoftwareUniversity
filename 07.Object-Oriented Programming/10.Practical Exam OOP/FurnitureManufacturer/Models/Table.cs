using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, ITable
    {
        private decimal lenght;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal lenght, decimal width)
            : base(model, material, price, height)
        {
            this.Length = lenght;
            this.Width = width;
        }

        public decimal Length
        {
            get { return this.lenght; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table lenht must be positive number!");
                }

                this.lenght = value;
            }
        }
        public decimal Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table width must be positive number!");
                }

                this.width = value;
            }
        }
        public decimal Area { get { return this.Width * this.Length; } }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
