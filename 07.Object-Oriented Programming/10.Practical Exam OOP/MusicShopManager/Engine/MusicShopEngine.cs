namespace MusicShopManager.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MusicShopManager.Engine.Factories;
    using MusicShopManager.Interfaces;
    using MusicShopManager.Interfaces.Engine;
    using MusicShopManager.Models;

    public sealed class MusicShopEngine : IMusicShopEngine
    {
        private static IMusicShopEngine instance;

        private readonly IMusicShopFactory musicShopFactory;
        private readonly IArticleFactory articleFactory;

        private readonly IDictionary<string, IMusicShop> musicShops;
        private readonly IDictionary<string, IArticle> articles;

        private readonly IUserInterface userInterface;

        private MusicShopEngine()
        {
            this.musicShopFactory = new MusicShopFactory();
            this.articleFactory = new ArticleFactory();
            this.musicShops = new Dictionary<string, IMusicShop>();
            this.articles = new Dictionary<string, IArticle>();
            this.userInterface = new ConsoleInterface();
        }

        public static IMusicShopEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicShopEngine();
                }

                return instance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResults = this.ProcessCommands(commands);
            this.userInterface.Output(commandResults);
        }

        private ICollection<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            foreach (var line in this.userInterface.Input())
            {
                commands.Add(Command.Parse(line));
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(ICollection<ICommand> commands)
        {
            var commandResults = new List<string>();
            foreach (var command in commands)
            {
                string commandResult;
                switch (command.Name)
                {
                    case EngineConstants.CreateMusicShopCommand:
                        commandResult = this.CreateMusicShop(command.Parameters["name"]);
                        break;
                    case EngineConstants.CreateMicrophoneCommand:
                        commandResult = this.CreateMicrophone(
                            command.Parameters["make"],
                            command.Parameters["model"],
                            decimal.Parse(command.Parameters["price"]),
                            this.ParseBoolean(command.Parameters["cable"]));
                        break;
                    case EngineConstants.CreateDrumsCommand:
                        commandResult = this.CreateDrums(
                            command.Parameters["make"],
                            command.Parameters["model"],
                            decimal.Parse(command.Parameters["price"]),
                            command.Parameters["color"],
                            int.Parse(command.Parameters["width"]),
                            int.Parse(command.Parameters["height"]));
                        break;
                    case EngineConstants.CreateElectricGuitarCommand:
                        commandResult = this.CreateElectricGuitar(
                            command.Parameters["make"],
                            command.Parameters["model"],
                            decimal.Parse(command.Parameters["price"]),
                            command.Parameters["color"],
                            command.Parameters["body"],
                            command.Parameters["fingerboard"],
                            int.Parse(command.Parameters["adapters"]),
                            int.Parse(command.Parameters["frets"]));
                        break;
                    case EngineConstants.CreateAcousticGuitarCommand:
                        commandResult = this.CreateAcousticGuitar(
                            command.Parameters["make"],
                            command.Parameters["model"],
                            decimal.Parse(command.Parameters["price"]),
                            command.Parameters["color"],
                            command.Parameters["body"],
                            command.Parameters["fingerboard"],
                            this.ParseBoolean(command.Parameters["case"]),
                            command.Parameters["strings"]);
                        break;
                    case EngineConstants.CreateBassGuitarCommand:
                        commandResult = this.CreateBassGuitar(
                            command.Parameters["make"],
                            command.Parameters["model"],
                            decimal.Parse(command.Parameters["price"]),
                            command.Parameters["color"],
                            command.Parameters["body"],
                            command.Parameters["fingerboard"]);
                        break;
                    case EngineConstants.AddArticleToShopCommand:
                        commandResult = this.AddArticleToShop(
                            command.Parameters["name"],
                            command.Parameters["make"],
                            command.Parameters["model"]);
                        break;
                    case EngineConstants.RemoveArticleFromShopCommand:
                        commandResult = this.RemoveArticleFromShop(
                            command.Parameters["name"],
                            command.Parameters["make"],
                            command.Parameters["model"]);
                        break;
                    case EngineConstants.ListArticlesCommand:
                        commandResult = this.ListArticles(
                            command.Parameters["name"]);
                        break;
                    default:
                        commandResult = string.Format(EngineConstants.InvalidCommandMessage, command.Name);
                        break;
                }

                commandResults.Add(commandResult);
            }

            return commandResults;
        }

        private bool ParseBoolean(string boolValue)
        {
            if (boolValue == "yes")
            {
                return true;
            }
            else if (boolValue == "no")
            {
                return false;
            }
            else
            {
                throw new ArgumentException("Invalid boolean value provided: " + boolValue);
            }
        }

        private string CreateMusicShop(string name)
        {
            if (this.musicShops.ContainsKey(name))
            {
                return string.Format(EngineConstants.MusicShopExistsMessage, name);
            }

            var musicShop = this.musicShopFactory.CreateMusicShop(name);
            this.musicShops.Add(name, musicShop);
            return string.Format(EngineConstants.MusicShopCreatedMessage, name);
        }

        private string CreateMicrophone(string make, string model, decimal price, bool hasCable)
        {
            string name = make + " " + model;
            try
            {
                this.EnsureUniqueArticle(make, model);
            }
            catch (ArgumentException)
            {
                return string.Format(EngineConstants.ArticleExistsMessage, name);
            }

            var microphone = this.articleFactory.CreateMirophone(make, model, price, hasCable);
            this.articles.Add(name, microphone);
            return string.Format(EngineConstants.ArticleCreatedMessage, "Microphone", name);
        }

        private string CreateDrums(string make, string model, decimal price, string color, int width, int height)
        {
            string name = make + " " + model;
            try
            {
                this.EnsureUniqueArticle(make, model);
            }
            catch (ArgumentException)
            {
                return string.Format(EngineConstants.ArticleExistsMessage, name);
            }

            var drums = this.articleFactory.CreateDrums(make, model, price, color, width, height);
            this.articles.Add(name, drums);
            return string.Format(EngineConstants.ArticleCreatedMessage, "Drums", name);
        }

        private string CreateElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
        {
            string name = make + " " + model;
            try
            {
                this.EnsureUniqueArticle(make, model);
            }
            catch (ArgumentException)
            {
                return string.Format(EngineConstants.ArticleExistsMessage, name);
            }

            var electricGuitar = this.articleFactory.CreateElectricGuitar(make, model, price, color, bodyWood, fingerboardWood, numberOfAdapters, numberOfFrets);
            this.articles.Add(name, electricGuitar);
            return string.Format(EngineConstants.ArticleCreatedMessage, "Electric guitar", name);
        }

        private string CreateAcousticGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, bool caseIncluded, string stringMaterial)
        {
            string name = make + " " + model;
            try
            {
                this.EnsureUniqueArticle(make, model);
            }
            catch (ArgumentException)
            {
                return string.Format(EngineConstants.ArticleExistsMessage, name);
            }

            var acousticGuitar = this.articleFactory.CreateAcousticGuitar(make, model, price, color,
                bodyWood, fingerboardWood, caseIncluded, (StringMaterial)Enum.Parse(typeof(StringMaterial), stringMaterial));
            this.articles.Add(name, acousticGuitar);
            return string.Format(EngineConstants.ArticleCreatedMessage, "Acoustic guitar", name);
        }

        private string CreateBassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
        {
            string name = make + " " + model;
            try
            {
                this.EnsureUniqueArticle(make, model);
            }
            catch (ArgumentException)
            {
                return string.Format(EngineConstants.ArticleExistsMessage, name);
            }

            var bassGuitar = this.articleFactory.CreateBassGuitar(make, model, price, color, bodyWood, fingerboardWood);
            this.articles.Add(name, bassGuitar);
            return string.Format(EngineConstants.ArticleCreatedMessage, "Bass guitar", name);
        }

        private void EnsureUniqueArticle(string make, string model)
        {
            string name = make + " " + model;
            if (this.articles.ContainsKey(name))
            {
                throw new ArgumentException(EngineConstants.ArticleExistsMessage, name);
            }
        }

        private string AddArticleToShop(string shopName, string make, string model)
        {
            if (!this.musicShops.ContainsKey(shopName))
            {
                return string.Format(EngineConstants.MusicShopDoesNotExistMessage, shopName);
            }

            string articleName = make + " " + model;
            if (!this.articles.ContainsKey(articleName))
            {
                return string.Format(EngineConstants.ArticleDoesNotExistMessage, articleName);
            }

            if (this.musicShops[shopName].Articles.Select(a => a.Make + " " + a.Model).Contains(articleName))
            {
                return string.Format(EngineConstants.ArticleExistsInShopMessage, articleName, shopName);
            }

            this.musicShops[shopName].AddArticle(this.articles[articleName]);
            return string.Format(EngineConstants.ArticleAddedMessage, articleName, shopName);
        }

        private string RemoveArticleFromShop(string shopName, string make, string model)
        {
            if (!this.musicShops.ContainsKey(shopName))
            {
                return string.Format(EngineConstants.MusicShopDoesNotExistMessage, shopName);
            }

            string articleName = make + " " + model;
            if (!this.articles.ContainsKey(articleName))
            {
                return string.Format(EngineConstants.ArticleDoesNotExistMessage, articleName);
            }

            if (!this.musicShops[shopName].Articles.Select(a => a.Make + " " + a.Model).Contains(articleName))
            {
                return string.Format(EngineConstants.ArticleDoesNotExistInShopMessage, articleName, shopName);
            }

            this.musicShops[shopName].RemoveArticle(this.articles[articleName]);
            return string.Format(EngineConstants.ArticleRemovedMessage, articleName, shopName);
        }

        private string ListArticles(string shopName)
        {
            if (!this.musicShops.ContainsKey(shopName))
            {
                return string.Format(EngineConstants.MusicShopDoesNotExistMessage, shopName);
            }

            return this.musicShops[shopName].ListArticles();
        }
    }
}
