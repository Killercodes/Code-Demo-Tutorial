using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Dynamic;

namespace DynamicDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            object person = GetPersonInstance();
            
            ReflectionDemoLegacy(person);
            ReflectionDemoDynamic(person);
        }

        #region Helper methods
        static object GetPersonInstance()
        {
            // Load the plugin assembly
            Assembly assembly = Assembly.LoadFile(
                Environment.CurrentDirectory + @"\MyPlugin.dll");

            // Get the person type
            Type t = assembly.GetType("MyPlugin.Person");

            // Get the constructor
            ConstructorInfo c = t.GetConstructor(
                new Type[] { typeof(string), typeof(int) });

            // Call constructor
            return c.Invoke(new object[] { "adam", 13 });
        }
        #endregion

        static void ReflectionDemoLegacy(object person)
        {
            // Get the type (MyPlugin.Person)
            Type t = person.GetType();

            // Get the Age property
            PropertyInfo p = t.GetProperty("Age");

            // Set the Age property
            p.SetValue(person, 32, null);

            // Get the ToString method
            MethodInfo m = t.GetMethod("ToString", new Type[] { });

            // Call the ToString method
            Console.WriteLine((string)m.Invoke(person, null));
        }

        static void ReflectionDemoDynamic(dynamic person)
        {
            // Set the Age property
            person.Age = 32;

            // Call the ToString method
            Console.WriteLine(person.ToString());
        }
    }
}
