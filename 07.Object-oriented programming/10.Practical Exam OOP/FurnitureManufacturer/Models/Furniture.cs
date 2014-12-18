using System;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private MaterialType materialType;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.Material = material;
        }

        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 3)
                {
                    throw new ArgumentNullException("Model cannot be empty, null or with less than 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get { return this.materialType.ToString(); }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Material cannot be empty, null!");
                }
                switch (value)
                {
                    case "wooden":
                        this.materialType = MaterialType.Wooden;
                        break;
                    case "plastic":
                        this.materialType = MaterialType.Plastic;
                        break;
                    case "leather":
                        this.materialType = MaterialType.Leather;
                        break;
                    default:
                        throw new ArgumentException("Material can be one of Wooden, Plastic or Leather!");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less or equal to $0.00!");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Hight cannot be less or equal to 0.00m!");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name,
                this.Model, this.Material, this.Price, this.Height);
        }
    }
}
