using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhonebookCodeFirst
{
    public class Contact
    {
        public Contact()
        {
            this.Emails = new HashSet<Email>();
            this.Phones = new HashSet<Phone>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Position { get; set; }
        public string Company { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public string Notes { get; set; }
        public string Site { get; set; }
    }
}