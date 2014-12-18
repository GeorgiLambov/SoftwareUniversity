namespace FurnitureManufacturer.Interfaces.Engine
{
    using System.Collections.Generic;

    public interface IRenderer
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}
