namespace MusicShop.Models
{
    using System;
    using System.Text;
    using MusicShopManager.Interfaces;

    public abstract class Article : IArticle
    {
        private string make;
        private string model;
        private decimal price;

        public Article(string make, string model, decimal price)
        {
            this.Model = model;
            this.Make = make;
            this.Price = price;
        }
        public string Make
        {
            get { return this.make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The make is required.");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The model is required.");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price must be positive.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("= {0} {1} =", this.Make, this.Model)
                .AppendLine()
                .AppendFormat("Price: ${0:F}", this.Price);
            
            return result.ToString();
        }
    }
}
