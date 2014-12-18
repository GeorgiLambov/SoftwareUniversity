namespace BankSystem.Common
{
    using System;
    public class IndividualCustomer : Customer
    {
        private string fname;
        private string lname;
        public IndividualCustomer(string fname, string lname, uint id)
            : base(id)
        {
            this.Fname = fname;
            this.Lname = lname;
        }

        public string Fname
        {
            get { return this.fname; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Names cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name too short! Should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("First name too long! Should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.fname = value;
            }
        }

        public string Lname
        {
            get { return this.lname; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Names cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name too short! Should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Last name too long! Should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.lname = value;
            }
        }

        public override string ToString()
        {
            return string.Format("First name: {0}\nLast name: {1}\nID: {2}", this.fname, this.lname, this.ID);
        }
    }
}
