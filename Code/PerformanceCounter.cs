using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace PerformanceCounterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateNewCounter();
            //MonitorCounter();
            //DeletePerformanceCounter();
        }

        static void CreateNewCounter()
        {
            // Create the counters and set their properties.
            CounterCreationData myCounter =
               new CounterCreationData();
            
            myCounter.CounterName = "My Counter";
            myCounter.CounterHelp = "An example counter";
            myCounter.CounterType = PerformanceCounterType.NumberOfItems64;

            // Create a collection of type CounterCreationDataCollection.
            CounterCreationDataCollection counterDataCollection =
               new CounterCreationDataCollection();

            // Add counters to the collection.
            counterDataCollection.Add(myCounter);
            
            // Create the category and pass the collection to it.
            PerformanceCounterCategory.Create("My Counter Category", "An example category",
                PerformanceCounterCategoryType.SingleInstance, counterDataCollection);
        }

        static void MonitorCounter()
        {
            bool readOnly = false;

            PerformanceCounter counter =
                new PerformanceCounter("My Counter Category", "My Counter", readOnly);

            for (int i = 0; i < 10; i++)
            {
                counter.Increment();

                float value = counter.NextValue();

                Console.WriteLine("Value: {0}", value);
                Thread.Sleep(1000);
            }
        }

        static void DeletePerformanceCounter()
        {
            // Delete an entire category of performance counters
            if (PerformanceCounterCategory.Exists("My Counter Category"))
                PerformanceCounterCategory.Delete("My Counter Category");
        }
    }
}
