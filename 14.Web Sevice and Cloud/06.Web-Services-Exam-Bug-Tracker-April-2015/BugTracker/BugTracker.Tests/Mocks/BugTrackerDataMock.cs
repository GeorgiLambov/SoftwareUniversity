namespace BugTracker.Tests.Mocks
{
    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;
    using BugTracker.Data.UnitOfWork;

    using Microsoft.AspNet.Identity;

    public class BugTrackerDataMock : IBugsData
    {
        private GenericRepositoryMock<User> usersMock = new GenericRepositoryMock<User>();
        private GenericRepositoryMock<Bug> bugsMock = new GenericRepositoryMock<Bug>();
        private GenericRepositoryMock<Comment> commentsMock = new GenericRepositoryMock<Comment>();
        private GenericUserStoreMock<User> userStoreMock = new GenericUserStoreMock<User>();

        public bool ChangesSaved { get; set; }

        public IRepository<User> Users {
            get { return this.usersMock; }
        }

        public IRepository<Bug> Bugs
        {
            get { return this.bugsMock; }
        }

        public IRepository<Comment> Comments
        {
            get { return this.commentsMock; }
        }

        public IUserStore<User> UserStore
        {
            get { return this.userStoreMock; }
        }

        public void SaveChanges()
        {
            this.ChangesSaved = true;
        }
    }
}
