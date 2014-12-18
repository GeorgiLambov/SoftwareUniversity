namespace Company.Data
{
    using System;
    public interface ISale
    {
        string ProductName { get; set; }

        decimal Price { get; set; }

        DateTime SaleDate { get; set; }
    }
}
