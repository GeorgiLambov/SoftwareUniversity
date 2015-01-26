namespace MusicShopManager.Interfaces
{
    using System;

    public interface IArticle
    {
        string Make { get; }

        string Model { get; }

        decimal Price { get; }        
    }
}
