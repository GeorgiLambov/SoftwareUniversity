namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces.Engine;
    using RestaurantManager.Models;

    public class RestaurantFactory : IRestaurantFactory
    {
        public Interfaces.IRestaurant CreateRestaurant(string name, string location)
        {
            return new Restaurant(name, location);
        }
    }
}
