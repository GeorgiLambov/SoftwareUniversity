namespace CustomerSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private string id;
        private string address;
        private string mobilePhone;
        private string email;
        private IList<Payment> payments;
        private CustomerType type;

        public Customer(string firstName, string middleName, string lastName, string id, string address, string mobilePhone, string email, IList<Payment> payments, CustomerType type)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Id = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Names cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name too short! It should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("First name too long! It should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Names cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name too short! It should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Last name too long! It should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.lastName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Names cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Middle name too short! It should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Middle name too long! It should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.middleName = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid ID!! 10 digits must be provided!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsDigit((symbol)))
                    {
                        throw new ArgumentException("Invali ID!! It consist olny of digits!!!");
                    }
                }
                this.id = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                foreach (char symbol in value)
                {
                    if (!char.IsLetterOrDigit(symbol) && symbol != ' ' && symbol != ',' && symbol != '#' &&
                        symbol != ';' && symbol != ':' && symbol != '\"' && symbol != '\'')
                    {
                        throw new ArgumentException("Invalid address!!!");
                    }
                }
                this.address = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid phone nuber! Mobile phone must be 10 digits!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Invalid phone nuber! Mobile phone must beonly digits!");
                    }
                }
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                string emailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(value, emailRegex))
                {
                    throw new ArgumentException("Invalid e-mail provided!");
                }
                this.email = value;
            }
        }

        public CustomerType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public IList<Payment> Payments
        {
            get { return this.payments; }
            set { this.payments = value; }
        }

        public override bool Equals(object param)
        {
            Customer customer = param as Customer;

            if ((object)customer == null)  // == is not overide "=="
            {
                return false;
            }

            if (object.Equals(this.Id, customer.Id))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Using a small prime number to reduce the chance of collisions and overflow of int type
            int prime = 7;
            int result = 1;
            unchecked // Using "unchecked" so if the result is evaluated to overflow it is truncated
            {
                result = result * prime + this.FirstName.GetHashCode();
                result = result * prime + this.MiddleName.GetHashCode();
                result = result * prime + this.LastName.GetHashCode();
                result = result * prime + this.Id.GetHashCode();
                result = result * prime + this.MobilePhone.GetHashCode();
                result = result * prime + this.Email.GetHashCode();
                result = result * prime + this.Address.GetHashCode();
                result = result * prime + this.Type.GetHashCode();
            }

            return result;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Customer.Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(Customer.Equals(customer1, customer2));
        }

        object ICloneable.Clone()  // The method from the ICloneable interface
        {
            return this.Clone();
        }

        public Customer Clone()    // The class method for deep cloning
        {
            string cloneFirstName = string.Copy(this.FirstName);
            string cloneMiddleName = string.Copy(this.MiddleName);
            string cloneLastName = string.Copy(this.LastName);
            string cloneId = string.Copy(this.Id);
            string cloneAddress = string.Copy(this.Address);
            string cloneMobilePhone = string.Copy(this.MobilePhone);
            string cloneEmail = string.Copy(this.Email);

            IList<Payment> newCustomerpayments = new List<Payment>(this.Payments.Count);

            foreach (var payment in this.Payments)
            {
                newCustomerpayments.Add(payment);
            }

            return new Customer(cloneFirstName, cloneMiddleName, cloneLastName, cloneId, cloneAddress, cloneMobilePhone, cloneEmail, newCustomerpayments, this.Type);

        }

        public int CompareTo(Customer other)
        {
            // The other student is not valid reference so the current is greater
            if (other == null)
            {
                return 1;
            }

            // Getting the concatenations of the names of both students so they can be easily compared
            string currentCustomerNames = this.FirstName + this.MiddleName + this.LastName;
            string otherCustomerNames = other.FirstName + other.MiddleName + other.LastName;

            int nameComparison = currentCustomerNames.CompareTo(otherCustomerNames);

            if (nameComparison != 0) // The names are different
            {
                return nameComparison;
            }
            else
            {
                return this.Id.CompareTo(other.Id);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("---Customer information---");
            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Middle name: " + this.MiddleName);
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine("ID: " + this.Id);
            result.AppendLine("Permanent address: " + this.Address);
            result.AppendLine("Mobile phone: " + this.MobilePhone);
            result.AppendLine("E-mail: " + this.Email);
            result.AppendLine("Payments: " + string.Join(", ", this.payments));
            result.AppendLine("Customer type: " + this.Type);
            return result.ToString();
        }
    }
}
