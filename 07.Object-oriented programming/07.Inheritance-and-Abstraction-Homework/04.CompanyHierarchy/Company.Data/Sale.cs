using System;

namespace Company.Data
{
    public class Sale : ISale
    {
        private string productName;
        private DateTime saleDate;
        private decimal price;

        public Sale(string productName, decimal price, DateTime saleDate)
        {
            this.ProductName = productName;
            this.Price = price;
            this.SaleDate = saleDate;
        }
        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be null or empty!");
                }

                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The product price cannot be negative!");
                }

                this.price = value;
            }
        }

        public DateTime SaleDate
        {
            get { return this.saleDate; }
            set
            {
                if (value == default(DateTime))
                {
                    throw new ArgumentException("Datetime is invalid!");
                }

                this.saleDate = value;
            }
        }
    }
}
