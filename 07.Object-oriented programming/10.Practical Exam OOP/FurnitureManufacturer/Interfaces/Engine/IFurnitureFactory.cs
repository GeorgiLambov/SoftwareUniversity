namespace FurnitureManufacturer.Interfaces.Engine
{
    public interface IFurnitureFactory
    {
        ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width);

        IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs);

        IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs);

        IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs);
    }
}
