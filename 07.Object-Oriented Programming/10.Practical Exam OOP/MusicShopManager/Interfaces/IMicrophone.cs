namespace MusicShopManager.Interfaces
{
    using System;

    public interface IMicrophone : IArticle
    {
        bool HasCable { get; }
    }
}
