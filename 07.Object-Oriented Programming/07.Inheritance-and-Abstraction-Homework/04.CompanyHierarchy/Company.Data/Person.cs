using System;
using System.Collections.Generic;

namespace Company.Data
{
    public abstract class Person : IPerson
    {
        private static HashSet<string> uniqueID = new HashSet<string>();

        private string firstName;
        private string lastName;
        private string id;

        public Person(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Person's firstName cannot be empty or null!");
                }
                string[] names = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length < 2)
                {
                    throw new ArgumentException("Only one firstName provided! At least two names required!");
                }
                foreach (string name in names)
                {
                    if (name.Length < 2)
                    {
                        throw new ArgumentException("First and/or last firstName too short! They should be at least 2 letters!");
                    }
                    if (name.Length > 50)
                    {
                        throw new ArgumentException("First and/or last firstName too long! They should be maximum 50 letters!");
                    }
                    foreach (char symbol in name)
                    {
                        if (!char.IsLetter(symbol) && symbol != '-')
                        {
                            throw new ArgumentOutOfRangeException("Invalid firstName! Allowed symbols are only letters and hyphen!");
                        }
                    }
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Person's laststName cannot be empty or null!");
                }
                string[] names = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length < 2)
                {
                    throw new ArgumentException("Only one firstName provided! At least two names required!");
                }
                foreach (string name in names)
                {
                    if (name.Length < 2)
                    {
                        throw new ArgumentException("First and/or last firstName too short! They should be at least 2 letters!");
                    }
                    if (name.Length > 50)
                    {
                        throw new ArgumentException("First and/or last firstName too long! They should be maximum 50 letters!");
                    }
                    foreach (char symbol in name)
                    {
                        if (!char.IsLetter(symbol) && symbol != '-')
                        {
                            throw new ArgumentOutOfRangeException("Invalid firstName! Allowed symbols are only letters and hyphen!");
                        }
                    }
                }
                this.lastName = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Person Id cannot be smaler than 10 digits!");
                }
                foreach (var symbol in value)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentOutOfRangeException("Person Id must consist only digits!");
                    }
                }

                this.id = value;
            }
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\nFirst Name: {1}\nLast Name: {2}", this.Id, this.FirstName, this.LastName);
        }
    }
}