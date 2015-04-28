namespace BlogSystem.Data.Repositories
{
    using System.Linq;

    using Models;

    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(BlogSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<User> AllAuthors()
        {
            return this.All().Where(x => x.Posts.Any());
        }

        public IQueryable<User> AllByGender(Gender gender)
        {
            return this.All().Where(x => x.Gender == gender);
        }

        public User GetUserByUsername(string username)
        {
            return this.All().FirstOrDefault(x => x.UserName == username);
        }
    }
}
