namespace Estates.Interfaces
{
    public interface IOffer
    {
        OfferType Type { get; set; }
        IEstate Estate { get; set; }
    }
}
