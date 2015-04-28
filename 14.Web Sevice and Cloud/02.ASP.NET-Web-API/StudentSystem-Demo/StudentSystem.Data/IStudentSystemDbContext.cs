﻿namespace StudentSystem.Data
{
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IStudentSystemDbContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<Test> Tests { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
