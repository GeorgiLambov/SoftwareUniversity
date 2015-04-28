namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketCatalogBusTicketsUnitTests
    {
        [TestMethod]
        public void TestAddBusTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();
            
            string cmdResult = catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddBusTicketDuplicates()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            string cmdResult = catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 28.00M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTickedDeleted()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            string cmdResult = catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            string cmdResult = catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 07));

            Assert.AreEqual("Ticket does not exist", cmdResult);

            cmdResult = catalog.DeleteBusTicket(from: "Sofia", to: "VARNA", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            cmdResult = catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "Bus Express", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteDeletedBusTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);
            catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            string cmdResult = catalog.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}
