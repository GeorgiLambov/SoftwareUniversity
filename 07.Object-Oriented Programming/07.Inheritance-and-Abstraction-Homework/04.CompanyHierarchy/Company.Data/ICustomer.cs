namespace Company.Data
{
    public interface ICustomer : IPerson
    {
        decimal NetPurchaseAmount { get; set; }
    }
}
