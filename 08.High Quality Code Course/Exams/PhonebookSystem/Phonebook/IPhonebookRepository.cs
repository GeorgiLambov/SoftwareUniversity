using System.Collections.Generic;

namespace PhonebookSystem
{
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Assigns a set of phone numbers for given name. If the name already exist,
        /// the phone numbers are merged with the existing ones stored for this name.
        /// </summary>
        /// <param name="name">The name is case-insensitive non-empty string</param>
        /// <param name="phoneNumbers">The phone numbers are expected to be given in strict
        /// cannonical form (with leading "+" and digits only, e.g. +359883445566). Cannot
        /// be empty enumeration.</param>
        /// <returns>true if the phonebook entry is was just created or false when
        /// the phonebook entry was existing the the phones were merged in it</returns>
        /// <remarks>When merging an existing name with a new name, the name remains in
        /// the same character casing as the existing name in the repository and the
        /// duplicated phone numbers are removed. The phone numbers for each name are
        /// sorted in alphabetical order as simple text.</remarks>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes all occurences of given phone number from the repository to another
        /// phone number. Duplicated phones for a single name are merged (no duplicates).
        /// </summary>
        /// <param name="oldPhoneNumber">Cannonical phone number, e.g. +35988334455</param>
        /// <param name="newPhoneNumber">Cannonical phone number, e.g. +35988778899</param>
        /// <returns>The total number of replaced phone numbers or 0 if the specified
        /// old phone number does not exist in the repository</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Lists a sub-range of the entires in the phonebook repository assuming the
        /// entries are sorted by their text representation. The sub-range is specified
        /// by start index (zero-based) and count.
        /// </summary>
        /// <param name="startIndex">A zero-based start index for the first returned
        /// phonebok entry</param>
        /// <param name="count">The number of phonebook entries to return</param>
        /// <returns>The phonebook entries (name + associated phone numbers) that
        /// represent the specified sub-range in the phonebook.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When the specified
        /// sub-range in invalid (invalid start position or invalid count)</exception>
        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}
