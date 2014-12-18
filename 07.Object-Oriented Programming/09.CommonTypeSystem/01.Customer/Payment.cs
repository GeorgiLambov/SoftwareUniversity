namespace CustomerSystem
{
    using System;

    public class Payment : ICloneable
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cannot be negative!");
                }
                this.price = value;
            }
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name cannot be null or empty!!!");
                }

                this.productName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1:C2}", this.ProductName, this.Price);
        }

        public object Clone()
        {
            Payment newPayment = this.MemberwiseClone() as Payment;

            if (newPayment == null)
            {
                throw new ArgumentException("Clone object payment cannot be cast to type Payment!");
            }

            return newPayment;
        }
    }
}
