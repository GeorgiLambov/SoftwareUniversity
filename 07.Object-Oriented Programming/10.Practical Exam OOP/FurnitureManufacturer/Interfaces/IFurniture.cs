namespace FurnitureManufacturer.Interfaces
{
    public interface IFurniture
    {
        string Model { get; }

        string Material { get; }

        decimal Price { get; set; }

        decimal Height { get; }
    }
}
