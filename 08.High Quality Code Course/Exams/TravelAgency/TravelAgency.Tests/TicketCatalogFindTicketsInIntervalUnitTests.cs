namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class TicketCatalogFindTicketsInIntervalUnitTests
    {
        [TestMethod]
        public void TestFindTicketsInIntervalReturnsTickets()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            catalog.AddAirTicket(from: "Sofia", to: "Plovdiv", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            catalog.AddBusTicket(from: "Varna", to: "Pleven", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddTrainTicket(from: "Sofia", to: "Veliko Tarnovo", dateTime: new DateTime(2015, 1, 23, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddBusTicket(from: "Varna", to: "Sofia", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            string cmdResult = catalog.FindTicketsInInterval(
                startDateTime: new DateTime(2015, 1, 29, 7, 40, 00),
                endDateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            string expectedCmdResult =
                "[29.01.2015 07:40; air; 24.00] [30.01.2015 11:35; bus; 25.00] [30.01.2015 12:55; train; 26.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsInIntervalReturnsNotFound()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            catalog.AddAirTicket(from: "Sofia", to: "Plovdiv", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            catalog.AddBusTicket(from: "Varna", to: "Pleven", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddTrainTicket(from: "Sofia", to: "Veliko Tarnovo", dateTime: new DateTime(2015, 1, 23, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddBusTicket(from: "Varna", to: "Sofia", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            string cmdResult = catalog.FindTicketsInInterval(
                startDateTime: new DateTime(2015, 1, 29, 7, 40, 01),
                endDateTime: new DateTime(2015, 1, 30, 11, 34, 59));

            Assert.AreEqual("Not found", cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsCheckCorrectSortingOrder()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 224.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 224.00M, airline: "Bulgaria Air", flightNumber: "SV453-2");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 40, 00), price: 224.00M, airline: "Air BG", flightNumber: "S9473");
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 1224.00M, airline: "Air Travel Corp.", flightNumber: "V245X");

            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 26, 7, 40, 00), price: 24.00M, studentPrice: 16.30M);
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 426.55M, studentPrice: 16.30M);

            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet2");
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 28.00M, travelCompany: "Etap");
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 27, 7, 40, 00), price: 25.00M, travelCompany: "New Bus Corp.");
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 5.72M, travelCompany: "Sofia Bus Ltd.");
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 1235.72M, travelCompany: "Varna Bus Travel Ltd.");

            string cmdResult = catalog.FindTicketsInInterval(
                startDateTime: new DateTime(1980, 1, 1, 0, 0, 0),
                endDateTime: new DateTime(2050, 2, 1, 0, 0, 0));

            string expectedCmdResult =
                "[24.01.2015 07:40; train; 426.55] " +
                "[26.01.2015 07:40; train; 24.00] " +
                "[27.01.2015 07:40; bus; 25.00] " +
                "[28.01.2015 07:40; air; 224.00] " +
                "[28.01.2015 07:45; train; 26.00] " +
                "[29.01.2015 07:40; air; 211.00] " +
                "[29.01.2015 07:40; air; 224.00] " +
                "[29.01.2015 07:40; air; 224.00] " +
                "[29.01.2015 07:40; air; 1224.00] " +
                "[29.01.2015 07:40; bus; 5.72] " +
                "[29.01.2015 07:40; bus; 25.00] " +
                "[29.01.2015 07:40; bus; 25.00] " +
                "[29.01.2015 07:40; bus; 28.00] " +
                "[29.01.2015 07:40; bus; 1235.72] " +
                "[29.01.2015 07:40; train; 26.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsCheckDeletedTickets()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00), price: 26.00M, studentPrice: 16.30M);
            catalog.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            string cmdResult = catalog.FindTicketsInInterval(
                startDateTime: new DateTime(1980, 1, 1, 0, 0, 0),
                endDateTime: new DateTime(2050, 2, 1, 0, 0, 0));
            string expectedCmdResult =
                "[28.01.2015 07:45; train; 26.00] " +
                "[29.01.2015 07:40; air; 211.00] " +
                "[29.01.2015 07:40; bus; 25.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);

            catalog.DeleteAirTicket(flightNumber: "SV1234");
            catalog.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00));
            catalog.DeleteBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), travelCompany: "Biomet");
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
            string cmdResultFind = catalog.FindTicketsInInterval(
                startDateTime: new DateTime(1980, 1, 1, 0, 0, 0),
                endDateTime: new DateTime(2050, 2, 1, 0, 0, 0));
            Assert.AreEqual("Not found", cmdResultFind);
        }
    }
}
