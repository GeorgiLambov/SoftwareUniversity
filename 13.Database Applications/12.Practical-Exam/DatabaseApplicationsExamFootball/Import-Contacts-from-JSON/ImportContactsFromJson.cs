namespace Import_Contacts_from_JSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using PhonebookCodeFirst;

    class ImportContactsFromJson
    {
        static void Main()
        {
            var json = File.ReadAllText(@"..\..\contacts.json");
            var jsonSerializer = new JavaScriptSerializer();
            var parsedContacts = jsonSerializer.Deserialize<ContactDTO[]>(json);

            foreach (var contactDTO in parsedContacts)
            {
                try
                {
                    ImportContactToDatabase(contactDTO);
                    Console.WriteLine("Contact {0} imported", contactDTO.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ImportContactToDatabase(ContactDTO contactDTO)
        {
            if (contactDTO.Name == null)
            {
                throw new ArgumentException("Name is required");
            }
            var newContact = new Contact()
            {
                Name = contactDTO.Name,
                Company = contactDTO.Company,
                Position = contactDTO.Position,
                Site = contactDTO.Site,
                Notes = contactDTO.Notes
            };
            if (contactDTO.Emails != null)
            {
                newContact.Emails = contactDTO.Emails.Select(e => new Email() { EmailAddress = e }).ToList();
            }
            if (contactDTO.Phones != null)
            {
                newContact.Phones = contactDTO.Phones.Select(p => new Phone() { PhoneNumber = p }).ToList();
            }
            var context = new PhonebookContext();
            context.Contacts.Add(newContact);
            context.SaveChanges();
        }
    }
}
