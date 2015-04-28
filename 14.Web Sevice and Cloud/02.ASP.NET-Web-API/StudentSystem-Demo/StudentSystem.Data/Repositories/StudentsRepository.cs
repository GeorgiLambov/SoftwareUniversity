namespace StudentSystem.Data.Repositories
{
    using StudentSystem.Models;
    using System.Linq;

    public class StudentsRepository : GenericRepository<Student>, IGenericRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Student> AllAsistants()
        {
            return this.All().Where(st => st.Trainees.Count() > 0);
        }
    }
}
