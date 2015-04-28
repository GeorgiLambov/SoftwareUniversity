namespace ThetreUnitTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheatreSystem;

    [TestClass]
    public class ThetreUnitTests
    {
        private PerformanceDatabase performanceDatabase;

        [TestInitialize]
        public void InitializePerformanceRepository()
        {
            this.performanceDatabase = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestAddTheatreReturnsTheatreCount()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            Assert.AreEqual(1, this.performanceDatabase.GetTheatresCount());
        }

        [TestMethod]
        public void TestAddTheatreReturnsTheatreZeroPerformers()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            Assert.AreEqual(0, this.performanceDatabase.GetPerformancesCount("Theatre Sofia"));
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException), Constants.DuplicateTheatreMsg)]
        public void TestAddTheatreDuplicatesReturnsDuplicateTheatreException()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            Assert.AreEqual(0, this.performanceDatabase.GetPerformancesCount("Theatre Sofia"));
        }

        [TestMethod]
        public void TestListAllTheatreReturnsTheatreCount()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddTheatre("Theatre Nov");
            Assert.AreEqual(3, this.performanceDatabase.ListTheatres().Count());
        }
    }
}
