using System;
using System.Collections.Generic;

namespace PhonebookSystem
{
    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        public string Name { get; private set; }
        public SortedSet<string> Phones { get; private set; }

        public PhonebookEntry(string name)
        {
            this.Name = name;
            this.Phones = new SortedSet<string>();
        }

        public override string ToString()
        {
            string phonesAsList = string.Join(", ", this.Phones);
            string result = String.Format("[{0}: {1}]", this.Name, phonesAsList);
            return result;
        }

        public int CompareTo(PhonebookEntry other)
        {
            return string.Compare(this.Name, other.Name, true);
        }
    }
}
