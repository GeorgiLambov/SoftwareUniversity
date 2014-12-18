namespace Estates.Interfaces
{
    public interface IGarage : IEstate
    {
        int Width { get; set; }
        int Height { get; set; }
    }
}
