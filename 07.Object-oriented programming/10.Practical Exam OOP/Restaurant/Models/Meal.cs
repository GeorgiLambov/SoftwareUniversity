using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Meal : Recipe, IMeal
    {
        public Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.Unit = MetricUnit.Grams;
        }

        public bool IsVegan { get; private set; }

        public virtual void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.IsVegan)
            {
                result.Append("[VEGAN] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}

