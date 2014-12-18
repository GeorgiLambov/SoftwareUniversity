using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Estate : IEstate
    {
        private string name;
        private double area;
        private string location;
        private bool isFurnished;
        private EstateType type;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Estate name cannot be null or empty!");
                }

                this.name = value;
            }
        }
        public EstateType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("Estate area should be in range [0…10000]!");
                }

                this.area = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Location name cannot be null or empty!");
                }

                this.location = value;
            }
        }

        public bool IsFurnished
        {
            get { return this.isFurnished; }
            set { this.isFurnished = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.Type,
                this.Name,      //this.GetType().Name,
                this.Area,
                this.Location,
                this.IsFurnished ? "Yes" : "No");

        }
    }
}
