using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Salad : Meal, ISalad
    {
        private const bool SaladIsVegan = true;

        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, SaladIsVegan)
        {
            this.ContainsPasta = containsPasta;
        }
        public bool ContainsPasta { get; private set; }
        public override void ToggleVegan()
        {
            throw new InvalidOperationException("A salad must should always be vegan.");
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no");
            return result.ToString();
        }
    }
}
