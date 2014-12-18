using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType initialType)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = initialType;
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Type: {0}", this.Type.ToString());
            return result.ToString();
        }
    }
}
