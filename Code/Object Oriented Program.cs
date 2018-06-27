using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OODemo
{
    class UnmanagedHandler : IDisposable
    {
        bool isDisposed;

        ~UnmanagedHandler()
        {
            Dispose();
        }

        public void Open()
        {
            // Open unmanaged resource here
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                // Close unmanaged resources here

                isDisposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }

    // --- Inheritance ---
    // --- Sealed keyword ---
    public sealed class SalesPerson : Employee
    {
        int totalSales;

        // --- Inherited costructors ---
        public SalesPerson(string name, int salary, int totalSales)
            : base(name, salary)
        {
            this.totalSales = totalSales;
        }

        // --- Overriding #2 ---
        public override void GiveRaise()
        {
            salary += Convert.ToInt32(0.15 * totalSales);
        }
    }

    class Company
    {
        // --- Delegates ---
        public delegate void MyDelegate(string employeeName);

        // --- Events ---
        public event MyDelegate TopSalaryReached;

        // --- Polymorphism ---
        public void RaiseEmployeeWages(Employee employee)
        {
            employee.GiveRaise();

            if (employee.Salary > 45000)
            {
                if (TopSalaryReached != null)
                    TopSalaryReached(employee.Name);
            }
        }
    }

    // --- Classes ---
    public class Employee
    {
        // --- Fields ---
        string name;
        protected int salary;
        static int totalCount;

        // --- Constructors ---
        public Employee(string name, int salary)
        {
            this.name = name;
            this.salary = salary;
            totalCount++;
        }

        // --- Destructors ---
        ~Employee()
        {
            totalCount--;
        }

        // --- Overriding #1 ---
        public override string ToString()
        {
            return string.Format("Name: {0}, Salary: {1}", Name, Salary);
        }

        // --- Instance methods ---
        public virtual void GiveRaise()
        {
            salary += 100;
        }

        // --- Overloading ---
        public void GiveRaise(int newSalary)
        {
            salary = newSalary;
        }

        // --- Properties ---
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Salary
        {
            // --- Attributes ---
            [DebuggerHidden]
            get { return salary; }
        }

        // --- Static members ---
        public static int TotalCount
        {
            get { return totalCount; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OODemo1();
            //OODemo2();
        }

        static void OODemo1()
        {
            // --- Instantiation ---
            Employee employee1 = new Employee("Bosse", 20000);
            Employee employee2 = new Employee("Eva", 25000);

            // Call instance method
            employee2.GiveRaise();

            // Dump employees
            Console.WriteLine(employee1);
            Console.WriteLine(employee2);

            // Dump the static employee counter
            Console.WriteLine("Total employees: {0}", Employee.TotalCount);

            // --- Dispose pattern ---
            UnmanagedHandler o = new UnmanagedHandler();
            o.Open();
            //o.Dispose();
        }

        static void OODemo2()
        {
            Employee bosse = new Employee("Bosse", 25000);
            Employee ewa = new SalesPerson("Ewa", 25000, 50000);

            Company company = new Company();
            company.TopSalaryReached += company_TopSalaryReached;

            for (int i = 0; i < 5; i++)
            {
                // Give raise to employees (polymorphically)
                company.RaiseEmployeeWages(bosse);
                company.RaiseEmployeeWages(ewa);

                // Display employee info
                Console.WriteLine(bosse);
                Console.WriteLine(ewa);
                Console.WriteLine();

                // Pause thread for readability
                Thread.Sleep(1000);
            }
        }

        static void company_TopSalaryReached(string employeeName)
        {
            Console.WriteLine("{0} earns too much cash - sending mail to the CEO...", employeeName);
            // Send mail to CEO
        }
    }
}
