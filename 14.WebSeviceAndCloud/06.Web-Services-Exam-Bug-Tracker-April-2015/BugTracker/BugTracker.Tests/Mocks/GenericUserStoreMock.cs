namespace BugTracker.Tests.Mocks
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    public class GenericUserStoreMock<TUser> : IUserStore<TUser>
        where TUser : class, IUser
    {
        private GenericRepositoryMock<TUser> users = new GenericRepositoryMock<TUser>();

        public async Task CreateAsync(TUser user)
        {
            await Task.Run(() => this.users.Add(user));
        }

        public async Task DeleteAsync(TUser user)
        {
            await Task.Run(() => this.users.Remove(user));
        }

        public async Task<TUser> FindByIdAsync(string userId)
        {
            return await Task.Run(() => this.users.Find(userId));
        }

        public async Task<TUser> FindByNameAsync(string userName)
        {
            return await Task.Run(() =>
                this.users.All().FirstOrDefault(u => u.UserName == userName));
        }

        public async Task UpdateAsync(TUser user)
        {
            await Task.Run(() => this.users.Update(user));
        }

        public IQueryable<TUser> AllUsers
        {
            get { return this.users.All(); }
        }

        public void Dispose()
        {
            this.users = null;
        }
    }
}
