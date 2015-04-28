namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketCatalogTrainTicketsUnitTests
    {
        [TestMethod]
        public void TestAddTrainTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();

            string cmdResult = catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestAddTrainTicketDuplicates()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);

            string cmdResult = catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 28.00M, studentPrice: 17.70M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTickedDeleted()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);

            string cmdResult = catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 22.00M, studentPrice: 11.00M);

            string cmdResult = catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 33));

            Assert.AreEqual("Ticket does not exist", cmdResult);

            cmdResult = catalog.DeleteTrainTicket(from: "Sofia", to: "VARNA", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);

            cmdResult = catalog.DeleteTrainTicket(from: "sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteDeletedTrainTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            string cmdResult = catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }
    }
}
