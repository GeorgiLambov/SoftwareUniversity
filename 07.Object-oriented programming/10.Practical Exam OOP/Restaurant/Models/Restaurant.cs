using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using RestaurantManager.Engine.Factories;
using RestaurantManager.Interfaces;
using System.Threading;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> recipes = new List<IRecipe>();

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = recipes;
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
        public string Location
        {
            get { return this.location; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The location is required.");
                }

                this.location = value;
            }
        }
        public IList<IRecipe> Recipes
        {
            get { return this.recipes; }
            private set { this.recipes = value; }
        }
        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("***** {0} - {1} *****", this.Name, this.Location).AppendLine();

            if (this.Recipes.Count > 0)
            {
                var list = this.Recipes;
                var sorderedBypeDRINKS = from target in list
                                         where target.GetType().Name == "Drink"
                                         orderby target.Name
                                         select target;

                if (sorderedBypeDRINKS.Count() > 0)
                {
                    result.AppendLine("~~~~~ DRINKS ~~~~~");

                    foreach (var recipe in sorderedBypeDRINKS)
                    {
                        result.AppendLine(recipe.ToString());
                    }

                    result.ToString().Trim();
                }

                var sorderedBypeSalads = from target in list
                                         where target.GetType().Name == "Salad"
                                         orderby target.Name
                                         select target;

                if (sorderedBypeSalads.Count() > 0)
                {
                    result.AppendLine("~~~~~ SALADS ~~~~~");

                    foreach (var recipe in sorderedBypeSalads)
                    {
                        result.AppendLine(recipe.ToString());
                    }

                    result.ToString().Trim();
                }

                var sorderedBypeMain = from target in list
                                       where target.GetType().Name == "MainCourse"
                                       orderby target.Name
                                       select target;

                if (sorderedBypeMain.Count() > 0)
                {
                    result.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                    foreach (var recipe in sorderedBypeMain)
                    {
                        result.AppendLine(recipe.ToString());
                    }
                }

                var sorderedBypeDesserts = from target in list
                                           where target.GetType().Name == "Dessert"
                                           orderby target.Name
                                           select target;

                if (sorderedBypeDesserts.Count() > 0)
                {
                    result.AppendLine("~~~~~ DESSERTS ~~~~~");

                    foreach (var recipe in sorderedBypeDesserts)
                    {
                        result.AppendLine(recipe.ToString());
                    }
                }
            }
            else
            {
                result.AppendLine("No recipes... yet");
            }

            return result.ToString().Trim();
        }
    }
}
