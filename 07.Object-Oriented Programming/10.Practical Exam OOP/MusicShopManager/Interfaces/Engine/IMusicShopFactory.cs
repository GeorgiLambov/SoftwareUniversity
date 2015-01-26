namespace MusicShopManager.Interfaces.Engine
{
    using System;

    public interface IMusicShopFactory
    {
        IMusicShop CreateMusicShop(string name);
    }
}
