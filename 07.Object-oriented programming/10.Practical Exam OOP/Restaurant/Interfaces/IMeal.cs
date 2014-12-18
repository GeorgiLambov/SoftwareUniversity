namespace RestaurantManager.Interfaces
{
    public interface IMeal : IRecipe
    {
        bool IsVegan { get; }

        void ToggleVegan(); // Turns "vegan" to "not vegan" and vice versa
    }
}
