namespace RestaurantManager.Engine
{
    internal static class EngineConstants
    {
        #region Commands
        internal const string CreateRestaurantCommand = "CreateRestaurant";
        internal const string CreateDrinkCommand = "CreateDrink";
        internal const string CreateSaladCommand = "CreateSalad";
        internal const string CreateMainCourseCommand = "CreateMainCourse";
        internal const string CreateDessertCommand = "CreateDessert";
        internal const string ToggleSugarCommand = "ToggleSugar";
        internal const string ToggleVeganCommand = "ToggleVegan";
        internal const string AddRecipeToRestaurantCommand = "AddRecipeToRestaurant";
        internal const string RemoveRecipeFromRestaurantCommand = "RemoveRecipeFromRestaurant";
        internal const string PrintRestaurantMenuCommand = "PrintRestaurantMenu";

        #endregion

        #region Error messages
        internal const string InvalidCommandMessage = "Invalid command name: {0}";
        internal const string RestaurantExistsMessage = "The restaurant {0} already exists";
        internal const string RecipeExistsMessage = "The recipe {0} already exists";
        internal const string RestaurantDoesNotExistMessage = "The restaurant {0} does not exist";
        internal const string RecipeDoesNotExistMessage = "The recipe {0} does not exist";
        internal const string InapplicableCommandMessage = "The command {0} is not applicable to recipe {1}";
        #endregion

        #region Success messages
        internal const string RestaurantCreatedMessage = "Restaurant {0} created";
        internal const string RecipeCreatedMessage = "Recipe {0} created";
        internal const string CommandSuccessfulMessage = "Command {0} executed successfully. New value: {1}";
        internal const string RecipeAddedMessage = "Recipe {0} successfully added to restaurant {1}";
        internal const string RecipeRemovedMessage = "Recipe {0} successfully removed from restaurant {1}";
        #endregion
    }
}
