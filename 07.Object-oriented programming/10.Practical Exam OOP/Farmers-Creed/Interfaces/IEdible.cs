namespace FarmersCreed.Interfaces
{
    using FarmersCreed.Units;

    public interface IEdible : IProduct 
    {
        FoodType FoodType { get; set; }

        int HealthEffect { get; set; }
    }
}
