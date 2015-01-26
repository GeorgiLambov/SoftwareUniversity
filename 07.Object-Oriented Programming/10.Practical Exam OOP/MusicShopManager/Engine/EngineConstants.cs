namespace MusicShopManager.Engine
{
    using System;

    internal static class EngineConstants
    {
        #region Commands
        internal const string CreateMusicShopCommand = "CreateMusicShop";
        internal const string CreateMicrophoneCommand = "CreateMicrophone";
        internal const string CreateDrumsCommand = "CreateDrums";
        internal const string CreateElectricGuitarCommand = "CreateElectricGuitar";
        internal const string CreateAcousticGuitarCommand = "CreateAcousticGuitar";
        internal const string CreateBassGuitarCommand = "CreateBassGuitar";
        internal const string AddArticleToShopCommand = "AddArticleToShop";
        internal const string RemoveArticleFromShopCommand = "RemoveArticleFromShop";
        internal const string ListArticlesCommand = "ListArticles";
        #endregion

        #region Error messages
        internal const string InvalidCommandMessage = "Invalid command name: {0}";
        internal const string MusicShopExistsMessage = "The music shop {0} already exists";
        internal const string ArticleExistsMessage = "The article {0} already exists";
        internal const string ArticleExistsInShopMessage = "The article {0} already exists in shop {1}";
        internal const string ArticleDoesNotExistInShopMessage = "The article {0} does not exist in shop {1}";
        internal const string MusicShopDoesNotExistMessage = "The music shop {0} does not exist";
        internal const string ArticleDoesNotExistMessage = "The article {0} does not exist";
        #endregion

        #region Success messages
        internal const string MusicShopCreatedMessage = "Music shop {0} created";
        internal const string ArticleCreatedMessage = "{0} {1} created";
        internal const string ArticleAddedMessage = "Article {0} successfully added to music shop {1}";
        internal const string ArticleRemovedMessage = "Article {0} successfully removed from music shop {1}";
        #endregion
    }
}
