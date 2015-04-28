using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhonebookSystem;
using System.Text;
using System.IO;

namespace Phonebook.Tests
{
    [TestClass]
    public class UnitTestsPerformance
    {
        [TestMethod]
        [Timeout(3000)]
        public void TestPerformance()
        {
            StringBuilder input = new StringBuilder();

            int addCommandsCount = 1500;
            for (int i = 0; i < addCommandsCount / 2; i++)
            {
                input.AppendLine("AddPhone(Nakov, +359887333" + i + ", +359887333999)");
                input.AppendLine("AddPhone(Nakov" + i + ", +359887333999, +359887" + i + ")");
            }

            int changePhoneCommandsCount = 100;
            for (int i = 0; i < changePhoneCommandsCount / 3; i++)
            {
                input.AppendLine("ChangePhone(+359887333" + (i + 100) + ", +359887333" + (i + 200) +")");
                input.AppendLine("ChangePhone(+359887333999" + ", +359887333777)");
                input.AppendLine("ChangePhone(+359887333777" + ", +359887333999)");
                input.AppendLine("ChangePhone(+359887" + (i + 500) + ", +359887333999)");
            }

            int listCommandsCount = 5000;
            for (int i = 0; i < listCommandsCount; i++)
            {
                input.AppendLine("List(" + i + ", " + (1 + (i % 20)) + ")");
            }

            input.AppendLine("End");

            // Forcefully invoke the static constructor to ensure the program state is clean
            typeof(PhonebookSystem.Phonebook).TypeInitializer.Invoke(null, null);
            
            // Redirect the console input / output and invoke the Main() method
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            PhonebookSystem.Phonebook.Main();

            // Assert is not needed, just check the performance
            // Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Timeout(1000)]
        public void TestPerformanceConvertPhoneToCannonicalForm()
        {
            // Prepare input commands
            StringBuilder input = new StringBuilder();
            int addCommandsCount = 1000;
            for (int i = 0; i < addCommandsCount; i++)
            {
                input.AppendLine("AddPhone(Nakov, 02 / 981 45 66)");
                input.AppendLine("AddPhone(Nakov, +359 899 99 22 22)");
                input.AppendLine("AddPhone(Nakov, (062) 62 62 62)");
                input.AppendLine("AddPhone(Nakov, (+359) 899 777-555)");
            }

            input.AppendLine("List(0, 1)");
            input.AppendLine("End");

            // Prepare the expected result 
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Phone entry created");
            for (int i = 0; i < 4 * addCommandsCount - 1; i++)
            {
                expectedOutput.AppendLine("Phone entry merged");
            }
            expectedOutput.AppendLine("[Nakov: +35929814566, +35962626262, +359899777555, +359899992222]");

            // Forcefully invoke the static constructor to ensure the program state is clean
            typeof(PhonebookSystem.Phonebook).TypeInitializer.Invoke(null, null);

            // Redirect the console input / output and invoke the Main() method
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            PhonebookSystem.Phonebook.Main();

            // Assert that the program execution result is correct
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected.Length, actual.Length);
        }

        [TestMethod]
        [Timeout(1000)]
        public void TestPerformanceChangePhone()
        {
            // This test is expected to fail due to timeout. It just shows that
            // a performance bottleneck exists in the ChangePhone() method.

            StringBuilder input = new StringBuilder();
            int addCommandsCount = 2000;
            for (int i = 0; i < addCommandsCount; i++)
            {
                input.AppendLine("AddPhone(Nakov" + i + ", +359887333999)");
            }

            int changePhoneCommandsCount = 500;
            for (int i = 0; i < changePhoneCommandsCount / 2; i++)
            {
                input.AppendLine("ChangePhone(+359887333999" + ", +359887333777)");
                input.AppendLine("ChangePhone(+359887333777" + ", +359887333999)");
            }

            input.AppendLine("End");

            // Forcefully invoke the static constructor to ensure the program state is clean
            typeof(PhonebookSystem.Phonebook).TypeInitializer.Invoke(null, null);

            // Redirect the console input / output and invoke the Main() method
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            PhonebookSystem.Phonebook.Main();

            // Assert is not needed, just check the performance
            // Assert.AreEqual(expected, actual);
        }
    }
}
