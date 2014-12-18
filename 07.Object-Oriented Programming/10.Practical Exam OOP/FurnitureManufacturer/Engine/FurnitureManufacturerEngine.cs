namespace FurnitureManufacturer.Engine
{
    using System.Collections.Generic;
    using Factories;
    using Interfaces;
    using Interfaces.Engine;

    public sealed class FurnitureManufacturerEngine : IFurnitureManufacturerEngine
    {
        private static IFurnitureManufacturerEngine instance;

        private readonly ICompanyFactory companyFactory;
        private readonly IFurnitureFactory furnitureFactory;

        private readonly IDictionary<string, ICompany> companies;
        private readonly IDictionary<string, IFurniture> furnitures;

        private readonly IRenderer renderer;

        private FurnitureManufacturerEngine()
        {
            this.companyFactory = new CompanyFactory();
            this.furnitureFactory = new FurnitureFactory();
            this.companies = new Dictionary<string, ICompany>();
            this.furnitures = new Dictionary<string, IFurniture>();
            this.renderer = new ConsoleRenderer();
        }

        public static IFurnitureManufacturerEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FurnitureManufacturerEngine();
                }

                return instance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResults = this.ProcessCommands(commands);
            this.RenderCommandResults(commandResults);
        }

        private ICollection<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            foreach (var currentLine in this.renderer.Input())
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(ICollection<ICommand> commands)
        {
            var commandResults = new List<string>();

            foreach (var command in commands)
            {
                string commandResult;

                switch (command.Name)
                {
                    case EngineConstants.CreateCompanyCommand:
                        var companyName = command.Parameters[0];
                        var companyRegistrationNumber = command.Parameters[1];
                        commandResult = this.CreateCompany(companyName, companyRegistrationNumber);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.AddFurnitureToCompanyCommand:
                        var companyToAddTo = command.Parameters[0];
                        var furnitureToBeAdded = command.Parameters[1];
                        commandResult = this.AddFurnitureToCompany(companyToAddTo, furnitureToBeAdded);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.RemoveFurnitureFromCompanyCommand:
                        var companyToRemoveFrom = command.Parameters[0];
                        var furnitureToBeRemoved = command.Parameters[1];
                        commandResult = this.RemoveFurnitureFromCompany(companyToRemoveFrom, furnitureToBeRemoved);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.FindFurnitureFromCompanyCommand:
                        var companyToFindFrom = command.Parameters[0];
                        var furnitureToBeFound = command.Parameters[1];
                        commandResult = this.FindFurnitureFromCompany(companyToFindFrom, furnitureToBeFound);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.ShowCompanyCatalogCommand:
                        var companyToShowCatalog = command.Parameters[0];
                        commandResult = this.ShowCompanyCatalog(companyToShowCatalog);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.CreateTableCommand:
                        var tableModel = command.Parameters[0];
                        var tableMaterial = command.Parameters[1];
                        var tablePrice = decimal.Parse(command.Parameters[2]);
                        var tableHeight = decimal.Parse(command.Parameters[3]);
                        var tableLength = decimal.Parse(command.Parameters[4]);
                        var tableWidth = decimal.Parse(command.Parameters[5]);
                        commandResult = this.CreateTable(tableModel, tableMaterial, tablePrice, tableHeight, tableLength, tableWidth);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.CreateChairCommand:
                        var chairModel = command.Parameters[0];
                        var chairMaterial = command.Parameters[1];
                        var chairPrice = decimal.Parse(command.Parameters[2]);
                        var chairHeight = decimal.Parse(command.Parameters[3]);
                        var chairLegs = int.Parse(command.Parameters[4]);
                        var chairType = command.Parameters[5];
                        commandResult = this.CreateChair(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs, chairType);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.SetChairHeight:
                        var adjChairModel = command.Parameters[0];
                        var adjChairHeight = decimal.Parse(command.Parameters[1]);
                        commandResult = this.AdjustChairHeight(adjChairModel, adjChairHeight);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.ConvertChair:
                        var convertibleChairModel = command.Parameters[0];
                        commandResult = this.ConvertChair(convertibleChairModel);
                        commandResults.Add(commandResult);
                        break;
                    default:
                        commandResults.Add(string.Format(EngineConstants.InvalidCommandErrorMessage, command.Name));
                        break;
                }
            }

            return commandResults;
        }

        private void RenderCommandResults(IEnumerable<string> output)
        {
            this.renderer.Output(output);
        }

        private string CreateCompany(string name, string registrationNumber)
        {
            if (this.companies.ContainsKey(name))
            {
                return string.Format(EngineConstants.CompanyExistsErrorMessage, name);
            }

            var company = this.companyFactory.CreateCompany(name, registrationNumber);
            this.companies.Add(name, company);

            return string.Format(EngineConstants.CompanyCreatedSuccessMessage, name);
        }

        private string AddFurnitureToCompany(string companyName, string furnitureName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            if (!this.furnitures.ContainsKey(furnitureName))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnitureName);
            }

            var company = this.companies[companyName];
            var furniture = this.furnitures[furnitureName];
            company.Add(furniture);

            return string.Format(EngineConstants.FurnitureAddedSuccessMessage, furnitureName, companyName);
        }

        private string RemoveFurnitureFromCompany(string companyName, string furnitureName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            if (!this.furnitures.ContainsKey(furnitureName))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnitureName);
            }

            var company = this.companies[companyName];
            var furniture = this.furnitures[furnitureName];
            company.Remove(furniture);

            return string.Format(EngineConstants.FurnitureRemovedSuccessMessage, furnitureName, companyName);
        }

        private string FindFurnitureFromCompany(string companyName, string furnitureName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            var company = this.companies[companyName];
            var furniture = company.Find(furnitureName);
            if (furniture == null)
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnitureName);
            }

            return furniture.ToString();
        }

        private string ShowCompanyCatalog(string companyName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            return this.companies[companyName].Catalog();
        }

        private string CreateTable(string model, string material, decimal price, decimal height, decimal length, decimal width)
        {
            if (this.furnitures.ContainsKey(model))
            {
                return string.Format(EngineConstants.FurnitureExistsErrorMessage, model);
            }

            var table = this.furnitureFactory.CreateTable(model, material, price, height, length, width);
            this.furnitures.Add(model, table);

            return string.Format(EngineConstants.TableCreatedSuccessMessage, model);
        }

        private string CreateChair(string model, string material, decimal price, decimal height, int legs, string type)
        {
            if (this.furnitures.ContainsKey(model))
            {
                return string.Format(EngineConstants.FurnitureExistsErrorMessage, model);
            }

            IChair chair;
            switch (type)
            {
                case EngineConstants.NormalChairType:
                    chair = this.furnitureFactory.CreateChair(model, material, price, height, legs);
                    break;
                case EngineConstants.AdjustableChairType:
                    chair = this.furnitureFactory.CreateAdjustableChair(model, material, price, height, legs);
                    break;
                case EngineConstants.ConvertibleChairType:
                    chair = this.furnitureFactory.CreateConvertibleChair(model, material, price, height, legs);
                    break;
                default:
                    return string.Format(EngineConstants.InvalidChairTypeErrorMessage, type);
            }

            this.furnitures.Add(model, chair);

            return string.Format(EngineConstants.ChairCreatedSuccessMessage, model);
        }

        private string AdjustChairHeight(string model, decimal height)
        {
            if (!this.furnitures.ContainsKey(model))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, model);
            }

            var adjChair = this.furnitures[model] as IAdjustableChair;
            if (adjChair == null)
            {
                return string.Format(EngineConstants.FurnitureIsNotAdjustableChairErrorMessage, model);
            }

            adjChair.SetHeight(height);

            return string.Format(EngineConstants.ChairHeightAdjustedSuccessMessage, model, height);
        }

        private string ConvertChair(string model)
        {
            if (!this.furnitures.ContainsKey(model))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, model);
            }

            var convChair = this.furnitures[model] as IConvertibleChair;
            if (convChair == null)
            {
                return string.Format(EngineConstants.FurnitureIsNotConvertibleChairErrorMessage, model);
            }

            convChair.Convert();

            return string.Format(EngineConstants.ChairStateConvertedSuccessMessage, model);
        }
    }
}
