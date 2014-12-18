namespace RestaurantManager.Interfaces
{
    using System.Collections.Generic;

    public interface IRestaurant
    {
        string Name { get; }

        string Location { get; }

        IList<IRecipe> Recipes { get; }

        void AddRecipe(IRecipe recipe);

        void RemoveRecipe(IRecipe recipe);

        string PrintMenu();
    }
}
