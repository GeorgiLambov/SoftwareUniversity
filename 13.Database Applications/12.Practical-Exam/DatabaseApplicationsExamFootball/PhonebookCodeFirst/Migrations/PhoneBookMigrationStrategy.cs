namespace PhonebookCodeFirst.Migrations
{
    using System.Data.Entity;

    internal sealed class PhonebookMigrationStrategy : DropCreateDatabaseIfModelChanges<PhonebookContext>
    {
        protected override void Seed(PhonebookContext context)
        {

            var contactPetar = new Contact
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Company",
                Site = "http://blog.peter.com",
                Notes = "Friend from school",

            };

            context.Contacts.Add(contactPetar);
            context.SaveChanges();
        }
    }
}
