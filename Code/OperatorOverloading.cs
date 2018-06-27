using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorOverloadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // The unary ++/-- operator for Time
            Time t1 = new Time(10);
            t1++;
            Console.WriteLine(t1.Seconds); // 11
            t1--;
            Console.WriteLine(t1.Seconds); // 10

            // The binary + operator for Time and Time
            Time t2 = t1 + new Time(20);
            Console.WriteLine(t2.Seconds); // 30 (20 + 10)

            // The binary + operator for Time and Int32
            Time t3 = t2 + 10;
            Console.WriteLine(t3.Seconds); // 40 (30 + 10)

            // The binary == operator for Time and Time
            Time t4 = new Time(40);
            if (t4 == new Time(t4.Seconds)) // true (40 == 40)
                Console.WriteLine("Same");
            else
                Console.WriteLine("Not same");

            // Implicit convertion           
            Time t5 = 50;
            Console.WriteLine(t5.Seconds); // 50
            int i = t5;
            Console.WriteLine(i); // 50
            
            // Explicit convertion           
            Time t6 = (Time)60;
            Console.WriteLine(t6.Seconds); // 60
            int j = (int)t6;
            Console.WriteLine(j); // 50
        }
    }

    struct Time
    {
        public int Seconds;

        public Time(int seconds)
        {
            Seconds = seconds;
        }

        #region Unary operators for Time
        // The unary ++ operator for Time
        public static Time operator ++(Time lhs)
        {
            lhs.Seconds++;
            return new Time(lhs.Seconds);
        }

        // The unary -- operator for Time
        public static Time operator --(Time lhs)
        {
            lhs.Seconds--;
            return new Time(lhs.Seconds);
        }
        #endregion

        #region Symmetric implementation of the addition operator (Time and Time)
        // The binary + operator for Time and Time
        public static Time operator +(Time lhs, Time rhs)
        {
            return new Time(lhs.Seconds + rhs.Seconds);
        }
        #endregion

        #region Symmetric implementation of the addition (Time and Int32) operator
        // The binary + operator for Time and Int32
        public static Time operator +(Time lhs, int rhs)
        {
            return new Time(lhs.Seconds + rhs);
        }

        // The binary + operator for Int32 and Time
        public static Time operator +(int lhs, Time rhs)
        {
            return rhs + lhs;
        }
        #endregion

        #region Symmetric implementation of the equals operator
        // The binary == operator for Time and Time
        public static bool operator ==(Time lhs, Time rhs)
        {
            return lhs.Seconds == rhs.Seconds;
        }

        // The binary != operator for Time and Time
        public static bool operator !=(Time lhs, Time rhs)
        {
            return lhs.Seconds != rhs.Seconds;
        }

        // When overloading the == and != operators, one should also override Object.Equals(Object obj)
        // Used as an alternative to the == operator
        public override bool Equals(object obj)
        {
            if (obj is Time)
                return Seconds == ((Time)obj).Seconds;
            else
                return base.Equals(obj);
        }

        // When overloading the == and != operators, one should also override Object.GetHashCode()
        // Used when comparing equality between objects stored in struchtures such as a hash table
        public override int GetHashCode()
        {
            return Seconds.GetHashCode();
        }
        #endregion

        #region Implicit conversion operatos
        // Implicit convertion from Time to Int32
        public static implicit operator int (Time from)
        {
            return from.Seconds;
        }

        // Implicit convertion from Int32 to Time
        public static implicit operator Time(int from)
        {
            return new Time(from);
        }
        #endregion

        #region Explicit conversion operatos
        // Explicit operators only compiles if no implicit operators exist for the type
        //// Explicit convertion from Time to Int32
        //public static explicit operator int(Time from)
        //{
        //    return from.Seconds;
        //}

        //// Explicit convertion from Int32 to Time
        //public static explicit operator Time(int from)
        //{
        //    return new Time(from);
        //}
        #endregion
    }
}
