namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;
    using RestaurantManager.Models;
    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            return new Drink(name, price, calories, quantityPerServing, timeToPrepare, isCarbonated);
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            return new Salad(name, price, calories, quantityPerServing, timeToPrepare, containsPasta);
        }

        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            MainCourseType mainCourseType = GetMainCourseTypeEnum(type);

            return new MainCourse(name, price, calories, quantityPerServing, timeToPrepare, isVegan, mainCourseType);
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            return new Dessert(name, price, calories, quantityPerServing, timeToPrepare, isVegan);
        }

        private MainCourseType GetMainCourseTypeEnum(string stringType)
        {
            switch (stringType)
            {
                case "Soup":
                    return MainCourseType.Soup;

                case "Entree":
                    return MainCourseType.Entree;

                case "Pasta":
                    return MainCourseType.Pasta;

                case "Side":
                    return MainCourseType.Side;

                case "Meat":
                    return MainCourseType.Meat;

                case "Other":
                    return MainCourseType.Other;

                default:
                    throw new InvalidOperationException("The MainCourseType is required.");
            }
        }
    }
}
