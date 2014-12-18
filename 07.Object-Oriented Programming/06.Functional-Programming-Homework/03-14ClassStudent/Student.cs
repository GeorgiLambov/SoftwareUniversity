namespace _03_14ClassStudent
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string fucultyNumber;
        private string phone;
        private string email;
        private IList<int> marks;
        private int groupNumber;
        private string groupName;

        public Student(string firstName, string lastName, int age, string fucultyNumber, string phone, string email, IList<int> marks, int groupNumber, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FucultyNumber = fucultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
            if (marks == null)
            {
                this.Marks = new List<int>();
            }
            else
            {
                this.Marks = marks;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName", "First Name Can't be null or empty! ");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "Last Name Can't be null or empty! ");
                }

                this.lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age can not be negative!!!");
                }

                this.age = value;
            }
        }
        public string FucultyNumber
        {
            get
            {
                return this.fucultyNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Faculty number can not be null or empty!!!");
                }

                this.fucultyNumber = value;
            }
        }
        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                this.phone = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email", "Email can not be empty or null!!!");
                }

                this.email = value;
            }
        }
        public IList<int> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Marks list can not be null!!!");
                }
                this.marks = value;
            }
        }
        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                this.groupNumber = value;
            }
        }

        public string GroupName
        {
            get
            {
                return this.groupName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Group name can not be null or empty!!!");
                }
                this.groupName = value;
            }

        }


        public override string ToString()
        {
            string marks = string.Join(", ", this.Marks as IEnumerable<int>);
            return string.Format("{0} {1}, age: {2}, phone: {3}, email: {4}, fac number: {4},  group number: {5}, marks: {7}, GroupName: {8}.",
                 this.firstName,
                 this.lastName,
                 this.age,
                 this.phone,
                 this.email,
                 this.fucultyNumber,
                 this.groupNumber,
                 marks,
                 this.groupName);
        }

    }
}