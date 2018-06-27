using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reference type example
            Person p = new Person() { Name="Homer", Age=45 };
            ModifyRefType(p);
            Console.WriteLine("Name:'{0}' Age:{1}", p.Name, p.Age);

            // Value type example
            int i = 10;
            ModifyValueType(i);
            Console.WriteLine("i:{0}", i);
        }

        static void ModifyRefType(Person value)
        {
            value.Name += " Simpson";
            value.Age += 1;
        }

        static void ModifyValueType(int value)
        {
            value += 1;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
