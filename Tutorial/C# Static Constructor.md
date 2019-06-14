# C# - Static Constructors

I'm going to guess that pretty much everyone who reads this blog knows about constructors and how they work. And I bet everyone knows about static variables and functions as well. But did you know that there is such a thing as a static constructor in C#? Yup, a static constructor. And that's what we are going to take a look at today.
The concept behind them is actually pretty simple.
> A static constructor in C# is a chunk of code that is executed right after all the static variables for a class are initialized. You declare it similar to the way you declare a regular constructor (except that it is declared static). So in many ways, they act exactly like a class constructor, except for statics. 
Don't worry, if that didn't make perfect sense, there are plenty of examples to come.

Lets take a look at a really simple class with a static constructor:
```csharp
public class StaticTest
{
  public static int SomeVarA;

  static StaticTest()
  {
    SomeVarA = 1; 
  }
}
```
Granted, that is a pretty silly constructor, since I could have initialized SomeVarA right up in the field declaration. But it gets the point across. The static constructor has to follow all the rules of a normal static function, i.e., no this keyword and things like that. In addition, it doesn't have a private/public/protected modifier. This is because those modifiers don't make sense in this context - no one can ever directly call this function. Also, it can't take any arguments - again, because no one ever actually directly calls this function.
If no one ever directly calls this function, when does it actually get run? Well, that is a good question. Essentially, the first time someone touches the class, by creating an instance, or by touching some static variable or function, the static constructor gets run. We can actually see this in action:

```csharp
public class Program
{
  static void Main(string[] args)
  {
    Debug.WriteLine("Start Time: " + Environment.TickCount);
    Debug.WriteLine("StaticTest Static Field At: " + StaticTest.AFieldToAccess);
  }
}

public class StaticTest
{
  public static long AFieldToAccess = Environment.TickCount;

  static StaticTest()
  {
    Debug.WriteLine("StaticTest Static Constructor At: " + Environment.TickCount);
  }
}
```
Running this code produces the following output (or something similar, depending on your current computer time):
```
Start Time: 167393939
StaticTest Static Constructor At: 167393959
StaticTest Static Field At: 167393959
```
So we hit the start time first, as expected, and then because we are hitting on theStaticTest class for the first time (we are trying to access AFieldToAccess), the static constructor runs.
Creating an instance of StaticTest would have the same affect:

```csharp
public class Program
{
  static void Main(string[] args)
  {
    Debug.WriteLine("Start Time: " + Environment.TickCount);
    new StaticTest();
    new StaticTest();
    new StaticTest();
  }
}

public class StaticTest
{
  public static long AFieldToAccess = Environment.TickCount;

  static StaticTest()
  {
    Debug.WriteLine("StaticTest Static Constructor At: " + Environment.TickCount);
  }

  public StaticTest()
  {
    Debug.WriteLine("StaticTest Regular Constructor At: " + Environment.TickCount);
  }
}
```
This produces the output:
```
Start Time: 167855613
StaticTest Static Constructor At: 167855633
StaticTest Regular Constructor At: 167855633
StaticTest Regular Constructor At: 167855633
StaticTest Regular Constructor At: 167855633
```
As expected, the static constructor runs only once, right before any of the StaticTestobjects get instantiated.
So What happens if StaticTest is never referred to? Well, the static constructor never gets run:

```csharp
public class Program
{
  static void Main(string[] args)
  {
    Debug.WriteLine("Start Time: " + Environment.TickCount);
  }
}

public class StaticTest
{
  public static long AFieldToAccess = Environment.TickCount;

  static StaticTest()
  {
    Debug.WriteLine("StaticTest Static Constructor At: " + Environment.TickCount);
  }
}
```
In this case, the only output is:
```
Start Time: 168189944
```
This shows that static constructors don't 'just run' - they are only triggered when code touches a class for the first time.

What are static constructors useful for? They have come in handy every once in a while when I have needed to initialize some static fields in a complex way. For example, say you have a static class that the rest of your code uses to do database access. 

A static constructor is a handy place to initialize that database connection, because it means that the connection will get created right before it is first needed. There are plenty of other uses for them as well - that just happens to be the fist one that popped into my head.

That is it for this short primer on static constructors C#. Thanks for reading.

