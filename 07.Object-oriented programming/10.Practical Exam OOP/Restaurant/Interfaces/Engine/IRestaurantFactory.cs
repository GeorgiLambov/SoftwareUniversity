namespace RestaurantManager.Interfaces.Engine
{
    public interface IRestaurantFactory
    {
        IRestaurant CreateRestaurant(string name, string location);
    }
}
