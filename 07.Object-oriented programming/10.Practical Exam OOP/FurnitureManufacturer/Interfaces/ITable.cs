namespace FurnitureManufacturer.Interfaces
{
    public interface ITable : IFurniture
    {
        decimal Length { get; }

        decimal Width { get; }

        decimal Area { get; }
    }
}
