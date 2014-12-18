namespace FurnitureManufacturer.Interfaces
{
    public interface IConvertibleChair : IChair
    {
        bool IsConverted { get; }

        void Convert();
    }
}
