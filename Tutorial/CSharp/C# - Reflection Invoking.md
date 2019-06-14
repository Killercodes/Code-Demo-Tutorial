# C# - Reflection Invoking
One nice thing about C# is that you can be holding a string in your hand, and get your fingers on the method or property that is actually represented by that string - using Reflection and Invoke. This is not unique to C# by any means, and in fact in a number of other languages it is a lot easier to do (such as PHP), but it is there and you can use it. But one thing to remember is that Invoke is a costly operation - you don't want to be doing it when you don't have to be.
Recently, I wrote a piece of code that had access to some method attributes, and needed to find the correct method to call on an object based on those attributes. Essentially, I wanted to be able to add and remove "abilities" (other methods) to the object without needing to modify the code that is calling these methods. And in my initial iteration of the code, I ended up calling Invoke a lot. And it was slow. So I took a look at the code, and came up with a way around this problem, but while still using reflection.
Here is a very simplistic representation of the type of action I was performing:
```cs
using System;
using System.Reflection;

namespace SillyReflection
{
  class Program
  {
    static void Main(string[] args)
    {
      MyTestObject obj = new MyTestObject();

      MethodInfo mi = typeof(MyTestObject).GetMethod("Increment");

      for(int i=0; i<5000000; i++)
        mi.Invoke(obj, null);
    }
  }

  public class MyTestObject
  {
    private int _counter = 0;

    public void Increment()
    {
      _counter++;
    }
  }
}
```

This code is slow, taking just under 17 seconds to complete on my computer - compared to 0.1 seconds to complete if the Increment method was called directly. Granted, the above code is kind of silly (to put it lightly) - but there are situations where its equivalent can arise in a much more complicated manner.
Now, it is true that in my situation there is probably a way to get by without ever using Invoke at all - but the particular paradigm I was using lent itself to some nice clean looking code. So I wanted to preserve that if possible. And one of the solutions I came up with was not to Invoke the method I actually wanted to call, but to instead Invoke a thunk. Essentially, a method that returns a delegate representing the actual method that I wanted to call. And once I had that delegate in my hands, I would store it, and anytime I needed to hit against that method again I would use the delegate instead of Invoking against the object. This meant that I only needed to do an Invoke call once per method, instead of once per call.
Here is what the above code looks like when modified to work in this fashion:
```cs
using System;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTestObject obj = new MyTestObject();

            MethodInfo mi = typeof(MyTestObject).GetMethod("GetIncDelegate");

            NoArgDelegate del = (NoArgDelegate)mi.Invoke(obj, null);
            for (int i = 0; i < 5000000; i++)
                del();
        }
    }

    public delegate void NoArgDelegate();

    public class MyTestObject
    {
        private int _counter = 0;

        public void Increment()
        {
            _counter++;
        }

        public NoArgDelegate GetIncDelegate()
        {
            return new NoArgDelegate(Increment);
        }
    }
}
```


In this case, performance is almost equivalent to calling the method directly - 110 milliseconds vs. 100 milliseconds (and a difference of 10 milliseconds here is essentially meaningless). This is because we are only doing 1 Invoke call instead of 5 million, and calling a delegate is just ever so slightly more expensive then a regular method (or so I have read).
Here is all the code together complete with timing stuff - you should be able to copy this into Visual Studio and play around for yourself:
```cs
using System;
using System.Reflection;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      long ticks = Environment.TickCount;
      MyTestObject obj = new MyTestObject();
      for (int i = 0; i < 5000000; i++)
        obj.Increment();
      Console.WriteLine(Environment.TickCount - ticks);

      ticks = Environment.TickCount;
      obj = new MyTestObject();
      MethodInfo mi = typeof(MyTestObject).GetMethod("Increment");
      for (int i = 0; i < 5000000; i++)
        mi.Invoke(obj, null);
      Console.WriteLine(Environment.TickCount - ticks);

      ticks = Environment.TickCount;
      obj = new MyTestObject();
      mi = typeof(MyTestObject).GetMethod("GetIncDelegate");
      NoArgDelegate del = (NoArgDelegate)mi.Invoke(obj, null);
      for (int i = 0; i < 5000000; i++)
        del();
      Console.WriteLine(Environment.TickCount - ticks);

      Console.Read();
    }
  }

  public delegate void NoArgDelegate();

  public class MyTestObject
  {
    private int _counter = 0;

    public void Increment()
    {
      _counter++;
    }

    public NoArgDelegate GetIncDelegate()
    {
      return new NoArgDelegate(Increment);
    }
  }
}
```

And so there you go - don't go crazy using Invoke. Which is not to say avoid it altogether - besides the fact that in some situations you are required to use it, it (and other Reflection stuff) enable us to write some pretty cool code. Just remember that there are performance costs here, and balance that against what you are trying to do.

