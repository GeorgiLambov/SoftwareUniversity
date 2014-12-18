using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Rent : Offer, IRentOffer
    {

        private decimal pricePerMonth;
        public Rent()
        {
            this.Type = OfferType.Rent;
        }
        public decimal PricePerMonth
        {
            get { return this.pricePerMonth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price Per Month cannot be negative number!");
                }

                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Price = {0}", this.PricePerMonth);
        }
    }
}
