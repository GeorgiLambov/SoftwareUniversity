using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Drink : Recipe, IDrink
    {
        private const int MaxDrinkCalories = 100;
        private const int MaxDrinkTimeToPrepare = 20;
        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.Unit = MetricUnit.Milliliters;
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; private set; }
        public override int Calories
        {
            get
            {
                return base.Calories;
            }

            protected set
            {
                if (value > MaxDrinkCalories)
                {
                    throw new ArgumentException(
                        string.Format("The calories in a drink must not be greater than {0}.",
                        MaxDrinkCalories));
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }

            protected set
            {
                if (value > MaxDrinkTimeToPrepare)
                {
                    throw new ArgumentException(string.Format("The time to prepare a drink must not be greater than {0} minutes.", MaxDrinkTimeToPrepare));
                }

                base.TimeToPrepare = value;
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Carbonated: {0}", this.IsCarbonated ? "yes" : "no");
            return result.ToString();
        }
    }
}

