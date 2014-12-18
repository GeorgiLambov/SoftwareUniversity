namespace RestaurantManager.Interfaces.Engine
{
    public interface IRecipeFactory
    {
        IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated);

        ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta);

        IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type);

        IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan);
    }
}
