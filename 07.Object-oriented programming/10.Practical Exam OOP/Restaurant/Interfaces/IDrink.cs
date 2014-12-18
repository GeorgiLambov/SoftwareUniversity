namespace RestaurantManager.Interfaces
{
    public interface IDrink : IRecipe
    {
        bool IsCarbonated { get; }
    }
}
