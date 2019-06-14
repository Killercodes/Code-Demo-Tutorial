# C# Custom Event Handlers
 
Every Control in C# is full of events like MouseButtonDown and KeyDown, but what happens when you want an object to fire an event that isn't already built in? This snippet tutorial will go through all the code required to create your own events and custom event handlers.
As an example, I'm going to create a class that holds information about a car. This will include make, model, year, and owner. When information about the car is changed, this class will fire events letting anyone who is listening know that something has changed.

Below is the basic class with all the members mentioned above. I've also added properties to get and set each variable.
```csharp
using System;
namespace CustomEvents
{
  public class Car
  {
    private string make;
    private string model;
    private int year;
    private string owner;

    public string CarMake
    {
      get { return this.make; }
      set { this.make = value; }
    }

    public string CarModel
    {
      get { return this.model; }
      set { this.model = value; }
    }

    public int CarYear
    {
      get { return this.year; }
      set { this.year = value; }
    }

    public string CarOwner
    {
      get { return this.owner; }
      set { this.owner = value; }
    }

    public Car()
    {
    }
  }
}
```
Let's say I want to know whenever the Owner property of my Car object changes. The quickest way to do this is to use simply use an event handler delegate already supplied by Microsoft - such as EventHandler.
using System;

```csharp
namespace CustomEvents
{
  public class Car
  {
    public event EventHandler OwnerChanged;

    private string make;
    private string model;
    private int year;
    private string owner;

    public string CarMake
    {
      get { return this.make; }
      set { this.make = value; }
    }

    public string CarModel
    {
      get { return this.model; }
      set { this.model = value; }
    }

    public int CarYear
    {
      get { return this.year; }
      set { this.year = value; }
    }

    public string CarOwner
    {
      get { return this.owner; }
      set
      {
        this.owner = value;
        if (this.OwnerChanged != null)
          this.OwnerChanged(this, new EventArgs());
      }
    }

    public Car()
    {
    }
  }
}
```
Here I created an event which uses the EventHandler delegate and called it OwnerChanged. I fire the event in the CarOwner property whenever it is set. When firing the event, you should always check to make sure it's not null. The event will be null if no one is listening for it - you can't fire an event to no one. Once you determined the event is not null, you simply execute it like any other method. The EventHandler signature requires an object and EventArgs as parameters, so I pass in this and a new instance of the EventArgs class. Now let's see how use this event.
```csharp
Car car = new Car();

//adds an event handler to the OwnerChanged event
car.OwnerChanged += new EventHandler(car_OwnerChanged);

//setting this will fire the OwnerChanged event
car.CarOwner = "The Reddest";
```
This code simply creates a car object, attaches to the OwnerChanged event, and sets the CarOwner property. As you can see, using custom events is exactly the same as using built in events. In the code above, whenever the CarOwner property is set, the function car_OwnerChanged will be called.
```csharp
void car_OwnerChanged(object sender, EventArgs e)
{
    //the CarOwner property has been modified
}
```
Now let's say I want the new owner passed in through the event. I could do this with the current event handler by passing the car's owner as sender, but that would mean I have to cast it whenever the event is fired. I also have this EventArgs parameter that I'm not using anywhere.
```csharp
public string CarOwner
{
  get { return this.owner; }
  set
  {
    this.owner = value;
    if (this.OwnerChanged != null)
      this.OwnerChanged(value, new EventArgs());
  }
}
```
Here's a modified version of the CarOwner property that passes the new name through the event. The problem here is that value is passed through as an object, so on the receiving end, they would have to cast it back to a string to get the car's new owner. What we want is a new event handler delegate that doesn't need those parameters. To do this we'll first have to declare a new delegate matching the method signature we want and then create an event using the new delegate.
```csharp
using System;

namespace CustomEvents
{
  public class Car
  {
    public delegate void OwnerChangedEventHandler(string newOwner);
    public event OwnerChangedEventHandler OwnerChanged;

    private string make;
    private string model;
    private int year;
    private string owner;

    public string CarMake
    {
      get { return this.make; }
      set { this.make = value; }
    }

    public string CarModel
    {
      get { return this.model; }
      set { this.model = value; }
    }

    public int CarYear
    {
      get { return this.year; }
      set { this.year = value; }
    }

    public string CarOwner
    {
      get { return this.owner; }
      set
      {
        this.owner = value;
        if (this.OwnerChanged != null)
          this.OwnerChanged(value);
      }
    }

    public Car()
    {
    }
  }
}
```
Here we create a delegate that takes a string as an argument. We then create an event handler using our new delegate. Lastly I modified the CarOwner property to use our new event handler. The code required to listen for our new event handler is identical to before except for the new delegate.
```csharp
Car car = new Car();

//adds an event handler to the OwnerChanged event
car.OwnerChanged += new OwnerChangedEventHandler(car_OwnerChanged);

//setting this will fire the OwnerChanged event
car.CarOwner = "The Reddest";
```
Now whenever car_OwnerChanged is called, the car's owner is passed in as a string. That's all the code required to create and use your own custom events and event handlers.

