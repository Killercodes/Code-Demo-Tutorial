using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;
using DemoUtils;

namespace LinqToObjectsDemo
{
    #region Shared classes
    class Person
    {
        public int Id { get; set; }
        public int WorkplaceId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} Name:{1}", Id, Name);
        }
    }

    class Workplace
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} Title:{1}", Id, Title);
        }
    }

    class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Id == y.Id && x.Name == y.Name && x.WorkplaceId == y.WorkplaceId;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Id.GetHashCode() + obj.Name.GetHashCode() + obj.WorkplaceId.GetHashCode();
        }
    }
    #endregion

    class Program
    {
        static List<Person> persons;
        static List<Workplace> workplaces;

        static void Main(string[] args)
        {
            persons = new List<Person>()
            {
                new Person() { Id = 1, Name = "Homer", WorkplaceId = 1 },
                new Person() { Id = 2, Name = "Marge", WorkplaceId = 2 },
                new Person() { Id = 3, Name = "Bart", WorkplaceId = 3 },
                new Person() { Id = 4, Name = "Lisa", WorkplaceId = 3 },
                new Person() { Id = 5, Name = "Maggie", WorkplaceId = 2 }
            };

            workplaces = new List<Workplace>()
            {
                new Workplace() { Id = 1, Title = "Powerplant" },
                new Workplace() { Id = 2, Title = "Home" },
                new Workplace() { Id = 3, Title = "School" }
            };

            // ==================
            // DEFERRED OPERATORS
            // ==================

            //// Projection operators
            //WhereOperator();
            //SelectOperator();
            //SelectManyOperator();

            //// Partitioning operators
            //TakeOperator();
            //TakeWhileOperator();
            //SkipOperator();
            //SkipWhileOperator();

            //// Concatenation operators
            //ConcatOperator();

            //// Ordering operators
            //OrderByOperator();
            //OrderByDescendingOperator();
            //ThenByOperator();
            //ThenByDescendingOperator();
            //ReverseOperator();
            //JoinOperator();
            //GroupJoinOperator();
            //GroupByOperator();

            //// Set operators
            //DistinctOperator();
            //UnionOperator();
            //IntersectOperator();
            //ExceptOperator();

            //// Conversion operators
            //CastOpertator();
            //OfTypeOpertator();
            //AsEnumerableOperator();

            //// Element operators
            //DefaultIfEmptyOperator();

            //// Generation operators
            //RangeOperator();
            //RepeatOperator();
            //EmptyOperator();

            //// =====================
            //// Nondeferred operators
            //// =====================

            //// Conversion operators
            //ToArrayOperator();
            //ToListOperator();
            //ToDictionaryOperator();
            //ToLookupOperator();

            //// Equality operators
            //SequenceEqualOperator();

            //// Element operators
            //FirstOperator();
            //FirstOrDefaultOperator();
            //LastOperator();
            //LastOrDefaultOperator();
            //SingleOperator();
            //SingleOrDefaultOperator();
            //ElementAtOperator();
            //ElementAtOrDefaultOperator();

            //// Quantifier operators
            //AnyOperator();
            //AllOperator();
            //ContainsOperator();

            //// Aggregate operators
            //CountOperator();
            //LongCountOperator();
            //SumOperator();
            //MinOperator();
            //MaxOperator();
            //AverageOperator();
            //AggregateOperator();
        }

        #region Deferred operators
        // ==================
        // Deferred operators
        // ==================

        static void WhereOperator()
        {
            Print.Header();

            // Gets all items where the name is loger than 4 characters
            var q = from p in persons
                    where p.Name.Length > 4
                    select p;

            q.Print();
        }

        static void SelectOperator()
        {
            Print.Header();

            // Gets all persons in the list
            var q = from p in persons
                    select p;

            q.Print();

            Print.Divider("Select an anonymous type");

            var q2 = from p in persons
                     select new
                     {
                         EmployeeId = p.Id,
                         EmployeeName = p.Name,
                         Created = DateTime.Now
                     };

            q2.Print();
        }

        static void SelectManyOperator()
        {
            Print.Header();

            // Gets an array of chars containing the name of each person in the list
            var q = persons.SelectMany(p => p.Name.ToCharArray());

            q.Print();
        }

        static void TakeOperator()
        {
            Print.Header();

            // Gets the first 3 items
            var q = persons.Take(3);

            q.Print();
        }

        static void TakeWhileOperator()
        {
            Print.Header();

            // Gets all items where the name is 5 characters long
            // (until the first non-match is found)
            var q = persons.TakeWhile(p => p.Name.Length == 5);

            q.Print();
        }

        static void SkipOperator()
        {
            Print.Header();

            // Skips the first 3 items
            var q = persons.Skip(3);

            q.Print();
        }

        static void SkipWhileOperator()
        {
            Print.Header();

            // Skips all items as long as the name is 5 characters long
            // (until the first non-match is found)
            var q = persons.SkipWhile(p => p.Name.Length == 5);

            q.Print();
        }

        static void ConcatOperator()
        {
            Print.Header();

            var persons1 = persons.Take(2); // Homer, Marge
            var persons2 = persons.Skip(3); // Lisa, Maggie

            // Gets a list containing both sequences
            var q = persons1.Concat(persons2);

            q.Print();
        }

        static void OrderByOperator()
        {
            Print.Header();

            // Gets all persons and orders them by name in ascending order
            var q = from p in persons
                    orderby p.Name
                    select p;

            q.Print();
        }

        static void OrderByDescendingOperator()
        {
            Print.Header();

            // Gets all persons and orders them by name in descending order
            var q = from p in persons
                    orderby p.Name descending
                    select p;

            q.Print();
        }

        static void ThenByOperator()
        {
            Print.Header();

            // Gets all persons and orders them by
            // #1: Workplace id in ascending order
            // #2: Name in ascending order
            var q = from p in persons
                    orderby p.WorkplaceId, p.Name
                    select p;

            q.Print();
        }

        static void ThenByDescendingOperator()
        {
            Print.Header();

            // Gets all persons and orders them by
            // #1: Workplace id in ascendingorder
            // #2: Name in descending order
            var q = from p in persons
                    orderby p.WorkplaceId, p.Name descending
                    select p;

            q.Print();
        }

        static void ReverseOperator()
        {
            Print.Header();

            // Reverse the list
            persons.Reverse();

            persons.Print();

            // Re-reverse the list
            persons.Reverse();
        }

        static void JoinOperator()
        {
            Print.Header();

            // Gets all persons and their workplace
            var q = from p in persons
                    join w in workplaces on p.WorkplaceId equals w.Id
                    select new
                    {
                        PersonName = p.Name,
                        Workplace = w.Title
                    };

            q.Print();
        }

        static void GroupJoinOperator()
        {
            Print.Header();

            // Gets a list of objects containing the name of each workplace
            // and a group containing their persons
            var q = from w in workplaces
                    join p in persons
                    on w.Id equals p.WorkplaceId into g
                    select new
                    {
                        Workplace = w.Title,
                        Persons = g
                    };

            foreach (var w in q)
            {
                Console.WriteLine(w.Workplace);
                foreach (var pers in w.Persons)
                {
                    Console.WriteLine("\t{0}", pers.Name);
                }
            }
        }

        static void GroupByOperator()
        {
            Print.Header();

            // Gets the workplace id and a number indicating how many persons
            // each workplace contains
            var q = from p in persons
                    group p by p.WorkplaceId into theGroup
                    select new
                    {
                        WorkplaceId = theGroup.Key,
                        Count = theGroup.Count()
                    };

            q.Print();

            Print.Divider("Including the title of the workplace");

            // Gets the workplace title and a number indicating how many persons
            // each workplace contains
            var q2 = from p in persons
                     group p by p.WorkplaceId into theGroup
                     join w in workplaces on theGroup.Key equals w.Id
                     select new
                     {
                         WorkplaceTitle = w.Title,
                         Count = theGroup.Count()
                     };

            q2.Print();
        }

        static void DistinctOperator()
        {
            Print.Header();

            // Add a new person to the list of persons (it now has two instances of Bart)
            persons.Add(persons[2]);

            // Delete all duplicate instances from the list (leaving just one instance of Bart)
            persons = persons.Distinct().ToList();

            persons.Print();
        }

        static void UnionOperator()
        {
            Print.Header();

            var persons1 = persons.Take(3); // Homer, Marge, Bart
            var persons2 = persons.Skip(2); // Bart, Lisa, Maggie

            // Gets all items but with no duplicates
            var q = persons1.Union(persons2);

            q.Print();
        }

        static void IntersectOperator()
        {
            Print.Header();

            var persons1 = persons.Take(3); // Homer, Marge, Bart
            var persons2 = persons.Skip(2); // Bart, Lisa, Maggie

            // Gets all items found in both sequences
            var q = persons1.Intersect(persons2);

            q.Print();
        }

        static void ExceptOperator()
        {
            Print.Header();

            var persons1 = persons.Take(3); // Homer, Marge, Bart
            var persons2 = persons.Skip(2); // Bart, Lisa, Maggie

            // Gets all items from the first sequences that is NOT present in the second sequences
            var q = persons1.Except(persons2);

            q.Print();
        }

        static void CastOpertator()
        {
            Print.Header();

            ArrayList legacyList = new ArrayList();
            legacyList.Add(persons[2]);
            legacyList.Add(persons[4]);
            //legacyList.Add(workplaces[1]); // Will cast an exception

            // Converts the legacy collection into a sequence capable of handling
            // all the LINQ to Objects operators (throws an exception if cast fails)
            var q = legacyList.Cast<Person>().Where(p => p.Name.StartsWith("M"));

            q.Print();
        }

        static void OfTypeOpertator()
        {
            Print.Header();

            ArrayList legacyList = new ArrayList();
            legacyList.Add(persons[2]);
            legacyList.Add(persons[4]);
            legacyList.Add(workplaces[1]); // Will be filtered out

            // Converts the legacy collection into a sequence capable of handling
            // all the LINQ to Objects operators (will NOT throws an exception if cast fails)
            var q = legacyList.OfType<Person>().Where(p => p.Name.StartsWith("M"));

            q.Print();
        }

        static void AsEnumerableOperator()
        {
            Print.Header();

            //// Create an instance of the LINQ to SQL data context
            //NorthwinddataContext db = new NorthwinddataContext();

            //// Gets all customers in the DB
            //var custs = from c in db.Customers;

            //// Calls AsEnumerable in order to convert the IQueryable<Customer> to an
            //// IEnumerable<Customer> (in order to use the LINQ to Object operators)
            //custs.AsEnumerable().Reverse();
        }

        static void DefaultIfEmptyOperator()
        {
            Print.Header();

            // Since no elements exist in the sequence - a new sequence containing the
            // Default wlwmwnt is returned
            var q = persons.Take(0).DefaultIfEmpty(new Person() { Name = "DefaultName" });

            q.Print();
        }

        static void RangeOperator()
        {
            Print.Header();

            // Generates an enumerable of int containing the numbers 1, 2, 3, 4, 5
            var q = Enumerable.Range(1, 5);

            q.Print();
        }

        static void RepeatOperator()
        {
            Print.Header();

            // Generates a sequence containing 5 copies of the specified object
            var q = Enumerable.Repeat<string>("RepeatMe", 5);

            q.Print();
        }

        static void EmptyOperator()
        {
            Print.Header();

            // Generates an empty enumerable of the specified type
            var q = Enumerable.Empty<Person>();

            q.Print();
        }
        #endregion

        #region Nondeferred operators
        // =====================
        // Nondeferred operators
        // =====================

        static void ToArrayOperator()
        {
            Print.Header();

            // Gets all persons in the list
            var q = from p in persons
                    select p;

            // Gets an array of type Person
            Person[] personArray = q.ToArray();

            // Add a new person to the persons list
            Person newPerson = new Person() { Id = 6, Name = "Snowball", WorkplaceId = 2 };
            persons.Add(newPerson);

            // Iterate over all the persons
            persons.Print();

            Print.Divider("And the array...");

            // Iterate over the person array
            personArray.Print();

            // Remove the new person to the persons list
            persons.Remove(newPerson);
        }

        static void ToListOperator()
        {
            Print.Header();

            // Gets all persons in the list
            var q = from p in persons
                    select p;

            // Gets a list of type Person
            List<Person> personList = q.ToList();

            // Add a new person to the persons list
            Person newPerson = new Person() { Id = 6, Name = "Snowball", WorkplaceId = 2 };
            persons.Add(newPerson);

            // Iterate over all the persons
            persons.Print();

            Print.Divider("And the list...");

            // Iterate over the person array
            personList.Print();

            // Remove the new person to the persons list
            persons.Remove(newPerson);
        }

        static void ToDictionaryOperator()
        {
            Print.Header();

            // Gets all persons in the list
            var q = from p in persons
                    select p;

            // Gets a dictionary of type int and Person
            Dictionary<int, Person> personDictionary = q.ToDictionary(p => p.Id);

            Person person = personDictionary[2];
            Console.WriteLine(person);

            Print.Divider("A little more advanced");

            // Gets a dictionary of type int and string
            Dictionary<int, string> stringDictionary = q.ToDictionary(p => p.Id,
                p => string.Format("Person:{0} ({1})", p.Name, p.WorkplaceId));

            string personString = stringDictionary[2];
            Console.WriteLine(personString);
        }

        static void ToLookupOperator()
        {
            Print.Header();

            // Gets all persons in the list
            var q = from p in persons
                    select p;

            // Gets a dictionary of type int and Person
            ILookup<int, Person> personLookup = q.ToLookup(p => p.WorkplaceId);

            IEnumerable<Person> personEnumerable = personLookup[2];
            personEnumerable.Print();

            Print.Divider("A little more advanced");

            // Gets a dictionary of type int and string
            ILookup<int, string> stringLookup = q.ToLookup(p => p.WorkplaceId,
                p => string.Format("Person:{0} ({1})", p.Name, p.WorkplaceId));

            IEnumerable<string> personStrings = stringLookup[2];

            personStrings.Print();
        }

        static void SequenceEqualOperator()
        {
            Print.Header();

            // Gets all items in the person list
            IEnumerable<Person> persons2 = persons.Take(persons.Count);
            Console.WriteLine(persons2.SequenceEqual(persons));

            Print.Divider("All but one");

            // Gets all but one of the items in the person list
            IEnumerable<Person> persons3 = persons.Take(persons.Count - 1);
            Console.WriteLine(persons3.SequenceEqual(persons));

            Print.Divider("Using deep copied items");

            // Make deep copies of all persons in the person list to a new list
            List<Person> persons4 = new List<Person>();
            foreach (Person person in persons)
            {
                persons4.Add(new Person()
                {
                    Id = person.Id,
                    Name = person.Name,
                    WorkplaceId = person.WorkplaceId
                });
            }

            // Call without a comparer (will be false since addresses will not matched)
            Console.WriteLine(persons4.SequenceEqual(persons));

            Print.Divider("With a comparer");

            // Call with a comparer (will be true since our custom comparer matches the elements)
            Console.WriteLine(persons4.SequenceEqual(persons, new PersonComparer()));

            Print.Divider("Updated");

            // Update an item in the new person list
            persons4[2].Name += " Simpsons";

            // Call with a comparer (will fail since our new person list has been updated)
            Console.WriteLine(persons4.SequenceEqual(persons, new PersonComparer()));
        }

        static void FirstOperator()
        {
            Print.Header();

            // Gets the first person with a workplace id of 3 (throws an exeption if not found)
            Person person1 = persons.First(p => p.WorkplaceId == 3);
            Console.WriteLine(person1);
        }

        static void FirstOrDefaultOperator()
        {
            Print.Header();

            // Gets the first person with a workplace id of 4 (or null if not found)
            Person person2 = persons.FirstOrDefault(p => p.WorkplaceId == 4);
            if (person2 != null)
                Console.WriteLine(person2);
        }

        static void LastOperator()
        {
            Print.Header();

            // Gets the last person with a workplace id of 3 (throws an exeption if not found)
            Person person1 = persons.Last(p => p.WorkplaceId == 3);
            Console.WriteLine(person1);
        }

        static void LastOrDefaultOperator()
        {
            Print.Header();

            // Gets the last person with a workplace id of 4 (or null if not found)
            Person person2 = persons.LastOrDefault(p => p.WorkplaceId == 4);
            if (person2 != null)
                Console.WriteLine(person2);
        }

        static void SingleOperator()
        {
            Print.Header();

            // Gets the person with the specified name (throws an exception if none is found)
            Person person1 = persons.Single(p => p.Name == "Marge");
            Console.WriteLine(person1);
        }

        static void SingleOrDefaultOperator()
        {
            Print.Header();

            // Gets the person with the specified name (throws an exception if none is found)
            Person person2 = persons.SingleOrDefault(p => p.Name == "Peter Griffin");
            if (person2 != null)
                Console.WriteLine(person2);
        }

        static void ElementAtOperator()
        {
            Print.Header();

            // Gets the second person in the list (throws an exeption if not found)
            Person person1 = persons.ElementAt(1);
            Console.WriteLine(person1);
        }

        static void ElementAtOrDefaultOperator()
        {
            Print.Header();

            // Gets the sixth person in the list (or null if not found)
            Person person2 = persons.ElementAtOrDefault(5);
            if (person2 != null)
                Console.WriteLine(person2);
        }

        static void AnyOperator()
        {
            Print.Header();

            // Will be true if the list contains any person starting with the letter "M"
            Console.WriteLine(persons.Any(p => p.Name.StartsWith("M")));
        }

        static void AllOperator()
        {
            Print.Header();

            // Will be true if the name of all entries in the list start with the letter "M"
            Console.WriteLine(persons.All(p => p.Name.StartsWith("M")));
        }

        static void ContainsOperator()
        {
            Print.Header();

            // Create a new person
            Person homer = new Person() { Id = 1, Name = "Homer", WorkplaceId = 1 };
            Console.WriteLine(persons.Contains(homer, new PersonComparer()));

            // Create a new person
            Person snowball = new Person() { Id = 6, Name = "Snowball", WorkplaceId = 2 };
            Console.WriteLine(persons.Contains(snowball, new PersonComparer()));
        }

        static void CountOperator()
        {
            Print.Header();

            // Gets the number of persons whos names starts with the letter "M"
            Console.WriteLine(persons.Count(p => p.Name.StartsWith("M")));
        }

        static void LongCountOperator()
        {
            Print.Header();

            // Gets the number of persons whos names starts with the letter "M"
            Console.WriteLine(persons.LongCount(p => p.Name.StartsWith("M")));
        }

        static void SumOperator()
        {
            Print.Header();

            // Gets the total sum of the person ids
            Console.WriteLine(persons.Sum(p => p.Id));
        }

        static void MinOperator()
        {
            Print.Header();

            // Gets the lowest id found in the list
            Console.WriteLine(persons.Min(p => p.Id));
        }

        static void MaxOperator()
        {
            Print.Header();

            // Gets the highest id found in the list
            Console.WriteLine(persons.Max(p => p.Id));
        }

        static void AverageOperator()
        {
            Print.Header();

            // Gets the average id found in the list
            Console.WriteLine(persons.Average(p => p.Id));
        }

        static void AggregateOperator()
        {
            Print.Header();

            // Generate a range of integers (1, 2, 3, 4, 5)
            IEnumerable<int> range = Enumerable.Range(1, 5);

            // Calculate the factorial (1 * 2 * 3 * 4 * 5)
            int factorial = range.Aggregate((i1, i2) => i1 * i2);

            Console.WriteLine(factorial);
        }
        #endregion
    }
}
