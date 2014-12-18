namespace FurnitureManufacturer.Interfaces.Engine
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
