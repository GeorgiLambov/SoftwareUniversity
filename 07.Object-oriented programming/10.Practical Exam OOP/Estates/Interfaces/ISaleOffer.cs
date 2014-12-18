namespace Estates.Interfaces
{
    public interface ISaleOffer : IOffer
    {
        decimal Price { get; set; }
    }
}
