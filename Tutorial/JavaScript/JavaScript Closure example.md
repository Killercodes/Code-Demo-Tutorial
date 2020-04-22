# What is a closure

A closure is an inner function that has access to the outer function’s variables in addition to it's own variables and global variables. The inner function has access not only to the outer function’s variables, but also to the outer function’s parameters. You create a closure by adding a function inside another function.


``` javascript
// Example 1
function addNumbers(firstNumber, secondNumber) 
{
    var returnValue = "Result is : ";
    // This inner function has access to the outer function's variables & parameters
    function add() 
    {
        return returnValue + (firstNumber + secondNumber);
    }
    return add();
}

var result = addNumbers(10, 20);
document.write(result); //30
```
Output : Result is : 30

The following code Returns the inner function expression
``` javascript
//Example 2 - with closure (The following code Returns the inner function expression)
function addNumbers(firstNumber, secondNumber) 
{
    var returnValue = "Result is : ";
    function add() 
    {
        return returnValue + (firstNumber + secondNumber);
    }
    // We removed the parentheses. This will return the inner function expression without executing it.
    return add;
}

// addFunc will contain add() function (inner function) expression.
var addFunc = addNumbers(10, 20);

// call the addFunc() function and store the return value in result variable
var result = addFunc(); //result = 30
document.write(result);
```
Returning and executing the inner function
``` javascript
//Example 3 - (Returning and executing the inner function)
function addNumbers(firstNumber, secondNumber) 
{
    var returnValue = "Result is : ";
    function add() 
    {
        return returnValue + (firstNumber + secondNumber);
    }
    // We removed the parentheses. This will return the inner function add() expression without executing it.
    return add;
}

// This returns add() function (inner function) definition and executes it. Notice the additonal parentheses.
var result = addNumbers(10, 20)();
document.write(result);


//Example 4 - (with click counter)
var incrementClickCount = (function () 
    {
        var clickCount = 0;
        return function () 
        {
            return ++clickCount;
        }
    })();

alert(incrementClickCount);
```
In the Example 4 above, in the alert function we are calling the variable incrementClickCount without parentheses. At this point, when you invoke, you get the inner anonymous function expression in the alert. The outer self-invoking anonymous function run only once and sets clickCount variable to 0, and returns the inner function expression.

Whereas inner function has access to clickCount variable. Now every time we click the button, the inner function increments the clickCount variable. The important point to keep in mind is that no other script on the page has access to clickCount variable. The only way to change the clickCount variable is thru incrementClickCount function.



