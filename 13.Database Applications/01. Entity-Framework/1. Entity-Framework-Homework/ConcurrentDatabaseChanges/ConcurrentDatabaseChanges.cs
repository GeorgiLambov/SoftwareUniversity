using System;
using System.Linq;

namespace ConcurrentDatabaseChanges
{
    using EntityFramework.Data;

    public class ConcurrentDatabaseChanges
    {
        public static void Main()
        {
            var db = new SoftUniEntities();
            var concurrentDB = new SoftUniEntities();

            var person = db.Employees.FirstOrDefault(e => e.EmployeeID == 1);
            var concurrentPerson = concurrentDB.Employees.FirstOrDefault(e => e.EmployeeID == 1);

            person.LastName = "First";
            concurrentPerson.LastName = "Second";

            db.SaveChanges();
            concurrentDB.SaveChanges();
        }
    }
}
