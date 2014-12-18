using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantManager.Interfaces;
using System.Globalization;

namespace RestaurantManager.Models
{
    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private int timeToPrepare;
        private MetricUnit unit;

        public Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name is required.");
                }

                this.name = value;
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
        public virtual int Calories
        {
            get
            {
                return this.calories;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("The {0} must be positive.", "calories"));
                }

                this.calories = value;
            }
        }
        public int QuantityPerServing
        {
            get { return this.quantityPerServing; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The quantityPerServing must be positive.");
                }

                this.quantityPerServing = value;
            }
        }
        public MetricUnit Unit
        {
            get { return this.unit; }
            protected set { this.unit = value; }
        }
        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        string.Format("The {0} must be positive.", "time to prepare"));
                }

                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            var result = new StringBuilder();
            result.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine()
            .AppendFormat("Per serving: {0} {1}, {2} kcal",
                this.QuantityPerServing,
                this.Unit == MetricUnit.Milliliters ? "ml" : "g",
                this.Calories).AppendLine()
            .AppendFormat("Ready in {0} minutes", this.TimeToPrepare);

            return result.ToString();
        }
    }
}

