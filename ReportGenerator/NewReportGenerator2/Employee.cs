namespace NewReportGenerator
{
    public class Employee
    {

        public Employee(string name = "", uint salary = 0)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; private set; }
        public uint Salary { get; private set; }
    }
}