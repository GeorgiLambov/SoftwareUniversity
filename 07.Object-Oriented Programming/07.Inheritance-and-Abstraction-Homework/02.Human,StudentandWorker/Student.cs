using System;
using System.Text;

namespace HumansHierarchy
{
    public class Student : Human
    {
        private string faultyNumber;


        public Student(string firstName, string lastName, string faultyNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FaultyNumber = faultyNumber;
        }

        public string FaultyNumber
        {
            get { return this.faultyNumber; }
            set
            {
                if (value != null && value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faulty Number must be 5-10 digits / letters.");
                }
                this.faultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine("Faulty Number: " + this.faultyNumber);
            return result.ToString();
        }
    }
}