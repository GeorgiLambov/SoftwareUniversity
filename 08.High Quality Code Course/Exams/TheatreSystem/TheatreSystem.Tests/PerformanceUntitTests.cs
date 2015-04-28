namespace ThetreUnitTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheatreSystem;

    [TestClass]
    public class PerformanceUntitTests
    {
        private PerformanceDatabase performanceDatabase;

        [TestInitialize]
        public void InitializePerformanceRepository()
        {
            this.performanceDatabase = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestAddPerformanceReturnsPerformanceCount()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddPerformance("Theatre Sofia", "Duende", new DateTime(2015, 1, 30, 12, 55, 00), TimeSpan.Parse("1:30"), 14.5m);

            Assert.AreEqual(1, this.performanceDatabase.GetPerformancesCount("Theatre Sofia"));
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException), Constants.TimeOverlapMsg)]
        public void TestAddPerformanceReturnsTimeDurationOverlapException()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddPerformance("Theatre Sofia", "Duende", new DateTime(2015, 1, 30, 12, 40, 00), TimeSpan.Parse("1:30"), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre Sofia", "Duende", new DateTime(2015, 1, 30, 12, 55, 00), TimeSpan.Parse("1:30"), 14.5m);

            Assert.AreEqual(1, this.performanceDatabase.GetPerformancesCount("Theatre Sofia"));
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException), Constants.TheatreDoesNotExistMsg)]
        public void TestAddPerformanceReturnsTheatreNotFoundException()
        {
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 1, 30, 12, 40, 00), TimeSpan.Parse("1:30"), 14.5m);

            Assert.AreEqual(1, this.performanceDatabase.GetPerformancesCount("Theatre Sofia"));
        }

        [TestMethod]
        public void TestListAllPerformanceReturnsCountOfPerformens()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddTheatre("Theatre Nov");

            this.performanceDatabase.AddPerformance("Theatre Sofia", "Duende", new DateTime(2015, 1, 30, 12, 40, 00), TimeSpan.Parse("1:30"), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre 199", "Nova", new DateTime(2015, 1, 30, 12, 55, 00), TimeSpan.Parse("1:30"), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre Nov", "Sega", new DateTime(2015, 1, 30, 12, 55, 00), TimeSpan.Parse("1:30"), 14.5m);

            Assert.AreEqual(3, this.performanceDatabase.ListAllPerformances().ToList().Count());
        }

        [TestMethod]
        public void TestListPerformanceReturnsCountOfPerformens()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");

            this.performanceDatabase.AddPerformance("Theatre Sofia", "Duende", new DateTime(2015, 1, 30, 12, 40, 00), TimeSpan.Parse("1:30"), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre Sofia", "Nova", new DateTime(2015, 2, 22, 12, 55, 00), TimeSpan.Parse("1:30"), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre Sofia", "Sega", new DateTime(2015, 2, 14, 12, 55, 00), TimeSpan.Parse("1:30"), 14.5m);

            Assert.AreEqual(3, this.performanceDatabase.ListPerformances("Theatre Sofia").ToList().Count());
        }
    }
}
