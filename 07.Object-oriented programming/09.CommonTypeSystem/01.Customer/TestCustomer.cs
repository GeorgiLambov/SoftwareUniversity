using System.Collections.Generic;

namespace CustomerSystem
{
    using System;
    public class TestCustomer
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating some customer objects and performing some operations over them***");
            Console.Write(decorationLine);

            // Creating the Customer
            Customer customer1 = new Customer(
                "Ivan",
                "Ivanov",
                "Ivanov",
                "5712036203",
                "Sofia, street: \"Street name\" #15",
                "0888888888",
                "i.ivanov@email.com",
              new List<Payment>() { new Payment("VW Golf", 1000m) },
              CustomerType.Onetime
              );
            Customer customer2 = new Customer(
                "Georgi",
                "Georgiev",
                "Georgiev",
                "9003034466",
                "Sofia, street: \"Street name\" #199",
                "0887777777",
                "g.georgiev@email.com",
              new List<Payment>() { new Payment("Brigstone", 800m) },
              CustomerType.Regular
              );

            Console.WriteLine("***Printing the information about two Customer***");
            // The ToString() method demonstration
            Console.WriteLine(customer1);
            Console.WriteLine(customer2);

            Console.WriteLine("***Comparing the Customer with Equals()***");
            Console.WriteLine("Result of comparison: " + customer1.Equals(customer2));
            Console.WriteLine();

            Console.WriteLine("***Testing the GetHashCode() method***");
            Console.WriteLine("First Customer's hash code: " + customer1.GetHashCode());
            Console.WriteLine("Second Customer's has code: " + customer2.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("***Testing the operators '==' and '!='***");
            Console.WriteLine("first Customer == second Customer -> " + (customer1 == customer2));
            Console.WriteLine("first Customer != second Customer -> " + (customer1 != customer2));
            Console.WriteLine();

            Console.WriteLine("***Cloning the first Customer and printing the clone***");
            Customer cloneCustomer = customer1.Clone();
            Console.WriteLine("Result of comparison of cloneCustomer: " + customer1.Equals(cloneCustomer));
            Console.WriteLine(cloneCustomer);
            Console.WriteLine("***Changing original's address, clone's mobile phone  and new Payments and priniting both***");
            customer1.Address = "Sofia, street \"New street\" #111";
            cloneCustomer.MobilePhone = "0800000011";
            cloneCustomer.Type = CustomerType.Golden;
            cloneCustomer.Payments = new List<Payment>() { new Payment("eBook", 200m) };
            Console.WriteLine(customer1);
            Console.WriteLine(cloneCustomer);

            Console.WriteLine("***Comparing first Customer with second Customer by CompareTo() method***");
            if (customer1.CompareTo(customer2) == 0)
            {
                Console.WriteLine("Both Customer are equal!");
            }
            else if (customer1.CompareTo(customer2) < 0)
            {
                Console.WriteLine("The first Customer is before the second one!");
            }
            else
            {
                Console.WriteLine("The first Customer is after the second one!");
            }
        }
    }
}
