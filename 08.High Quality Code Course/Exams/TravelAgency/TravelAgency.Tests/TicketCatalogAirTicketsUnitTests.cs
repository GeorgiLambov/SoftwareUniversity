namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketCatalogAirTicketsUnitTests
    {
        [TestMethod]
        public void TestAddAirTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();
            
            string cmdResult = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketDuplicates()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            
            string cmdResult = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "London", airline: "Wizz Air", dateTime: new DateTime(2015, 1, 22, 06, 15, 00), price: 730.55M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTickedDeleted()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string cmdResult = catalog.DeleteAirTicket(flightNumber: "FX215");

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string cmdResult = catalog.DeleteAirTicket(flightNumber: "FX217");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteDeletedAirTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            catalog.DeleteAirTicket(flightNumber: "FX215");

            string cmdResult = catalog.DeleteAirTicket(flightNumber: "FX215");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
