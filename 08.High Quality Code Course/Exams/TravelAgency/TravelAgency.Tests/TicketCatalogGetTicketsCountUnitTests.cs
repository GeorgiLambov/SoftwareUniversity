namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketCatalogGetTicketsCountUnitTests
    {
        [TestMethod]
        public void TestGetTicketsCountEmptyReturns0()
        {
            ITicketCatalog catalog = new TicketCatalog();
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestGetAirTicketsCountReturnsCorrectValues()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            catalog.AddAirTicket(flightNumber: "FX407", from: "Varna", to: "Sofia", airline: "Bulgaria Air", dateTime: new DateTime(2015, 2, 2, 7, 45, 00), price: 135.00M);
            Assert.AreEqual(2, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestGetBusTicketsCountReturnsCorrectValues()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 50, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddBusTicket(from: "Sofia", to: "Pleven", dateTime: new DateTime(2015, 1, 29, 8, 00, 00), price: 12.00M, travelCompany: "Pleven Trans");
            catalog.AddBusTicket(from: "Varna", to: "Rousse", dateTime: new DateTime(2015, 1, 29, 7, 00, 00), price: 17.00M, travelCompany: "Etap");
            Assert.AreEqual(3, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestGetTrainTicketsCountReturnsCorrectValues()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddTrainTicket(from: "Sofia", to: "Pleven", dateTime: new DateTime(2015, 1, 26, 8, 56, 00), price: 14.00M, studentPrice: 8.30M);
            Assert.AreEqual(2, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestGetTicketsCountForDeletedTicketsReturnsZero()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));

            catalog.DeleteAirTicket(flightNumber: "SV1234");
            catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00));
            catalog.DeleteBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), travelCompany: "Biomet");
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}
