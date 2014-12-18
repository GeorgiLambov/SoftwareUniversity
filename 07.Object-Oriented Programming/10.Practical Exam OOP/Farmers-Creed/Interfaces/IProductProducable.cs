namespace FarmersCreed.Interfaces
{
    using FarmersCreed.Units;

    public interface IProductProduceable
    {
        int ProductionQuantity { get; set; }

        Product GetProduct();
    }
}
