using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Offer : IOffer
    {
        private IEstate estate;
        private OfferType type;

        public OfferType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public IEstate Estate
        {
            get { return this.estate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Cannot offer without estate!");
                }

                this.estate = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Estate = {1}, Location = {2}",
                this.GetType().Name,
                this.Estate.Name,
                this.Estate.Location);
        }
    }
}
