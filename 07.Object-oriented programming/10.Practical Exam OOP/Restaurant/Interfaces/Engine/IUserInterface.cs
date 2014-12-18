namespace RestaurantManager.Interfaces.Engine
{
    using System.Collections.Generic;

    public interface IUserInterface
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}
