namespace FurnitureManufacturer.Interfaces.Engine
{
    public interface ICompanyFactory
    {
        ICompany CreateCompany(string name, string registrationNumber);
    }
}
