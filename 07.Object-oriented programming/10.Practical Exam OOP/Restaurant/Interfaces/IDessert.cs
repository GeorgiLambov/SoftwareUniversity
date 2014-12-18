namespace RestaurantManager.Interfaces
{
    public interface IDessert : IMeal
    {
        bool WithSugar { get; }

        void ToggleSugar(); // Turns "with sugar" to "without sugar" and vice versa
    }
}
