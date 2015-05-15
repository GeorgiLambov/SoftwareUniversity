namespace PhonebookCodeFirst
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    class PhonebookCodeFirst
    {
        static void Main()
        {

            var context = new PhonebookContext();
            var contacts = context.Contacts
                .Include(c => c.Phones)
                .Include(c => c.Emails)
                .ToList();
            foreach (var contact in contacts)
            {
                Console.WriteLine("Name: {0}", contact.Name);
                Console.WriteLine("  Position: {0}", contact.Position);
                Console.WriteLine("  Company: {0}", contact.Company);
                Console.WriteLine("  Emails: {0}",
                    string.Join(", ", contact.Emails.Select(e => e.EmailAddress)));
                Console.WriteLine("  Phones: {0}",
                    string.Join(", ", contact.Phones.Select(e => e.PhoneNumber)));
                Console.WriteLine("  Url: {0}", contact.Site);
                Console.WriteLine("  Notes: {0}", contact.Notes);
                Console.WriteLine();
            }

        }
    }

}
