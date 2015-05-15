namespace StoredProcedure
{

    using System;
    using EntityFramework.Data;

    public class StoredProcedure
    {
        public static void Main()
        {
            //First must execute StoredProc.sql to create procedure in DB
            CallStoreProcedure("Gay", "Gilbert");
        }

        public static void CallStoreProcedure(string firstName, string lastName)
        {
            using (var db = new SoftUniEntities())
            {
                var projectCount = db.usp_ProjectsOfEmployee(firstName, lastName).Single();
                Console.WriteLine(string.Format("{0} {1} has {2} projects!", firstName, lastName, projectCount));
            }
        }
    }
}