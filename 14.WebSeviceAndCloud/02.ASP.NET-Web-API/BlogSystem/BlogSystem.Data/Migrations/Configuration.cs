namespace BlogSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogSystemDbContext context)
        {
            var pesho = new User
            {
                UserName = "Pesho",
                FullName = "Pesho Peshov",
                RegistrationDate = DateTime.Now,
                Gender = Gender.Male,
                ContactInfo = new UserContactInfo
                {
                    Facebook = "pesho face 123",
                    PhoneNumber = "123 123 123"
                },
                Posts = new Collection<Post>
                {
                    new Post{Content = "Post 1", Title = "Title Post 1"},
                    new Post{Content = "Post 2", Title = "Title Post 2"},
                    new Post{Content = "Post 3", Title = "Title Post 3"},
                },
                //Comments = new Collection<Comment>
                //{
                //    new Comment{PostID = 1, Content = "Pesho Coment Post 1"}
                //}
            };



            var gosho = new User
            {
                UserName = "Gosho",
                FullName = "Gosho Peshov",
                RegistrationDate = DateTime.Now,
                Email = "gosho",
                Gender = Gender.Male,
                ContactInfo = new UserContactInfo
                {
                    Facebook = "face 123",
                    PhoneNumber = "123 123 123"
                },
                Posts = new Collection<Post>
                {
                    new Post{Content = "Post 1", Title = "Title Post 1"},
                    new Post{Content = "Post 2", Title = "Title Post 2"},
                    new Post{Content = "Post 3", Title = "Title Post 3"},
                },
                //Comments = new Collection<Comment>
                //{
                //    new Comment{PostID = 1, Content = "Pesho Coment Post 1"},
                //    new Comment{PostID = 1, Content = "Pesho Coment Post 1"}
                //}
            };




            var gogo = new User
            {
                UserName = "gogo",
                FullName = "Log User",
                RegistrationDate = DateTime.Now,
                Birthday = DateTime.Now,
                Email = "gsssss",
                Gender = Gender.Female,
                ContactInfo = new UserContactInfo
                {
                    Facebook = "face Test",
                    PhoneNumber = "123 123 123 TEst"
                },
                Posts = new Collection<Post>
                {
                    new Post{Content = "Post 1", Title = "Title Post 1"},
                    new Post{Content = "Post 2", Title = "Title Post 2"},
                    new Post{Content = "Post 3", Title = "Title Post 3"},
                },
                //Comments = new Collection<Comment>
                //{
                //    new Comment{PostID = 1, Content = "Pesho Coment Post 1"},
                //    new Comment{PostID = 1, Content = "Pesho Coment Post 12"},
                //    new Comment{PostID = 1, Content = "Pesho Coment Post 133"}
                //}
            };

            context.Users.Add(pesho);
            context.Users.Add(gosho);
            context.Users.Add(gogo);

        }
    }
}
