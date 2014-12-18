using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ExtendedEstateEngine();       //EstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Apartment();
                    break;
                case EstateType.House:
                    return new House();
                    break;
                case EstateType.Office:
                    return new Office();
                    break;
                case EstateType.Garage:
                    return new Garage();
                    break;
                default:
                    throw new NotImplementedException("Estate type is not valid!");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new Rent();
                case OfferType.Sale:
                    return new Sale();
                default:
                    throw new NotImplementedException("Offer type not supported: " + type);
            }
        }
    }
}
