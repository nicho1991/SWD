using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewReportGenerator
{

    public class NameFirstGenerator :  Ireports
    {
        private EmployeeDB db;
        public NameFirstGenerator(EmployeeDB dbParam) : base()
        {
            if (dbParam == null) throw new ArgumentNullException("employeeDb");
            db = dbParam;
        }

        public virtual void print()
        {
            Employee next;
            Console.WriteLine("Name-first report");
            while (true)
            {
                next = db.GetNextEmployee();
                if (next == null)
                    break;
                Console.WriteLine("------------------");
                Console.WriteLine("Name: {0}", next.Name);
                Console.WriteLine("Salary: {0}", next.Salary);
                Console.WriteLine("------------------");
            }
            done();

        }

        public void done()
        {
            db.Reset();
        }
    }

    public class salaryFirstGenerator :  NameFirstGenerator
    {
        private EmployeeDB db;
        public override void print()
        {
            Employee next;
            Console.WriteLine("Salary-first report");
            while (true)
            {
                next = db.GetNextEmployee();
                if (next == null)
                    break;
                Console.WriteLine("------------------");
                Console.WriteLine("Salary: {0}", next.Salary);
                Console.WriteLine("Name: {0}", next.Name);
                Console.WriteLine("------------------");
            }
            done();
        }

        public salaryFirstGenerator(EmployeeDB dbParam) : base(dbParam)
        {
            if (dbParam == null) throw new ArgumentNullException("employeeDb");
            db = dbParam;
        }
    }

    interface Ireports
    {
        void print();
        void done();

    }
}
