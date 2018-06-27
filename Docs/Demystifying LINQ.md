# Demystifying LINQ

LINQ adds enormous power to the .NET Framework through both the libraries it contains and the language additions that power it. It can help you write powerful code faster and that is less error prone, and yet some people still seem to eschew it for various reasons.
More times than not, I believe this is still because people don't really understand what LINQ can offer or how to use it, and thus avoid it. My goal in this post is to demystify LINQ for the .NET beginners and show it for the little wonder that it is.

## What is LINQ?
LINQ is a major component of the .NET Framework and is one of the things that makes the platform so truly unique. LINQ is an acronym that stands for Language INtegrated Query and has several components:
1.	- **Providers** - Libraries that enable querying different types of collections (LINQ to objects, LINQ to SQL, etc.)
2.	- **Language Extensions** - Several new language features were added to .NET languages to support LINQ (lambda expressions, extension methods, anonymous types, etc.)
3.	- **Operations** - Defines several ways to query sequences (`Where`, `Select`, etc.)
Each of these components help to give LINQ its power and ease-of-use. Fortunately, you don't need to know about everything in LINQ to begin using it immediately, so let's just take a brief look inside.
## Providers
The providers are libraries that enable you to query a given source using LINQ. Think of a LINQ provider as the libraries that define operations that use the language extensions to allow LINQ to query the provided data.
There are providers for SQL Databases (LINQ to SQL), for sequences of objects (LINQ to objects), for XML (LINQ to XML), etc. For now, let's stick with LINQ to objects, since it is one of the simpler concepts and yet has the widest applicability - nearly any program can benefit from it as nearly all programs have sequences of objects.
## Language Extensions
Microsoft added several new framework components to help make LINQ a reality. The bonus is, this not only benefits LINQ, but they are useful features in their own right.
### Extension Methods
Extension methods allow you to essentially call a static utility method that "extends" a type in a clean, fluent syntax. As an illustration, say you have some (very contrived) static methods that operate on `int`:
``` csharp
public static class IntExtensions
{    
    public static int Half(int source)
    {
        return source / 2;
    }

    public static int Cube(int source)
    {
        return (int)Math.Pow(source, 3);
    }

    public static int Square(int source)
    {
        return (int)Math.Pow(source, 2);
    }
}
```

These methods, in effect, extend the functionality of int in a logical way by adding additional methods that operate on the public interface of int. The problem is, they are bulky to call. Say you want to take 13, cube it, half it, then square it, you'd have to write:
`IntExtensions.Square(IntExtensions.Half(IntExtensions.Cube(13)));`

Which is very wordy and not nearly as easy to read. Extensions methods are just a bit of syntactical sugar that let utility methods like this that "extend" a type logically behave as if they were first-class methods. To make a static method an extension method, all we need do is put it in a static class and make the first argument an instance of the type we want to "extend" and precede it with the this keyword:
``` csharp
public static class IntExtensions
{    
    public static int Half(this int source)
    {
        return source / 2;
    }

    public static int Cube(this int source)
    {
        return (int)Math.Pow(source, 3);
    }

    public static int Square(this int source)
    {
        return (int)Math.Pow(source, 2);
    }
}
```

Now, we can call the methods as if they were first-class methods and get:
`13.Cube().Half().Square();`

Which is much easier to read! Why is this syntactic sugar so important? Because many of the LINQ query operators we will see later are implemented through extension methods as you will see in a bit. This gives LINQ it's fluent feel and makes chaining operations together seem natural and fluid.
### Iterators
Iterators are one of the core enhancements to the framework that give LINQ (and you) a lot of power to create queries with deferred execution. This means it provides a way for you to be able to return a sequence of objects one item at a time, as they are requested.
For example, let's say you wanted to find the even numbers in a list, you could do this:
```csharp 
public List<int> GetEvens<int>(List<int> source)
{
    var results = new List<int>();
    foreach (var item in source)
    {
        if ((item%2) == 0)
        {
            results.Add(item);
        }
    }

    return results;
}
```

While this works, if we only wanted the first five even numbers out of the list, this would be overkill! Iterators allow you to create an algorithm that returns the next item as it's requested:
```csharp
public IEnumerable<int> GetEvens(List<int> source)
{
    foreach (var item in source)
    {
        if ((item%2) == 0)
        {
            yield return item;
        }
    }
}
```

Notice we don't create a container to hold every possible result, we just return each item with a `yield return` statement. Thus, each item is only computed when it is requested. So, if we only iterate over the first 5 items in the collection, only those get computed.
This also means that the query is not run until you begin iterating over it. For example, lets say we have a List of 1000 integers and we want to find the evens, but clear it before we iterate:
```cs
var items = Enumerable.Range(1, 1000).ToList();
var evens = GetEvens(items);

items.Clear();

// no items are printed, because the source was cleared
// before the query was iterated over
foreach (var i in evens)
{
    Console.WriteLine(i);
}
```
This is a key concept in LINQ, in fact you shouldn't think of calling a function that returns an iterator as returning all results, but returning a state machine that will give you the next result as you iterate over it.
Thus, when we call `var evens = GetEvens(items)` we are only creating a query over the items, not the result set. So when we clear the source collection, and then execute the query, it will yield no results.
#### Lambda Expressions
The other language feature that helps make LINQ (and in general, .NET) so powerful are lambda expressions. Lambda expressions make it easy to write short, anonymous methods at the point where they are used.
Is the syntax a bit new and frightening for new developers? Perhaps, but once you understand their syntax they are enormously powerful and truly improve a program's readability.
The .NET Framework has had delegates since the beginning. Delegates are very powerful as they allow you to store a reference to a method in a variable, and use that variable to invoke the method later. Delegates give the programmer the power to be able to specify functionality to be invoked generically without needing to subclass. The only problem with working with delegates in early .NET was that you would need to define a full-blown method to assign to the delegate, even for potentially trivial functionality.
Then, in .NET 2.0 they added anonymous method syntax, which let you assign an anonymous method to a delegate on the fly:
`Predicate<int> numCheck = delegate(int num) { return num % 2 == 0; };`
Which we can then invoke:
`if (numCheck(13)) { ... }`

Well, lambda expressions just took the anonymous method syntax and simplified it even further:
`Predicate<int> numCheck = (int x) => { return (x % 2) == 0; };`

The => operator is often pronounced as "goes to" and separates the args list from the body. There are a lot of simplifications that can be done with lambda expressions. First of all, if the type of the parameters can be inferred, you can omit the type. Further, if the body is a single statement you can omit the curlies and if the only statement is returning an expression you can omit the return.
Thus, these are really the same delegate:
```cs
Predicate<int> numCheck = (int x) => { return (x % 2) == 0; };
Predicate<int> numCheck = x => (x % 2) == 0;
```

So again, why am I spending time discussing lambdas? Because they are the best way to specify logic concisely at the point of use. This is important because it can make expressions easier to read and maintain. Plus, you won't have to clutter up your source files with tons of single-line methods.
There are other language additions as well (anonymous types, for example), but we'll save those for another time as you don't need them right away to get started with LINQ.
### Query Syntax
The third language extension in .NET was the addition of the query syntax. As we will see in just a bit, many of the LINQ methods are handled through LINQ extension methods. While these read easy enough, Microsoft decided to give the query operations a more SQL-ish feel to make querying objects seem more natural. To truly appreciate the query syntax, we first need to discuss the different operations, so let's come back to this at the end.
## Operations
There are many operations in LINQ, which are provided by extensions methods in theSystem.Linq assembly for querying sequences of `object.` Now, by sequence of object, we mean any `IEnumerable<T>,` such as `List<T>, T[]`, `HashSet<T>`, etc. This is really where LINQ shines, because it can be used to query nearly any sequence!
This is also why extension methods are so prominent, because they are used to extendIEnumerable<T> to add the operators in the System.Linq library.
This is why extension methods were invented! It gives the ability to "add" functionality to an interface (among other types), which cannot be done directly in interfaces. And since most of the collections do not share a parent class, and different forms of querying would need different implementations of each operation, the extension methods are a clever way to add this functionality indirectly.
Let's look at some of the key operations available, there are many more, but these are probably the most commonly used.
### Filtering
We can filter any sequence of items using Where() to get a query that will provide the items that meet the criteria:
```
// Get orders whose value is greater than 1000.00
var bigOrders1 = orders.Where(o => o.Price > 1000.0);
```
### Projection
Using Select(), we can transform a sequence from one type to another type. This is useful when you want to select a part of an object, or a composite object:
```
// Get just the list of order IDs from orders
var orderIds = orders.Select(o => o.OrderId);
```
### Consistency Checking
Using consistency checking methods such as Any() and All() we can check if any one or all items meet a condition.
```
// Return true if all orders are valid
if (orders.All(o => o.IsValid)) { ... }

// Return true if just one is invalid
if (orders.Any(o => !o.IsValid)) { ... }
```
### Uniqeness
The Distinct() operation will give us back the sequence with all duplicates removed. Now, it should be noted that to determine duplicates, your object has to correctly override both Equals() and GetHashCode(), in fact you will find this true for many of the LINQ methods that check equality.
```
// Get a list of unique order ids
var ids = orders.Select(o => o.OrderId).Distinct();
```
### Positional Selection
There are several methods that allow you to get just the first, last, or an item that meet a given criteria. These methods will throw an exception if no such item exists, unless you use the ...OrDefault() variant of that method, in which case it returns the default(T)if not found.
```
// Gets first order in list, or throws if empty
var firstOrder = orders.First();

// Gets first order in list, or `null` if empty
var firstOrderOrNull = orders.FirstOrDefault();

// Gets first order in list that is invalid, or throws if can't find one.
var firstInvalid = orders.First(o => !o.IsValid);

// Gets first order in list that is invalid, or null if can't find one.
var firstInvalidOrNull = orders.FirstOrDefault(o => !o.IsValid);
```

There Last() methods behave in the same manner, but return the last item in the sequence, or the last item that matches the condition respectively. In addition, there is aSingle() method which is similar to First(), except it will throw if there is more than one item that matches as well.
### Ordering
You can easily sort your sequences by one or more criteria in ascending or descending order.
```
// get the list of items sorted ascending by order id, descending by last name
var sorted = orders.OrderBy(o => o.OrderId).ThenByDescending(o => o.Name.Last);
```
### Grouping
Using grouping, you can group items together based on a criteria. When you do this, the items will be collected into a sequence of groupings where the Key is the criteria you grouped on, and the grouping itself is a sequence of all items that match the key.
```
// Get all orders grouped by department
var grouped = orders.GroupBy(o => o.Department);

foreach (var group in grouped)
{ 
    Console.WriteLine("Department: " + group.Key);

    foreach (var item in group)
    {
        ...
    }
}
```

And so on, there are many operations that you can perform on sequences of objects, take a look at the System.Linq namespace to learn more.
## Query Language
Now, we've seen that you can use the extension methods and query sequences of objects directly. This is all well and good and many people even prefer this syntax for representing their LINQ queries. That said, one of the language extensions in LINQ was adding a query language that makes the queries appear more SQL-esque.
To use the query language, we start with a from statement that defines an item iterating over a sequence, for example from o in orders says that the sequence we are iterating over is orders and o will represent each item in turn (much like saying foreach (var o in orders) does).
Then, each query must end with either a select clause (projection) or a group clause.
```
// get list of order ids using query language
var orderIds = from o in orders select o.Id;
```

Once again, you can filter using the where clause to get items that satisfy a given condition:
```
// get list of all valid orders
var validOrders = from o in orders where o.IsValid select o.Id;
```

SO which is better, the query language or using extension methods directly? That tends to be a matter of style and personal preference. There are some things the query language does not (yet) support directly (like FirstOrDefault()) but for many it can seem more natural. In the end, though, the same query written in either syntax will compile down to identical IL, so truly the choice is yours. Choose whichever you (and your team) find to be more readable and maintainable. Either way you should be happy with the results.
## Summary
LINQ is one of the most wonderful things about working with .NET, I truly miss it when I code in other languages because of the ease in which it lets me write very complex code in a quick and maintainable way. In addition, these methods have all been thoroughly tested for you, so that's less custom code to test and maintain!

