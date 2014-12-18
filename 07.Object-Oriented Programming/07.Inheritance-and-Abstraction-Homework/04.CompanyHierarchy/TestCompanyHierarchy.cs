using System;
using Company.Data;

namespace CompanyHierarchy
{
    public class TestCompanyHierarchy
    {
        private static void Main()
        {

            Projects opera = new Projects(
                "Opera Spy",
                new DateTime(2014, 2, 23),
                "Script to periodically take the loaded URLs in the opened windows and tabs of Opera browser and send them by email",
                ProjectState.closed
                );

            IProjects hospitalTokuda = new Projects(
                "Tokuda Care",
                new DateTime(2014, 5, 15),
                "Patient management system for Tokuda Hospital",
                ProjectState.open);


        }
    }
}