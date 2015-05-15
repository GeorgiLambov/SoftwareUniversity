namespace PhonebookCodeFirst
{
    using System.Data.Entity;
    using Migrations;


    public class PhonebookContext : DbContext
    {

        public PhonebookContext()
            : base("name=PhonebookContext")
        {
        }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new PhonebookMigrationStrategy());
        }
    }
}