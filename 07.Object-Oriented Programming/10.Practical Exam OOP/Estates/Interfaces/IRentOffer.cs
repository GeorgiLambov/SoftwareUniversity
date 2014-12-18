namespace Estates.Interfaces
{
    public interface IRentOffer : IOffer
    {
        decimal PricePerMonth { get; set; }
    }
}
