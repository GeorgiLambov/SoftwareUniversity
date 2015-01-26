namespace MusicShopManager.Interfaces
{
    using System;
    using System.Collections.Generic;
    
    public interface IMusicShop
    {
        string Name { get; }

        IList<IArticle> Articles { get; }

        void AddArticle(IArticle article);

        void RemoveArticle(IArticle article);

        string ListArticles();
    }
}
