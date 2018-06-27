using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VarianceDemo
{
    class Program
    {
        static List<Person> people;
        static List<Employee> employees;

        static void Main(string[] args)
        {
            people = new List<Person>
            {
                new Person { Name = "Person 1" },
                new Person { Name = "Person 2" },
                new Person { Name = "Person 3" }
            };

            employees = new List<Employee>
            {
                new Employee { Name = "Employee 1", HireDate = new DateTime(2001, 1, 1) },
                new Employee { Name = "Employee 2", HireDate = new DateTime(2001, 1, 1) },
                new Employee { Name = "Employee 3", HireDate = new DateTime(2001, 1, 1) }
            };

            //CovarianceDemo();
            //ContravarianceDemo();
        }

        static void PrintPersons(IEnumerable<Person> people)
        {
            foreach (var item in people)
                Console.WriteLine(item);
        }

        #region Covariance
        static void CovarianceDemo()
        {
            // Pass a collection of type Person (the expected type - always worked)
            PrintPersons(people);

            // Covariance: Passing a more derived type (Employee) in place of a less derived type (Person)
            // This call would fail in C# 3.0
            // This covariant call is made possible due to the "out" keyword added to IEnumerable<T> (IEnumerable<out T>)
            PrintPersons(employees);
        }
        #endregion

        #region Contravariance
        static void ContravarianceDemo()
        {
            PrintPersons(
                // Pass a comparer of type Employee (the expected type - always worked)
                employees.Distinct(new EmployeeComparer())
                );

            PrintPersons(
                // Contravariance: Passing a less derived type (Person) in place of a more derived type (Employee)
                // This call would fail in C# 3.0
                // This contravariant call is made possible due to the "in" keyword added to IEqualityComparer<T> (IEqualityComparer<in T>)
                employees.Distinct(new PersonComparer())
                );
        }
        #endregion
    }

    #region Shared classes
    class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0}", Name);
        }
    }

    class Employee : Person
    {
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return string.Concat(base.ToString(), ", ",
                string.Format("HireDate:{0}", HireDate));
        }
    }

    class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.Name == y.Name && x.HireDate == y.HireDate;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode() + obj.HireDate.GetHashCode();
        }
    }

    class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    #endregion
}
