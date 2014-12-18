using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Data;
using Estates.Interfaces;

namespace Estates.Engine
{
    class EstateEngine : IEstateEngine
    {
        protected List<IEstate> Estates { get; set; }
        private HashSet<string> uniqueEstateNames = new HashSet<string>();
        protected List<IOffer> Offers { get; set; }

        public EstateEngine()
        {
            this.Estates = new List<IEstate>();
            this.Offers = new List<IOffer>();
        }

        public virtual string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "create":
                    return ExecuteCreateCommand(cmdArgs);
                case "status":
                    return ExecuteStatusCommand();
                case "find-sales-by-location":
                    return this.ExecuteFindSalesByLocationCommand(cmdArgs[0]);
                default:
                    throw new NotImplementedException("Unknown command: " + cmdName);
            }
        }

        protected virtual string ExecuteCreateCommand(string[] cmdArgs)
        {
            string objType = cmdArgs[0];
            switch (objType)
            {
                case "Apartment":
                    var apartment = (IApartment)EstateFactory.CreateEstate(EstateType.Apartment);
                    LoadEstateProperties(apartment, cmdArgs);
                    apartment.Rooms = int.Parse(cmdArgs[5]);
                    apartment.HasElevator = bool.Parse(cmdArgs[6]);
                    AddEstate(apartment);
                    break;
                case "Office":
                    var office = (IOffice)EstateFactory.CreateEstate(EstateType.Office);
                    LoadEstateProperties(office, cmdArgs);
                    office.Rooms = int.Parse(cmdArgs[5]);
                    office.HasElevator = bool.Parse(cmdArgs[6]);
                    AddEstate(office);
                    break;
                case "House":
                    var house = (IHouse)EstateFactory.CreateEstate(EstateType.House);
                    LoadEstateProperties(house, cmdArgs);
                    house.Floors = int.Parse(cmdArgs[5]);
                    AddEstate(house);
                    break;
                case "Garage":
                    var garage = (IGarage)EstateFactory.CreateEstate(EstateType.Garage);
                    LoadEstateProperties(garage, cmdArgs);
                    garage.Width = int.Parse(cmdArgs[5]);
                    garage.Height = int.Parse(cmdArgs[6]);
                    AddEstate(garage);
                    break;
                case "RentOffer":
                    var rentOffer = (IRentOffer)EstateFactory.CreateOffer(OfferType.Rent);
                    rentOffer.Estate = FindEstateByName(cmdArgs[1]);
                    rentOffer.PricePerMonth = decimal.Parse(cmdArgs[2]);
                    AddOffer(rentOffer);
                    break;
                case "SaleOffer":
                    var saleOffer = (ISaleOffer)EstateFactory.CreateOffer(OfferType.Sale);
                    saleOffer.Estate = FindEstateByName(cmdArgs[1]);
                    saleOffer.Price = decimal.Parse(cmdArgs[2]);
                    AddOffer(saleOffer);
                    break;
                default:
                    throw new NotImplementedException("Unknown object to create: " + objType);
            }
            return objType + " created.";
        }

        private static void LoadEstateProperties(IEstate estate, string[] cmdArgs)
        {
            estate.Name = cmdArgs[1];
            estate.Area = double.Parse(cmdArgs[2]);
            estate.Location = cmdArgs[3];
            estate.IsFurnished = bool.Parse(cmdArgs[4]);
        }

        private IEstate FindEstateByName(string estateName)
        {
            var estate = this.Estates.First(e => e.Name == estateName);
            return estate;
        }

        private void AddEstate(IEstate estate)
        {
            this.Estates.Add(estate);
            if (this.uniqueEstateNames.Contains(estate.Name))
            {
                throw new ArgumentException("Duplicated estate name: " + estate.Name);
            }
            this.uniqueEstateNames.Add(estate.Name);
        }

        private void AddOffer(IOffer offer)
        {
            this.Offers.Add(offer);
        }

        protected virtual string ExecuteStatusCommand()
        {
            var result = new StringBuilder();
            if (this.Estates.Count > 0)
            {
                result.AppendLine("Estates:");
                foreach (var estate in this.Estates)
                {
                    result.AppendLine("  " + estate);
                }
            }
            else
            {
                result.AppendLine("No estates");
            }

            if (this.Offers.Count > 0)
            {
                result.AppendLine("Offers:");
                foreach (var offer in this.Offers)
                {
                    result.AppendLine("  " + offer);
                }
            }
            else
            {
                result.AppendLine("No offers");
            }

            return result.ToString().Trim();
        }

        private string ExecuteFindSalesByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Sale)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        protected string FormatQueryResults(IEnumerable<IOffer> offers)
        {
            var result = new StringBuilder();
            if (offers.Count() == 0)
            {
                result.AppendLine("No Results");
            }
            else
            {
                result.AppendLine("Query Results:");
                foreach (var offer in offers)
                {
                    decimal? price = null;
                    if (offer.Type == OfferType.Rent)
                    {
                        price = ((IRentOffer)offer).PricePerMonth;
                    }
                    if (offer.Type == OfferType.Sale)
                    {
                        price = ((ISaleOffer)offer).Price;
                    }
                    result.AppendFormat("  [Estate: {0}, Location: {1}",
                        offer.Estate.Name, offer.Estate.Location);
                    if (price != null)
                    {
                        result.AppendFormat(", Price: {0}", price);
                    }
                    result.AppendLine("]");
                }
            }
            return result.ToString().Trim();
        }
    }
}
