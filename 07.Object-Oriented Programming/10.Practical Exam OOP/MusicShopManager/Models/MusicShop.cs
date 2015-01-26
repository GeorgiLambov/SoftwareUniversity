namespace MusicShopManager.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles;
        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name is required.");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get { return this.articles; }
            private set { this.articles = value; }
        }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("===== {0} =====", this.Name).AppendLine();

            if (this.Articles.Count > 0)
            {
                var list = this.Articles;

                var sorderedMicrophones = from target in list
                                          where target.GetType().Name == "Microphone"
                                          orderby (target.Make + " " + target.Model)
                                          select target;

                if (sorderedMicrophones.Any())
                {
                    result.AppendLine("----- Microphones -----");

                    foreach (var mic in sorderedMicrophones)
                    {
                        result.AppendLine(mic.ToString());
                    }

                    result.ToString().Trim();
                }


                var sorderedDrums = from target in list
                                    where target.GetType().Name == "Drums"
                                    orderby (target.Make + " " + target.Model)
                                    select target;

                if (sorderedDrums.Any())
                {
                    result.AppendLine("----- Drums -----");

                    foreach (var drum in sorderedDrums)
                    {
                        result.AppendLine(drum.ToString());
                    }

                    result.ToString().Trim();
                }

                var sorderedElectricGuitars = from target in list
                                              where target.GetType().Name == "ElectricGuitar"
                                              orderby (target.Make + " " + target.Model)
                                              select target;

                if (sorderedElectricGuitars.Any())
                {
                    result.AppendLine("----- Electric guitars -----");

                    foreach (var item in sorderedElectricGuitars)
                    {
                        result.AppendLine(item.ToString());
                    }

                    result.ToString().Trim();
                }

                var sorderedAcousticGuitars = from target in list
                                              where target.GetType().Name == "AcousticGuitar"
                                              orderby (target.Make + " " + target.Model)
                                              select target;

                if (sorderedAcousticGuitars.Any())
                {
                    result.AppendLine("----- Acoustic guitars -----");

                    foreach (var item in sorderedAcousticGuitars)
                    {
                        result.AppendLine(item.ToString());
                    }

                    result.ToString().Trim();
                }


                var sorderedBassGuitars = from target in list
                                          where target.GetType().Name == "BassGuitar"
                                          orderby (target.Make + " " + target.Model)
                                          select target;

                if (sorderedBassGuitars.Any())
                {
                    result.AppendLine("----- Bass guitars -----");

                    foreach (var item in sorderedBassGuitars)
                    {
                        result.AppendLine(item.ToString());
                    }

                    result.ToString().Trim();
                }


            }
            else
            {
                result.Append("The shop is empty. Come back soon.");
            }

            return result.ToString();
        }
    }
}
