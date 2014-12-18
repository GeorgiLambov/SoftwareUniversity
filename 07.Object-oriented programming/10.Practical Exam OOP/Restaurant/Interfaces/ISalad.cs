namespace RestaurantManager.Interfaces
{
    public interface ISalad : IMeal
    {
        bool ContainsPasta { get; }
    }
}
