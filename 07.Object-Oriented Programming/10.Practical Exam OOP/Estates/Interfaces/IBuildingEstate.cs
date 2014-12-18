namespace Estates.Interfaces
{
    public interface IBuildingEstate : IEstate
    {
        int Rooms { get; set; }
        bool HasElevator { get; set; }
    }
}
