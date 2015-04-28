using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace PhonebookSystem
{
    public class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<PhonebookEntry> entriesSorted =
            new OrderedSet<PhonebookEntry>();
        private Dictionary<string, PhonebookEntry> entriesByName =
            new Dictionary<string, PhonebookEntry>();
        private MultiDictionary<string, PhonebookEntry> entriesByPhone =
            new MultiDictionary<string, PhonebookEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            // Create / find the phonebook entry
            string nameLowercase = name.ToLowerInvariant();
            PhonebookEntry entry;
            bool isNewEntry = !this.entriesByName.TryGetValue(nameLowercase, out entry);
            if (isNewEntry)
            {
                entry = new PhonebookEntry(name);
                this.entriesByName.Add(nameLowercase, entry);
                this.entriesSorted.Add(entry);
            }

            // Add the entry by phone
            foreach (var phoneNumber in phoneNumbers)
            {
                this.entriesByPhone.Add(phoneNumber, entry);
            }

            // Add / merge the phone numbers
            entry.Phones.UnionWith(phoneNumbers);

            return isNewEntry;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            // Performance bottleneck: this method is potentially slow because
            // it transforms all matching phones to list. No fix is available.

            var matchedEntries = this.entriesByPhone[oldPhoneNumber].ToList();
            foreach (var entry in matchedEntries)
            {
                entry.Phones.Remove(oldPhoneNumber);
                this.entriesByPhone.Remove(oldPhoneNumber, entry);
                entry.Phones.Add(newPhoneNumber);
                this.entriesByPhone.Add(newPhoneNumber, entry);
            }
            return matchedEntries.Count;
        }

        public PhonebookEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            PhonebookEntry[] matchedEntries = new PhonebookEntry[count];
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhonebookEntry entry = this.entriesSorted[i];
                matchedEntries[i - startIndex] = entry;
            }
            return matchedEntries;
        }

        public int EntriesCount
        {
            get
            {
                return this.entriesByName.Count;
            }
        }

        public int PhonesCount
        {
            get
            {
                return this.entriesByPhone.Count;
            }
        }
    }

    ///// <summary>
    ///// PhonebookRepositorySlow is a slow implementation of IPhonebookRepository based on List<T>.
    ///// It may be used just as second implementation to check the results from the fast implemantation.
    ///// </summary>
    //public class PhonebookRepositorySlow : IPhonebookRepository
    //{
    //    private List<PhonebookEntry> entries = new List<PhonebookEntry>();

    //    public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
    //    {
    //        var existingEntries =
    //            from e in this.entries
    //            where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
    //            select e;

    //        bool isNewEntry;
    //        if (existingEntries.Count() == 0)
    //        {
    //            PhonebookEntry newEntry = new PhonebookEntry(name);
    //            foreach (var phoneNumber in phoneNumbers)
    //            {
    //                newEntry.Phones.Add(phoneNumber);
    //            }
    //            this.entries.Add(newEntry);
    //            isNewEntry = true;
    //        }
    //        else if (existingEntries.Count() == 1)
    //        {
    //            PhonebookEntry existingEntry = existingEntries.First();
    //            foreach (var phoneNumber in phoneNumbers)
    //            {
    //                existingEntry.Phones.Add(phoneNumber);
    //            }
    //            isNewEntry = false;
    //        }
    //        else
    //        {
    //            throw new InvalidOperationException("Duplicated name in the phonebook found: " + name);
    //        }

    //        return isNewEntry;
    //    }

    //    public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
    //    {
    //        var matchedEntries =
    //            from e in this.entries
    //            where e.Phones.Contains(oldPhoneNumber)
    //            select e;

    //        int changedCount = 0;
    //        foreach (var entry in matchedEntries)
    //        {
    //            entry.Phones.Remove(oldPhoneNumber);
    //            entry.Phones.Add(newPhoneNumber);
    //            changedCount++;
    //        }

    //        return changedCount;
    //    }

    //    public PhonebookEntry[] ListEntries(int startIndex, int count)
    //    {
    //        if (startIndex < 0 || startIndex + count > this.entries.Count)
    //        {
    //            throw new ArgumentOutOfRangeException("Invalid start index or count.");
    //        }

    //        this.entries.Sort();
    //        PhonebookEntry[] matchedEntries = new PhonebookEntry[count];
    //        for (int i = startIndex; i <= startIndex + count - 1; i++)
    //        {
    //            PhonebookEntry entry = this.entries[i];
    //            matchedEntries[i - startIndex] = entry;
    //        }
    //        return matchedEntries;
    //    }
    //}
}
