using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Engine;
using Estates.Interfaces;

namespace Estates.Data
{
    class ExtendedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocation(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPrice(cmdArgs[0], cmdArgs[1]);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPrice(string minP, string maxPr)
        {
            decimal minPrice = decimal.Parse(minP);
            decimal maxPrice = decimal.Parse(maxPr);

            var targets = from target in this.Offers
                          where target.Type == OfferType.Rent      // .Cast<IRentOffer>()
                          where ((IRentOffer)target).PricePerMonth >= minPrice &&
                          ((IRentOffer)target).PricePerMonth <= maxPrice
                          orderby ((IRentOffer)target).PricePerMonth, target.Estate.Name
                          select target;           // .ThenBy(target.Estate.Name);

            return FormatQueryResults(targets);
        }

        private string ExecuteFindRentsByLocation(string location)
        {
            var list = this.Offers;
            if (list == null)
            {
                throw new ArgumentException("List of offers cannot be null!");
            }

            var offers = list
                    .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                    .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}
