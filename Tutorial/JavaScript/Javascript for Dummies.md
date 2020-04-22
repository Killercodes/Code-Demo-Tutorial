Dummies for JS
If you are dummy you are welcome

# JavaScript Basics

## Is JavaScript case sensitive
Yes, JavaScript is case sensitive programming language. Variable names, keywords, methods, object properties and event handlers all are case sensitive.

Example 1 : `alert()` function name should be all small letters
``` javascript
    alert("JavaScripts Basics Tutorial");
```

Example 2 : Alert() is not same as alert(). Throws Alert is not defined error. To see the error press F12 key.
``` javascript
    Alert("JavaScripts Basics Tutorial");
[/script]

Comments in JavaScript : There are 2 types of comments in JavaScript.
-	Single Line Comment
Example : 
``` javascript
    // This is a sinle line comment
```

2) Multi Line Comment
Example:
``` javascript
    /* This is a 
       multi line 
       comment */
[/script]

Data types in JavaScript

The following are the different data types in JavaScript
Numbers - 5, 5.234
Boolean - true / false
String - "MyString", 'MyString'

To create a variable in JavaScript use var keyword. Variable names are case sensitive.

With JavaScript we always use var keyword to create any type of variable. Based on the value assigned the type of the variable is inferred.
var a = 10;
var b = "MyString";

JavaScript is a dynamically typed language. This means JavaScript data types are converted automatically as needed during script execution. Notice that, in myVariable we are first storing a number and then a string later.
``` javascript
    var myVariable = 100;
    alert(myVariable);
    myVariable = "Assigning a string value";
    alert(myVariable);
[/script]

When a + operator is used with 2 numbers, JavaScripts adds those numbers.
``` javascript
    var a = 10;
    var b = 20;
    var c = a + b;
    alert(c);
[/script]

Output : 30

When a + operator is used with 2 strings, JavaScript concatenates those 2 strings
``` javascript
    var a = "Hello "
    var b = "JavaScript";
    var c = a + b;
    alert(c);
[/script]

Output : Hello JavaScript

When a + operator is used with a string and a number, JavaScript converts the numeric value to a string and performs concatenation.
``` javascript
    var a = "Number is : "
    var b = 10;
    var c = a + b;
    alert(c);
[/script]

Output : Number is 10

``` javascript
    var a = "50"
    var b = 10;
    var c = a + b;
    alert(c);
[/script]

Output : 5010

But if you use a minus operator, numeric value is not converted to string
``` javascript
    var a = "50"
    var b = 10;
    var c = a - b;
    alert(c);
[/script]

Output : 40

## Inline vs external javascript
Here we will discuss
1. Different places where JavaScript can be present
2. Advantages of external JavaScript over inline JavaScript

JavaScript can be stored either inline on the page or in an external .js file. Let's look at an example of both the approaches.

Inline JavaScript example : In this example, IsEven() JavaScript function is present inline on the page.
``` javascript
<html>
<head>
    <script type="text/javascript">
        function IsEven() 
        {
            var number = document.getElementById("TextBox1").value;
            if (number % 2 == 0) 
            {
                alert(number + " is even number");
            }
            else 
            {
                alert(number + " is odd number");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        Number : 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <input type="button" value="Check Number" onclick="IsEven()" />
    </form>
</body>
</html>
```

External JavaScript example : Steps to store JavaScript in an external .js file
1. In Visual Studio, right click on the project name in Solution Explorer and select add select Add =] New Item
2. From the "Add New Item" dialog box select "JScript File". Name the file "ExternalJavaScript.js" and click Add.
3. Copy and paste the following JavaScript function in the "ExternalJavaScript.js" file

``` javascript 
function IsEven() 
{
    var number = document.getElementById("TextBox1").value;
    if (number % 2 == 0) 
    {
        alert(number + " is even number");
    }
    else 
    {
        alert(number + " is odd number");
    }
}
```

4. On your webform in the head section include a reference to the external JavaScript file using script element as shown below
```
<script type="text/javascript" src="ExternalJavaScript.js"></script>
```

5. At this point the HTML on your webform should be as shown below.
```html
<html>
<head>
    <script type="text/javascript" src="ExternalJavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        Number :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <input type="button" value="Check Number" onclick="IsEven()" />
    </form>
</body>
</html>
```
Advantages of external JavaScript over inline JavaScript : Here are some of the general advantages of external JavaScript over inline JavaScript

Maintainability : JavaScript in external files can be referenced on multiple pages without having to duplicate the code inline on every page. If something has to change, you only have one place to change. So external JavaScript code can be reused and maintenance will be much easier.

Separation of Concerns : Storing JavaScript in a separate external .js file adheres to Separation of concerns design principle. In general it is a good practice to separate HTML, CSS and JavaScript as it makes it easier working with them. Also allows multiple developers to work simultaneously.

Performance : An external JavaScript file can be cached by the browser, where as an inline JavaScript on the page is loaded every time the page loads.


# Arrays in JS
Arrays are collections and ZERO indexed. This means the first element is at index ZERO and the last element is at index arrayObject.length - 1. length property of the array object returns the size of the array.

The following JavaScript code creates an empty array. length property returns 0 in this case.
```javascript
var emptyArray = [];
alert(emptyArray.length);
```
Output : 0

Another way to create an array is by busing the Array constructor as shown below. In this example we are setting the length of the array to 10.
```javascript
var myArray = new Array(10);
alert(myArray.length);
```
Output : 10

Retrieving first and last elements from the array using the array index
```javascript
var myArray = [10, 20, 30];
document.write("First element = " + myArray[0] + "[br/]");
document.write("Last element = " + myArray[myArray.length - 1] + "[br/]");
```
Output : 
First element = 10
Last element = 30

Populating an array in JavaScript : There are several ways to populate an array in JavaScript. Let's look at those different option now.

Declaring an array first and then populating using the array index
```javascript

var myArray = [];
        
myArray[0] = 10;
myArray[1] = 20;
myArray[2] = 30;
        
alert(myArray);
```
Output : 10, 20, 30

Declaring and populating the array at the same time
```javascript

var myArray = [10, 20, 30];        
alert(myArray);
```
Output : 10, 20, 30

Declaring an array first using the Array constructor and then populating using the array index. Though the initial size is set to 3, adding a fourth element to the array will not throw an exception, because arrays in JavaScript can grow in size.
```javascript
var myArray = new Array(3);
        
myArray[0] = 10;
myArray[1] = 20;
myArray[2] = 30;      

alert(myArray);
```
Output : 10, 20, 30

Declaring and populating the array at the same time using the Array constructor
```javascript

var myArray = new Array(10, 20, 30);
alert(myArray);
```
Output : 10, 20, 30

Please note : If only one number is passed to the Array constructor, then that number is used to set the size of the array. If more that one number is passed then those will be used as elements to populate the array.

A for loop can be used to populate and retrieve elements from the array object in JavaScript

Populating an array using for loop : The following JavaScript code stores even numbers in the array from 0 to 10. Notice that we are using a for loop to populate the array.
```javascript
var evenNumbersArray = [];
for (var i = 0; i [= 5; i++) 
{
    evenNumbersArray[i] = i * 2;
}
alert(evenNumbersArray);
```
Output : 0,2,4,6,8,10

Retrieving elements from the array using for loop : 
```javascript
var evenNumbersArray = [];
for (var i = 0; i [= 5; i++) 
{
    evenNumbersArray[i] = i * 2;
}

for (var i = 0; i [ evenNumbersArray.length; i++) 
{
    document.write(evenNumbersArray[i] + "[br/]");
}
```
Output :
0
2
4
6
8
10

## Array Push & Pop
In the example below, we are populating myArray using a for loop and the array index. Subsequently we are using another for loop to retrieve the elements from the array. Finally we are displaying the length of the array using JavaScript alert.
```javascript
var myArray = [];

for (var i = 0; i [= 5; i++) 
{
    myArray[i] = i * 2;
}

for (var i = 0; i [= 5; i++) 
{
    document.write(myArray[i] + "[br/]");
}

alert(myArray.length);
```

Please note : Retrieving array elements using the array index, will not change the length of the array.

### JavaScript push() method
This method adds new items to the end of the array. This method also changes the length of the array. 

### JavaScript pop() method
This method removes the last element of an array, and returns that element. This method changes the length of an array.

**Example :** In the exampe below, we are using push() method to populate the array and pop() method to retrieve elements from the array. Notice that push() and pop() methods change the length property of the array.
```javascript

var myArray = [];

for (var i = 0; i [= 5; i++) 
{
    myArray.push(i * 2);
}

alert(myArray.length);

for (var i = 0; i [= 5; i++) 
{
    document.write(myArray.pop() + "[br/]");
}

alert(myArray.length);
```javascript

### JavaScript unshift() Method
push() method adds new items to the end of the array. To add new items to the beginning of an array, then use unshift() method. Just like push() method, unshift() method also changes the length of an array

Example : 
```javascript
var myArray = [2,3];

// Adds element 4 after element 3
myArray.push(4);

// Adds element 1 before element 2
myArray.unshift(1);

document.write("Array elements = " + myArray + "[br/]");
document.write("Array Length = " + myArray.length);
```
### JavaScript shift() Method
pop() method removes the last element of an array, and returns that element. shift() method removes the first item of an array, and returns that item. Just like pop() method, shift() method also changes the length of an array.

Example : 
```javascript

var myArray = [1, 2, 3, 4, 5];

// removes the last element i.e 5 from the array
var lastElement = myArray.pop();
document.write("Last element = " + lastElement + "[br/]");

// removes the first element i.e 1 from the array
var firstElement = myArray.shift();
document.write("First element = " + firstElement + "[br/][br/]");

document.write("Array elements = " + myArray + "[br/]");
document.write("Array Length = " + myArray.length);
```

## Array mutators
There are several methods that can be used with the array object in JavaScript. Some methods modify the array object while the others do not. The methods that modify the array object are called as mutator methods. 

The following are the examples of non-mutator methods
```
contains
indexOf
lastIndexOf
```

The following are the examples of mutator methods
```
push
pop
shift
unshift
reverse
sort
splice
```
We discusssed push(), pop(), shift() and unshift() methods in Part 20. In this video we will discuss 
```
sort
reverse
splice
```
JavaScript sort method : Sorts the elements of an array. By default, the sort() method sorts the values by converting them to strings and then comparing those strings. This works well for strings but not for numbers. Let us look at an example.

Example : Notice that the strings are sorted correctly as expected.
```javascript
var myArray = ["Sam","Mark","Tom","David"];
myArray.sort();
document.write(myArray);
```
Output : David,Mark,Sam,Tom

Now, let's look at an example of sorting numbers. 
```javascript
var myArray = [20, 1 , 10 , 2, 3];
myArray.sort();
document.write(myArray);
```
Output : 1,10,2,20,3

Notice that the numbers are not sorted as expected. We can fix this by providing a "compare function" as a parameter to the sort function. The compare function should return a negative, zero, or positive value.

Example :
```javascript
var myArray = [20, 1, 10, 2, 3];
myArray.sort(function (a, b) { return a - b });
document.write(myArray);
```
Output : 1,2,3,10,20

Let's now discuss how the compare function work. The function has 2 parameters (a,b). This function subtracts a from b and returns the result. If the return value is
Positive - a is a number bigger than b
Negative - a is a number smaller than b
ZERO - a is equal to b

So, based on these return values, the numbers in the array are sorted.

Sorting the numbers in descending order : There are 2 ways to sort an array in descending order

1. Return (b-a) from the compare function instead of (a-b)

Example : 

```javascript
var myArray = [20, 1, 10, 2, 3];
myArray.sort(function (a, b) { return b - a });
document.write(myArray);
```
Output : 20,10,3,2,1

2. Sort the numbers first in ascending order and then use the reverse function to reverse the order of the elements in the array.

Example :

```javascript
var myArray = [20, 1, 10, 2, 3];
myArray.sort(function (a, b) { return a - b }).reverse();
document.write(myArray);
```
Output : 20,10,3,2,1

JavaScript reverse method : reverses the order of the elements in an array.

JavaScript splice method : This method is used to add or remove elements from an array. 

Syntax : array.splice(index,deleteCount,item1,.....,itemX)

index - Required. Specifies at what position to add or remove items
deleteCount - Required. The number of items to be removed. If set to 0, no items will be removed.
item1,.....,itemX - Optional. The new item(s) to be added to the array

Example : 

```javascript
var myArray = [1,2,5];
myArray.splice(2, 0, 3, 4);
document.write(myArray);
```
Output : 1,2,3,4,5

Example : 

```javascript
var myArray = [1,2,55,67,3];
myArray.splice(2, 2);
document.write(myArray);
```
Output : 1,2,3

## Array Filters
The filter() method creates a new array and populates that array with all the elements that meet the condition specified in a callback function.

Syntax : ```array.filter(callbackFunction[, thisArg])```

### Parameters
#### callbackFunction
Required. Function that gets called for each element of the array. If the function returns true, the element is kept otherwise filtered.

#### thisArg
Optional. An object to which the this keyword can refer in the callbackfn function.

The filter method calls the callbackfn function one time for each element in the array. If the callback function returns false for all elements of the array, the length of the new array that will be returned is 0.

### Callback Function Syntax
```
function callbackFunction(value, index, array)
```

#### Callback Function Parameters
**Value** The value of the element in the array
**Index** The index position of the element in the array
**Array** The source array object that contains the element


Example 1 : Retrieve only even numbers from myArray
```javascript
// Callback function
function IsEven(value, index, array) 
{
    if (value % 2 == 0) 
    {
        return true;
    }
    else 
    {
        return false;
    }
}

// Source array
var myArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// Pass the callback function as argument to the filter method
var result = myArray.filter(IsEven);

document.write(result);
```
Output : 2,4,6,8,10


Example 2 : In Example 1 we defined a callback function first and then passed it as an argument to the filter() method. In the example below, we created the callback function as an anonymous function directly in the filter method where it is required.

// Source array
var myArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// callback function created directly in the filter method as anonymous function
var result = myArray.filter(function (v, i, a) { return v % 2 == 0 });

document.write(result);

Output : 2,4,6,8,10

Example 3 : Remove duplicates from javascript array

var myArray = ["Sam", "Mark", "Tim", "Sam"];
var uniqueItems = myArray.filter(function (v, i, a) { return a.indexOf(v) == i });
document.write(uniqueItems);

Output :
Sam,Mark,Tim

Two dimensional array in javascript
JavaScript does not have a special syntax for creating multidimensional arrays. Instead we create an array of arrays.

Example : The following JavaScript code creates a 2 dimensional 3x3 array

var myArray1 = new Array(3)

for (i=0; i [ 3; i++)
myArray1[i]=new Array(3)

myArray1[0][0] = "1"
myArray1[0][1] = "2"
myArray1[0][2] = "3"

myArray1[1][0] = "4"
myArray1[1][1] = "5"
myArray1[1][2] = "6"

myArray1[2][0] = "7"
myArray1[2][1] = "8"
myArray1[2][2] = "9"

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        document.write(myArray1[i][j] + "&emsp;");
    }
    document.write("[br/]");
}

In Example 1, we have manually populated each storage location in the array. Instead we can use to 2 nested for loops as shown below.

var myArray1 = new Array(3)

for (i=0; i [ 3; i++)
myArray1[i]=new Array(3)

var start = 1;

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        myArray1[i][j] = start;
        start = start + 1;
    }
}


for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        document.write(myArray1[i][j] + "&emsp;");
    }
    document.write("[br/]");
}

Performing addition between 2 two dimensional arrays in JavaScript 

Example : 
The first 3 x 3 array should contain numbers from 1 to 9
The second 3 x 3 array should contain numbers from 9 to 1
The numbers present at each index position in the first and second array should be added and the result should be stored in a third 3x3 array.

// Create the first 2 dimensional 3 X 3 array
var myArray1 = new Array(3)

for (i=0; i [ 3; i++)
myArray1[i]=new Array(3)

var start = 1;

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        myArray1[i][j] = start;
        start = start + 1;
    }
}

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        document.write(myArray1[i][j] + "&emsp;");
    }
    document.write("[br/]");
}

document.write("[br/]");
document.write("&emsp;+");
document.write("[br/]");
document.write("[br/]");

// Create the second 2 dimensional 3 X 3 array
var myArray2 = new Array(3)

for (i = 0; i [ 3; i++)
    myArray2[i] = new Array(3)

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        start = start - 1;
        myArray2[i][j] = start;
    }
}

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        document.write(myArray2[i][j] + "&emsp;");
    }
    document.write("[br/]");
}

document.write("[br/]");
document.write("&emsp;=");
document.write("[br/]");
document.write("[br/]");

// Create the third 2 dimensional 3 X 3 array
var myArray3 = new Array(3)

for (i = 0; i [ 3; i++)
    myArray3[i] = new Array(3)

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        myArray3[i][j] = myArray1[i][j] + myArray2[i][j];
    }
}


for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 3; j++) 
    {
        document.write(myArray3[i][j] + "&emsp;");
    }
    document.write("[br/]");
}

Creating a 2 dimensional 3 X 5 array

var myArray1 = new Array(3)

for (i=0; i [ 3; i++)
myArray1[i]=new Array(5)

var start = 101;

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 5; j++) 
    {
        myArray1[i][j] = start;
        start = start + 1;
    }
}

for (var i = 0; i [ 3; i++) 
{
    for (var j = 0; j [ 5; j++) 
    {
        document.write(myArray1[i][j] + "&emsp;");
    }
    document.write("[br/]");
}

Functions in JavaScript
A function is a block of reusable code. A function allows us to write code once and use it as many times as we want just by calling the function.

JavaScript function syntax
function functionName(parameter1, parameter2,..parameter_n)
{
  //function statements
}

Points to remember
1. Use the function keyword to define a function, followed by the name of the function. The name of the function should be followed by parentheses ().
2. Function parameters are optional. The parameter names must be with in parentheses separated by commas.

Example : JavaScript function to add 2 numbers. The following JavaScript function adds 2 numbers and return the sum

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

Calling the JavaScript function : Call the JavaScript function by specifying the name of the function and values for the parameters if any.

var sum = addNumbers(10, 20);
alert(sum);

Output : 30

What happens when you do not specify values for the function parameters when calling the function
The parameters that are missing values are set to undefined

Example : In the example below, we are passing 10 for the firstNumber parameter but the secondNumber parameter is missing a value, so this parameter will be set to undefined. When a plus (+) operator is applied between 10 and undefined we get not a number (NaN) and that will be alerted.

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

var sum = addNumbers(10);
alert(sum);

Output : NaN

What happens when you specify too many parameter values when calling the function. 
The extra parameter values are ignored.

Example : In the example below, 30 & 40 are ignored.

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

var sum = addNumbers(10, 20, 30, 40);
alert(sum);

Should a javascript function always return a value
No, they don't have to. It totally depends on what you want the function to do. If an explicit return is omitted, undefined is returned automatically. Let's understand this with an example.

The following function returns the sum of two numbers. We are storing the return value of the function in sum variable and writing it's value to the document.

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

var sum = addNumbers(10, 20);
document.write(sum);

The following function does not return any value. It simply writes the sum of two numbers to the page. However, we are assigning the return value of addNumbers() function to sum variable. Since addNumbers() function in this case does not have an explicit return statement, undefined will be returned.

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    document.write(result);
}

var sum = addNumbers(10, 20);
alert(sum);

Different ways of defining functions in JavaScript
In JavaScript, there are several different ways of defining functions.

Defining a function using function declaration

Example 1 : Declaring a function first and then calling it.

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

var sum = addNumbers(10, 20);
document.write(sum);

Output : 30

Example 2 : A function call is present before the respective function declaration

In Example 1, we are first defining the function and then calling it. The call to a JavaScript function can be present anywhere, even before the function is declared. The following code also works just fine. In the example below, we are calling the function before it is declared.

var sum = addNumbers(10, 20);
document.write(sum);

function addNumbers(firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

Function Hoisting : By default, JavaScript moves all the function declarations to the top of the current scope. This is called function hoisting. This is the reason JavaScript functions can be called before they are declared.

Defining a JavaScript function using a function expression : A Function Expression allows us to define a function using an expression (typically by assigning it to a variable). There are 3 different ways of defining a function using a function expression.

Anonymous function expression example : In this example, we are creating a function without a name and assigning it to variable add. We use the name of the variable to invoke the function.

var add = function (firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

var sum = add(10, 20);
document.write(sum);

Functions defined using a function expression are not hoisted. So, this means a function defined using a function expression can only be called after it has been defined while a function defined using standard function declaration can be called both before and after it is defined.

// add() is undefined at this stage
var sum = add(10, 20);
document.write(sum);

var add = function (firstNumber, secondNumber) 
{
    var result = firstNumber + secondNumber;
    return result;
}

Named function expression example : This is similar to the example above. The difference is instead of assigning the variable to an anonymous function, we’re assigning it to a named function (with the name computeFactorial). 

var factorial = function computeFactorial(number) 
{
    if (number [= 1) 
    {
        return 1;
    }

    return number * computeFactorial(number - 1);
}

var result = factorial(5);
document.write(result);

The name of the function (i.e computeFactorial) is available only with in the same function. This syntax is useful for creating recursive functions. If you use computeFactorial() method outside of the function it raises  'computeFactorial' is undefined error.

var factorial = function computeFactorial(number) 
{
    if (number [= 1) 
    {
        return 1;
    }

    return number * computeFactorial(number - 1);
}

var result = computeFactorial(5);
document.write(result);

Output : Error - 'computeFactorial' is undefined.

Self invoking function expression example : 

var result = (function computeFactorial(number) 
{
    if (number [= 1) 
    {
        return 1;
    }

    return number * computeFactorial(number - 1);
})(5);

document.write(result);

Output : 120

These are called with different names
•	Immediately-Invoked Function Expression (IIFE)
•	Self-executing anonymous functions
•	Self-invoked anonymous functions

Recursive function in JavaScript
Recursion is a programming concept that is applicable to all programming languages including JavaScript. 

What is a recursive function?
Recursive function is function that calls itself. 

When writing recursive functions there must be a definite break condition, otherwise we risk creating infinite loops.

Example : Computing the factorial of a number without recursion

function factorial(n) 
{
    if (n == 0 || n == 1) 
    {
        return 1;
    }
    var result = n;
    while (n ] 1) 
    {
        result = result * (n - 1)
        n = n - 1;
    }
    return result;
}

document.write(factorial(5));

Output : 120

Example : Computing the factorial of a number using a recursive function
function factorial(n) 
{
    if (n == 0 || n == 1) 
    {
        return 1;
    }
    return n * factorial(n - 1);
}

document.write(factorial(5));

Output : 120
JavaScript arguments object
The JavaScript arguments object is a local variable available within all functions. It contains all the function parameters that are passed to the function and can be indexed like an array. The length property of the arguments object returns the number of arguments passed to the function.

JavaScript arguments object example :
function printArguments() 
{
    document.write("Number of arguments = " + arguments.length + "[br/]")
    for (var i = 0; i [ arguments.length; i++) 
    {
        document.write("Argument " + i + " = " + arguments[i] + "[br/]");
    }
    document.write("[br/]");
}

printArguments();
printArguments("A", "B");
printArguments(10, 20, 30);

Is it possible to pass variable number of arguments to a JavaScript function
Yes, you can pass as many arguments as you want to any javascript function. All the parameters will be stored in the arguments object.

function addNumbers() 
{
    var sum = 0;
    document.write("Count of numbers = " + arguments.length + "[br/]")
    for (var i = 0; i [ arguments.length; i++) 
    {
        sum = sum + arguments[i];
    }
    document.write("Sum of numbers = " + sum);
    document.write("[br/][br/]");
}

addNumbers();
addNumbers(10, 20, 30);

The arguments object is available only inside a function body. Attempting to access the arguments object outside a function results in 'arguments' is undefined error. Though you can index the arguments object like an array, it is not an array. It does not have any Array properties except length. For example it does not have the sort() method, that the array object has. However, you can convert the arguments object to an array.

Converting JavaScript arguments object to an array
function numbers() 
{
    var argsArray = Array.prototype.slice.call(arguments);
    argsArray.sort();
    document.write(argsArray);
}

numbers(50, 20, 40);

Output : 20, 40, 50

Converting JavaScript arguments object to an array using array literals
function numbers() 
{
    var argsArray = [].slice.call(arguments);
    argsArray.sort();
    document.write(argsArray);
}

numbers(50, 20, 40);

Output : 20, 40, 50

Local and global variables in javascript
In JavaScript there are 2 types of variables
1. Local variables
2. Global variables

JavaScript local variables : Local variables are the variables declared with in a function. These variables have local scope meaning these are available only inside the function that contains them. Local variables are created when a function starts, and deleted as soon as the function completes execution.

function helloWorld() 
{
    var greeting = "Hello";
    // The variable greeting is available in the function
    greeting = greeting + " JavaScript";
    alert(greeting);
}

helloWorld();

// The variable greeting is not available outside the function
// Error : 'greeting' is undefined
alert(greeting);

JavaScript global variables : Global variables are the variables declared outside a function. Global variables have global scope meaning all scripts and functions on the page can access them. The lifetime of a global variable starts with it's declaration and is deleted when the page is closed.

// Global variable
var greeting = "Hello";

function helloWorld() 
{
    // The variable greeting is available in the function
    greeting = greeting + " JavaScript";
    alert(greeting);
}

helloWorld();

If you assign a value to a variable that has not been declared, it will automatically become a global variable, even if it is present inside a function.

function helloWorld() 
{
    // The variable greeting is not declared but a value is assigned. 
    // So it will automatically become a global variable
    greeting = "Hello JavaScript";
}

helloWorld();

// Variable greeting is available outside the function
alert(greeting);

A local variable can have the same name as a global variable. Changing the value of one variable has no effect on the other. If the variable value is changed inside a function, and if a local version of the variable exists then the local variable gets modified. If the variable value is changed outside a function then the global variable gets modified.

var greeting = "This is from global Variable";

function helloWorld() 
{
    var greeting = "This is from local variable";
    document.write(greeting + "[br/]");
}

// This line will modify the global greeting variable
greeting += "!!!";

helloWorld();

document.write(greeting);

Output : 
This is from local variable
This is from global Variable!!! 

Sometimes, variable hoisting and local & global variable with the same name can cause unexpected behavior.

var greeting = "This is from global Variable";
helloWorld();

function helloWorld() 
{
    document.write(greeting);
    var greeting = "Hello from local variable"
}

Output :
undefined

At runtime due to variable hoisting, the above program would look more like as shown below.

var greeting = "This is from global Variable";
helloWorld();

function helloWorld() 
{
    var greeting;
    document.write(greeting);
    greeting = "Hello from local variable"
}

Braces do not create scope in JavaScript : In the following example otherNumber is a global variable though it is defined inside braces. In many languages like C# and Java, braces create scope, but not JavaScript.

var number = 100;

if (number ] 10) 
{
    var otherNumber = number;
}

document.write(otherNumber);

Output : 100

Closures in JavaScript
What is a closure
A closure is an inner function that has access to the outer function’s variables in addition to it's own variables and global variables. The inner function has access not only to the outer function’s variables, but also to the outer function’s parameters. You create a closure by adding a function inside another function.

JavaScript Closure Example 

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
document.write(result);

Output : Result is : 30

The following code Returns the inner function expression

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
var result = addFunc();

document.write(result);


Returning and executing the inner function
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

JavaScript closure example
Using a global variable and incrementing it everytime we click the button : The problem with this approach is that, since clickCount is a global variable any script on the page can accidentally change the variable value.

[script type="text/javascript"]
    var clickCount = 0;
[/script]
[input type="button" value="Click Me" onclick="alert(++clickCount);" /]

Using a local variable with in a function and incrementing it by calling the function : The problem with this approach is that, click count is not incremented beyond 1, no matter how many times you click the button.

[script type="text/javascript"]
    function incrementClickCount() 
    {
        var clickCount = 0;
        return ++clickCount;
    }
[/script]
[input type="button" value="Click Me" onclick="alert(incrementClickCount());" /]

Using a JavaScript closure : A closure is an inner function that has access to the outer function’s variables in addition to it's own variables and global variables. In simple terms a closure is function inside a function. These functions, that is the inner and outer functions could be named functions or anonymous functions. In the example below we have an anonymous function inside another anonymous function. The variable incrementClickCount is assigned the return value of the self invoking anonymous function.

[script type="text/javascript"]
    var incrementClickCount = (function () 
    {
        var clickCount = 0;
        return function () 
        {
            return ++clickCount;
        }
    })();
[/script]
[input type="button" value="Click Me" onclick="alert(incrementClickCount);" /]

In the example above, in the alert function we are calling the variable incrementClickCount without parentheses. At this point, when you click the button, you get the inner anonymous function expression in the alert. The point I want to prove here is that, the outer self-invoking anonymous function run only once and sets clickCount variable to ZERO, and returns the inner function expression. Inner function has access to clickCount variable. Now every time we click the button, the inner function increments the clickCount variable. The important point to keep in mind is that no other script on the page has access to clickCount variable. The only way to change the clickCount variable is thru incrementClickCount function.

[script type="text/javascript"]
    var incrementClickCount = (function () 
    {
        var clickCount = 0;
        return function () 
        {
            return ++clickCount;
        }
    })();
[/script]
[input type="button" value="Click Me" onclick="alert(incrementClickCount());" /]

Error handling in JavaScript
Use try/catch/finally to handle runtime errors in JavaScript. These runtime errors are called exceptions. An exception can occur for a variety of reasons. For example, referencing a variable or a method that is not defined can cause an exception. 

The JavaScript statements that can possibly cause exceptions should be wrapped inside a try block. When a specific line in the try block causes an exception, the control is immediately transferred to the catch block skipping the rest of the code in the try block.

JavaScript try catch example :
try 
{
    // Referencing a function that does not exist cause an exception
    document.write(sayHello());
    // Since the above line causes an exception, the following line will not be executed
    document.write("This line will not be executed");
}
// When an exception occurs, the control is transferred to the catch block
catch (e) 
{
    document.write("Description = " + e.description + "[br/]");
    document.write("Message = " + e.message + "[br/]");
    document.write("Stack = " + e.stack + "[br/][br/]");
}
document.write("This line will be executed");

Output :
// JavaScript try catch example.png

Please note : A try block should be followed by a catch block or finally block or both.

finally block is guaranteed to execute irrespective of whether there is an exception or not. It is generally used to clean and free resources that the script was holding onto during the program execution. For example, if your script in the try block has opened a file for processing, and if there is an exception, the finally block can be used to close the file.

JavaScript try catch finally example :

try 
{
    // Referencing a function that does not exist cause an exception
    document.write(sayHello());
    // Since the above line causes an exception, the following line will not be executed
    document.write("This line will not be executed");
}
// When an exception occurs, the control is transferred to the catch block
catch (e) 
{
    document.write("Description = " + e.description + "[br/]");
    document.write("Message = " + e.message + "[br/]");
    document.write("Stack = " + e.stack + "[br/][br/]");
}
finally 
{
    document.write("This line is guaranteed to execute");
}

Output : 
JavaScript try catch finally example.png

Syntax errors and exceptions in JavaScript
try/catch/finally block can catch exceptions but not syntax errors.

Example : In the example, below we have a syntax error - missing the closing parentheses. The associated catch block will not catch the syntax errors.
try 
{
    alert("Hello";
}
catch (e) 
{
    document.write("JavaScript syntax errors cannot be caught in the catch block");       
}

JavaScript throw statement : Use the throw statement to raise a customized exceptions. 

JavaScript throw exception example :
function divide() 
{
    var numerator = Number(prompt("Enter numerator"));
    var denominator = Number(prompt("Enter denominator"));

    try 
    {
        if (denominator == 0) 
        {
            throw {
                error: "Divide by zero error",
                message: "Denominator cannot be zero"
            };
        }
        else 
        {
            alert("Result = " + (numerator / denominator));
        }

    }
    catch (e) 
    {
        document.write(e.error + "[br/]");
        document.write(e.message + "[br/]");
    }
}

divide();

JavaScript window onerror event
In general we use try/catch statement to catch errors in JavaScript. If an error is raised by a statement that is not inside a try...catch block, the onerror event is fired.

Assign a function to window.onerror event that you want to be executed when an error is raised as shown below. The function that is associated as the event handler for the onerror event has three parameters:

message Specifies the error message.
URL Specifies the location of the file where the error occurred.
line Specifies the line number where the error occurred.

JavaScript window onerror event example

window.onerror = function (message, url, line) 
{
    alert("Message : " + message + "\nURL : " + url + "\nLine Number : " + line);
    // Return true to supress the browser error messages (like in older versions of Internet Explorer)
    return true;
}

NonExistingFunction();

If the error is handled by a try/catch statement, then the onerror event is not raised. onerror event is raised only when there is an unhandled exception.
window.onerror = function (message, url, line) 
{
    alert("Message : " + message + "\nURL : " + url + "\nLine Number : " + line);
    // Return true to supress the browser error messages (like in older versions of Internet Explorer)
    return true;
}

try 
{
    NonExistingFunction();
}
catch (e) 
{
    document.write(e.message);    
}

Output : 'NonExistingFunction' is undefined 

onerror event handler method can also be used with HTML elements : In the example below, since the image is not existing and cannot be found we get "There is a problem loading the image" error.
[script type="text/javascript"]
    function imageErrorHandler() 
    {
        alert("There is a problem loading the image");
    }
[/script]
[img src="NonExistingImage.jpg" onerror="imageErrorHandler()" /]

Working with dates in javascript
To create date object in JavaScript use Date() constructor

The following example writes the current Date and Time to the web page
document.write(new Date());

If the Date() constructor is used without any arguments, it returns the current date and time. To create a date object with specific dates there are 2 ways.

Creating a specific date object in JavaScript using a date string
var dateOfBirth = new Date("January 13, 1980 11:20:00");
document.write(dateOfBirth);

You can also create a specific date object using number for year, month, day, hours, minutes, seconds, & milliseconds. The syntax is shown below.
var dateOfBirth = new Date(year, month, day, hours, minutes, seconds, milliseconds);

Example :
var dateOfBirth = new Date(1980, 0, 13, 11, 20, 0, 0);
document.write(dateOfBirth);

Please note : In JavaScript month numbers start from ZERO. So if you want the month of march then use 2 instead of 3.

The above code produces the following output on my machine, because I have (UTC) Dublin, Edinburgh, Lisbon, London time zone selected on my machine
Sun Jan 13 1980 11:20:00 GMT+0000 (GMT Standard Time) 

If you have a different time zone selected on your computer, you may get a slightly different result. For example if you have (UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi time zone selected, the result will be as shown below
Sun Jan 13 1980 11:20:00 GMT+0530 (India Standard Time)

Some useful Date object methods in JavaScript
getFullYear() - Returns the full year (all the four digits)

Example : The following example returns 1980
var year = new Date(1980, 0, 13, 11, 20, 0, 0).getFullYear();
document.write(year);

getMonth() - Returns the month number (from 0-11)

Example : The following example returns 0 (for January)
var month = new Date(1980, 0, 13, 11, 20, 0, 0).getMonth();
document.write(month);

You can use the following code to get the month name from the month number in Javascript. The following example returns January.
function getMonthNameFromNumber(monthNumber) 
{
    var monthNames = ["January", "February", "March", "April",
                        "May", "June", "July", "August", "September", 
                        "October", "November", "December"];
    return monthNames[monthNumber];
}

var monthName = getMonthNameFromNumber(new Date(1980, 0, 13, 11, 20, 0, 0).getMonth());
document.write(monthName);

getDate() - Returns the day of the month (from 1-31)

Example : The following example returns 13
var dayOfMonth = new Date(1980, 0, 13, 11, 20, 0, 0).getDate();
document.write(dayOfMonth);

getDay() - Returns the day number of the week (from 0-6). 0 is sunday, 1 is monday and so on.

Example : The following example returns 0
var dayOfWeek = new Date(1980, 0, 13, 11, 20, 0, 0).getDay();
document.write(dayOfWeek);

You can use the following code to get the day of the week from the day number in Javascript. The following example returns Sunday.
function getWeekDayNameFromNumber(dayNumber) 
{
    var weekDays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    return weekDays[dayNumber];
}

var weekdayName = getWeekDayNameFromNumber(new Date(1980, 0, 13, 11, 20, 0, 0).getDay());
document.write(weekdayName);

You also have the following methods that return the time parts of the date object
getHours() - Returns the hour (from 0-23)
getMinutes() - Returns the minutes (from 0-59)
getSeconds() - Returns the seconds (from 0-59)
getMilliseconds() - Returns the milliseconds (from 0-999)

How to convert date in javascript to dd/mm/yyyy format
function formatDate(date) 
{
    var day = date.getDate();
    if (day [ 10) 
    {
        day = "0" + day;
    }

    var month = date.getMonth() + 1;
    if (month [ 10) 
    {
        month = "0" + month;
    }

    var year = date.getFullYear();

    return day + "/" + month + "/" + year;
}

document.write(formatDate(new Date()));

If you don't want ZERO (0) before a single digit month or day number, then modify the formatDate() function as shown below.
function formatDate(date) 
{
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    return day + "/" + month + "/" + year;
}

document.write(formatDate(new Date()));

JavaScript timing events
In JavaScript a piece of code can be executed at specified time interval. For example, you can call a specific JavaScript function every 1 second. This concept in JavaScript is called timing events. 

The global window object has the following 2 methods that allow us to execute a piece of JavaScript code at specified time intervals.

setInterval(func, delay) - Executes a specified function, repeatedly at specified time interval. This method has 2 parameters. The func parameter specifies the name of the function to execute. The delay parameter specifies the time in milliseconds to wait before calling the specified function.

setTimeout(func, delay) - Executes a specified function, after waiting a specified number of milliseconds. This method has 2 parameters. The func parameter specifies the name of the function to execute. The delay parameter specifies the time in milliseconds to wait before calling the specified function. The actual wait time (delay) may be longer.

Let's understand timing events in JavaScript with an example. The following code displays current date and time in the div tag.

[div id="timeDiv" ][/div]
[script type="text/javascript"]
    function getCurrentDateTime() {
        document.getElementById("timeDiv").innerHTML = new Date();
    }

    getCurrentDateTime();
[/script]

At the moment the time is static. To make the time on the page dynamic modify the script as shown below. Notice that the time is now updated every second. In this example, we are using setInterval() method and calling getCurrentDateTime() function every 1000 milli-seconds.

[div id="timeDiv" ][/div]
[script type="text/javascript"]
    setInterval(getCurrentDateTime, 1000);

    function getCurrentDateTime() {
        document.getElementById("timeDiv").innerHTML = new Date();
    }
[/script]

clearInterval(intervalID) - Cancels the repeated execution of the method that was set up using setInterval() method. intervalID is the identifier of the repeated action you want to cancel. This ID is returned from setInterval() method. The following example demonstrates the use of clearInterval() method.

Starting and stopping the clock with button click : In this example, setInterval() method returns the intervalId which is then passed to clearInterval() method. When you click the "Start Clock" button the clock is updated with new time every second, and when you click "Stop Clock" button it stops the clock.

[div id="timeDiv" ][/div]
[br /]
[input type="button" value="Start Clock" onclick="startClock()" /]
[input type="button" value="Stop Clock" onclick="stopClock()" /]
[script type="text/javascript"]
    var intervalId;

    function startClock() {
        intervalId = setInterval(getCurrentDateTime, 1000);
    }

    function stopClock() {
        clearInterval(intervalId);
    }

    function getCurrentDateTime() {
        document.getElementById("timeDiv").innerHTML = new Date();
    }

    getCurrentDateTime();
[/script]

Now let's look at example of using setTimeout() and clearTimeout() functions. The syntax and usage of these 2 functions is very similar to setInterval() and clearInterval(). 

Countdown timer example : When we click "Start Timer" button, the value 10 displayed in the textbox must start counting down. When click "Stop Timer" the countdown should stop. When you click "Start Timer" again, it should start counting down from where it stopped and when it reaches ZERO, it should display done in the textbox and function should return.

// timing events in javascript.png

[input type="text" value="10" id="txtBox" /]
[br /][br /]
[input type="button" value="Start Timer" onclick="startTimer('txtBox')" /]
[input type="button" value="Stop Timer" onclick="stopTimer()" /]
[script type="text/javascript"]
    var intervalId;

    function startTimer(controlId) 
    {
        var control = document.getElementById(controlId);
        var seconds = control.value;
        seconds = seconds - 1;
        if (seconds == 0) 
        {
            control.value = "Done";
            return;
        }
        else 
        {
            control.value = seconds;
        }

        intervalId = setTimeout(function () { startTimer('txtBox'); }, 1000);
    }

    function stopTimer() 
    {
        clearTimeout(intervalId);
    }
[/script]

Events in JavaScript
What is an event
An event is a signal from the browser that something has happened. For example, 
1. When a user clicks on an HTML element, click event occurs
2. When a user moves the mouse over an HTML element, mouseover event occurs

When events occur, we can execute JavaScript code or functions in response to those events. To do this we need to associate JavaScript code or functions to the events. The function that executes in response to an event is called event handler.

In JavaScript, there are several ways to associate an event handler to the event
1. Using the attributes of an HTML tag
2. Using DOM object property
3. Using special methods

In this video we will discuss associating event handler methods to events using the attributes of HTML tags. 

In the following example, the code to execute in response to onmouseover & onmouseout events is set directly in the HTML markup. The keyword "this" references the current element. In this example "this" references the button control.

[input type="button" value="Click me" id="btn" 
onmouseover="this.style.background= 'red'; this.style.color = 'yellow'" 
onmouseout="this.style.background= 'black'; this.style.color = 'white'" /]

The above example, can be rewritten as shown below. In this case the code to execute in response to the event is placed inside a function and then the function is associated with the event.

[input type="button" value="Click me" id="btn" 
onmouseover="changeColorOnMouseOver()" 
onmouseout="changeColorOnMouseOut()" /]

[script type="text/javascript"]
    function changeColorOnMouseOver() 
    {
        var control = document.getElementById("btn");
        control.style.background = 'red';
        control.style.color = 'yellow';
    }

    function changeColorOnMouseOut() 
    {
        var control = document.getElementById("btn");
        control.style.background = 'black';
        control.style.color = 'white';
    }
[/script]

Events are very useful in real-world applications. For example they can be used to 
1. Display confirmation dialog box on submitting a form
2. Form data validation and many more

How to show confirmation dialog in JavaScript

[input type="submit" value="Submit" id="btn" onclick="return confirmSubmit()" /]
[script type="text/javascript"]
    function confirmSubmit() 
    {
        if (confirm("Are you sure you want to submit")) 
        {
            alert("You selected OK");
            return true;
        }
        else 
        {
            return false;
            confirm("You selected cancel");
        }
    }
[/script]

JavaScript form validation example : In this example, both First Name and Last Name fields are required fields. When you type the first character in any of the textbox, the background colour is automatically changed to green. If you delete all the characters you typed or if you leave the textbox without entering any characters the background colour changes to red indicating the field is required. We made this possible using onkeyup and onblur events.

onkeyup occurs when the user releases a key.
onblur occurs when an element loses focus.

[table]
    [tr]
        [td]
            First Name
        [/td]
        [td]
            [input type="text" id="txtFirstName" onkeyup="validateRequiredField('txtFirstName')"
                   onblur="validateRequiredField('txtFirstName')"/]
        [/td]
    [/tr]
    [tr]
        [td]
            Last Name
        [/td]
        [td]
            [input type="text" id="txtLastName" onkeyup="validateRequiredField('txtLastName')" 
                   onblur="validateRequiredField('txtLastName')"/]
        [/td]
    [/tr]
[/table]
[script type="text/javascript"]
    function validateRequiredField(controlId) 
    {
        var control = document.getElementById(controlId);
        control.style.color = 'white';
        if (control.value == "") 
        {
            control.style.background = 'red';
        }
        else 
        {
            control.style.background = 'green';
        }
    }
[/script]

Event handlers in JS 
In JavaScript there are several ways to associate an event handler to the event. In Part 36, we discussed, associating event handler methods to events using the attributes of HTML tags. In this video we will discuss using DOM object property to assign event handlers to events.

First let us understand, what is DOM
DOM stands for Document Object Model. When a browser loads a web page, the browser creates a Document Object Model of that page. The HTML DOM is created as a tree of Objects. 

Example : 
[html]
    [head]
        [title]My Page Title[/title]
    [/head]
    [body]
        [script type="text/javascript"]
        [/script]        
        [div]
            [h1]This is browser DOM[/h1]
        [/div]
    [/body]
[/html]

JavaScript can be used to access and modify these DOM objects and their properties. For example, you can add, modify and remove HTML elements and their attributes. Along the same lines, you can use DOM object properties to assign event handlers to events. We will discuss the DOM object in detail in a later video session.

We will continue with the same examples that we worked with in Part 36. Notice that in this case, we are assigning event handlers using the DOM object properties (onmouseover & onmouseout) instead of using the attributes of the HTML tag. We are using this keyword to reference the current HTML element. In this example "this" references the button control.

[input type="button" value="Click me" id="btn"/]
[script type="text/javascript"]
    document.getElementById("btn").onmouseover = changeColorOnMouseOver;
    document.getElementById("btn").onmouseout = changeColorOnMouseOut;

    function changeColorOnMouseOver() 
    {
        this.style.background = 'red';
        this.style.color = 'yellow';
    }

    function changeColorOnMouseOut() 
    {
        this.style.background = 'black';
        this.style.color = 'white';
    }
[/script]


The following example is same as the above. In this case we are assigning an anonymous function to onmouseover & onmouseout properties.
[input type="button" value="Click me" id="btn" /]
[script type="text/javascript"]
    document.getElementById("btn").onmouseover = function () 
    {
        this.style.background = 'red';
        this.style.color = 'yellow';
    }

    document.getElementById("btn").onmouseout = function () 
    {
        this.style.background = 'black';
        this.style.color = 'white';
    }
[/script]

If an event handler is assigned using both, i.e an HTML attribute and DOM object property, the handler that is assigned using the DOM object property overwrites the one assigned using HTML attribute. Here is an example.
[input type="button" value="Click me" id="btn" onclick="clickHandler1()"/]
[script type="text/javascript"]
    document.getElementById("btn").onclick = clickHandler2;

    function clickHandler1() 
    {
        alert("Handler set using HTML attribute");
    }

    function clickHandler2() 
    {
        alert("Handler set using DOM object property");
    }
[/script]

Using this approach you can only assign one event handler method to a given event. The handler that is assigned last wins. In the following example, Handler2() is assigned after Handler1. So Handler2() owerites Handler1().
[input type="button" value="Click me" id="btn"/]
[script type="text/javascript"]
    document.getElementById("btn").onclick = clickHandler1;
    document.getElementById("btn").onclick = clickHandler2;

    function clickHandler1() 
    {
        alert("Handler 1");
    }

    function clickHandler2() 
    {
        alert("Handler 2");
    }
[/script]

addeventlistener and removeeventlistener in JavaScript
assigning event handlers in JavaScript using the following special methods
addEventListener
removeEventListener
attachEvent
detachEvent

Internet Explorer 9 (and later versions) & all the other modern browsers support addEventListener() and removeEventListener() methods. 

Sytnax for assigning event handler using addEventListener() method
element.addEventListener(event, handler, phase)

Sytnax for removing event handler using removeEventListener() method
element.removeEventListener(event, handler, phase)

Please note :  The third parameter phase is usually set to false as it is not used.

Example : In this example, we are passing values for all the 3 parameters including phase. 

[input type="button" value="Click me" id="btn"/]
[script type="text/javascript"]
    btn.addEventListener("mouseover", changeColorOnMouseOver, false);
    btn.addEventListener("mouseout", changeColorOnMouseOut, false);

    function changeColorOnMouseOver() 
    {
        this.style.background = 'red';
        this.style.color = 'yellow';
    }

    function changeColorOnMouseOut() 
    {
        this.style.background = 'black';
        this.style.color = 'white';
    }
[/script]

Since the third parameter "phase" is optional you can omit it if you wish.
btn.addEventListener("mouseover", changeColorOnMouseOver);
btn.addEventListener("mouseout", changeColorOnMouseOut);

Example : This example demonstrates removing event handlers.

[input type="button" value="Click me" id="btn"/]
[input type="button" value="Remove Event Handlers" onclick="removeEventHandlers()" /]
[script type="text/javascript"]
    btn.addEventListener("mouseover", changeColorOnMouseOver);
    btn.addEventListener("mouseout", changeColorOnMouseOut);

    function changeColorOnMouseOver() 
    {
        this.style.background = 'red';
        this.style.color = 'yellow';
    }

    function changeColorOnMouseOut() 
    {
        this.style.background = 'black';
        this.style.color = 'white';
    }

    function removeEventHandlers() 
    {
        btn.removeEventListener("mouseover", changeColorOnMouseOver);
        btn.removeEventListener("mouseout", changeColorOnMouseOut);
    }
[/script]

Using this approach you can assign more than one event handler method to a given event. The order in which handler methods are executed is not defined. In this example, 2 event handler methods (clickHandler1 & clickHandler3) are assigned to click event of the button control. When you click the button both the handler methods are executed.

[input type="button" value="Click me" id="btn"/]
[script type="text/javascript"]
    btn.addEventListener("click", clickHandler1);
    btn.addEventListener("click", clickHandler2);

    function clickHandler1() 
    {
        alert("Handler 1");
    }

    function clickHandler2() 
    {
        alert("Handler 2");
    }
[/script]

attachEvent() and detachEvent() methods only work in Internet Explorer 8 and earlier versions. 

Sytnax for assigning event handler using attachEvent() method
element.attachEvent( "on"+event, handler)

Sytnax for removing event handler using detachEvent() method
element.detachEvent( "on"+event, handler)

Example : This example will only work in Internet Explorer 8 and earlier versions.

[input type="button" value="Click me" id="btn"/]
[script type="text/javascript"]
    btn.attachEvent("onclick", clickEventHandler);

    function clickEventHandler() 
    {
        alert("Click Handler");
    }
[/script]

Cross browser solution : For the above example to work in all browsers, modify the script as shown below.

[input type="button" value="Click me" id="btn"/]
[script type="text/javascript"]

    if (btn.addEventListener) 
    {
        btn.addEventListener("click", clickEventHandler);
    }
    else 
    {
        btn.attachEvent("onclick", clickEventHandler);
    }

    function clickEventHandler() 
    {
        alert("Click Handler");
    }
[/script]

JavaScript event object
Whenever an event (like click, mouseover, mouseout etc) occurs, the relevant data about that event is placed into the event object. For example, the event object contains event data like, the X and Y coordinates of the mouse pointer when the event occurred, the HTML element that fired the event, which mouse button is clicked etc.

Obtaining the event object is straightforward. The event object is always passed to the event handler method. Let us understand this with an example. When we click the button, we want to capture the following event data
1. Event name
2. Mouse X coordinate when the event occured
3. Mouse Y coordinate when the event occured
4. The control that raised the event
5. The HTML tag name that raised the event

Notice that in the example below, we are passing event object as a parameter to the event handler method. The type property gives us the event name that occured. clientX and clientY properties return the X and Y coordinates of the mouse pointer. Target property returns the HTML element that raised the event. Target property is supported by all modern browsers and Internet Explorer 9 and above. The following code will not work in Internet Explorer 8 and earlier versions. In addition to click event, the following example returns mouseover and mouseout event data.

[input type="button" value="Click me" id="btn" 
       onclick="displayEventDetails(event)" 
       onmouseover="displayEventDetails(event)" 
       onmouseout="displayEventDetails(event)" /]
[br /][br /]
[div id="resultDiv"][/div]
[script type="text/javascript"]
    function displayEventDetails(event) 
    {
        var eventDetails = "Event = " + event.type + "[br/] X = " + event.clientX + "[br/]Y = " +
                            event.clientY + "[br/]Target Type = " + event.target.type +
                            "[br/]Target Tag Name = " + event.target.tagName;

        document.getElementById("resultDiv").innerHTML = eventDetails;
    }
[/script]

The following code works in all browsers including Internet Explorer 8 and earlier versions. IE 8 and earlier versions use srcElement property to return the HTML element that raised the event. IE 9 and all the other modern browsers use target property. So this is a cross browser solution.

[input type="button" value="Click me" id="btn" onclick="displayEventDetails(event)" 
       onmouseover="displayEventDetails(event)" 
       onmouseout="displayEventDetails(event)" /]
[br /][br /]
[div id="resultDiv"][/div]
[script type="text/javascript"]
    function displayEventDetails(event) 
    {
        var sourceElement;

        if (event.srcElement) 
        {
            sourceElement = event.srcElement;
        }
        else 
        {
            sourceElement = event.target;
        }

        var eventDetails = "Event = " + event.type + "[br/] X = " + event.clientX + "[br/]Y = " +
                            event.clientY + "[br/]Target Type = " + sourceElement.type +
                            "[br/]Target Tag Name = " + sourceElement.tagName;

        document.getElementById("resultDiv").innerHTML = eventDetails;
    }
[/script]

The following example retrieves mousemove event data. Notice that as you move the mouse pointer over the button, the X & Y coordinates changes.

[input type="button" value="Click me" id="btn" onmousemove="displayEventDetails(event)" /]
[br /][br /]
[div id="resultDiv"][/div]
[script type="text/javascript"]
    function displayEventDetails(event) 
    {
        var sourceElement;

        if (event.srcElement) 
        {
            sourceElement = event.srcElement;
        }
        else 
        {
            sourceElement = event.target;
        }

        var eventDetails = "Event = " + event.type + "[br/] X = " + event.clientX + "[br/]Y = " +
                            event.clientY + "[br/]Target Type = " + sourceElement.type +
                            "[br/]Target Tag Name = " + sourceElement.tagName;

        document.getElementById("resultDiv").innerHTML = eventDetails;
    }
[/script]


Event bubbling in JavaScript
What is event bubbling 
Let us understand this with an example. HTML elements can be nested inside each other. For example a button element can be nested inside a span element and the span element inturn can be nested inside a div element.

Notice that we have onclick attribute specified for all the 3 elements.

[html]
[head]
    [style type="text/css"]
        .styleClass
        {
            display: table-cell;
            border: 1px solid black;
            padding: 20px;
            text-align: center;
        }
    [/style]
[/head]
[body]
    [div class="styleClass" onclick="alert('Div click handler')"]DIV element 
        [span class="styleClass" onclick="alert('Span click handler')"]Span element
            [input type="button" value="Click me" onclick="alert('Button click handler')" /]
        [/span]
    [/div]
[/body]
[/html]

A click on the button, causes a click event to be fired on the button. The button click event handler method handles the event. The click event then bubbles up to the button element parent (span element), which is handled by the span element event handler method. The click event then bubbles up to the span element parent (div element). This is called event bubbling.

Notice that if you click on the [span] element, it's event handler and it's parent([div]) element event handler are called. If you click on the [div] element, just the [div] element event handler method is called. So, the event bubbling process starts with the element that triggered the event and then bubbles up to the containing elements in the hierarchy.

The following example is similar to the one above, except we removed the onclick attribute from button and span elements. Because of event bubbling, when you click on the button or the span element, the event gets handled by the div element handler.

[html]
[head]
    [style type="text/css"]
        .styleClass
        {
            display: table-cell;
            border: 1px solid black;
            padding: 20px;
            text-align: center;
        }
    [/style]
[/head]
[body]
    [div class="styleClass" onclick="alert('Click event handled by DIV element')"]DIV element 
        [span class="styleClass"]Span element
            [input type="button" value="Click me"/]
        [/span]
    [/div]
[/body]
[/html]

When the event gets bubbled, the keyword this references the current element to which the event is bubbled. In the example below, we are using "this" keyword to reference the current div element and change it's border color. When you click on the innermost [div] element, all the 3 [div] elements border get changed due to event bubbling.

[html]
[head]
    [style type="text/css"]
        .divStyle
        {
            display: table-cell;
            border: 5px solid black;
            padding: 20px;
            text-align: center;
        }
    [/style]
[/head]
[body]
    [div id="DIV1" class="divStyle"]
        DIV 1
        [div id="DIV2" class="divStyle"]
            DIV 2
            [div id="DIV3" class="divStyle"]
                DIV 3
            [/div]
        [/div]
    [/div]
    [script type="text/javascript"]
        var divElements = document.getElementsByTagName('div');

        for (var i = 0; i [ divElements.length; i++) {
            divElements[i].onclick = function () {
                this.style.borderColor = "red";
                alert(this.getAttribute("id") + " backgound changed");
            }
        }
    [/script]
[/body]
[/html]

Stopping event bubbling : If you don't want the event to be bubbled up, you can stop it. 

With Internet Explorer 8 and earlier versions
event.cancelBubble = true

With Internet Explorer 9 (and later versions) & all the other browsers
event.stopPropagation()

JavaScript event capturing
Event capturing is the opposite of event bubbling. We discussed event bubbling in detail in Part 40 of JavaScript tutorial.

With event bubbling the event bubbles up from the inner most element to the outer most element in the DOM hierarchy. With event capuring the opposite happens, the event gets captured from the outer most element to innermost element. In real world event capturing is rarely used. Let us understand this with an example.

In the following example we have 3 [div] nested elements. Notice that we are using addEventListener() method to assign event handler to each [div] element. To enable event capturing we have set the third parameter (phase) of addEventListener() method to true. Now when you click on the innermost [div] (DIV3), notice that the events are fired from the outermost [div] to innermost [div] (DIV1 =] DIV 2 =] DIV 3).

[html]
[head]
    [style type="text/css"]
        .divStyle
        {
            display: table-cell;
            border: 5px solid black;
            padding: 20px;
            text-align: center;
        }
    [/style]
[/head]
[body]
    [div id="DIV1" class="divStyle"]
        DIV 1
        [div id="DIV2" class="divStyle"]
            DIV 2
            [div id="DIV3" class="divStyle"]
                DIV 3
            [/div]
        [/div]
    [/div]
    [script type="text/javascript"]
        var divElements = document.getElementsByTagName('div');

        for (var i = 0; i [ divElements.length; i++) 
        {
            divElements[i].addEventListener("click", clickHandler, true);
        }

        function clickHandler() {
            alert(this.getAttribute("id") + " click event handled");
        }
    [/script]
[/body]
[/html]

Please note : IE8 and earlier versions does not support addEventListener() method. This implies that event capturing is not supported in IE8 and earlier versions, and hence the above code will not work in IE 8 and earlier versions.

Stopping event capturing : Stopping event capturing is very similar to stopping event bubbling. With the example below, when you click on any [div] element notice that DIV 1 element handles the click event and it does not get captured down.

[html]
[head]
    [style type="text/css"]
        .divStyle
        {
            display: table-cell;
            border: 5px solid black;
            padding: 20px;
            text-align: center;
        }
    [/style]
[/head]
[body]
    [div id="DIV1" class="divStyle"]
        DIV 1
        [div id="DIV2" class="divStyle"]
            DIV 2
            [div id="DIV3" class="divStyle"]
                DIV 3
            [/div]
        [/div]
    [/div]
    [script type="text/javascript"]
        var divElements = document.getElementsByTagName('div');

        for (var i = 0; i [ divElements.length; i++) 
        {
            divElements[i].addEventListener("click", clickHandler, true);
        }

        function clickHandler(event) 
        {
            event.stopPropagation();
            alert(this.getAttribute("id") + " click event handled");
        }
    [/script]
[/body]
[/html]

Using addEventListener() method with last argument set to true is the only way to enable event capturing. If the thid parameter (phase) is set to true event capturing is enabled and if it is set to false event bubbling is enabled. If you want both even bubbling and capturing to be enabled, then assign handlers 2 times, once with the phase parameter set to false and once with the phase parameter set to true as shown below.

[html]
[head]
    [style type="text/css"]
        .divStyle
        {
            display: table-cell;
            border: 5px solid black;
            padding: 20px;
            text-align: center;
        }
    [/style]
[/head]
[body]
    [div id="DIV1" class="divStyle"]
        DIV 1
        [div id="DIV2" class="divStyle"]
            DIV 2
            [div id="DIV3" class="divStyle"]
                DIV 3
            [/div]
        [/div]
    [/div]
    [script type="text/javascript"]
        var divElements = document.getElementsByTagName('div');

        for (var i = 0; i [ divElements.length; i++) 
        {
            divElements[i].addEventListener("click", clickHandler, false);
            divElements[i].addEventListener("click", clickHandler, true);
        }

        function clickHandler() {
            alert(this.getAttribute("id") + " click event handled");
        }
    [/script]
[/body]
[/html]

With both event capturing and bubbling enabled, events are first captured from the outermost element to the innermost element and then bubbles up from the innermost to the outermost element.

Preventing browser default action
In this video we will discuss how to prevent browser default action. First let's look at some of the browser default actions. For example,
1. When you click on a link, the browser navigates to the page specified in the link
2. When you right click on a web page, the browser displays the context menu

In some situations you may want to prevent these default actions of the browser. For example some of the websites prevent you from right clicking on the page. Disabling right click is annoying users. Many people say they disabled right click for security, because they do not want their content to be copied. But if you disable JavaScript in the browser, you will still be able to right click and copy the content. So you are achieving nothing by disabling right click. 

Having said that, now let us see how to prevent the context menu from appearing when you right click on the web page. There are 2 ways you can do this. 

Using oncontextmenu attribute of the body element to disable right click
[html]
    [head]
    [/head]
    [body oncontextmenu="return false"]
        [h1]On this page right click is disabled[/h1]    
    [/body]
[/html]

Using the event object to disable right click 

IE 8 and earlier versions 
event.returnValue = false;

IE 9 & later versions and all other browsers
event.preventDefault();

[h1]On this page right click is disabled[/h1]
[script type="text/javascript"]
    document.oncontextmenu = disableRightClick;

    function disableRightClick(event) 
    {
        event = event || window.event;

        if (event.preventDefault) 
        {
            event.preventDefault();
        }
        else 
        {
            event.returnValue = false
        }
    }
[/script]

When you click on a link, how to prevent the browser from navigating to the page specified in the link

[a href="http://pragimtech.com" onclick="return false"]
    Clicking on the link will not take you to PragimTech 
[/a]

OR

[a id="linkElement" href="http://pragimtech.com" onclick="preventLinkNavigation(event)"]
    Clicking on the link will not take you to PragimTech 
[/a]

[script type="text/javascript"]
    function preventLinkNavigation(event) 
    {
        event = event || window.event;

        if (event.preventDefault) 
        {
            event.preventDefault();
        }
        else 
        {
            event.returnValue = false
        }
    }
[/script]

JavaScript to detect which mouse button is clicked
JavaScript to detect which mouse button is clicked

In this video, we will discuss how to use JavaScript and detect which mouse button is clicked. 

Depending on the browser, event.button or event.which properties of the event object are used to determine which mouse button is clicked. 

IE 8 & earlier versions use event.button property
Left Button 1
Middle Button 4
Right Button 2

IE 9 & later versions and most other W3C compliant browsers use event.which property
Left Button 1
Middle Button 2
Right Button 3

Depending on the browser used, the following code returns left, middle and right click codes.

[input type="button" value="Click Me" onmouseup="getMouseClickCode(event)" /]
[input type="button" value="Clear" onclick="clearText()" /]
[br /]
[br /]
[textarea id="txtArea" rows="3" cols="10"][/textarea]

[script type="text/javascript"]
    function clearText() 
    {
        document.getElementById("txtArea").value = "";
    }

    function getMouseClickCode(event) 
    {
        if (event.which) 
        {
            document.getElementById("txtArea").value += "event.which = " + event.which + "\r\n";
        }
        else 
        {
            document.getElementById("txtArea").value += "event.button = " + event.button + "\r\n";
        }
    }

    document.oncontextmenu = disableRightClick;

    function disableRightClick(event) 
    {
        event = event || window.event;

        if (event.preventDefault) 
        {
            event.preventDefault();
        }
        else 
        {
            event.returnValue = false
        }
    }
[/script]

Test the above script is tested with Google chrome or IE 9 (or later version). Notice that these browsers support event.which property. 

Test the above script is tested with IE 8 (or earlier version). Notice that IE & earlier versions support event.button property. 

The following JavaScript code detects which mouse button is clicked. It works in all versions of IE and most other W3C complaint browsers.

[script type="text/javascript"]
    function whichMouseButtonClicked(event) 
    {
        var whichButton;
        if (event.which) 
        {
            switch (event.which) 
            {
                case 1:
                    whichButton = "Left Button Clicked";
                    break;
                case 2:
                    whichButton = "Middle Button Clicked";
                    break;
                case 3:
                    whichButton = "Right Button Clicked";
                    break;
                default:
                    whichButton = "Invalid Button Clicked";
                    break;
            }
        }
        else
        {
            switch (event.button) 
            {
                case 1:
                    whichButton = "Left Button Clicked";
                    break;
                case 4:
                    whichButton = "Middle Button Clicked";
                    break;
                case 2:
                    whichButton = "Right Button Clicked";
                    break;
                default:
                    whichButton = "Invalid Button Clicked";
                    break;
            }
        }

        alert(whichButton);
    }

    document.oncontextmenu = disableRightClick;

    function disableRightClick(event) 
    {
        event = event || window.event;

        if (event.preventDefault) 
        {
            event.preventDefault();
        }
        else 
        {
            event.returnValue = false
        }
    }
[/script]
[button onmouseup="whichMouseButtonClicked(event)"]Click Me[/button]

JavaScript mouse events
In this video we will discuss the commonly used JavaScript mouse events. Most browsers support these events.

mouseover - Occurs when the mouse pointer is moved over an element
mouseout - Occurs when the mouse pointer is moved out of an element
mousemove - Occurs when the mouse pointer is moving while it is over an element
mouseup - Occurs when the mouse button is released over an element
mousedown - Occurs when the mouse button is pressed over an element
click - Occurs when the mouse button is clicked. mousedown, mouseup & click events occur in sequence
dblclick - Occurs when the mouse button is double-clicked. mousedown, mouseup, mousedown, mouseup, click & dblclick events occur in sequence
contextmenu - Occurs when the mouse right button is clicked. mousedown, mouseup & contextmenu events occur in sequence

Here is an example which logs the mouse events to textarea element as they occur.

[input type="button" value="Single, Double or Right Click" onclick="logEvent(event)" 
       onmousedown="logEvent(event)" onmouseup="logEvent(event)" onmouseover="logEvent(event)" 
       onmouseout="logEvent(event)" ondblclick="logEvent(event)" oncontextmenu="logEvent(event)" /]
[input type="button" value="Clear" onclick="clearText()"/]
[br /][br /]
[textarea id="txtArea" rows="10" cols="20"][/textarea]
[script type="text/javascript"]
    function logEvent(event) 
    {
        event = event || window.event;
        document.getElementById("txtArea").value += event.type + "\r\n";
    }

    function clearText() 
    {
        document.getElementById("txtArea").value = "";
    }
[/script]

JavaScript popup window
To open a popup window, use window.open() method. All the parameters are optional.
window.open(URL, name, features, replace)

URL - URL of the page to open. If URL is not specified, a new window with about:blank is opened
name - Specifies the target attribute or the name of the window. 
_blank - URL is loaded into a new window. This is the default value if not specified.
_parent - URL is loaded into the parent frame
_self - URL replaces the current page
_top - URL replaces any framesets that may be loaded
name - name of the window
features - Must be a comma-separated list. Some of the browsers does not support these features.
menubar (yes/no) - Shows or hides the browser menu
toolbar (yes/no) - Shows or hides the browser navigation bar
location (yes/no) - Shows or hides the address field
status (yes/no) - Shows or hides the status bar
resizable (yes/no) - Whether or not the window is resizable
scrollbars (yes/no) - Whether or not to display scroll bars
top(pixels) - The top position of the window
left(pixels) - The left position of the window
height (pixels) - The height of the new window
width (pixels) - The width of the new window

replace - Specifies whether the URL creates a new entry or replaces the current entry in the browser history. Works only if the url is loaded into the same window.
 true - URL replaces the current document in the browser history list
 false - URL creates a new entry in the browser history list

No parameters are passed to window.open() method. Since URL is not specified, a new window with about:blank will be opened.
[input type="button" value="Open popup" onclick="window.open()" /]

Most modern browsers open new tabs instead of separate windows. If you want to open the popup in a new window, one workaround I have found is to specify the URL, name, and features(height and width) parameters. This may not work in all browsers and it also depends on user's browser preferences.
[input type="button" value="Open popup" onclick="window.open('http://google.com', '_blank', 'height=200,width=200')" /]

When name parameter is set to _self, the new window replaces the current window
[input type="button" value="Open popup" onclick="window.open('http://google.com', '_self')" /]

Specify where you want the new popup window to be positioned using top and left features.
[input type="button" value="Open popup" onclick="window.open('http://google.com', 'My Window', 'height=300,width=300, top=400, left=400')" /]

Disable scrollbars and resizing. Works in IE but not in Chrome.
[input type="button" value="Open popup" onclick="window.open('http://google.com', 'My Window', 'height=300,width=300, scrollbars=no, resizable=no')" /]

To close pouup use window.close() method.
[input type="button" value="Open popup" onclick="openPopup()" /]
[input type="button" value="Close popup" onclick="closePopup()" /]
[script type="text/javascript"]
    var popup;
    function openPopup() 
    {
        popup = window.open("http://google.com","My Window", "height=300,width=300")
    }

    function closePopup() 
    {
        popup.close();
    }
[/script]

Using regular expressions in JavaScript
What is a Regular Expression
A regular expression is a sequence of characters that forms a search pattern. 

Let us understand the use of regular expressions with an example. The following strings contain words and numbers. From the string we want to extract all the numbers. Bsically the program should work with any string.

Mark-9 Tim-890 Sam-10 Sara-9902
Result : 9, 890, 10, 9902

908ABC12XYZ34
Result : 908, 12, 34

$1 $2 $901 ABC(100)
Result : 1, 2, 901, 100

Here is what we want the page to do
1. User enters the string in the first textbox
2. When "Process String" button is clicked, the numbers should be extracted from the string and displayed in the text area element.

It will be very complex and error prone if we have to achieve this without using regular expressions.

[input type="text" id="txtBox" style="width:250px" /]
[br /][br /]
[input type="button" value="Process String" onclick="processString()" style="width:250px" /]
[br /][br /]
[textarea id="txtArea" rows="4" cols="30"][/textarea]
[script type="text/javascript"]
    function processString() 
    {
        // Clear the textarea element
        document.getElementById("txtArea").value = "";
        // Retrieve the user intput from the textbox
        var inputString = document.getElementById("txtBox").value;
        // Regular expression should be in 2 forward slashes //
        // Letter g at the end of the regular expression performs a global match
        // match() method returns all substrings that match the given regular expression
        var result = inputString.match(/\d+/g);

        if (result != null) {
            // Add the retrieved numbers to the textarea element
            for (var i = 0; i [ result.length; i++) {
                document.getElementById("txtArea").value += result[i] + "\r\n";
            }
        }
    }
[/script]

JavaScript strings and regular expressions
In JavaScript regular expressions can be used with the following string methods.
1. match()
2. replace()
3. split()
4. search()

Along with regular expressions you can use modifiers to specify the kind of search you want to perform.
g Global search
i Case-insensitive search
m Multiline search

Let us look at some examples of using the above methods with regular expressions 

Using regular expression with JavaScript string object's match() method. All the numbers in the string will be returned. The letter g at the end of the regular expression  performs a global match. If the letter g is omitted we will only get the first match.

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

document.write(string.match(/\d+/g));

Output : 1011011010,35,8912398912,45 

Using regular expression with JavaScript string object's replace() method. All the numbers in the string will be replaced with XXX.

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

document.write(string.replace(/\d+/g, "XXX"));

Output : Tom contact number is XXX. His age is XXX.Mark contact number is XXX. His age is XXX

Using regular expression with JavaScript string object's split() method. split() method breaks a string into an array of substrings. The following example breaks the string into an array of substrings wherever it finds a number.

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

document.write(string.split(/\d+/))

Output : Tom contact number is ,. His age is ,.Mark contact number is ,. His age is ,

Using regular expression with JavaScript string object's search() method. search() method returns the index of the match, or -1 if the search item is not found. search() method returns the index of the first matching item only. The following example returns the index of the first occurrence of a number in the string.

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

document.write(string.search(/\d+/))

Global case insensitive match using a regular expression

var string = "TOM contact number is 1011011010. tom is 35";
document.write(string.match(/tom/gi));

Output : TOM,tom

JavaScript RegExp object
There are 2 ways to create a regular expression in JavaScript

Using a regular expression literal
var regex = /\d+/g;

All the examples so far in this video series used regular expression literal to create a regular expression. Regular expressions created using regular expression literals are automatically compiled when the script is loaded. So if you know that the regular expression is not going to change then use this approach for better performance.

The following example replaces all the numbers with XXX.

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

document.write(string.replace(/\d+/g, "XXX"));

Output : Tom contact number is XXX. His age is XXX.Mark contact number is XXX. His age is XXX 


Using the constructor function of the RegExp object

var regexp = new RegExp("\\d+", "g");

Regular expressions created using the constructor function are compiled at runtime. Use this approach when the regular expression is expected to change.

Please note : Since the first argument of the RegExp constructor is a string, you have to escape the backslash.

The following example replaces all the numbers with XXX. 

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

var regexp = new RegExp("\\d+", "g");

document.write(string.replace(regexp, "XXX"));

Output : Tom contact number is XXX. His age is XXX.Mark contact number is XXX. His age is XXX 

Commonly used RegExp object properties

global     - returns true if the global modifier (g) is set, otherwise false
ignoreCase - returns true if the case-insensitive modifier (i) is set, otherwise false
multiline    - returns true if the multi-line modifier (m) is set, otherwise false
source     - Returns the text of the regular expression

Example : 

var regexp = new RegExp("\\d+", "gi");

document.write("g = " + regexp.global + "[br/]");
document.write("i = " + regexp.ignoreCase + "[br/]");
document.write("m = " + regexp.multiline + "[br/]");
document.write("source = " + regexp.source + "[br/]");

Commonly used RegExp object methods

exec() - Tests for a match in a given string and returns the first match if found otherwise null.
test() - Tests for a match in a gievn string and returns true or false
toString() - Returns the string value of the regular expression

exec() method returns the first match

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

var regexp = new RegExp("\\d+");
document.write(regexp.exec(string));

Output : 1011011010

To get all the matches call .exec() method repeatedly with the g flag as shown below

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

var regexp = new RegExp("\\d+", "g");
var result;

while ((result = regexp.exec(string)) != null) 
{
    document.write(result[0] + "[br/]");
}

The following example calls test() method of the RegExp object to check if the string contains numbers.

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

var regexp = new RegExp("\\d+", "g");
document.write("String contain numbers - " + regexp.test(string))

Output : String contain numbers - true


You can also call exec() and test() methods of the RegExp object as shown below

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

var regexp = /\d+/g;
document.write("String contain numbers - " + regexp.test(string))

OR

var string = "Tom contact number is 1011011010. His age is 35.";
string += "Mark contact number is 8912398912. His age is 45";

document.write("String contain numbers - " + /\d+/g.test(string))


Client side validation using regular expression
On most of the websites it is common to check if the format of the email is valid. Using regular expressions we can achieve this very easily.

Here is an example.
Email : [input type="text" id="txtEmail" onkeyup="validateEmail()" /] 
[script type="text/javascript"]
    function validateEmail() {
        var emailTextBox = document.getElementById("txtEmail");
        var email = emailTextBox.value;
        var emailRegEx = /^(([^[]()[\]\\.,;:\s@\"]+(\.[^[]()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        emailTextBox.style.color = "white";

        if (emailRegEx.test(email)) {
            emailTextBox.style.backgroundColor = "green";
        }
        else {
            emailTextBox.style.backgroundColor = "red";
        }
    }
[/script]

JavaScript and object oriented programming
JavaScript is object oriented programming language. The following are the 4 pillars of any object oriented programming language.  We will discuss examples of these in a later video session.
1. Inheritance
2. Encapsulation
3. Abstraction
4. Polymorphism

In this video let's focus on creating objects in JavaScript. Objects in JavaScript can be broadly classified into 2 categories.
1. Standard built-in objects
2. Custom objects

Standard built-in objects : So far in this video series, we have already seen many of the JavaScript standard built-in objects. Examples include string, array, RegExp, Date etc. In the example below we are creating Date object using the Date constructor function and then using it's getFullYear() method to get the year.

var currentDate = new Date();
document.write(currentDate.getFullYear());

Custom objects : In C#, to create a custom object, we create a Custom class and then create an instance of a class. In JavaScript we don't have classes. Instead we use functions. In JavaScript there are two ways to create a custom object.
1. Constructor function 
2. Literal notation

Creating an object in JavaScript using constructor function 

[script type="text/javascript"]
    function Employee(firstName, lastName) 
    {
        this.firstName = firstName;
        this.lastName = lastName;

        this.getFullName = function () 
        {
            return this.firstName + " " + this.lastName;
        }
    }

    var employee = new Employee("Pragim", "Tech");
    document.write("FirstName = " + employee.firstName + "[br/]");
    document.write("LastName = " + employee.lastName + "[br/]");
    document.write("FullName = " + employee.getFullName() + "[br/]");
[/script]

Creating an object in JavaScript using literal notation
[script type="text/javascript"]
    var employee = 
    {
        firstName : "Pragim",
        lastName : "Tech",

        getFullName : function () 
        {
            return this.firstName + " " + this.lastName;
        }
    }

    document.write("FirstName = " + employee.firstName + "[br/]");
    document.write("LastName = " + employee.lastName + "[br/]");
    document.write("FullName = " + employee.getFullName() + "[br/]");
[/script]

Both the examples above produce the same output.

What is the difference between creating an object using constructor function and literal notation. 
1. In the constructor function the properties and their values separated using an equal-to sign(=) whereas in the literal version, they are separated using a colon (:)
2. In constructor function at the end of each property you can have a semi-colons (;) whereas in the literal version properties must be separated with a comma (,)
3. With literal notation you have already created an object, so to access firstName value you simply use employee.firstName. With the constructor function you have to first create an instance and then use the created instance and the property name separated by DOT as shown below.

var employee = new Employee("Pragim", "Tech");
employee.firstName

Object literal vs object constructor
Creating an object using object literal notation

[script type="text/javascript"]
    var employee = 
    {
        name : "John"
    }

    // Create a new variable and assign the employee object
    var newEmployee = employee;

    // Change the name property of the employee object using the new variable
    newEmployee.name = "Mary";

    // Retrieve the name property from the original employee object
    // Notice that name is changed to Mary
    document.write(employee.name);
[/script]

Output : Mary

Objects created using object literals are singletons. This means when a change is made to the object, it affects that object across the entire script.

Creating an object using constructor function 

[script type="text/javascript"]
    var emp = function () 
    {
        this.name = "John";
    }

    // Create an instance of employee
    // employee.name will return John
    var employee = new emp();

    // Create an other instance of employee
    // newEmployee.name will return John
    var newEmployee = new emp();

    // Change the name property of the newEmployee object
    newEmployee.name = "Mary";

    // Retrieve the name property from the original employee object
    // Notice that name is not changed to Mary, it is still John
    document.write(employee.name);
[/script]

Output : John

Object defined with a function constructor lets you have multiple instances of that object. This means change made to one instance, will not affect other instances.

So, when to use one over the other?
If you need multiple instances of the object use constructor function where as if you need just one instance of the object then use literal notation.

Global namespace pollution in JavaScript
the problem of global namespace pollution in JavaScript with an example. When working with JavaScript on a big project, you might hear senior developers saying during the code review, this code pollutes the global scope. In this video let's understand the problem of global namespace pollution. In our next video we will discuss how to write JavaScript in such a way that it does not pollute the global scope.

Let us say we have 2 software development teams (TeamA & TeamB) working on a large project for Pragim Technologies.

TeamA has created a customer constructor function with 2 parameters (firstName & lastName) and added it to TeamA.js file
function customer (firstName, lastName) 
{
    this.firstName = firstName;
    this.lastName = lastName;
    this.getFullName = function () 
    {
        return this.firstName + " " + this.lastName;
    }
}

TeamB has also created a customer constructor function but with 3 parameters (firstName, middleName & lastName) and added it TeamB.js file. 
function customer (firstName, middleName, lastName) 
{
    this.firstName = firstName;
    this.middleName = middleName;
    this.lastName = lastName;

    this.getFullName = function () 
    {
        return this.firstName + " " + this.middleName + " " + this.lastName;
    }
}

So at the moment we have 2 customer constructor functions. One version has 2 parameters (firstName & lastName) and the other version has 3 parameters (firstName, middleName & lastName). 

HTML Page code : In this HTML page we want to use the customer constructor function that has 2 parameters (firstName & lastName). Notice that in the header section we are first loading TeamA.js and then TeamB.js.
[html]
    [head]
        [script type="text/javascript" src="TeamA.js" ][/script]
        [script type="text/javascript" src="TeamB.js" ][/script]
    [/head]
    [body]
        [div id="resultDiv"][/div]
        [script type="text/javascript"]
            document.getElementById("resultDiv").innerHTML = new customer("Tom", "Grover").getFullName();
        [/script]
    [/body]
[/html]

When you view the page in the browser, we get the following output. We expected it to print to "Tom Grover"
Tom Grover undefined

This is because JavaScript does not support function overloading and as a result, the customer() constructor function with 3 parameters simply overwrites the customer() constructor function with 2 parameters.

You may be wondering why didn't it happen the other way round. Why didn't customer() constructor function with 2 parameters overwrite the customer() constructor function with 3 parameters. That is because TeamB.js is loaded after TeamA.js. So the customer() constructor function in TeamB.js has overwritten the customer() constructor function in TeamA.js.

The reason, one of the customer() constructor function got overwritten is because we have already polluted the global scope. Let's understand what we mean by this. 

1. window is the Global object in JavaScript

2. When TeamA.js script file is loaded, the customer() function in TeamA.js file is added to the global namespace

3. When TeamB.js script file is loaded, the customer() function in TeamB.js file is added to the global namespace. Since 2 functions with the same name cannot exist in the global namespce, the customer() function in TeamB.js overwrites the customer() function in TeamA.js. As a result we cannot use the customer() function in TeamA.js file.

4. In JavaScript if you declare a variable or a function second time, it simply overwrites the one you created earlier. JavaScript does not raise any errors like C# or Java if you redefine a variable or a function.

Here is the summary.
Polluting global namespace causes name collision. This is especially true in large projects where you may be using several JavaScript libraries (both internally developed as well as third party libraries). That's why it is very important not to add everything to the global namespace. If someone else use the same variable or function names it can lead to name collision.

In our next we will discuss, how to write JavaScript code in such a way that it does not pollute the global scope.

Namespaces in JavaScript
JavaScript lack namespaces. However we can use objects to create namespaces.

The following line says use the PragimTech object if it already exists, otherwise create an empty object.
var PragimTech = PragimTech || {};

The following line adds a nested namespace. A nested namespace is a namespace inside another namespace. In JavaScript to define a nested namespace, you define an object inside another object. 
PragimTech.TeamA = PragimTech.TeamA || {};

Modify the script in TeamA.js file as shown below. In this example we are adding customer() function to PragimTech.TeamA namespace. 

var PragimTech = PragimTech || {};
PragimTech.TeamA = PragimTech.TeamA || {};

PragimTech.TeamA.customer = function (firstName, lastName) 
{
    this.firstName = firstName;
    this.lastName = lastName;

    this.getFullName = function () 
    {
        return this.firstName + " " + this.lastName;
    }

    return this;
}

PragimTech will be added to the global namespace. window is the alias for global namespace in JavaScript. You can now access customer() function as shown below.

PragimTech.TeamA.customer("Tom", "Grover")

OR

window.PragimTech.TeamA.customer("Tom", "Grover")

Modify the script in TeamB.js file as shown below. In this example we are adding customer() function to PragimTech.TeamB namespace. 

var PragimTech = PragimTech || {};
PragimTech.TeamB = PragimTech.TeamB || {};

PragimTech.TeamB.customer = function (firstName, middleName, lastName) 
{
    this.firstName = firstName;
    this.middleName = middleName;
    this.lastName = lastName;

    this.getFullName = function () 
    {
        return this.firstName + " " + this.middleName + " " + this.lastName;
    }

    return this;
}

PragimTech will be added to the global namespace. You can now access customer() function as shown below.

PragimTech.TeamB.customer("Tom", "T", "Grover")

OR

window.PragimTech.TeamB.customer("Tom", "T", "Grover")

On any given HTML page you should be able to access both the versions of customer() function as shown below.

[html]
    [head]
        [script type="text/javascript" src="TeamA.js" ][/script]
        [script type="text/javascript" src="TeamB.js" ][/script]
    [/head]
    [body]
        [script type="text/javascript"]
            // Call the customer function that is defined in TeamA.js
            alert(PragimTech.TeamA.customer("Tom", "Grover").getFullName());

            // Call the customer function that is defined in TeamB.js
            alert(PragimTech.TeamB.customer("Tom", "T", "Grover").getFullName());
        [/script]
    [/body]
[/html]

Private members in JavaScript
In any object oriented programming language, classes can have private and public members. For example a class in C# can have private and public fields and functions. An example is shown below.

public class Employee
{
    // Private Field
    private string privateFullName;
        
    // Public Fields
    public string firstName;
    public string lastName;

    // Private Function
    private string privateGetFullName()
    {
        privateFullName = this.firstName + " " + this.lastName;
        return privateFullName;
    }

    // Public Function
    public string publicGetFullName()
    {
        return privateGetFullName();
    }
}

JavaScript is object oriented programming language, so objects in JavaScript can also have private and public fields and functions. An example is shown below. 

function Employee(firstName, lastName) 
{
    // Private Field
    var privateFullName;

    // Public Fields
    this.firstName = firstName;
    this.lastname = lastName;

    // Private Function
    var privateGetFullName = function () 
    {
        privateFullName = firstName + " " + lastName;
        return privateFullName;
    }

    // Privileged Function
    this.privilegedGetFullName = function () 
    {
        return privateGetFullName();
    }

    // Public Function
    Employee.prototype.publicGetFullName = function () 
    {
        return this.privilegedGetFullName();
    }
}

In the example above, we also have a privileged Function. So, what is a Privileged Function?
1. Privileged methods are created using "this" keyword and Public methods are created using prototype property of the constructor function.
2. Privileged method can access private variables and methods
3. Public methods can call Privileged methods but not Private methods.
4. Like Public methods, Privileged methods are also available outside the constructor function.

Public fields and functions are available both inside and outside of the Employee() constructor function. Private fields and functions are available only inside the Employee() constructor function. Attempting to access private fields and properties outside of the constructor function will result in undefined error.

var employee = new Employee("Tom", "Grover");

document.write(employee.publicGetFullName() + "[br/]");     // Calling public function works fine
document.write(employee.privilegedGetFullName() + "[br/]"); // Calling Privileged function works fine
employee.privateGetFullName()                               // Calling private method - undefined error
employee.privateFullName                                    // Calling private field - undefined error

Can we modify a private field outside of the constructor function?
Straight answer, no you can't.

In the example below, when we call the private field (employee.privateFullName) it results in undefined error. On the next line we are adding a new public field with same name as the private field to the employee object. Is this going to change the private field (privateFullName). The answer is NO. You cannot access or modify private fields outside of the object. In this example, you are just adding new public field (employee.privateFullName) to the employee object. 

var employee = new Employee("Tom", "Grover");
employee.privateFullName // Calling private field - undefined error

// Add a field with same name as private field
employee.privateFullName = "ABC"; 
document.write(employee.publicGetFullName() + "[br/]");
document.write(employee.privateFullName);

Here is the summary

Private fields - Declared using the var keyword inside the object, and can only be accessed by private functions and privileged methods.

Public fields - Declared using this keyword and are available outside the object.

Private functions - Declared inside the object using one of the 2 ways shown below. Can be called only by privileged methods.

var privateGetFullName = function () 
{
    privateFullName = firstName + " " + lastName;
    return privateFullName;
}

OR

function privateGetFullName()
{
    privateFullName = firstName + " " + lastName;
    return privateFullName;
}

Privileged methods - Declared using this keyoword and are available both within and outside the object.

// Privileged Function
this.privilegedGetFullName = function () 
{
    return privateGetFullName();
}

Public methods - Defined by using the object's prototype property and are available both within and outside the object.

// Public Function
Employee.prototype.publicGetFullName = function () 
{
    return this.privilegedGetFullName();
}

Properties in JavaScript
Since JavaScript is also an object oriented programming language, objects in JavaScript can also have properties. 

Why do we need properties when we have public fields
Encapsulation is one of the pillars of object oriented programming language. Properties provide encapsulation. If you use public fields you cannot control on what is assigned and returned from that public field.

In the example below we have an employee object with age public field. There is nothing stopping us from setting the age value of the employee object to 1000. Using properties you can control on what values can be assigned. You can also use properties to create just read-only or write-only properties.

function Employee(age) 
{
    this.age = age;
}

var employee = new Employee(50);
// Nothing stops you from assigning a value of 1000 to age field
employee.age = 1000;

An example is shown below. In the example name is read-only property and age is read/write property.

function Employee(name, age) 
{
    var _name = name;
    var _age = age;

    Object.defineProperty(this, "age", {
        get: function () { return _age; },
        set: function (value) {
            if (value [ 100 || value ] 1) 
            {
                alert("Invalid age");
            }
            else 
            {
                _age = value;
            }
        }
    });

    Object.defineProperty(this, "name", { 
        get: function () { return _name; }
    });
}

var employee = new Employee("Tom", 55);
// Cannot change the value of name property (read-only)
employee.name = "Tommy";
// Will alert an error - Invalid age
employee.age = 195;
document.write(employee.name + " " + employee.age);


Static members in JavaScript
What is the difference between static member and instance member and when to use one over the other
An instance member belongs to a specific instance. So if I create 3 instances (objects) there will be 3 copies of instance fields in memory whereas there will ever be only one copy of a static field no matter how many instances we create.

In the above example, radius is specific to the circle instance you are creating but the PI value need to be shared by all the circle objects. So, if you want a member to be shared by all instances then make it a static member otherwise make it an instance member.

Since JavaScript is also an object oriented programming language, objects in JavaScript can also have static and instance fields and methods. Here is an example. In this example PI is a static field and _radius is an instance field. 

function Circle(radius) {
    // Instance field
    this.Radius = radius;

    // Static field
    Circle.PI = 3.141;

    this.CalculateArea = function () 
    {
        return Circle.PI * this.Radius * this.Radius;
    }
}

var circleObject = new Circle(10);
document.write("Area = " + circleObject.CalculateArea());

Points to remember
1. Define a static member using the name of the constructor function.
2. To invoke a static member use the name of the constructor function.
3. To invoke an instance member use the instance of the constructor function.

Static methods in JavaScript : In the following example ShowCount() is a static method. Notice that, just like a static variable, static method is also defined using the name of the constructor function. To keep track of the number of Shape objects created we are using Shape.Count static field. Shape.ShowCount() method returns the count of shapes when called.

function Shape(shapeName) 
{
    // Instance field
    this.ShapeName = shapeName;

    // Static Field
    Shape.Count = ++Shape.Count || 1;

    // Static method
    Shape.ShowCount = function () 
    {
        return Shape.Count;
    }
}

var shape1 = new Shape("Circle");
var shape2 = new Shape("Rectangle");
var shape3 = new Shape("Triangle");

document.write("Shape.Count = " + Shape.ShowCount());

Since we have created 3 shapes, the output will be 3.

Prototype in JavaScript
The following Employee constructor function constructs Employee object. 
function Employee(name) 
{
    this.name = name;
}

There are several ways to add a function to the Employee object. One way is as shown below. This works but the problem with this approach is that, if you create 100 employee objects there will be 100 copies of getName() function. We don't want to be creating copies of functions, instead we want all the objects to share the same function code. This can be achieved using JavaScript prototype object.

function Employee(name) 
{
    this.name = name;

    this.getName = function () 
    {
        return this.name;
    }
}

var e1 = new Employee("Mark");
var e2 = new Employee("Sara");

document.write("e1.name = " + e1.getName() + "[br/]");
document.write("e2.name = " + e2.getName() + "[br/]");

Output : 
e1.name = Mark
e2.name = Sara

In this example, getName() function is added just to e1 object, and not to e2 object. So e2.getName() would throw an undefined error.
function Employee(name) 
{
    this.name = name;
}

var e1 = new Employee("Mark");

e1.getName = function () 
{
    return this.name;
}

var e2 = new Employee("Sara");

document.write("e1.name = " + e1.getName() + "[br/]");
document.write("e2.name = " + e2.getName() + "[br/]");

In the following example getName() function is added to the Employee object using the name of the constructor function. This would also result in undefined error.

function Employee(name) 
{
    this.name = name;
}

Employee.getName = function () 
{
    return this.name;
}

var e1 = new Employee("Mark");
var e2 = new Employee("Sara");

document.write("e1.name = " + e1.getName() + "[br/]");
document.write("e2.name = " + e2.getName() + "[br/]");

Using the prototype object to add functions : The following are the advantages of using the prototype object to add functions.
1. No matter how many objects you create, functions are loaded only once into memory
2. Allows you to override functions if required.

function Employee(name) 
{
    this.name = name;
}

Employee.prototype.getName = function () 
{
    return this.name;
}

var e1 = new Employee("Mark");
var e2 = new Employee("Sara");

document.write("e1.name = " + e1.getName() + "[br/]");
document.write("e2.name = " + e2.getName() + "[br/]");

Output :
e1.name = Mark
e2.name = Sara

Overriding JavaScript functions
we discussed that one of the advantages of using prototype property to add functions is that it enables us to override an existing function if required. Let us continue with the same example we worked with in Part 60.

function Employee(name) 
{
    this.name = name;
}

Employee.prototype.getName = function () 
{
    return this.name;
}

var e1 = new Employee("Mark");
var e2 = new Employee("Sara");

document.write("e1.name = " + e1.getName() + "[br/]");
document.write("e2.name = " + e2.getName() + "[br/]");

Output :
e1.name = Mark
e2.name = Sara

Let us say for some reason we want to override getName() function of Employee object. Notice that in GetEmployeeDetails() function we have overridden getName() function of the Employee object. The overridden version converts the name of the Employee to UPPERCASE.

GetEmployeeDetails();

function GetEmployeeDetails() 
{
    Employee.prototype.getName = function () 
    {
        return this.name.toUpperCase();
    }

    var e1 = new Employee("Mark");
    var e2 = new Employee("Sara");

    document.write("e1.name = " + e1.getName() + "[br/]");
    document.write("e2.name = " + e2.getName() + "[br/]");
}

function Employee(name) 
{
    this.name = name;
}

Employee.prototype.getName = function () 
{
    return this.name;
}

Output :
e1.name = MARK
e2.name = SARA

In this example, all the JavaScript is in the same file, i.e
1. The JavaScript that creates Employee constructor function and getName() function &
2. The script that overrides getName() function 

The JavaScript that creates Employee constructor function and getName() function could even be present in a separate JavaScript file. 

1. To your project add a new JScript file with name = EmployeeScript.js.

2. Copy and paste the following JavaScript code in EmployeeScript.js file
function Employee(name) 
{
    this.name = name;
}

Employee.prototype.getName = function () 
{
    return this.name;
}

3. Modify the code on the HTML page as shown below.
[html]
    [head]
        [script type="text/javascript" src="EmployeeScript.js"]
        [/script]
    [/head]
    [body]
        [script]
            GetEmployeeDetails();

            function GetEmployeeDetails() 
            {
                Employee.prototype.getName = function () 
                {
                    return this.name.toUpperCase();
                }

                var e1 = new Employee("Mark");
                var e2 = new Employee("Sara");

                document.write("e1.name = " + e1.getName() + "[br/]");
                document.write("e2.name = " + e2.getName() + "[br/]");
            }
        [/script]
    [/body]
[/html]

Run the page and the output should be exactly the same as the previous example.

JavaScript built-in methods can also be overridden. The following example overrides the built-in JavaScript alert() function.
[script type="text/javascript"]

    // Overriding JavaScript alert function to write to the page 
    // instead of displaying the alert dialog box
    var alert = function (msg) 
    {
        document.write(msg);
    }

    // The following calls will invoke the overridden alert() method    
    alert("Hello");
    window.alert(" JavaScript");

[/script]

Output : Hello JavaScript

Inheritance in JavaScript
Object oriented programming languages support inheritance. Since JavaScript is also an object oriented programming language, it supports inheritance. 

In Object oriented programming languages like C# and Java to implement inheritance, a class inherits from another class. In JavaScript, we don't have the concept of classes, so inheritance in JavaScript is prototype-based. This means to implement inheritance in JavaScript, an object inherits from another object. Let us understand this with an example.

    // Employee will be the base object (Similar to base class in c#)
    var Employee = function (name) 
    {
        this.name = name;
    }

    // getName() function is added to the base object (Employee)
    Employee.prototype.getName = function () 
    {
        return this.name;
    }

    // PermanentEmployee will be the derived object
    var PermanentEmployee = function (annualSalary) 
    {
        this.annualSalary = annualSalary;
    }

    // Use prototype to associate Employee as the base object for PermanentEmployee
    PermanentEmployee.prototype = new Employee("Mark");

    var pe = new PermanentEmployee(50000);
    // Derived object (permanentEmployee) can see the base object (Employee) getName() method
    document.write(pe.getName());
    alert(pe instanceof Employee); // Returns true
    alert(pe instanceof PermanentEmployee); // Returns true

Notice that the derived object (PermanentEmployee) can see the base object (Employee) getName() method. When getName() method is called, JavaScript first tries to find this method in the derived object (). It can't find the method there so it goes to the parent object and finds it there.

If you add a new method to the parent object, it becomes available in the derived object.

    var Employee = function (name) 
    {
        this.name = name;
    }

    Employee.prototype.getName = function () 
    {
        return this.name;
    }

    // Adding getNameLength() method to the parent object
    // which becomes available in the derived object
    Employee.prototype.getNameLength = function () 
    {
        return this.name.length + " characters";
    }

    // PermanentEmployee will be the derived object
    var PermanentEmployee = function (annualSalary) 
    {
        this.annualSalary = annualSalary;
    }

    PermanentEmployee.prototype = new Employee("Mark");

    var pe = new PermanentEmployee(50000);
    // Call getNameLength() method added to the parent object
    document.write(pe.getNameLength()); // Output : 4 characters 

Use hasOwnProperty() method to determine if a property is defined on the actual object or it's prototype. Here is an example.

    var Employee = function (name) 
    {
        this.name = name;
    }
    
    var PermanentEmployee = function (annualSalary) 
    {
        this.annualSalary = annualSalary;
    }

    var employee = new Employee("Mark");

    PermanentEmployee.prototype = employee;

    var pe = new PermanentEmployee(50000);

    document.write("Employee.name: " + employee.hasOwnProperty('name'));
    document.write("Employee.annualSalary: " + employee.hasOwnProperty('annualSalary'));

    document.write("PermanentEmployee.name: " + pe.hasOwnProperty('name'));
    document.write("PermanentEmployee.annualSalary: " + pe.hasOwnProperty('annualSalary'));

Output :
Employee.name: true
Employee.annualSalary: false

PermanentEmployee.name: false
PermanentEmployee.annualSalary: true

Abstract classes in JavaScript
Object oriented programming languages like C# and Java, support abstract classes. Abstract classes are incomplete. So, trying to create an instance of an abstract class raises a compiler error. Abstract classes can only be used as base classes. 

Let us first look at a simple C# example.

1. Open visual studio and create a new empty asp.net web application project.

2. Add a webform to the project. Name it WebForm1.aspx. Copy and past the following code in the code-behind file.

using System;

namespace Demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Error: Cannot create an instance of an abstract class
            // Shape s = new Shape();
            
            Circle circle = new Circle();
            circle.shapeName = "Circle";
            Response.Write(circle.draw() + "[br/][br/]");

            Response.Write(circle is Shape + "[br/]");  // Returns true
            Response.Write(circle is Circle + "[br/]"); // Returns true
        }
    }

    public abstract class Shape
    {
        public string shapeName = "None";
        public string draw()
        {
            return "Drawing " + this.shapeName;
        }
    }

    public class Circle : Shape
    { 
        // Code specific to Circl class
    }
}

Since JavaScript is also an object oriented programming language, it also supports the concept of abstract classes. Here is an example.

Add a new HTML page to the project. Name it HTMLPage1.htm. Copy and paste the following code in HTMLPage1.htm.

[script type="text/javascript"]
    // Create a Shape object which is abstract
    var Shape = function () 
    {
        this.shapeName = "None";
        throw new Error("Cannot create an instance of abstract class");
    }

    // Error : Cannot create an instance of abstract class
    // var shape = new Shape();

    // Add draw function to the Shape prototype
    // Objects derived from Shape should be able to call draw() method
    Shape.prototype.draw = function () 
    {
        return "Drwaing " + this.shapeName;
    }

    // Create a Circle object
    var Circle = function (shapeName) 
    {
        this.shapeName = shapeName;
    }

    // Make shape the parent for Circle
    // Object.create() allows to create an object without using constructor
    Circle.prototype = Object.create(Shape.prototype);

    var circle = new Circle("Circle");
    // Since Circle inherits from abstract Shape object, it can call draw() method
    document.write(circle.draw());

    alert(circle instanceof Circle); // Returns true
    alert(circle instanceof Shape);  // Returns true
[/script]

Polymorphism in JavaScript
Since JavaScript is also an object oriented programming language, it also supports the concept of polymorphism. Here is an example.

[script type="text/javascript"]
    // Shape object is be the base object
    var Shape = function () { }

    // Add draw function to the Shape prototype
    // Objects derived from Shape should be able to override draw() method
    Shape.prototype.draw = function () 
    {
        return "I am a generic shape";
    }

    // Create a Circle object
    var Circle = function () { }

    // Make shape the parent for Circle
    Circle.prototype = Object.create(Shape.prototype);

    // Circle object overrides draw() method
    Circle.prototype.draw = function () 
    {
        return "I am a circle";
    }

    var Square = function () { }

    Square.prototype = Object.create(Shape.prototype);

    Square.prototype.draw = function () 
    {
        return "I am a square";
    }

    var Triangle = function () { }
    Triangle.prototype = Object.create(Shape.prototype);

    var shapes = [new Shape(), new Circle(), new Square(), new Triangle()];

    shapes.forEach(function (val) 
    {
        document.write(val.draw() + "[br/]") 
    });
[/script]

Ouptut:
I am a generic shape
I am a circle
I am a square
I am a generic shape

Object reflection in JavaScript
Object oriented programming languages like C# and Java, support reflection. Reflection allows us to inspect meta data of assemblies, modules and types. Since JavaScript is also an object oriented programming language, it also supports the concept of reflection. Let's understand Object reflection in JavaScript with an example.

Employee object in the following example has 4 public properties
1. firstName
2. lastName
3. email
4. gender

and 3 public functions
1. getFullName
2. getEmail
3. getGender

var Employee = function (firstName, lastName, gender, email) 
{
    this.firstName = firstName;
    this.lastName = lastName;
    this.gender = gender;
    this.email = email;
}

Employee.prototype.getFullName = function () 
{
    return this.firstName + " " + this.lastName;
}

Employee.prototype.getEmail = function () 
{
    return this.email;
}

Employee.prototype.getGender = function () 
{
    return this.gender;
}

var employee = new Employee("Mark", "Matt", "Male", "a@a.com");

The following code retrieves all the public properties and methods of the Employee object.

for (var property in employee) 
{
    document.write(property + "[br/]");
}

Output :
firstName
lastName
gender
email
getFullName
getEmail
getGender

The following code retrieves all the public properties & functions of the Employee object along with their values.

for (var property in employee) 
{
    document.write(property + " : " + employee[property] + "[br/]");
}

Output :
firstName : Mark
lastName : Matt
gender : Male
email : a@a.com
getFullName : function () { return this.firstName + " " + this.lastName; }
getEmail : function () { return this.email; }
getGender : function () { return this.gender; }

The following code retrieves only the public properties of the Employee object.

for (var property in employee) 
{
    if (typeof employee[property] != "function") 
    {
        document.write(property + " : " + employee[property] + "[br/]");
    }
}

Output:
firstName : Mark
lastName : Matt
gender : Male
email : a@a.com

The following code retrieves only the public functions of the Employee object.

for (var property in employee) 
{
    if (typeof employee[property] == "function") 
    {
        document.write(property + " : " + employee[property] + "[br/]");
    }
}

Output :
getFullName : function () { return this.firstName + " " + this.lastName; }
getEmail : function () { return this.email; }
getGender : function () { return this.gender; }

When 2 objects are related thru inheritance, the child object will have access to parent object methods and properties. In this example, PermanentEmployee is a child of Employee. The following code shows all the properties and methods of the PermanentEmployee object including those it inherited from the Employee object.

var employee = new Employee("Mark", "Matt", "Male", "a@a.com");

var PermanentEmployee = function (annualSalry) 
{
    this.annualSalary = annualSalry;
}

PermanentEmployee.prototype = employee;

var pe = new PermanentEmployee(50000);

for (var property in pe) 
{
    document.write(property + " : " + pe[property] + "[br/]");
}

Output : 
annualSalary : 50000
firstName : Mark
lastName : Matt
gender : Male
email : a@a.com
getFullName : function () { return this.firstName + " " + this.lastName; }
getEmail : function () { return this.email; }
getGender : function () { return this.gender; }

In this example, we are using hasOwnProperty() method to determine if a property is defined on the actual object or it's prototype. This method returns true if the property is defined by the object itself, otherwise false. The following code retrieves only the public members that are defined in the PermanentEmployee object. The members inherited from the base Employee object are excluded.

for (var property in pe) 
{
    if (pe.hasOwnProperty(property)) 
    {
        document.write(property + " : " + pe[property] + "[br/]");
    }
}

Output : annualSalary : 50000

The following code retrieves only the public members inherited from the parent object. Public members defined in PermanentEmployee object are excluded.
for (var property in pe) 
{
    if (!pe.hasOwnProperty(property)) 
    {
        document.write(property + " : " + pe[property] + "[br/]");
    }
}

Output : 
firstName : Mark
lastName : Matt
gender : Male
email : a@a.com
getFullName : function () { return this.firstName + " " + this.lastName; }
getEmail : function () { return this.email; }
getGender : function () { return this.gender; }

Strict Mode in JavaScript
How to enable strict mode in JavaScript : Just add "use strict" statement in your script file as shown below. When you run the page, you will now get an error stating - Variable undefined in strict mode. To see the error in google chrome, please go the console window in developer tools.

[script type="text/javascript"]

"use strict";

myString = "This is a string";

document.write(myString);

[/script]

Since "use strict" is specified at the top of the JavaScript file, strictness will be enforced across the entire script file.

How to enforce JavaScript strictness in a specific function : Just add "use strict" statement in the function as shown below. In this example, strictness is enforced only in myFunction().

[script type="text/javascript"]

myString = "This is a string[br/]";
document.write(myString);

function myFunction() 
{
    "use strict";
    var myOtherString = "This is also a string";
    document.write(myOtherString);
}

myFunction();

[/script]

Output :
This is a string
This is also a string

Let us look at another example : In C# if you assign a value to a read-only property you get an error. For example, the following C# code would raise an error stating - Property or indexer 'Demo.Employee.Name' cannot be assigned to -- it is read only.

public partial class WebForm1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Employee employee = new Employee("Mark");
        employee.Name = "Mark M";
    }
}

public class Employee
{
    private string _name;
    public Employee(string name)
    {
        this._name = name;
    }
        
    public string Name
    {
        get
        {
            return this._name;
        }
    }
}

We discussed JavaScript properties in Part 58 of JavaScript tutorial.

In JavaScript, if you assign a value to a read-only property, JavaScript silently fails without raising an error.

[script type="text/javascript"]

    var Employee = function (name) 
    {
        var _name = name;

        Object.defineProperty(this, "name", {
            get: function () 
            {
                return _name;
            }
        });
    }

    var employee = new Employee("Mark");
    // name is readonly property. It is an error to assign a value to a read-only property 
    // JavaScript silently fails the following line without raising an error
    employee.name = "Mark M";

    document.write(employee.name);

[/script]

If you want JavaScript to raise an error instead of failing silently, use JavaScript strict mode. The code below raises an error stating - Assignment to read-only properties is not allowed in strict mode.

[script type="text/javascript"]

    "use strict";

    var Employee = function (name) 
    {
        var _name = name;

        Object.defineProperty(this, "name", {
            get: function () 
            {
                return _name;
            }
        });
    }

    var employee = new Employee("Mark");
    employee.name = "Mark M";

    document.write(employee.name);

[/script]

ECMAScript version 5 introduced strict mode to JavaScript. With strict mode on it is easier to detect JavaScript silent errors as they would throw an error now. This makes debugging much easier and the chances of developers making mistakes is reduced. Most modern browsers support strict mode.

JavaScript Cookies
we will discuss
1. What are cookies and why are they needed
2. How to write a cookie and read it later

Why are cookies needed
Web applications work on HTTP protocol which is a stateless protocol. This means after the web server has processed the client request for a web page, the web server will not remember anything about the client that made the request. Let us understand what this statement means with an example.

1. Design a web page with a DropDownList.

2. When the user selects a color from the DropDownList we want to change the background color of the page to the selected color.


3. We want the web application to remember the user's preferred color. On a subsequent visit to the same page it should display the page with the background color that we previously selected. 

4. Now close the browser. Open a new instance of the browser and navigate to the same page. Notice that, the page does not remember the color we selected earlier. This is because web applications work on HTTP protocol which is a stateless protocol. This means after the web server has processed the initial client request, it does not remember aynthing about the settings the client made. There are several ways to make a web application remember these settings. One of the easiest and common ways is by using cookies.

What are cookies
Cookies are small text files that a browser stores in the visitor's computer. A cookie is basically a string of name-value pairs separated by semi-colons.

How does a cookie look 
color=red;expires=Fri, 5 Aug 2016 01:00:00 UTC;

In the cookie string above we have 2 name-value pairs. 
The expires attribute specifies when the cookie is going to expire. By default cookies are deleted when the current browser session ends. If you want to store the cookie on the client computer even after the browser session has ended then specify either expires or max-age attributes. The color attribute is set to "red".

How to write a cookie : Use the document object's cookie property to write the cookie.
document.cookie = "color=red;expires=Fri, 5 Aug 2016 01:00:00 UTC;"

How to read a cookie : Use the document object's cookie property to read the cookie.
var cookieString = document.cookie;

Here is the complete example which remembers the user color preference
[select id="ddlTheme" onchange="setColorCookie()"]
    [option value="Select Color"]Select Color[/option]
    [option value="red"]Red[/option]
    [option value="green"]Green[/option]
    [option value="blue"]Blue[/option]
[/select]
[script type="text/javascript"]
    window.onload = function () 
    {
        if (document.cookie.length != 0) {
            var nameValueArray = document.cookie.split("=");
            document.getElementById("ddlTheme").value = nameValueArray[1];
            document.bgColor = nameValueArray[1];
        }
    }
    
    function setColorCookie() 
    {
        var selectedValue = document.getElementById("ddlTheme").value;
        if (selectedValue != "Select Color") 
        {
            document.bgColor = selectedValue;
            document.cookie = "color=" + selectedValue + ";expires=Fri, 5 Aug 2016 01:00:00 UTC;";
        }
    }
[/script]

JavaScript cookie attributes
Optional Cookie Attributes
expires
max-age
domain
path
secure

The following code creates a cookie that expires as soon as the browser is closed
document.cookie = "color=red";

expires and max-age attributes : If you want to create a persistent cookie, that is a cookie that is not deleted after the browser is closed either use expires or max-age attributes

document.cookie = "color=red;expires=Fri, 5 Aug 2016 01:00:00 UTC";
OR
document.cookie = "color=red;max-age=" + (60 * 60 * 24 * 30) + ";"// Creates a cookie that expires in 30 days

What is the difference between expires and max-age attributes
With expires attribute you set an expiry date. The expires attribute is obsolete. Very few modern browsers support this attribute. Internet Explorer is one of them.
With max-age attribute you specify the expiry time in seconds. Most modern browsers support this attribute except Internet Explorer.

If you want to create a persistent cookie that works in IE and all the other browsers then specify both expires and max-age attributes.

domain attribute : Specifies the doamin for which the cookie is valid. If you specify the doamin as PragimTech.Blog.com then that cookie will be valid only for that sub-domain. It will not be valid for PragimTech.com. 

If you want a cookie to be valid for all sub-domains of PragimTech.com then specify domain=PragimTech.com. So this cookie will be valid for
PragimTech.com
PragimTech.Blog.com
PragimTech.Blog.KudVenkat.com

path attribute : By default cookies are valid only for web pages in the directory of the current web page that stored them, as well as its descendants. 

Example : The following diagram shows the directory structure of a web application
// JavaScript cookie attributes.png

If a cookie is set by http://localhost/Home/Page2.htm, it will be valid for http://localhost/Home/SubFolder/Page1... but not for http://localhost/Page3.htm

If you want to create a cookie that is valid across all your pages in your website, then set the path attribute to the root of your web directory, that is, "/".

document.cookie = "color=red;max-age=" + (60 * 60 * 24 * 30) + ";path=/";

secure attribute : secure attribute specifies that the cookie is secure and is only used over HTTPS protocol which ensures that the cookie is always encrypted when transmitting from client to server.

Store multiple key value pairs in a cookie
When we click "Set Cookie" button, we want to store name, email & gender along with their values in the cookie.

Copy and paste the following code in HTMLPage1.htm
[html]
[head][/head]
[body]
    [table border="1"]
        [tr]
            [td]
                Name
            [/td]
            [td]
                [input type="text" id="txtName" /]
            [/td]
        [/tr]
        [tr]
            [td]
                Email
            [/td]
            [td]
                [input type="text" id="txtEmail" /]
            [/td]
        [/tr]
        [tr]
            [td]
                Gender
            [/td]
            [td]
                [input type="text" id="txtGender" /]
            [/td]
        [/tr]
        [tr]
            [td colspan="2"]
                [input type="button" value="Set Cookie" onclick="setCookie()" /]
                [input type="button" value="Get Cookie" onclick="getCookie()" /]
                [input type="button" value="Clear" onclick="clearTextBoxes()" /]
            [/td]
        [/tr]
    [/table]
    [script type="text/javascript"]

        function setCookie() 
        {
            var cookieString = "name=" + document.getElementById("txtName").value +
                               ";email=" + document.getElementById("txtEmail").value +
                               ";gender=" + document.getElementById("txtGender").value;

            document.cookie = cookieString;
        }

        function getCookie() 
        {
            alert(document.cookie);
        }

        function clearTextBoxes() 
        {
            document.getElementById("txtName").value = "";
            document.getElementById("txtEmail").value = "";
            document.getElementById("txtGender").value = "";
        }
    [/script]
[/body]
[/html]

1. Run the application. 
2. Fill in data for Name, Email and Gender. 
3. Click "Set Cookie" button
4. Click "Get Cookie" button

Notice that we only get the first key-value pair. This is because you can only store one key-value pair in one cookie
name=Venkat

If you want to store all the 3 key-value pairs, you have 2 options
1. Create a custom object, serialize the object to a JSON string and store the serialized string in a cookie
2. Use a different cookie for each key-value pair you want to store

Create a custom object, serialize the object to a JSON string and store the serialized string in a cookie : 

Modify the code in setCookie() function as shown below. 

function setCookie() 
{
    var customObject = {};

    customObject.name = document.getElementById("txtName").value;
    customObject.email = document.getElementById("txtEmail").value;
    customObject.gender = document.getElementById("txtGender").value;

    var jsonString = JSON.stringify(customObject);

    document.cookie = "cookieObject=" + jsonString;
}

JSON.stringify() method converts a JavaScript object to a JavaScript Object Notation (JSON) string.

Modify the code in getCookie() function as shown below. 

function getCookie() 
{
    var nameValueArray = document.cookie.split("=");

    var customObject = JSON.parse(nameValueArray[1]);

    document.getElementById("txtName").value = customObject.name;
    document.getElementById("txtEmail").value = customObject.email;
    document.getElementById("txtGender").value = customObject.gender;
}

JSON.parse() method parses a JSON string and returns the corresponding object.

In our next video we will discuss the second option, i.e using a different cookie for each key-value pair that we want to store.

Set and get multiple cookies in JavaScript
When we click "Set Cookie" button we want to store the following 3 key-value pairs in 3 cookies.
name=Venkat;
email=Kudevnkat@gmail.com;
gender=Male;

When we click "Get Cookie" button we want to retrieve all the 3 key-value pairs from the 3 cookies

Modify the code in setCookie() function as shown below. 
function setCookie() 
{
    document.cookie = "name=" + document.getElementById("txtName").value;
    document.cookie = "email=" + document.getElementById("txtEmail").value;
    document.cookie = "gender=" + document.getElementById("txtGender").value;
}

The above code creates 3 cookies and stores the 3 key-value pairs. At this point document.cookie property contains the following string
"name=Venkat; email=Kudvenkat@gmail.com; gender=Male"

Now, modify the code in getCookie() function as shown below. 
function getCookie() 
{
    if (document.cookie.length != 0) 
    {
        var cookiesArray = document.cookie.split("; ");
        for (var i = 0; i [ cookiesArray.length; i++) 
        {
            var nameValueArray = cookiesArray[i].split("=");
            if (nameValueArray[0] == "name") 
            {
                document.getElementById("txtName").value = nameValueArray[1];
            }
            else if (nameValueArray[0] == "email") 
            {
                document.getElementById("txtEmail").value = nameValueArray[1];
            }
            else if (nameValueArray[0] == "gender") 
            {
                document.getElementById("txtGender").value = nameValueArray[1];
            }
        }
    }
    else 
    {
        alert("No cookies found");
    }
}

Update and delete cookies
we will discuss
1. Updating a cookie
2. Deleting a cookie
3. Cookie limitations

Updating a cookie : To update a cookie, set a cookie with the same name again. The following code updates the color cookie with the New_Color if a cookie with name=color exists otherwise it creates a new cookie with that name.
document.cookie = "color=New_Color";

Deleting a cookie : To delete a cookie, set a cookie with max-age attribute set to a negative value
document.cookie = "color=red;max-age=-60";

If you are using a browser that supports expires attribute, then set the expires attribute to a date in the past.
document.cookie = "color=red;expires=Mon, 01 Jan 1900 01:00:00 UTC;";

Please note: Users can also use the browser interface to delete cookies anytime they want.

Cookie limitations : 
1. What is the maximum allowed cookie size per cookie
2. How many cookies are allowed per domain

How to check if cookies are enabled
Most websites rely on browser cookies being enabled. For example, if you have disabled cookies and if you try to log into gmail.com, you will receive an error message saying - Oops! Your browser seems to have cookies disabled. Make sure cookies are enabled or try opening a new browser window. 

The following JavaScript code detects if cookies are enabled. Most modern browser's support navigator.cookieEnabled property. This property returns true if cookies are enabled and false if cookies are disabled. Some old browsers don't support this property. For those browsers that don't support navigator.cookieEnabled property, we are setting "mytestcookie" and then reading again to make sure cookies are enabled. If we are not able to read "mytestcookie" then we know that cookies are disabled.

[div id="msg"][/div]
[script type="text/javascript"]
    function cookiesEnabled() 
    {
        var cookiesEnabled = (navigator.cookieEnabled) ? true : false;

        if (typeof navigator.cookieEnabled == "undefined" && !cookiesEnabled) 
        {
            document.cookie = "mytestcookie";
            cookiesEnabled = (document.cookie.indexOf("mytestcookie") != -1) ? true : false;
        }

        return cookiesEnabled;
    }

    if (cookiesEnabled()) 
    {
        document.getElementById("msg").innerHTML = "Cookies enabled";
    }
    else 
    {
        document.getElementById("msg").innerHTML = "Cookies disabled";
    }
[/script]

How to check if JavaScript is enabled
We have a page that captures Name and Gender. Both fields are required. The page relies on JavaScript being enabled for performing validation. We should always have server side validation irrespective of whether we have client side validation or not. It is not a good practice to rely just on client side validation, but for the purpose of this demo, let us say we only have client side validation.

If JavaScript is enabled then we want to display the Name and Gender elements and the user can continue to use the application.

If JavaScript is disabled then we want to hide the Name and Gender elements and we want to display the following message.
It seems that you have disabled JavaScript. Please enable JavaScript.

The easiest way to detect if JavaScript is enabled is by using noscript tag. The content inside the [noscript] element will be displayed only if scripts are not supported, or are disabled in the user's browser. 

[noscript]
    [style type="text/css"]
        .rootDiv
        {
            display: none;
        }
    [/style]
    [h1]It seems that you have disabled JavaScript. Please enable JavaScript.[/h1]
[/noscript]
[div id="rootElement" class="rootDiv"]
    [table border="1"]
        [tr]
            [td]
                Name
            [/td]
            [td]
                [input id="txtName" type="text" onfocus="validateIfEmpty('txtName')" 
                onblur="validateIfEmpty('txtName')" onkeyup="validateIfEmpty('txtName')" /]
            [/td]
        [/tr]
        [tr]
            [td]
                Gender
            [/td]
            [td]
                [input id="txtGender" type="text" onfocus="validateIfEmpty('txtGender')" 
                onblur="validateIfEmpty('txtGender')" onkeyup="validateIfEmpty('txtGender')" /]
            [/td]
        [/tr]
    [/table]
[/div]
[script type="text/javascript"]
    function validateIfEmpty(control) 
    {
        var controlToValidate = document.getElementById(control);
        if (controlToValidate.value == "") 
        {
            controlToValidate.style.background = "red";
        }
        else 
        {
            controlToValidate.style.background = "white";
        }
    }
[/script]

window location in JavaScript
The Window.location property returns a Location object that can be used to get information about the current page. Window.location property can also be used to redirect the browser to a new page.

In Part 73 of JavaScript tutorial we discussed how to detect if JavaScript is enabled by using [noscript] element. Another way is by using window.location property. Let us use the example we worked with in Part 73. We will use window.location property along with [noscript] element to detect if JavaScript is enabled.

Add a new HTML page to your project. Name it Default.htm. Copy and paste the following HTML and JavaScript.
[html]
[head]
    [script]
        // If JavaScript is enabled this code redirects the user to HTMLPag1.htm
        // If JavaScript is disable this code will not execute and the user reamains on this
        // page and he gets to the see the message that JavaScript is disabled.
        window.location = "/HTMLPage1.htm";
    [/script]
[/head]
[body]
    [h1]It seems that you have disabled JavaScript. Please enable JavaScript.[/h1]
[/body]
[/html]

We don't need to make any modification to HTMLPage1.htm.

At this point
If you have JavaScript enabled, and if you visit Default.htm page, you will be redirected to HTMLPage1.htm
If you have JavaScript disabled, and if you visit Default.htm page, you will reamin on Default.htm page and you will get to see the message that says JavaScript is disabled.

window.location property is especially useful if you have 2 sites
1. One for users with JavaScript 
2. Another for users without JavaScript

Make the home-page of Non-JavaScript website the default page. In the default page include the following JavaScript code to redirect the user to the JavaScript-EnabledSite.com
window.location = "http://www.JavaScript-EnabledSite.com";

If you have JavaScript enabled, you will be redirected to JavaScript enabled website.
If you have JavaScript disabled, you will not be redirected and stay with the website which works without JavaScript.

Some of the useful properties of the location object 
window.location.href - Returns the URL of the current page
window.location.hostname - Returns the domain name
window.location.protocol - Returns the protocol (http or https)
window.location.pathname - Returns the path of the current page

[script type="text/javascript"]
    document.write("window.location.href = " + window.location.href + "[br/]");
    document.write("window.location.hostname = " + window.location.hostname + "[br/]");
    document.write("window.location.pathname = " + window.location.pathname + "[br/]");
    document.write("window.location.protocol = " + window.location.protocol + "[br/]");
[/script]

Output :
```
window.location.href = http://localhost:57695/Default.htm
window.location.hostname = localhost
window.location.pathname = /Default.htm
window.location.protocol = http:
```









