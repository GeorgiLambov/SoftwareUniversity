using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Sale : Offer, ISaleOffer
    {
        private decimal sellPrice;
        public Sale()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price
        {
            get { return this.sellPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Sell price cannot be negative number!");
                }

                this.sellPrice = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Price = {0}", this.Price);
        }
    }
}
