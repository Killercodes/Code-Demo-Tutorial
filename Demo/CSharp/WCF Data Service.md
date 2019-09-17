# WCF Odata Service 

This is a sample for a WCF Data service, it supports querying with Odata protocols


```csharp
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebServices
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    public class ExampleDataContext
    {
        public IQueryable<Employee> Employees 
        {
            get
            {
                return new List<Employee>()
                {
                    new Employee() { ID = 1, Name = "Steve",Salary = 6000},
                    new Employee() { ID = 2, Name = "Dave",Salary = 5000},
                    new Employee() { ID = 3, Name = "Bruce",Salary = 4000},
                    new Employee() { ID = 4, Name = "Json",Salary = 3000},
                    new Employee() { ID = 5, Name = "Brad",Salary = 2000},
                    new Employee() { ID = 6, Name = "Arnold",Salary = 1000}
                }.AsQueryable();
            }
        }
    }

    public class EmployeeDataService : DataService<ExampleDataContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Employees", EntitySetRights.All|EntitySetRights.ReadMultiple|EntitySetRights.ReadSingle);
            config.DataServiceBehavior.AcceptCountRequests = true;
            config.DataServiceBehavior.AcceptProjectionRequests = true;
            config.DataServiceBehavior.AcceptReplaceFunctionInQuery = true;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.UseVerboseErrors = true;             
        }        
    }
}
```
