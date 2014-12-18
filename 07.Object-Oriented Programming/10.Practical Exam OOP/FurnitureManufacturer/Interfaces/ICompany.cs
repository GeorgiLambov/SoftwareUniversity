namespace FurnitureManufacturer.Interfaces
{
    using System.Collections.Generic;

    public interface ICompany
    {
        string Name { get; }

        string RegistrationNumber { get; }

        ICollection<IFurniture> Furnitures { get; }

        void Add(IFurniture furniture);

        void Remove(IFurniture furniture);

        IFurniture Find(string model);

        string Catalog();
    }
}
