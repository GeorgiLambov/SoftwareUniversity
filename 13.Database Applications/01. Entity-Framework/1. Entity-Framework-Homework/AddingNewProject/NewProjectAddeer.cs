namespace AddingNewProject
{
    using System;
    using System.Collections.ObjectModel;
    using EntityFramework.Data;

    public class NewProjectAddeer
    {
        //In all versions of Entity Framework, whenever you execute SaveChanges() to insert, update or delete on the database the framework will wrap that operation in a transaction. This transaction lasts only long enough to execute the operation and then completes. When you execute another such operation a new transaction is started.

        static void Main()
        {
            ProjectAdderImlicitlyStartTransaction();
            ProjectAdderExplicitlyStartTransaction();
        }

        static void ProjectAdderImlicitlyStartTransaction()
        {
            using (var db = new SoftUniEntities())
            {
                var firstEmployee = db.Employees.Find(15);
                var lastEmployee = db.Employees.Find(30);
                var project = new Project
                {
                    Name = "DatabaseTeamWork",
                    StartDate = new DateTime(2015, 2, 15, 0, 0, 0),
                    EndDate = new DateTime(2015, 3, 20, 0, 0, 0),
                    Employees = new Collection<Employee>
                    {
                        firstEmployee,
                        lastEmployee
                    },
                    Description = "TeamWork"
                };
                try
                {
                    db.Projects.Add(project);
                    db.SaveChanges();
                    Console.WriteLine("Adding end succesfully => Commit Transaction");
                }
                catch (Exception)
                {
                    Console.WriteLine("Adding finish unsuccesfully => Rollback Transaction");
                }
            }
        }

        static void ProjectAdderExplicitlyStartTransaction()
        {
            var db = new SoftUniEntities();
            using (var transaction = db.Database.BeginTransaction())
            {
                var firstEmployee = db.Employees.Find(121);
                var lastEmployee = db.Employees.Find(3);
                var project = new Project
                {
                    Name = "DatabaseTeamWork2",
                    StartDate = new DateTime(2015, 2, 15, 0, 0, 0),
                    EndDate = new DateTime(2015, 3, 20, 0, 0, 0),
                    Employees = new Collection<Employee>
                    {
                        firstEmployee,
                        lastEmployee
                    },
                    Description = "TeamWork2"
                };
                try
                {
                    db.Projects.Add(project);
                    db.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("Adding end succesfully => Commit Transaction2");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Adding finish unsuccesfully => Rollback Transaction2");
                }
            }
        }
    }
}