using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhonebookSystem;
using System.Linq;

namespace Phonebook.Tests
{
    [TestClass]
    public class UnitTestsPhonebookRepository
    {
        [TestMethod]
        public void TestAddSinglePhonebookEntry()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            bool isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(true, isNew);
            Assert.AreEqual(1, phonebook.EntriesCount);
            Assert.AreEqual(1, phonebook.PhonesCount);

            // Notes: we have intentionally added the properties EntriesCount
            // and PhonesCount in the PhonebookRepository class to simplify testing
        }

        [TestMethod]
        public void TestAddDuplicatedEntry()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            bool isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(true, isNew);
            isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(false, isNew);
            isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(false, isNew);
            Assert.AreEqual(1, phonebook.EntriesCount);
            Assert.AreEqual(1, phonebook.PhonesCount);
        }

        [TestMethod]
        public void TestAddEntryDifferentCasing()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            bool isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(true, isNew);
            isNew = phonebook.AddPhone("NAKOV", new string[] { "+359887333555" });
            Assert.AreEqual(false, isNew);
            isNew = phonebook.AddPhone("nakov", new string[] { "+359887333777" });
            Assert.AreEqual(false, isNew);
            Assert.AreEqual(1, phonebook.EntriesCount);
            Assert.AreEqual(3, phonebook.PhonesCount);
        }

        [TestMethod]
        public void TestAddWithMerge()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            bool isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333444", "+359887333555" });
            Assert.AreEqual(true, isNew);
            isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333555", "+359887333777" });
            Assert.AreEqual(false, isNew);
            isNew = phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            Assert.AreEqual(false, isNew);
            Assert.AreEqual(1, phonebook.EntriesCount);
            Assert.AreEqual(3, phonebook.PhonesCount);
        }

        [TestMethod]
        public void TestMethodAddPhoneManyForms()
        {
            // Conversion to cannonical form is not responsibility of the PhonebookRepository
            // class and thus the below phones are considered different

            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.AddPhone("Nakov", new string[] { "0887 333 555" });
            phonebook.AddPhone("Nakov", new string[] { "0887 33 35 55" });
            phonebook.AddPhone("Nakov", new string[] { "+359 887 33 35 55" });
            phonebook.AddPhone("Nakov", new string[] { "(+359) 887 33 35 55" });
            phonebook.AddPhone("Nakov", new string[] { "(+359) 887 333-555" });
            phonebook.AddPhone("Nakov", new string[] { "0887 / 33 35 55" });
            Assert.AreEqual(1, phonebook.EntriesCount);
            Assert.AreEqual(7, phonebook.PhonesCount);
        }

        [TestMethod]
        public void TestListSingleEntrySinglePhone()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            string expectedResult = "[Nakov: +359887333555]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 1);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestListSingleEntryMultiplePhones()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.AddPhone("Nakov", new string[] { "+3592555444" });
            string expectedResult = "[Nakov: +3592555444, +359887333555]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 1);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestListMultipleEntriesWithMergeAndSorting()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Svetlin Nakov", new string[] { "+359887333555", "+35962445566" });
            phonebook.AddPhone("SVETLIN NAKOV", new string[] { "+3592555444", "+359887333555" });
            phonebook.AddPhone("Niki Kostov", new string[] { "+35989911222", "+35929887744" });
            phonebook.AddPhone("niki kostov", new string[] { "+35929887744", "+35989911222" });
            string expectedResult =
                "[Niki Kostov: +35929887744, +35989911222]; [Svetlin Nakov: +3592555444, +35962445566, +359887333555]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 2);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestListMultipleEntriesSubPageWithSorting()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.AddPhone("Niki", new string[] { "+35989911222" });
            phonebook.AddPhone("Ani", new string[] { "+359886344544" });
            phonebook.AddPhone("Yana", new string[] { "+3599874456" });
            phonebook.AddPhone("Tanya", new string[] { "+359884222333" });
            string expectedResult =
                "[Nakov: +359887333555]; [Niki: +35989911222]; [Tanya: +359884222333]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(1, 3);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListMultipleEntriesNegativeStart()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.ListEntries(-1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListMultipleEntriesInvalidStart()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.ListEntries(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListMultipleEntriesInvalidCount()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.AddPhone("Jorro", new string[] { "+359888444777" });
            phonebook.ListEntries(1, 2);
        }

        [TestMethod]
        public void TestChangeSingleExistingPhone()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            int changedPhonesCount = phonebook.ChangePhone("+359887333555", "+359888888888");
            Assert.AreEqual(1, changedPhonesCount);
            string expectedResult = "[Nakov: +359888888888]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 1);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestChangeSingleNonExistingPhone()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555" });
            phonebook.AddPhone("Niki", new string[] { "+359887333666" });
            int changedPhonesCount = phonebook.ChangePhone("+359887333777", "+359888888888");
            Assert.AreEqual(0, changedPhonesCount);
            string expectedResult = "[Nakov: +359887333555]; [Niki: +359887333666]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 2);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestChangeSharedPhone()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555", "+3592981981" });
            phonebook.AddPhone("Ina", new string[] { "+3592981981" });
            phonebook.AddPhone("Aneliya", new string[] { "+3592981981" });
            phonebook.AddPhone("Niki", new string[] { "+3592981981", "+359999888777" });
            int changedPhonesCount = phonebook.ChangePhone("+3592981981", "+3592982982");
            Assert.AreEqual(4, changedPhonesCount);
            string expectedResult =
                "[Aneliya: +3592982982]; [Ina: +3592982982]; [Nakov: +3592982982, +359887333555]; " +
                "[Niki: +3592982982, +359999888777]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 4);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestChangePhoneWithMerge()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            phonebook.AddPhone("Nakov", new string[] { "+359887333555", "+359887333999" });
            phonebook.AddPhone("Ina", new string[] { "+359887333999" });
            phonebook.AddPhone("Ani", new string[] { "+359887333555", "359887333444" });
            int changedPhonesCount = phonebook.ChangePhone("+359887333999", "+359887333555");
            Assert.AreEqual(2, changedPhonesCount);
            string expectedResult =
                "[Ani: +359887333555, 359887333444]; [Ina: +359887333555]; [Nakov: +359887333555]";
            PhonebookEntry[] listedEntries = phonebook.ListEntries(0, 3);
            string actualResult = string.Join("; ", (object[])listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
