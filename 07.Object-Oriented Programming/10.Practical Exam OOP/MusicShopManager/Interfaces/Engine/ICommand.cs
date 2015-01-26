namespace MusicShopManager.Interfaces.Engine
{
    using System;
    using System.Collections.Generic;

    public interface ICommand
    {
        string Name { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
