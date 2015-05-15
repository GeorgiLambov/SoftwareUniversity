namespace CreateDBContext
{
    using System;
    using EntityFramework.Data;

    public class CreateDBContext
    {
        public static void Main()
        {
            using (var db = new SoftUniEntities())
            {
                foreach (var emp in db.Employees)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName);
                }
            }
        }
    }
}
