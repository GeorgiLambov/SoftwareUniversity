namespace RestaurantManager.Engine
{
    using System;
    using System.Collections.Generic;
    using RestaurantManager.Engine.Factories;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;

    public sealed class RestaurantManagerEngine : IRestaurantManagerEngine
    {
        private static IRestaurantManagerEngine instance;

        private readonly IRestaurantFactory restaurantFactory;
        private readonly IRecipeFactory recipeFactory;

        private readonly IDictionary<string, IRestaurant> restaurants;
        private readonly IDictionary<string, IRecipe> recipes;

        private readonly IUserInterface userInterface;

        private RestaurantManagerEngine()
        {
            this.restaurantFactory = new RestaurantFactory();
            this.recipeFactory = new RecipeFactory();
            this.restaurants = new Dictionary<string, IRestaurant>();
            this.recipes = new Dictionary<string, IRecipe>();
            this.userInterface = new ConsoleInterface();
        }

        public static IRestaurantManagerEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestaurantManagerEngine();
                }

                return instance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResults = this.ProcessCommands(commands);
            this.userInterface.Output(commandResults);
        }

        private ICollection<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            foreach (var line in this.userInterface.Input())
            {
                commands.Add(Command.Parse(line));
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
                    case EngineConstants.CreateRestaurantCommand:
                        commandResult = this.CreateRestaurant(
                            command.Parameters["name"],
                            command.Parameters["location"]);
                        break;
                    case EngineConstants.CreateDrinkCommand:
                        commandResult = this.CreateDrink(
                            command.Parameters["name"],
                            decimal.Parse(command.Parameters["price"]),
                            int.Parse(command.Parameters["calories"]),
                            int.Parse(command.Parameters["quantity"]),
                            int.Parse(command.Parameters["time"]),
                            this.ParseBoolean(command.Parameters["carbonated"]));
                        break;
                    case EngineConstants.CreateSaladCommand:
                        commandResult = this.CreateSalad(
                            command.Parameters["name"],
                            decimal.Parse(command.Parameters["price"]),
                            int.Parse(command.Parameters["calories"]),
                            int.Parse(command.Parameters["quantity"]),
                            int.Parse(command.Parameters["time"]),
                            this.ParseBoolean(command.Parameters["pasta"]));
                        break;
                    case EngineConstants.CreateMainCourseCommand:
                        commandResult = this.CreateMainCourse(
                            command.Parameters["name"],
                            decimal.Parse(command.Parameters["price"]),
                            int.Parse(command.Parameters["calories"]),
                            int.Parse(command.Parameters["quantity"]),
                            int.Parse(command.Parameters["time"]),
                            this.ParseBoolean(command.Parameters["vegan"]),
                            command.Parameters["type"]);
                        break;
                    case EngineConstants.CreateDessertCommand:
                        commandResult = this.CreateDessert(
                            command.Parameters["name"],
                            decimal.Parse(command.Parameters["price"]),
                            int.Parse(command.Parameters["calories"]),
                            int.Parse(command.Parameters["quantity"]),
                            int.Parse(command.Parameters["time"]),
                            this.ParseBoolean(command.Parameters["vegan"]));
                        break;
                    case EngineConstants.ToggleVeganCommand:
                        commandResult = this.ToggleVegan(command.Parameters["name"]);
                        break;
                    case EngineConstants.ToggleSugarCommand:
                        commandResult = this.ToggleSugar(command.Parameters["name"]);
                        break;
                    case EngineConstants.AddRecipeToRestaurantCommand:
                        commandResult = this.AddRecipeToRestaurant(command.Parameters["restaurant"], command.Parameters["recipe"]);
                        break;
                    case EngineConstants.RemoveRecipeFromRestaurantCommand:
                        commandResult = this.RemoveRecipeFromRestaurant(command.Parameters["restaurant"], command.Parameters["recipe"]);
                        break;
                    case EngineConstants.PrintRestaurantMenuCommand:
                        commandResult = this.PrintRestaurantMenu(command.Parameters["name"]);
                        break;
                    default:
                        commandResult = string.Format(EngineConstants.InvalidCommandMessage, command.Name);
                        break;
                }

                commandResults.Add(commandResult);
            }

            return commandResults;
        }

        private bool ParseBoolean(string boolValue)
        {
            if (boolValue == "yes")
            {
                return true;
            }
            else if (boolValue == "no")
            {
                return false;
            }
            else
            {
                throw new ArgumentException("Invalid boolean value provided: " + boolValue);
            }
        }

        private string CreateRestaurant(string name, string location)
        {
            if (this.restaurants.ContainsKey(name))
            {
                return string.Format(EngineConstants.RestaurantExistsMessage, name);
            }

            var restaurant = this.restaurantFactory.CreateRestaurant(name, location);
            this.restaurants.Add(name, restaurant);
            return string.Format(EngineConstants.RestaurantCreatedMessage, name);
        }

        private string CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            if (this.recipes.ContainsKey(name))
            {
                return string.Format(EngineConstants.RecipeExistsMessage, name);
            }

            var drink = this.recipeFactory.CreateDrink(name, price, calories, quantityPerServing, timeToPrepare, isCarbonated);
            this.recipes.Add(name, drink);
            return string.Format(EngineConstants.RecipeCreatedMessage, name);
        }

        private string CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            if (this.recipes.ContainsKey(name))
            {
                return string.Format(EngineConstants.RecipeExistsMessage, name);
            }

            var salad = this.recipeFactory.CreateSalad(name, price, calories, quantityPerServing, timeToPrepare, containsPasta);
            this.recipes.Add(name, salad);
            return string.Format(EngineConstants.RecipeCreatedMessage, name);
        }

        private string CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            if (this.recipes.ContainsKey(name))
            {
                return string.Format(EngineConstants.RecipeExistsMessage, name);
            }

            var mainCourse = this.recipeFactory.CreateMainCourse(name, price, calories, quantityPerServing, timeToPrepare, isVegan, type);
            this.recipes.Add(name, mainCourse);
            return string.Format(EngineConstants.RecipeCreatedMessage, name);
        }

        private string CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            if (this.recipes.ContainsKey(name))
            {
                return string.Format(EngineConstants.RecipeExistsMessage, name);
            }

            var dessert = this.recipeFactory.CreateDessert(name, price, calories, quantityPerServing, timeToPrepare, isVegan);
            this.recipes.Add(name, dessert);
            return string.Format(EngineConstants.RecipeCreatedMessage, name);
        }

        private string ToggleVegan(string name)
        {
            if (!this.recipes.ContainsKey(name))
            {
                return string.Format(EngineConstants.RecipeDoesNotExistMessage, name);
            }

            var recipe = this.recipes[name];
            if (recipe is IMeal)
            {
                var meal = recipe as IMeal;
                try
                {
                    meal.ToggleVegan();
                }
                catch (ArgumentException) 
                {
                    return string.Format(EngineConstants.InapplicableCommandMessage, "ToggleVegan", name);
                }

                return string.Format(EngineConstants.CommandSuccessfulMessage, "ToggleVegan", meal.IsVegan.ToString().ToLower());
            }
            else
            {
                return string.Format(EngineConstants.InapplicableCommandMessage, "ToggleVegan", name);
            }
        }

        private string ToggleSugar(string name)
        {
            if (!this.recipes.ContainsKey(name))
            {
                return string.Format(EngineConstants.RecipeDoesNotExistMessage, name);
            }

            var recipe = this.recipes[name];
            if (recipe is IDessert)
            {
                var dessert = recipe as IDessert;
                dessert.ToggleSugar();
                return string.Format(EngineConstants.CommandSuccessfulMessage, "ToggleSugar", dessert.WithSugar.ToString().ToLower());
            }
            else
            {
                return string.Format(EngineConstants.InapplicableCommandMessage, "ToggleSugar", name);
            }
        }

        private string AddRecipeToRestaurant(string restaurantName, string recipeName) 
        {
            if (!this.restaurants.ContainsKey(restaurantName))
            {
                return string.Format(EngineConstants.RestaurantDoesNotExistMessage, restaurantName);
            }

            if (!this.recipes.ContainsKey(recipeName))
            {
                return string.Format(EngineConstants.RecipeDoesNotExistMessage, recipeName);
            }

            this.restaurants[restaurantName].AddRecipe(this.recipes[recipeName]);
            return string.Format(EngineConstants.RecipeAddedMessage, recipeName, restaurantName);
        }

        private string RemoveRecipeFromRestaurant(string restaurantName, string recipeName)
        {
            if (!this.restaurants.ContainsKey(restaurantName))
            {
                return string.Format(EngineConstants.RestaurantDoesNotExistMessage, restaurantName);
            }

            if (!this.recipes.ContainsKey(recipeName))
            {
                return string.Format(EngineConstants.RecipeDoesNotExistMessage, recipeName);
            }

            this.restaurants[restaurantName].RemoveRecipe(this.recipes[recipeName]);
            return string.Format(EngineConstants.RecipeRemovedMessage, recipeName, restaurantName);
        }

        private string PrintRestaurantMenu(string name)
        {
            if (!this.restaurants.ContainsKey(name))
            {
                return string.Format(EngineConstants.RestaurantDoesNotExistMessage, name);
            }

            return this.restaurants[name].PrintMenu();
        }
    }
}
