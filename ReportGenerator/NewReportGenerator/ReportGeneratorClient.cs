using System;

namespace NewReportGenerator
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000));
            db.AddEmployee(new Employee("Berit", 2000));
            db.AddEmployee(new Employee("Christel", 1000));

            Ireports reportGenerator = new NameFirstGenerator(db);

            // Create a default (name-first) report
            reportGenerator.print();

            Console.WriteLine("");
            Console.WriteLine("");

            // Create a salary-first report
            
            reportGenerator = new salaryFirstGenerator(db);
            reportGenerator.print();
        }
    }
}