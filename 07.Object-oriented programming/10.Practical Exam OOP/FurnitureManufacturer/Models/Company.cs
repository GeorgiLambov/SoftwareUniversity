using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures = new Collection<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            //this.Furnitures = furnitures;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name cannot be empty, null or with less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Registration Number cannot be null or empty!");
                }
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("Registration Number must be exacly ten symbols!");
                }
                foreach (char ch in value)
                {
                    if (!Char.IsDigit(ch))
                    {
                        throw new ArgumentOutOfRangeException("Registration Number must be exacly ten symbols!");
                    }
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }

        }
        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Furniture cannot be null");
            }

            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Furniture cannot be null");
            }

            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            var result = from target in this.furnitures
                         where target.Model.ToLower() == model.ToLower()
                         select target;
            return result.FirstOrDefault() as IFurniture;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();

            var orderedCatalogFurnitures = from target in furnitures
                                           orderby target.Price ascending, target.Model ascending
                                           select target;


            result.AppendFormat("{0} - {1} - {2} {3}\n",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                );

            foreach (var orderedCataloFurniture in orderedCatalogFurnitures)
            {
                result.AppendLine(orderedCataloFurniture.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
