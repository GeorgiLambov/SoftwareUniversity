namespace Estates.Interfaces
{
    public interface IEstate
    {
        string Name { get; set; }
        EstateType Type { get; set; }
        double Area { get; set; }
        string Location { get; set; }
        bool IsFurnished { get; set; }
    }
}
