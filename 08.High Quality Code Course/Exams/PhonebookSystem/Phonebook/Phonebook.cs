using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhonebookSystem
{
    public class Phonebook
    {
        private const string DefaultPhonePrefix = "+359";

        private static IPhonebookRepository phoneBook = new PhonebookRepository();
        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            ProcessAllCommands();
            PrintCollectedOutput();
        }

        private static void ProcessAllCommands()
        {
            while (true)
            {
                string commandText = Console.ReadLine();
                if (commandText == "End" || commandText == null)
                {
                    // The sequence of commands is finished
                    break;
                }
                ExecuteCommand(commandText);
            }
        }

        private static void ExecuteCommand(string commandText)
        {
            // Parse the command and its arguments
            int colonIndex = commandText.IndexOf('(');
            if (colonIndex == -1)
            {
                throw new ArgumentException("Invalid command format: " + commandText);
            }
            string command = commandText.Substring(0, colonIndex);
            if (!commandText.EndsWith(")"))
            {
                throw new ArgumentException("Invalid command format: " + commandText);
            }
            string argumentsStr = commandText.Substring(
                colonIndex + 1, commandText.Length - colonIndex - 2);
            string[] arguments = argumentsStr.Split(',');
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            ExecuteCommand(command, arguments);
        }

        private static void ExecuteCommand(string command, string[] arguments)
        {
            if ((command.StartsWith("AddPhone")) && (arguments.Length >= 2))
            {
                ProcessAddPhoneCommand(arguments);
            }
            else if ((command == "ChangePhone") && (arguments.Length == 2))
            {
                ProcessChangePhoneCommand(arguments);
            }
            else if ((command == "List") && (arguments.Length == 2))
            {
                ProcessListCommand(arguments);
            }
            else
            {
                throw new ArgumentException("Invalid command: " + command);
            }
        }

        private static void ProcessAddPhoneCommand(string[] arguments)
        {
            string name = arguments[0];
            var phones = arguments.Skip(1).ToList();
            for (int i = 0; i < phones.Count; i++)
            {
                phones[i] = ConvertPhoneToCannonicalForm(phones[i]);
            }

            bool isNewEntry = phoneBook.AddPhone(name, phones);
            if (isNewEntry)
            {
                Print("Phone entry created");
            }
            else
            {
                Print("Phone entry merged");
            }
        }

        private static void ProcessChangePhoneCommand(string[] arguments)
        {
            string oldPhoneNumber = ConvertPhoneToCannonicalForm(arguments[0]);
            string newPhoneNumber = ConvertPhoneToCannonicalForm(arguments[1]);
            int updatedCount = phoneBook.ChangePhone(oldPhoneNumber, newPhoneNumber);
            Print("" + updatedCount + " numbers changed");
        }

        private static void ProcessListCommand(string[] arguments)
        {
            int startIndex = int.Parse(arguments[0]);
            int count = int.Parse(arguments[1]);

            try
            {
                IEnumerable<PhonebookEntry> entries =
                    phoneBook.ListEntries(startIndex, count);
                foreach (var entry in entries)
                {
                    string entryStr = entry.ToString();
                    Print(entryStr);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Print("Invalid range");
            }
        }

        public static string ConvertPhoneToCannonicalForm(string phoneNumber)
        {
            // Skip all non-digit characters except '+'
            // Example: (+359) 888 999 111 --> +359888999111
            StringBuilder cannonicalPhoneBuilder = new StringBuilder();
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    cannonicalPhoneBuilder.Append(ch);
                }
            }

            if (cannonicalPhoneBuilder.Length >= 2 &&
                cannonicalPhoneBuilder[0] == '0' && cannonicalPhoneBuilder[1] == '0')
            {
                // The phone number starts with "00", replace it with "+"
                // Example: 00359888999111 --> +359888999111
                cannonicalPhoneBuilder.Remove(0, 1);
                cannonicalPhoneBuilder[0] = '+';
            }

            while (cannonicalPhoneBuilder.Length > 0 && cannonicalPhoneBuilder[0] == '0')
            {
                // Remove any leading zeros
                // Example: 0894778899 --> 894778899
                cannonicalPhoneBuilder.Remove(0, 1);
            }

            if (cannonicalPhoneBuilder.Length > 0 && cannonicalPhoneBuilder[0] != '+')
            {
                // Insert the default country code the first char is not "+"
                // Example: 894778899 --> +359894778899
                cannonicalPhoneBuilder.Insert(0, DefaultPhonePrefix);
            }

            string cannonicalPhoneNumber = cannonicalPhoneBuilder.ToString();
            return cannonicalPhoneNumber;
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }

        private static void PrintCollectedOutput()
        {
            Console.Write(output);
        }
    }
}
