using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplDemo
{
    class Program
    {
        static int[] numbers =
            {
                1,1,1,
                2,2,2,
                3,3,3,
                4,4,4
            };

        static void Main(string[] args)
        {
            //PlinqDemo();
            //ParallelDemo();
            //TaskDemo();
        }

        static void PlinqDemo()
        {
            // Not executed in parallel
            foreach (var item in numbers.Where(n => n > 1))
                Console.Write(item);

            Console.WriteLine();

            // Executed in parallel
            foreach (var item in numbers.AsParallel().Where(n => n > 1))
                Console.Write(item);

            Console.WriteLine();

            // Executed in parallel (then ordered)
            foreach (var item in numbers.AsParallel().AsOrdered().Where(n => n > 1))
                Console.Write(item);

            Console.WriteLine();
        }

        static void ParallelDemo()
        {
            // A for loop executed in parallel
            Parallel.For(0, 10, i => Console.WriteLine(i));

            // A for each loop executed in parallel
            Parallel.ForEach(numbers, item => Console.WriteLine(item));

            // Parallel execution of several actions
            Parallel.Invoke(
                () => Console.WriteLine("Action 1"),
                () => Console.WriteLine("Action 2"),
                () => Console.WriteLine("Action 3"));
        }

        static void TaskDemo()
        {
            // Exetutes a separate task
            Task.Factory.StartNew(() => Console.WriteLine("Task 0"));

            // Creates a separate task to be executed later
            Task t1 = new Task(() => Console.WriteLine("Task 1"));
            
            // Executes directly after t1 is executed
            Task t2 = t1.ContinueWith(t => Console.WriteLine("Task 2"));
            
            // Start t1 and t2 (will be executed in parallel to the current thread)
            t1.Start();

            // Pause the current thread until t2 is executed
            t2.Wait();

            // Execute a task and retrieve a result
            Task<string> t3 = new Task<string>(() => "Task 3");
            t3.Start();

            // Will call Wait implicitly
            Console.WriteLine(t3.Result);
        }
    }
}
