namespace FurnitureManufacturer.Engine
{
    internal static class EngineConstants
    {
        // Commands
        internal const string CreateCompanyCommand = "CreateCompany";
        internal const string AddFurnitureToCompanyCommand = "AddFurnitureToCompany";
        internal const string RemoveFurnitureFromCompanyCommand = "RemoveFurnitureFromCompany";
        internal const string FindFurnitureFromCompanyCommand = "FindFurnitureFromCompany";
        internal const string ShowCompanyCatalogCommand = "ShowCompanyCatalog";
        internal const string CreateTableCommand = "CreateTable";
        internal const string CreateChairCommand = "CreateChair";
        internal const string SetChairHeight = "SetChairHeight";
        internal const string ConvertChair = "ConvertChair";

        // Chair types
        internal const string NormalChairType = "Normal";
        internal const string AdjustableChairType = "Adjustable";
        internal const string ConvertibleChairType = "Convertible";

        // Error messages
        internal const string InvalidCommandErrorMessage = "Invalid command name: {0}";
        internal const string CompanyExistsErrorMessage = "Company {0} already exists";
        internal const string CompanyNotFoundErrorMessage = "Company {0} not found";
        internal const string FurnitureNotFoundErrorMessage = "Furniture {0} not found";
        internal const string FurnitureExistsErrorMessage = "Furniture {0} already exists";
        internal const string InvalidChairTypeErrorMessage = "Invalid chair type: {0}";
        internal const string FurnitureIsNotAdjustableChairErrorMessage = "{0} is not adjustable chair";
        internal const string FurnitureIsNotConvertibleChairErrorMessage = "{0} is not convertible chair";

        // Success messages
        internal const string CompanyCreatedSuccessMessage = "Company {0} created";
        internal const string FurnitureAddedSuccessMessage = "Furniture {0} added to company {1}";
        internal const string FurnitureRemovedSuccessMessage = "Furniture {0} removed from company {1}";
        internal const string TableCreatedSuccessMessage = "Table {0} created";
        internal const string ChairCreatedSuccessMessage = "Chair {0} created";
        internal const string ChairHeightAdjustedSuccessMessage = "Chair {0} adjusted to height {1}";
        internal const string ChairStateConvertedSuccessMessage = "Chair {0} converted";
    }
}
