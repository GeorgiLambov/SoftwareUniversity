namespace MusicShopManager.Interfaces.Engine
{
    using System;
    using System.Collections.Generic;

    public interface IUserInterface
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}
