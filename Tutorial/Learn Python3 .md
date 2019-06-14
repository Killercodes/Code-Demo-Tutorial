# What is Python
> This is Python 3

Python is a general-purpose interpreted, interactive, object-oriented, and high-level programming language. It was created by Guido van Rossum during 1985- 1990. Like Perl, Python source code is also available under the GNU General Public License (GPL). Python is named after a TV Show called ‘Monty Python’s Flying Circus’ and not after Python-the snake.

## Running Python
There are three different ways to start Python −

Interactive Interpreter
You can start Python from Unix, DOS, or any other system that provides you a command-line interpreter or shell window.


Here is the list of all the available command line options −

Option | Description
----|----
-d|provide debug output
-O|generate optimized bytecode (resulting in .pyo files)
-S|do not run import site to look for Python paths on startup
-v|verbose output (detailed trace on import statements)
-X|disable class-based built-in exceptions (just use strings); obsolete starting with version 1.6
-c cmd|run Python script sent in as cmd string
file|run Python script from given file



# Why Python
> Python has a design philosophy that emphasizes code readability (notably using whitespace indentation to delimit code blocks rather than curly brackets or keywords), and a syntax that allows programmers to express concepts in fewer lines of code

- Python is Interpreted − Python is processed at runtime by the interpreter. You do not need to compile your program before executing it. This is similar to PERL and PHP.

- Python is Interactive − You can actually sit at a Python prompt and interact with the interpreter directly to write your programs.

- Python is Object-Oriented − Python supports Object-Oriented style or technique of programming that encapsulates code within objects.

- Python is a Beginner's Language − Python is a great language for the beginner-level programmers and supports the development of a wide range of applications from simple text processing to WWW browsers to games.

# What is new in Python 3
## The print Function
Most notable and most widely known change in Python 3 is how the print function is used. Use of parenthesis () with print function is now mandatory. It was optional in Python 2.
``` python
print "Hello World" #is acceptable in Python 2
print ("Hello World") # in Python 3, print must be followed by ()
```
The print() function inserts a new line at the end, by default. In Python 2, it can be suppressed by putting ',' at the end. In Python 3, "end =' '" appends space instead of newline.
``` python
print x,           # Trailing comma suppresses newline in Python 2
print(x, end=" ")  # Appends a space instead of a newline in Python 3
```
## Reading Input from Keyboard
Python 2 has two versions of input functions, input() and raw_input(). The input() function treats the received data as string if it is included in quotes '' or "", otherwise the data is treated as number.

In Python 3, raw_input() function is deprecated. Further, the received data is always treated as string.
``` python
In Python 2

>>> x = input('something:') 
something:10 #entered data is treated as number
>>> x
10

>>> x = input('something:')
something:'10' #eentered data is treated as string
>>> x
'10'

>>> x = raw_input("something:")
something:10 #entered data is treated as string even without ''
>>> x
'10'

>>> x = raw_input("something:")
something:'10' #entered data treated as string including ''
>>> x
"'10'"

In Python 3

>>> x = input("something:")
something:10
>>> x
'10'

>>> x = input("something:")
something:'10' #entered data treated as string with or without ''
>>> x
"'10'"

>>> x = raw_input("something:") # will result NameError
Traceback (most recent call last):
   File "<pyshell#3>", line 1, in 
  <module>
   x = raw_input("something:")
NameError: name 'raw_input' is not defined
```
## Integer Division
In Python 2, the result of division of two integers is rounded to the nearest integer. As a result, `3/2` will show `1`. In order to obtain a floating-point division, numerator or denominator must be explicitly used as float. Hence, either 3.0/2 or 3/2.0 or 3.0/2.0 will result in 1.5

Python 3 evaluates `3 / 2 as 1.5` by default, which is more intuitive for new programmers.
``` python
#in python 2
>>> 3/2
1
#in python 3
>>> 3/2
1.5
```
## Unicode Representation
Python 2 requires you to mark a string with a u if you want to store it as Unicode.

Python 3 stores strings as Unicode, by default. We have Unicode (utf-8) strings, and 2 byte classes: byte and byte arrays.

## xrange() Function Removed
In Python 2 range() returns a list, and xrange() returns an object that will only generate the items in the range when needed, saving memory.

In Python 3, the range() function is removed, and xrange() has been renamed as range(). In addition, the range() object supports slicing in Python 3.2 and later.

## raise exception
Python 2 accepts both notations, the 'old' and the 'new' syntax; Python 3 raises a SyntaxError if we do not enclose the exception argument in parenthesis.
``` python
raise IOError, "file error" #This is accepted in Python 2
raise IOError("file error") #This is also accepted in Python 2
raise IOError, "file error" #syntax error is raised in Python 3
raise IOError("file error") #this is the recommended syntax in Python 3
```
## Arguments in Exceptions
In Python 3, arguments to exception should be declared with 'as' keyword.
``` python
except Myerror, err: # In Python2
except Myerror as err: #In Python 3
```
## next() Function and .next() Method
In Python 2, next() as a method of generator object, is allowed. In Python 2, the next() function, to iterate over generator object, is also accepted. In Python 3, however, next(0 as a generator method is discontinued and raises AttributeError.

``` python
gen = (letter for letter in 'Hello World') # creates generator object
next(my_generator) #allowed in Python 2 and Python 3
my_generator.next() #allowed in Python 2. raises AttributeError in Python 3
```
# The Python Language
## Reserved Words
The following list shows the Python keywords. These are reserved words and you cannot use them as constants or variables or any other identifier names. All the Python keywords contain lowercase letters only.
| | | | | | |
----|----|---|----|----|----
and	|exec	|not|as	|finally|	or
assert|	for|	pass|break|	from|	print
class|	global|	raise|continue|	if|	return
def|	import|	try|del|	in|	while
elif|	is|	with|else|	lambda|	yield
except|		|

## Lines and Indentation
Python does not use braces({}) to indicate blocks of code for class and function definitions or flow control. Blocks of code are denoted by line indentation, which is rigidly enforced.

The number of spaces in the indentation is variable, but all statements within the block must be indented the same amount. For example −
``` python
if True:
   print ("True")

else:
   print ("False")
```
## Quotation in Python
Python accepts single ('), double (") and triple (''' or """) quotes to denote string literals, as long as the same type of quote starts and ends the string.

The triple quotes are used to span the string across multiple lines. For example, all the following are legal −
``` python
word = 'word'
sentence = "This is a sentence."
paragraph = """This is a paragraph. It is
made up of multiple lines and sentences."""
```
## Comments in Python
A hash sign (#) that is not inside a string literal is the beginning of a comment. All characters after the #, up to the end of the physical line, are part of the comment and the Python interpreter ignores them.
``` python
#!/usr/bin/python3

# First comment
print ("Hello, Python!") # second comment
#This produces the following result −

#Hello, Python!
```
You can type a comment on the same line after a statement or expression −
``` python
name = "Madisetti" # This is again comment
```
Python does not have multiple-line commenting feature. You have to comment each line individually as follows −
``` python
# This is a comment.
# This is a comment, too.
# This is a comment, too.
# I said that already.
```
But there is a workaround with doc comment
``` python
''' this is a 
    doc comment
'''
print("helo")
```
# Variables & Data types
Assigning Values to Variables
Python variables do not need explicit declaration to reserve memory space. The declaration happens automatically when you assign a value to a variable. The equal sign (=) is used to assign values to variables.

The operand to the left of the = operator is the name of the variable and the operand to the right of the = operator is the value stored in the variable. For example −
``` python
#!/usr/bin/python3

counter = 100          # An integer assignment
miles   = 1000.0       # A floating point
name    = "John"       # A string

print (counter)
print (miles)
print (name)
```
Here, 100, 1000.0 and "John" are the values assigned to counter, miles, and name variables, respectively. This produces the following result −
```
100
1000.0
John
```
## Multiple Assignment
Python allows you to assign a single value to several variables simultaneously.

For example −
```
 a = b = c = 1
```
Here, an integer object is created with the value 1, and all the three variables are assigned to the same memory location. You can also assign multiple objects to multiple variables. For example −
```
 a, b, c = 1, 2, "john"
```
Here, two integer objects with values 1 and 2 are assigned to the variables a and b respectively, and one string object with the value "john" is assigned to the variable c.

## Standard Data Types
The data stored in memory can be of many types. For example, a person's age is stored as a numeric value and his or her address is stored as alphanumeric characters. Python has various standard data types that are used to define the operations possible on them and the storage method for each of them.

Python has five standard data types −

- Numbers
- String
- List
- Tuple
- Dictionary

## Python Numbers
Number data types store numeric values. Number objects are created when you assign a value to them. For example −
```
var1 = 1
var2 = 10
```
You can also delete the reference to a number object by using the del statement. The syntax of the del statement is −
```
del var1[,var2[,var3[....,varN]]]]
```
You can delete a single object or multiple objects by using the del statement.

For example −
```
del var
del var_a, var_b
```
### Python supports three different numerical types −

- int (signed integers)
- float (floating point real values)
- complex (complex numbers)
All integers in Python3 are represented as long integers. Hence, there is no separate number type as long.

Examples
Here are some examples of numbers −

int|	float|	complex
----|---|---
10|	0.0|	3.14j
100|	15.20|	45.j
-786|	-21.9|	9.322e-36j
080|	32.3+e18|	.876j
-0490|	-90.|	-.6545+0J
-0x260|	-32.54e100|	3e+26J
0x69|	70.2-E12|	4.53e-7j



A complex number consists of an ordered pair of real floating-point numbers denoted by `x + yj`, where `x` and `y` are real numbers and `j` is the imaginary unit.

## Python Strings
Strings in Python are identified as a contiguous set of characters represented in the quotation marks. Python allows either pair of single or double quotes. Subsets of strings can be taken using the slice operator ([ ] and [:] ) with indexes starting at 0 in the beginning of the string and working their way from -1 to the end.

The plus (+) sign is the string concatenation operator and the asterisk (*) is the repetition operator. For example −
``` python
#!/usr/bin/python3

str = 'Hello World!'

print (str)          # Prints complete string
print (str[0])       # Prints first character of the string
print (str[2:5])     # Prints characters starting from 3rd to 5th
print (str[2:])      # Prints string starting from 3rd character
print (str * 2)      # Prints string two times
print (str + "TEST") # Prints concatenated string
```
This will produce the following result −
```
Hello World!
H
llo
llo World!
Hello World!Hello World!
Hello World!TEST
```
## Python Lists
Lists are the most versatile of Python's compound data types. A list contains items separated by commas and enclosed within square brackets `[]`. To some extent, lists are similar to arrays in `C`. One of the differences between them is that all the items belonging to a list can be of different data type.

The values stored in a list can be accessed using the slice operator `[]` and `[:]` with indexes starting at 0 in the beginning of the list and working their way to end -1. The plus (+) sign is the list concatenation operator, and the asterisk `*` is the repetition operator. For example −
``` python
#!/usr/bin/python3

list = [ 'abcd', 786 , 2.23, 'john', 70.2 ]
tinylist = [123, 'john']

print (list)          # Prints complete list
print (list[0])       # Prints first element of the list
print (list[1:3])     # Prints elements starting from 2nd till 3rd 
print (list[2:])      # Prints elements starting from 3rd element
print (tinylist * 2)  # Prints list two times
print (list + tinylist) # Prints concatenated lists
```
This produces the following result −
```
['abcd', 786, 2.23, 'john', 70.200000000000003]
abcd
[786, 2.23]
[2.23, 'john', 70.200000000000003]
[123, 'john', 123, 'john']
['abcd', 786, 2.23, 'john', 70.200000000000003, 123, 'john']
```
## Python Tuples
A tuple is another sequence data type that is similar to the list. A tuple consists of a number of values separated by commas. Unlike lists, however, tuples are enclosed within parenthesis.

The main difference between lists and tuples are − Lists are enclosed in brackets `[]` and their elements and size can be changed, while tuples are enclosed in parentheses `()` and cannot be updated. Tuples can be thought of as read-only lists. 

For example −
``` python
#!/usr/bin/python3

tuple = ( 'abcd', 786 , 2.23, 'john', 70.2  )
tinytuple = (123, 'john')

print (tuple)           # Prints complete tuple
print (tuple[0])        # Prints first element of the tuple
print (tuple[1:3])      # Prints elements starting from 2nd till 3rd 
print (tuple[2:])       # Prints elements starting from 3rd element
print (tinytuple * 2)   # Prints tuple two times
print (tuple + tinytuple) # Prints concatenated tuple
```
This produces the following result −
```
('abcd', 786, 2.23, 'john', 70.200000000000003)
abcd
(786, 2.23)
(2.23, 'john', 70.200000000000003)
(123, 'john', 123, 'john')
('abcd', 786, 2.23, 'john', 70.200000000000003, 123, 'john')
```
The following code is invalid with tuple, because we attempted to update a tuple, which is not allowed. Similar case is possible with lists −
``` python
#!/usr/bin/python3

tuple = ( 'abcd', 786 , 2.23, 'john', 70.2  )
list = [ 'abcd', 786 , 2.23, 'john', 70.2  ]
tuple[2] = 1000    # Invalid syntax with tuple
list[2] = 1000     # Valid syntax with list
```
## Python Dictionary
Python's dictionaries are kind of hash-table type. They work like associative arrays or hashes found in Perl and consist of key-value pairs. A dictionary key can be almost any Python type, but are usually numbers or strings. Values, on the other hand, can be any arbitrary Python object.

Dictionaries are enclosed by curly braces `{ }` and values can be assigned and accessed using square braces `[]`. For example −
``` python
#!/usr/bin/python3

dict = {}
dict['one'] = "This is one"
dict[2]     = "This is two"

tinydict = {'name': 'john','code':6734, 'dept': 'sales'}

print (dict['one'])       # Prints value for 'one' key
print (dict[2])           # Prints value for 2 key
print (tinydict)          # Prints complete dictionary
print (tinydict.keys())   # Prints all the keys
print (tinydict.values()) # Prints all the values
```
This produces the following result −
```
This is one
This is two
{'name': 'john', 'dept': 'sales', 'code': 6734}
dict_keys(['name', 'dept', 'code'])
dict_values(['john', 'sales', 6734])
```
Dictionaries have no concept of order among the elements. It is incorrect to say that the elements are "out of order"; they are simply unordered.

## Data Type Conversion
Sometimes, you may need to perform conversions between the built-in types. To convert between types, you simply use the type-names as a function.

There are several built-in functions to perform conversion from one data type to another. These functions return a new object representing the converted value.

Function | Description
----|----
int(x [,base])|Converts x to an integer. The base specifies the base if x is a string.
float(x)|Converts x to a floating-point number.
complex(real [,imag])|Creates a complex number.
str(x)|Converts object x to a string representation.
repr(x)|Converts object x to an expression string.
eval(str)|Evaluates a string and returns an object.
tuple(s)|Converts s to a tuple.
list(s)|Converts s to a list.
set(s)|Converts s to a set.
dict(d)|Creates a dictionary. d must be a sequence of (key,value) tuples.
frozenset(s)|Converts s to a frozen set.
chr(x)|Converts an integer to a character.
unichr(x)|Converts an integer to a Unicode character.
ord(x)|Converts a single character to its integer value.
hex(x)|Converts an integer to a hexadecimal string.
oct(x)|Converts an integer to an octal string.

# Basic Operators
Operators are the constructs, which can manipulate the value of operands. Consider the expression `4 + 5 = 9`. Here, `4` and `5` are called the operands and `+` is called the operator.

Types of Operator
Python language supports the following types of operators −

- Arithmetic Operators
- Comparison (Relational) Operators
- Assignment Operators
- Logical Operators
- Bitwise Operators
- Membership Operators
- Identity Operators
Let us have a look at all the operators one by one.

## Python Arithmetic Operators
Assume variable a holds the value 10 and variable b holds the value 21, then −

``` python
#!/usr/bin/python3

a = 21
b = 10
c = 0

c = a + b
print ("Line 1 - Value of c is ", c)

c = a - b
print ("Line 2 - Value of c is ", c )

c = a * b
print ("Line 3 - Value of c is ", c)

c = a / b
print ("Line 4 - Value of c is ", c )

c = a % b
print ("Line 5 - Value of c is ", c)

a = 2
b = 3
c = a**b 
print ("Line 6 - Value of c is ", c)

a = 10
b = 5
c = a//b 
print ("Line 7 - Value of c is ", c)
```

Operator|	Description|	Example
----|----|----
+ Addition|	Adds values on either side of the operator.|	a + b = 31
- Subtraction|	Subtracts right hand operand from left hand operand.|	a – b = -11
* Multiplication|	Multiplies values on either side of the operator|	a * b = 210
/ Division|	Divides left hand operand by right hand operand|	b / a = 2.1
% Modulus|	Divides left hand operand by right hand operand and returns remainder|	b % a = 1
** Exponent|	Performs exponential (power) calculation on operators|	a**b =10 to the power 20
//	Floor Division| The division of operands where the result is the quotient in which the digits after the decimal point are removed. But if one of the operands is negative, the result is floored, i.e., rounded away from zero (towards negative infinity):|	9//2 = 4 and 9.0//2.0 = 4.0, -11//3 = -4, -11.0//3 = -4.0

## Python Comparison Operators
These operators compare the values on either side of them and decide the relation among them. They are also called Relational operators.

Assume variable a holds the value 10 and variable b holds the value 20, then −

``` python
#!/usr/bin/python3

a = 21
b = 10

if ( a == b ):
   print ("Line 1 - a is equal to b")
else:
   print ("Line 1 - a is not equal to b")

if ( a != b ):
   print ("Line 2 - a is not equal to b")
else:
   print ("Line 2 - a is equal to b")

if ( a < b ):
   print ("Line 3 - a is less than b" )
else:
   print ("Line 3 - a is not less than b")

if ( a > b ):
   print ("Line 4 - a is greater than b")
else:
   print ("Line 4 - a is not greater than b")

a,b=b,a #values of a and b swapped. a becomes 10, b becomes 21

if ( a <= b ):
   print ("Line 5 - a is either less than or equal to  b")
else:
   print ("Line 5 - a is neither less than nor equal to  b")

if ( b >= a ):
   print ("Line 6 - b is either greater than  or equal to b")
else:
   print ("Line 6 - b is neither greater than  nor equal to b")
```

Operator|	Description|	Example
----|----|----
==	|If the values of two operands are equal, then the condition becomes true.	|(a == b) is not true.
!=|	If values of two operands are not equal, then condition becomes true.|	(a!= b) is true.
>|	If the value of left operand is greater than the value of right operand, then condition becomes true.|	(a > b) is not true.
<|	If the value of left operand is less than the value of right operand, then condition becomes true.|	(a < b) is true.
>=|	If the value of left operand is greater than or equal to the value of right operand, then condition becomes true.|	(a >= b) is not true.
<=|	If the value of left operand is less than or equal to the value of right operand, then condition becomes true.|	(a <= b) is true.

the output will be
```
Line 1 - a is not equal to b
Line 2 - a is not equal to b
Line 3 - a is not less than b
Line 4 - a is greater than b
Line 5 - a is either less than or equal to  b
Line 6 - b is either greater than  or equal to b
```
## Python Assignment Operators
Assume variable a holds the value 10 and variable b holds the value 20, then −

``` python
#!/usr/bin/python3

a = 21
b = 10
c = 0

c = a + b
print ("Line 1 - Value of c is ", c)

c += a
print ("Line 2 - Value of c is ", c )

c *= a
print ("Line 3 - Value of c is ", c )

c /= a 
print ("Line 4 - Value of c is ", c )

c  = 2
c %= a
print ("Line 5 - Value of c is ", c)

c **= a
print ("Line 6 - Value of c is ", c)

c //= a
print ("Line 7 - Value of c is ", c)
```

Operator|	Description|	Example
----|----|----
=|	Assigns values from right side operands to left side operand|	c = a + b assigns value of a + b into c
+= Add AND|	It adds right operand to the left operand and assign the result to left operand|	c += a is equivalent to c = c + a
-= Subtract AND|	It subtracts right operand from the left operand and assign the result to left operand|	c -= a is equivalent to c = c - a
*= Multiply AND|	It multiplies right operand with the left operand and assign the result to left operand|	c *= a is equivalent to c = c * a
/= Divide AND|	It divides left operand with the right operand and assign the result to left operand|	c /= a is equivalent to c = c / ac /= a is equivalent to c = c / a
%= Modulus AND|	It takes modulus using two operands and assign the result to left |operand	c %= a is equivalent to c = c % a
**= Exponent AND|	Performs exponential (power) calculation on operators and assign value to the left operand|	c **= a is equivalent to c = c ** a
//= Floor Division|	It performs floor division on operators and assign value to the left operand|	c //= a is equivalent to c = c // a

The output
```
Line 1 - Value of c is  31
Line 2 - Value of c is  52
Line 3 - Value of c is  1092
Line 4 - Value of c is  52.0
Line 5 - Value of c is  2
Line 6 - Value of c is  2097152
Line 7 - Value of c is  99864
```
## Python Bitwise Operators
Bitwise operator works on bits and performs bit-by-bit operation. Assume if a = 60; and b = 13; Now in binary format they will be as follows −

a = 0011 1100

b = 0000 1101

-----------------

a&b = 0000 1100

a|b = 0011 1101

a^b = 0011 0001

~a = 1100 0011

Python's built-in function bin() can be used to obtain binary representation of an integer number.

The following Bitwise operators are supported by Python language −

``` python
#!/usr/bin/python3

a = 60            # 60 = 0011 1100
b = 13            # 13 = 0000 1101
print ('a=',a,':',bin(a),'b=',b,':',bin(b))
c = 0

c = a & b;        # 12 = 0000 1100
print ("result of AND is ", c,':',bin(c))

c = a | b;        # 61 = 0011 1101 
print ("result of OR is ", c,':',bin(c))

c = a ^ b;        # 49 = 0011 0001
print ("result of EXOR is ", c,':',bin(c))

c = ~a;           # -61 = 1100 0011
print ("result of COMPLEMENT is ", c,':',bin(c))

c = a << 2;       # 240 = 1111 0000
print ("result of LEFT SHIFT is ", c,':',bin(c))

c = a >> 2;       # 15 = 0000 1111
print ("result of RIGHT SHIFT is ", c,':',bin(c))
```

Operator|	Description|	Example
----|----|----
& Binary AND|	Operator copies a bit, to the result, if it exists in both operands|	(a & b) (means 0000 1100)
| Binary OR|	It copies a bit, if it exists in either operand.|	(a | b) = 61 (means 0011 1101)
^ Binary XOR|	It copies the bit, if it is set in one operand but not both.|	(a ^ b) = 49 (means 0011 0001)
~ Binary Ones Complement|	It is unary and has the effect of 'flipping' bits.|	(~a ) = -61 (means 1100 0011 in 2's complement form due to a signed binary number.
<< Binary Left Shift|	The left operand's value is moved left by the number of bits specified by the right operand.|	a << = 240 (means 1111 0000)
>> Binary Right Shift|	The left operand's value is moved right by the number of bits specified by the right operand.|	a >> = 15 (means 0000 1111)

```
a = 60 : 0b111100 b = 13 : 0b1101
result of AND is  12 : 0b1100
result of OR is  61 : 0b111101
result of EXOR is  49 : 0b110001
result of COMPLEMENT is  -61 : -0b111101
result of LEFT SHIFT is  240 : 0b11110000
result of RIGHT SHIFT is  15 : 0b111
```
## Python Logical Operators
The following logical operators are supported by Python language. Assume variable a holds True and variable b holds False then −

Operator|	Description|	Example
----|----|----
and Logical AND|	If both the operands are true then condition becomes true.	|(a and b) is False.
or Logical OR|	If any of the two operands are non-zero then condition becomes true.|	(a or b) is True.
not Logical NOT|	Used to reverse the logical state of its operand.|	Not(a and b) is True.


## Python Membership Operators
Python’s membership operators test for membership in a sequence, such as strings, lists, or tuples. There are two membership operators as explained below −

```python
#!/usr/bin/python3

a = 10
b = 20
list = [1, 2, 3, 4, 5 ]

if ( a in list ):
   print ("Line 1 - a is available in the given list")
else:
   print ("Line 1 - a is not available in the given list")

if ( b not in list ):
   print ("Line 2 - b is not available in the given list")
else:
   print ("Line 2 - b is available in the given list")

c=b/a
if ( c in list ):
   print ("Line 3 - a is available in the given list")
else:
   print ("Line 3 - a is not available in the given list")
```

Operator|	Description|	Example
----|----|----
in|	Evaluates to true if it finds a variable in the specified sequence and false otherwise.|	x in y, here in results in a 1 if x is a member of sequence y.
not in|	Evaluates to true if it does not finds a variable in the specified sequence and false otherwise.|	x not in y, here not in results in a 1 if x is not a member of sequence y.

The Output
```
Line 1 - a is not available in the given list
Line 2 - b is not available in the given list
Line 3 - a is available in the given list
```

## Python Identity Operators
Identity operators compare the memory locations of two objects. There are two Identity operators as explained below −

```python
#!/usr/bin/python3

a = 20
b = 20
print ('Line 1','a=',a,':',id(a), 'b=',b,':',id(b))

if ( a is b ):
   print ("Line 2 - a and b have same identity")
else:
   print ("Line 2 - a and b do not have same identity")

if ( id(a) == id(b) ):
   print ("Line 3 - a and b have same identity")
else:
   print ("Line 3 - a and b do not have same identity")

b = 30
print ('Line 4','a=',a,':',id(a), 'b=',b,':',id(b))

if ( a is not b ):
   print ("Line 5 - a and b do not have same identity")
else:
   print ("Line 5 - a and b have same identity")
```

Operator|	Description|	Example
----|----|----
is|	Evaluates to true if the variables on either side of the operator point to the same object and false otherwise.|	x is y, here is results in 1 if id(x) equals id(y).
is not|	Evaluates to false if the variables on either side of the operator point to the same object and true otherwise.|	x is not y, here is not results in 1 if id(x) is not equal to id(y).

```
Line 1 a= 20 : 1594701888 b= 20 : 1594701888
Line 2 - a and b have same identity
Line 3 - a and b have same identity
Line 4 a= 20 : 1594701888 b= 30 : 1594702048
Line 5 - a and b do not have same identity
```

## Python Operators Precedence
The following table lists all operators from highest precedence to the lowest.

Show Example

Operator | Description
----|----
**|Exponentiation (raise to the power)
~ + -|Ccomplement, unary plus and minus (method names for the last two are +@ and -@)
* / % //|Multiply, divide, modulo and floor division
+ -|Addition and subtraction
>> <<|Right and left bitwise shift
&|Bitwise 'AND'	
^\| |Bitwise exclusive `OR' and regular `OR'
<= < > >=|Comparison operators
<> == !=|Equality operators
= %= /= //= -= += *= **=|Assignment operators
is is not|Identity operators
in not in|Membership operators
not or and|Logical operators

# Decision Making
Decision-making is the anticipation of conditions occurring during the execution of a program and specified actions taken according to the conditions.

Decision structures evaluate multiple expressions, which produce TRUE or FALSE as the outcome. You need to determine which action to take and which statements to execute if the outcome is TRUE or FALSE otherwise.

Following is the general form of a typical decision making structure found in most of the programming languages −

Python programming language assumes any non-zero and non-null values as TRUE, and any zero or null values as FALSE value.

Python programming language provides the following types of decision-making statements.

Statement | Description
----|----
if statements|An if statement consists of a boolean expression followed by one or more statements.
if...else statements|An if statement can be followed by an optional else statement, which executes when the boolean expression is FALSE.
nested if statements|You can use one if or else if statement inside another if or else if statement(s).

Let us go through each decision-making statement quickly.

## IF Statements
The IF statement is similar to that of other languages. The if statement contains a logical expression using which the data is compared and a decision is made based on the result of the comparison.

Syntax
```
if expression:
   statement(s)
```
If the boolean expression evaluates to TRUE, then the block of statement(s) inside the if statement is executed. In Python, statements in a block are uniformly indented after the : symbol. If boolean expression evaluates to FALSE, then the first set of code after the end of block is executed.

**If statement Example**

``` python
#!/usr/bin/python3

var1 = 100
if var1:
   print ("1 - Got a true expression value")
   print (var1)

var2 = 0
if var2:
   print ("2 - Got a true expression value")
   print (var2)
print ("Good bye!")
```
**Output**

When the above code is executed, it produces the following result −
```
1 - Got a true expression value
100
Good bye!
```

## IF...ELIF...ELSE Statements
An else statement can be combined with an if statement. An else statement contains a block of code that executes if the conditional expression in the if statement resolves to 0 or a FALSE value.

The else statement is an optional statement and there could be at the most only one else statement following if.

**Syntax**
The syntax of the if...else statement is −
```
if expression:
   statement(s)

else:
   statement(s)
```

**Python if...else statement Example**
```python
#!/usr/bin/python3

amount = int(input("Enter amount: "))

if amount<1000:
   discount = amount*0.05
   print ("Discount",discount)
else:
   discount = amount*0.10
   print ("Discount",discount)
    
print ("Net payable:",amount-discount)
```
**Output**

In the above example, discount is calculated on the input amount. Rate of discount is 5%, if the amount is less than 1000, and 10% if it is above 10000. When the above code is executed, it produces the following result −
```
Enter amount: 600
Discount 30.0
Net payable: 570.0

Enter amount: 1200
Discount 120.0
Net payable: 1080.0
```
### The elif Statement
The elif statement allows you to check multiple expressions for TRUE and execute a block of code as soon as one of the conditions evaluates to TRUE.

Similar to the else, the elif statement is optional. However, unlike else, for which there can be at the most one statement, there can be an arbitrary number of elif statements following an if.

**syntax**
```
if expression1:
   statement(s)
elif expression2:
   statement(s)
elif expression3:
   statement(s)
else:
   statement(s)
```   
Core Python does not provide switch or case statements as in other languages, but we can use if..elif...statements to simulate switch case as follows −

**Example**
```python
#!/usr/bin/python3

amount = int(input("Enter amount: "))

if amount<1000:
   discount = amount*0.05
   print ("Discount",discount)
elif amount<5000:
   discount = amount*0.10
   print ("Discount",discount)
else:
   discount = amount*0.15
   print ("Discount",discount)
    
print ("Net payable:",amount-discount)
```
When the above code is executed, it produces the following result −
```
Enter amount: 600
Discount 30.0
Net payable: 570.0

Enter amount: 3000
Discount 300.0
Net payable: 2700.0

Enter amount: 6000
Discount 900.0
Net payable: 5100.0
```

## Nested IF Statements
There may be a situation when you want to check for another condition after a condition resolves to true. In such a situation, you can use the nested if construct.

>In a nested if construct, you can have an if...elif...else construct inside another if...elif...else construct.

**Syntax**

The syntax of the nested if...elif...else construct may be −
```
if expression1:
   statement(s)
   if expression2:
      statement(s)
   elif expression3:
      statement(s)
   else
      statement(s)
elif expression4:
   statement(s)
else:
   statement(s)
```

**Example**
``` python
# !/usr/bin/python3
num = int(input("enter number"))
if num%2 == 0:
   if num%3 == 0:
      print ("Divisible by 3 and 2")
   else:
      print ("divisible by 2 not divisible by 3")
else:
   if num%3 == 0:
      print ("divisible by 3 not divisible by 2")
   else:
      print  ("not Divisible by 2 not divisible by 3")
```
**Output**

When the above code is executed, it produces the following result −
```
enter number8
divisible by 2 not divisible by 3

enter number15
divisible by 3 not divisible by 2

enter number12
Divisible by 3 and 2

enter number5
not Divisible by 2 not divisible by 3
```


## Single Statement Suites
If the suite of an if clause consists only of a single line, it may go on the same line as the header statement.

Example
Here is an example of a one-line if clause −
``` python
#!/usr/bin/python3
var = 100
if ( var  == 100 ) : print ("Value of expression is 100")
print ("Good bye!")
```
Output
When the above code is executed, it produces the following result −
```
Value of expression is 100
Good bye!
```
# Loops
In general, statements are executed sequentially − The first statement in a function is executed first, followed by the second, and so on. There may be a situation when you need to execute a block of code several number of times.

Programming languages provide various control structures that allow more complicated execution paths.

A loop statement allows us to execute a statement or group of statements multiple times. The following diagram illustrates a loop statement −

Loop Architecture
Python programming language provides the following types of loops to handle looping requirements.

Loop Type | Description
----|----
while loop|Repeats a statement or group of statements while a given condition is TRUE. It tests the condition before executing the loop body.
for loop|Executes a sequence of statements multiple times and abbreviates the code that manages the loop variable.
nested loops|You can use one or more loop inside any another while, or for loop.

## while Loop Statements
A while loop statement in Python programming language repeatedly executes a target statement as long as a given condition is true.

**Syntax**
The syntax of a while loop in Python programming language is −
```
while expression:
   statement(s)
```
Here, statement(s) may be a single statement or a block of statements with uniform indent. The condition may be any expression, and true is any non-zero value. The loop iterates while the condition is true.

When the condition becomes false, program control passes to the line immediately following the loop.

In Python, all the statements indented by the same number of character spaces after a programming construct are considered to be part of a single block of code. Python uses indentation as its method of grouping statements.

Here, a key point of the while loop is that the loop might not ever run. When the condition is tested and the result is false, the loop body will be skipped and the first statement after the while loop will be executed.

**Example**
```python
#!/usr/bin/python3

count = 0
while (count < 9):
   print ('The count is:', count)
   count = count + 1

print ("Good bye!")
```
**Output**

When the above code is executed, it produces the following result −
```
The count is: 0
The count is: 1
The count is: 2
The count is: 3
The count is: 4
The count is: 5
The count is: 6
The count is: 7
The count is: 8
Good bye!
```
The block here, consisting of the print and increment statements, is executed repeatedly until count is no longer less than 9. With each iteration, the current value of the index count is displayed and then increased by 1.

### The Infinite Loop
A loop becomes infinite loop if a condition never becomes FALSE. You must be cautious when using while loops because of the possibility that this condition never resolves to a FALSE value. This results in a loop that never ends. Such a loop is called an infinite loop.

An infinite loop might be useful in client/server programming where the server needs to run continuously so that client programs can communicate with it as and when required.

Example
```python
#!/usr/bin/python3

var = 1
while var == 1 :  # This constructs an infinite loop
   num = int(input("Enter a number  :"))
   print ("You entered: ", num)

print ("Good bye!")
```
**Output**
When the above code is executed, it produces the following result −
```
Enter a number  :20
You entered:  20
Enter a number  :29
You entered:  29
Enter a number  :3
You entered:  3
Enter a number  :11
You entered:  11
Enter a number  :22
You entered:  22
Enter a number  :Traceback (most recent call last):
   File "examples\test.py", line 5, in 
      num = int(input("Enter a number  :"))
KeyboardInterrupt
```
The above example goes in an infinite loop and you need to use CTRL+C to exit the program.

### Using else Statement with Loops
Python supports having an else statement associated with a loop statement.

If the else statement is used with a for loop, the else statement is executed when the loop has exhausted iterating the list.

If the else statement is used with a while loop, the else statement is executed when the condition becomes false.

The following example illustrates the combination of an else statement with a while statement that prints a number as long as it is less than 5, otherwise the else statement gets executed.

**Example**
```python
#!/usr/bin/python3

count = 0
while count < 5:
   print (count, " is  less than 5")
   count = count + 1
else:
   print (count, " is not less than 5")
```   
**Output**
When the above code is executed, it produces the following result −
```
0 is less than 5
1 is less than 5
2 is less than 5
3 is less than 5
4 is less than 5
5 is not less than 5
```
### Single Statement Suites
Similar to the if statement syntax, if your while clause consists only of a single statement, it may be placed on the same line as the while header.

**Example**
Here is the syntax and example of a one-line while clause −
```python
#!/usr/bin/python3

flag = 1
while (flag): print ('Given flag is really true!')
print ("Good bye!")
```
The above example goes into an infinite loop and you need to press CTRL+C keys to exit.

## for loop Statements
The for statement in Python has the ability to iterate over the items of any sequence, such as a list or a string.

**Syntax**
```
for iterating_var in sequence:
   statements(s)
```
If a sequence contains an expression list, it is evaluated first. Then, the first item in the sequence is assigned to the iterating variable `iterating_var`. Next, the `statements` block is executed. Each item in the list is assigned to iterating_var, and the `statement(s)` block is executed until the entire sequence is exhausted.

### The range() function
The built-in function range() is the right function to iterate over a sequence of numbers. It generates an iterator of arithmetic progressions.

Example
```python
>>> range(5)
range(0, 5)
>>> list(range(5))
[0, 1, 2, 3, 4]
```
**Example**

**range()** generates an iterator to progress integers starting with 0 upto n-1. To obtain a list object of the sequence, it is typecasted to list(). Now this list can be iterated using the for statement.
```python
>>> for var in list(range(5)):
   print (var)
```
**Output**
This will produce the following output.
```
0
1
2
3
4
```
**Example**
```python
#!/usr/bin/python3

for letter in 'Python':     # traversal of a string sequence
   print ('Current Letter :', letter)
print()
fruits = ['banana', 'apple',  'mango']
for fruit in fruits:        # traversal of List sequence
   print ('Current fruit :', fruit)

print ("Good bye!")
```
**Output**
When the above code is executed, it produces the following result −
```
Current Letter : P
Current Letter : y
Current Letter : t
Current Letter : h
Current Letter : o
Current Letter : n

Current fruit : banana
Current fruit : apple
Current fruit : mango
Good bye!
```
### Iterating by Sequence Index
An alternative way of iterating through each item is by index offset into the sequence itself. Following is a simple example −

Example
```python
#!/usr/bin/python3

fruits = ['banana', 'apple',  'mango']
for index in range(len(fruits)):
   print ('Current fruit :', fruits[index])

print ("Good bye!")
```
**Output**

When the above code is executed, it produces the following result −
```
Current fruit : banana
Current fruit : apple
Current fruit : mango
Good bye!
```
Here, we took the assistance of the len() built-in function, which provides the total number of elements in the tuple as well as the range() built-in function to give us the actual sequence to iterate over.

### Using else Statement with Loops
Python supports having an else statement associated with a loop statement.

If the else statement is used with a for loop, the else block is executed only if for loops terminates normally (and not by encountering break statement).

If the else statement is used with a while loop, the else statement is executed when the condition becomes false.

**Example**
The following example illustrates the combination of an else statement with a for statement that searches for even number in given list.
``` python
#!/usr/bin/python3

numbers = [11,33,55,39,55,75,37,21,23,41,13]

for num in numbers:
   if num%2 == 0:
      print ('the list contains an even number')
      break
else:
   print ('the list doesnot contain even number')
```
**Output**
When the above code is executed, it produces the following result −
```
the list does not contain even number
```
## Nested Loops
Python programming language allows the usage of one loop inside another loop. The following section shows a few examples to illustrate the concept.

Syntax
```for iterating_var in sequence:
   for iterating_var in sequence:
      statements(s)
   statements(s)
```
The syntax for a nested while loop statement in Python programming language is as follows −
```
while expression:
   while expression:
      statement(s)
   statement(s)
```
A final note on loop nesting is that you can put any type of loop inside any other type of loop. For example a for loop can be inside a while loop or vice versa.

**Example**
The following program uses a nested-for loop to display multiplication tables from 1-10.
```python
#!/usr/bin/python3
import sys
for i in range(1,11):
   for j in range(1,11):
      k=i*j
      print (k, end=' ')
   print()
```   
The print() function inner loop has end=' ' which appends a space instead of default newline. Hence, the numbers will appear in one row.

Last print() will be executed at the end of inner for loop.

**Output**
When the above code is executed, it produces the following result −
```
1 2 3 4 5 6 7 8 9 10 
2 4 6 8 10 12 14 16 18 20 
3 6 9 12 15 18 21 24 27 30 
4 8 12 16 20 24 28 32 36 40 
5 10 15 20 25 30 35 40 45 50 
6 12 18 24 30 36 42 48 54 60 
7 14 21 28 35 42 49 56 63 70 
8 16 24 32 40 48 56 64 72 80 
9 18 27 36 45 54 63 72 81 90 
10 20 30 40 50 60 70 80 90 100 
```

## Loop Control Statements
The Loop control statements change the execution from its normal sequence. When the execution leaves a scope, all automatic objects that were created in that scope are destroyed.

Python supports the following control statements.

Control Statement | Description
----|----
break statement|Terminates the loop statement and transfers execution to the statement immediately following the loop.
continue statement|Causes the loop to skip the remainder of its body and immediately retest its condition prior to reiterating.
pass statement|The pass statement in Python is used when a statement is required syntactically but you do not want any command or code to execute.

Let us go through the loop control statements briefly.

## Iterator and Generator
Iterator is an object which allows a programmer to traverse through all the elements of a collection, regardless of its specific implementation. In Python, an iterator object implements two methods, iter() and next().

String, List or Tuple objects can be used to create an Iterator.
```
list = [1,2,3,4]
it = iter(list) # this builds an iterator object
print (next(it)) #prints next available element in iterator
```
Iterator object can be traversed using regular for statement
``` python
!usr/bin/python3
for x in it:
   print (x, end=" ")
or using next() function
while True:
   try:
      print (next(it))
   except StopIteration:
      sys.exit() #you have to import sys module for this
```      
A **generator** is a function that produces or yields a sequence of values using yield method.

When a generator function is called, it returns a generator object without even beginning execution of the function. When the next() method is called for the first time, the function starts executing until it reaches the yield statement, which returns the yielded value. The yield keeps track i.e. remembers the last execution and the second next() call continues from previous value.

**Example**
The following example defines a generator, which generates an iterator for all the Fibonacci numbers.
```python
!usr/bin/python3
import sys
def fibonacci(n): #generator function
   a, b, counter = 0, 1, 0
   while True:
      if (counter > n): 
         return
      yield a
      a, b = b, a + b
      counter += 1
f = fibonacci(5) #f is iterator object

while True:
   try:
      print (next(f), end=" ")
   except StopIteration:
      sys.exit()
```      

# Date & Time ?

# Functions
> A function is a block of organized, reusable code that is used to perform a single, related action. Functions provide better modularity for your application and a high degree of code reusing.

As you already know, Python gives you many built-in functions like print(), etc. but you can also create your own functions. These functions are called user-defined functions.

## Defining a Function
You can define functions to provide the required functionality. Here are simple rules to define a function in Python.

- Function blocks begin with the keyword def followed by the function name and parentheses `( )`.

- Any input parameters or arguments should be placed within these parentheses. You can also define parameters inside these parentheses.

- The first statement of a function can be an optional statement - the documentation string of the function or docstring.

- The code block within every function starts with a colon (:) and is indented.

- The statement return [expression] exits a function, optionally passing back an expression to the caller. A return statement with no arguments is the same as return None.

**Syntax**
```python
def functionname( parameters ):
   "function_docstring"
   function_suite
   return [expression]
```
By default, parameters have a positional behavior and you need to inform them in the same order that they were defined.

**Example**
The following function takes a string as input parameter and prints it on standard screen.
```
def printme( str ):
   "This prints a passed string into this function"
   print (str)
   return
```   
## Calling a Function
Defining a function gives it a name, specifies the parameters that are to be included in the function and structures the blocks of code.

Once the basic structure of a function is finalized, you can execute it by calling it from another function or directly from the Python prompt. Following is an example to call the printme() function −
```python
#!/usr/bin/python3

# Function definition is here
def printme( str ):
   "This prints a passed string into this function"
   print (str)
   return

# Now you can call printme function
printme("This is first call to the user defined function!")
printme("Again second call to the same function")
```
When the above code is executed, it produces the following result −
```
This is first call to the user defined function!
Again second call to the same function
```
## Pass by Reference vs Value
All parameters (arguments) in the Python language are passed by reference. It means if you change what a parameter refers to within a function, the change also reflects back in the calling function. For example −
```python
#!/usr/bin/python3

# Function definition is here
def changeme( mylist ):
   "This changes a passed list into this function"
   print ("Values inside the function before change: ", mylist)
   mylist[2]=50
   print ("Values inside the function after change: ", mylist)
   return

# Now you can call changeme function
mylist = [10,20,30]
changeme( mylist )
print ("Values outside the function: ", mylist)
```
Here, we are maintaining reference of the passed object and appending values in the same object. Therefore, this would produce the following result −
```
Values inside the function before change:  [10, 20, 30]
Values inside the function after change:  [10, 20, 50]
Values outside the function:  [10, 20, 50]
```
There is one more example where argument is being passed by reference and the reference is being overwritten inside the called function.
```python
#!/usr/bin/python3

# Function definition is here
def changeme( mylist ):
   "This changes a passed list into this function"
   mylist = [1,2,3,4] # This would assi new reference in mylist
   print ("Values inside the function: ", mylist)
   return

# Now you can call changeme function
mylist = [10,20,30]
changeme( mylist )
print ("Values outside the function: ", mylist)
```
The parameter mylist is local to the function changeme. Changing mylist within the function does not affect mylist. The function accomplishes nothing and finally this would produce the following result −
```
Values inside the function:  [1, 2, 3, 4]
Values outside the function:  [10, 20, 30]
```
## Function Arguments
You can call a function by using the following types of formal arguments −

- Required arguments
- Keyword arguments
- Default arguments
- Variable-length arguments

### Required Arguments
Required arguments are the arguments passed to a function in correct positional order. Here, the number of arguments in the function call should match exactly with the function definition.

To call the function printme(), you definitely need to pass one argument, otherwise it gives a syntax error as follows −
```python
#!/usr/bin/python3

# Function definition is here
def printme( str ):
   "This prints a passed string into this function"
   print (str)
   return

# Now you can call printme function
printme()
```
When the above code is executed, it produces the following result −
```
Traceback (most recent call last):
   File "test.py", line 11, in <module>
      printme();
TypeError: printme() takes exactly 1 argument (0 given)
```
### Keyword Arguments
Keyword arguments are related to the function calls. When you use keyword arguments in a function call, the caller identifies the arguments by the parameter name.

This allows you to skip arguments or place them out of order because the Python interpreter is able to use the keywords provided to match the values with parameters. You can also make keyword calls to the printme() function in the following ways −
```python
#!/usr/bin/python3

# Function definition is here
def printme( str ):
   "This prints a passed string into this function"
   print (str)
   return

# Now you can call printme function
printme( str = "My string")
```
When the above code is executed, it produces the following result −

### My string
The following example gives a clearer picture. Note that the order of parameters does not matter.
```python
#!/usr/bin/python3

# Function definition is here
def printinfo( name, age ):
   "This prints a passed info into this function"
   print ("Name: ", name)
   print ("Age ", age)
   return

# Now you can call printinfo function
printinfo( age = 50, name = "miki" )
```
When the above code is executed, it produces the following result −
```
Name:  miki
Age  50
```
### Default Arguments
A default argument is an argument that assumes a default value if a value is not provided in the function call for that argument. The following example gives an idea on default arguments, it prints default age if it is not passed −
```python
#!/usr/bin/python3

# Function definition is here
def printinfo( name, age = 35 ):
   "This prints a passed info into this function"
   print ("Name: ", name)
   print ("Age ", age)
   return

# Now you can call printinfo function
printinfo( age = 50, name = "miki" )
printinfo( name = "miki" )
```
When the above code is executed, it produces the following result −
```
Name:  miki
Age  50
Name:  miki
Age  35
```
### Variable-length Arguments
You may need to process a function for more arguments than you specified while defining the function. These arguments are called variable-length arguments and are not named in the function definition, unlike required and default arguments.

Syntax for a function with non-keyword variable arguments is given below −
```
def functionname([formal_args,] *var_args_tuple ):
   "function_docstring"
   function_suite
   return [expression]
```
An asterisk `*` is placed before the variable name that holds the values of all nonkeyword variable arguments. This tuple remains empty if no additional arguments are specified during the function call. Following is a simple example −
```python
#!/usr/bin/python3

# Function definition is here
def printinfo( arg1, *vartuple ):
   "This prints a variable passed arguments"
   print ("Output is: ")
   print (arg1)
   for var in vartuple:
      print (var)
   return

# Now you can call printinfo function
printinfo( 10 )
printinfo( 70, 60, 50 )
```
When the above code is executed, it produces the following result −
```
Output is:
10
Output is:
70
60
50
```
### The Anonymous Functions
> These functions are called anonymous because they are not declared in the standard manner by using the def keyword. You can use the `lambda` keyword to create small anonymous functions.

- Lambda forms can take any number of arguments but return just one value in the form of an expression. They cannot contain commands or multiple expressions.

- An anonymous function cannot be a direct call to print because lambda requires an expression.

- Lambda functions have their own local namespace and cannot access variables other than those in their parameter list and those in the global namespace.

Although it appears that lambdas are a one-line version of a function, they are not equivalent to inline statements in C or C++, whose purpose is to stack allocation by passing function, during invocation for performance reasons.

**Syntax**
The syntax of lambda functions contains only a single statement, which is as follows −
```
lambda [arg1 [,arg2,.....argn]]:expression
```
Following is an example to show how lambda form of function works −
```python
#!/usr/bin/python3

# Function definition is here
sum = lambda arg1, arg2: arg1 + arg2


# Now you can call sum as a function
print ("Value of total : ", sum( 10, 20 ))
print ("Value of total : ", sum( 20, 20 ))
```
When the above code is executed, it produces the following result −
```
Value of total :  30
Value of total :  40
```
## The return Statement
The statement return [expression] exits a function, optionally passing back an expression to the caller. A return statement with no arguments is the same as return None.

All the examples given below are not returning any value. You can return a value from a function as follows −
```python
#!/usr/bin/python3

# Function definition is here
def sum( arg1, arg2 ):
   # Add both the parameters and return them."
   total = arg1 + arg2
   print ("Inside the function : ", total)
   return total

# Now you can call sum function
total = sum( 10, 20 )
print ("Outside the function : ", total )
```
When the above code is executed, it produces the following result −
```
Inside the function :  30
Outside the function :  30
```
### Scope of Variables
All variables in a program may not be accessible at all locations in that program. This depends on where you have declared a variable.

The scope of a variable determines the portion of the program where you can access a particular identifier. There are two basic scopes of variables in Python −

- Global variables
- Local variables

#### Global vs. Local variables
Variables that are defined inside a function body have a local scope, and those defined outside have a global scope.

This means that local variables can be accessed only inside the function in which they are declared, whereas global variables can be accessed throughout the program body by all functions. When you call a function, the variables declared inside it are brought into scope. Following is a simple example −
```python
#!/usr/bin/python3

total = 0 # This is global variable.
# Function definition is here
def sum( arg1, arg2 ):
   # Add both the parameters and return them."
   total = arg1 + arg2; # Here total is local variable.
   print ("Inside the function local total : ", total)
   return total

# Now you can call sum function
sum( 10, 20 )
print ("Outside the function global total : ", total )
```
When the above code is executed, it produces the following result −
```
Inside the function local total :  30
Outside the function global total :  0
```

# Modules
A module allows you to logically organize your Python code. Grouping related code into a module makes the code easier to understand and use. A module is a Python object with arbitrarily named attributes that you can bind and reference.

Simply, a module is a file consisting of Python code. A module can define functions, classes and variables. A module can also include runnable code.

Example
The Python code for a module named aname normally resides in a file namedaname.py. Here is an example of a simple module, support.py −
```python
def print_func( par ):
   print "Hello : ", par
   return
```   
## The import Statement
You can use any Python source file as a module by executing an import statement in some other Python source file. The import has the following syntax −

```
import module1[, module2[,... moduleN]
```
When the interpreter encounters an import statement, it imports the module if the module is present in the search path. A search path is a list of directories that the interpreter searches before importing a module. For example, to import the module hello.py, you need to put the following command at the top of the script −
```python
#!/usr/bin/python3

# Import module support
import support

# Now you can call defined function that module as follows
support.print_func("Zara")
```
When the above code is executed, it produces the following result −
```
Hello : Zara
```
 A module is loaded only once, regardless of the number of times it is imported. This prevents the module execution from happening repeatedly, if multiple imports occur.

## The from...import Statement
Python's from statement lets you import specific attributes from a module into the current namespace. The from...import has the following syntax −
```
from modname import name1[, name2[, ... nameN]]
```
For example, to import the function fibonacci from the module fib, use the following statement −
```python
#!/usr/bin/python3

# Fibonacci numbers module

def fib(n): # return Fibonacci series up to n
   result = []
   a, b = 0, 1
   while b < n:
      result.append(b)
      a, b = b, a + b
   return result
>>> from fib import fib
>>> fib(100)
[1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
```
This statement does not import the entire module fib into the current namespace; it just introduces the item fibonacci from the module fib into the global symbol table of the importing module.
```
The from...import * Statement
```
It is also possible to import all the names from a module into the current namespace by using the following import statement −
```
from modname import *
```
This provides an easy way to import all the items from a module into the current namespace; however, this statement should be used sparingly.

## Executing Modules as Scripts
Within a module, the module’s name (as a string) is available as the value of the global variable __name__. The code in the module will be executed, just as if you imported it, but with the __name__ set to "__main__".

Add this code at the end of your module −
```python
#!/usr/bin/python3

# Fibonacci numbers module

def fib(n): # return Fibonacci series up to n
   result = []
   a, b = 0, 1
   while b < n:
      result.append(b)
      a, b = b, a + b
   return result
if __name__ == "__main__":
   f = fib(100)
   print(f)
```   
When you run the above code, the following output will be displayed.
```
[1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
```
## Locating Modules
When you import a module, the Python interpreter searches for the module in the following sequences −

- The current directory.
- If the module is not found, Python then searches each directory in the shell variable PYTHONPATH.
- If all else fails, Python checks the default path. On UNIX, this default path is normally /usr/local/lib/python3/.

The module search path is stored in the system module sys as the sys.path variable. The sys.path variable contains the current directory, PYTHONPATH, and the installation-dependent default.

## The PYTHONPATH Variable
The `PYTHONPATH` is an environment variable, consisting of a list of directories. The syntax of PYTHONPATH is the same as that of the shell variable PATH.

Here is a typical PYTHONPATH from a Windows system −
```
set PYTHONPATH = c:\python34\lib;
```
And here is a typical PYTHONPATH from a UNIX system −
```
set PYTHONPATH = /usr/local/lib/python
```
## Namespaces and Scoping
Variables are names (identifiers) that map to objects. A namespace is a dictionary of variable names (keys) and their corresponding objects (values).

- A Python statement can access variables in a local namespace and in the global namespace. If a local and a global variable have the same name, the local variable shadows the global variable.

- Each function has its own local namespace. Class methods follow the same scoping rule as ordinary functions.

- Python makes educated guesses on whether variables are local or global. It assumes that any variable assigned a value in a function is local.

Therefore, in order to assign a value to a global variable within a function, you must first use the global statement.

The statement global VarName tells Python that VarName is a global variable. Python stops searching the local namespace for the variable.

For example, *we define a variable Money in the global namespace. Within the function Money, we assign Money a value, therefore Python assumes Money as a local variable.*

However, we accessed the value of the local variable Money before setting it, so an UnboundLocalError is the result. Uncommenting the global statement fixes the problem.
```python
#!/usr/bin/python3

Money = 2000
def AddMoney():
   # Uncomment the following line to fix the code:
   # global Money
   Money = Money + 1

print (Money)
AddMoney()
print (Money)
```
## The dir( ) Function
> The dir() built-in function returns a sorted list of strings containing the names defined by a module.

The list contains the names of all the modules, variables and functions that are defined in a module. Following is a simple example −
```python
#!/usr/bin/python3

# Import built-in module math
import math

content = dir(math)

print (content)
When the above code is executed, it produces the following result −

['__doc__', '__file__', '__name__', 'acos', 'asin', 'atan', 
'atan2', 'ceil', 'cos', 'cosh', 'degrees', 'e', 'exp', 
'fabs', 'floor', 'fmod', 'frexp', 'hypot', 'ldexp', 'log',
'log10', 'modf', 'pi', 'pow', 'radians', 'sin', 'sinh', 
'sqrt', 'tan', 'tanh']
```
Here, the special string variable `__name__` is the module's name, and `__file__` is the filename from which the module was loaded.

## The globals() and locals() Functions
The `globals()` and `locals()` functions can be used to return the names in the global and local namespaces depending on the location from where they are called.

- If `locals()` is called from within a function, it will return all the names that can be accessed locally from that function.

- If `globals()` is called from within a function, it will return all the names that can be accessed globally from that function.

The return type of both these functions is dictionary. Therefore, names can be extracted using the keys() function.

## The reload() Function
When a module is imported into a script, the code in the top-level portion of a module is executed only once.

Therefore, if you want to reexecute the top-level code in a module, you can use the reload() function. The reload() function imports a previously imported module again. The syntax of the reload() function is this −

### reload(module_name)
Here, module_name is the name of the module you want to reload and not the string containing the module name. For example, to reload hello module, do the following −
```
 reload(hello)
```
## Packages in Python
A package is a hierarchical file directory structure that defines a single Python application environment that consists of modules and subpackages and sub-subpackages, and so on.

Consider a file Pots.py available in Phone directory. This file has the following line of source code −
```python
#!/usr/bin/python3

def Pots():
print ("I'm Pots Phone")  
```
Similar, we have other two files having different functions with the same name as above. They are −
```
Phone/Isdn.py file having function Isdn()

Phone/G3.py file having function G3()
```
Now, create one more file `__init__.py` in the Phone directory −
```
Phone/__init__.py
```
To make all of your functions available when you have imported Phone, you need to put explicit import statements in `__init__.py` as follows −
```
from Pots import Pots
from Isdn import Isdn
from G3 import G3
```
After you add these lines to `__init__.py`, you have all of these classes available when you import the Phone package.
```python
#!/usr/bin/python3

# Now import your Phone Package.
import Phone

Phone.Pots()
Phone.Isdn()
Phone.G3()
```
When the above code is executed, it produces the following result −
```
I'm Pots Phone
I'm 3G Phone
I'm ISDN Phone
```
In the above example, we have taken example of a single function in each file, but you can keep multiple functions in your files. You can also define different Python classes in those files and then you can create your packages out of those classes.

# Files I/O ?
# Exceptions Handling ?

# Object Oriented Python
Python has been an object-oriented language since the time it existed. Due to this, creating and using classes and objects are downright easy. This chapter helps you become an expert in using Python's object-oriented programming support.

If you do not have any previous experience with object-oriented (OO) programming, you may want to consult an introductory course on it or at least a tutorial of some sort so that you have a grasp of the basic concepts.

However, here is a small introduction of Object-Oriented Programming (OOP) to help you −

## Overview of OOP Terminology
- Class − A user-defined prototype for an object that defines a set of attributes that characterize any object of the class. The attributes are data members (class variables and instance variables) and methods, accessed via dot notation.

- Class variable − A variable that is shared by all instances of a class. Class variables are defined within a class but outside any of the class's methods. Class variables are not used as frequently as instance variables are.

- Data member − A class variable or instance variable that holds data associated with a class and its objects.

- Function overloading − The assignment of more than one behavior to a particular function. The operation performed varies by the types of objects or arguments involved.

- Instance variable − A variable that is defined inside a method and belongs only to the current instance of a class.

- Inheritance − The transfer of the characteristics of a class to other classes that are derived from it.

- Instance − An individual object of a certain class. An object obj that belongs to a class Circle, for example, is an instance of the class Circle.

- Instantiation − The creation of an instance of a class.

- Method − A special kind of function that is defined in a class definition.

- Object − A unique instance of a data structure that is defined by its class. An object comprises both data members (class variables and instance variables) and methods.

- Operator overloading − The assignment of more than one function to a particular operator.

## Creating Classes
The class statement creates a new class definition. The name of the class immediately follows the keyword class followed by a colon as follows −
```
class ClassName:
   'Optional class documentation string'
   class_suite
```
The class has a documentation string, which can be accessed via `ClassName.__doc__`.

The class_suite consists of all the component statements defining class members, data attributes and functions.

**Example**
Following is an example of a simple Python class −
```python
class Employee:
   'Common base class for all employees'
   empCount = 0

   def __init__(self, name, salary):
      self.name = name
      self.salary = salary
      Employee.empCount += 1
   
   def displayCount(self):
     print "Total Employee %d" % Employee.empCount

   def displayEmployee(self):
      print "Name : ", self.name,  ", Salary: ", self.salary
```
The variable empCount is a class variable whose value is shared among all the instances of a in this class. This can be accessed as Employee.empCount from inside the class or outside the class.

The first method `__init__()` is a special method, which is called class constructor or initialization method that Python calls when you create a new instance of this class.

You declare other class methods like normal functions with the exception that the first argument to each method is self. Python adds the self argument to the list for you; you do not need to include it when you call the methods.

## Creating Instance Objects
To create instances of a class, you call the class using class name and pass in whatever arguments its `__init__` method accepts.
```
#This would create first object of Employee class
emp1 = Employee("Zara", 2000)
#This would create second object of Employee class
emp2 = Employee("Manni", 5000)
```
## Accessing Attributes
You access the object's attributes using the dot operator with object. Class variable would be accessed using class name as follows −
```
emp1.displayEmployee()
emp2.displayEmployee()
print ("Total Employee %d" % Employee.empCount)
```
Now, putting all the concepts together −
```python
#!/usr/bin/python3

class Employee:
   'Common base class for all employees'
   empCount = 0

   def __init__(self, name, salary):
      self.name = name
      self.salary = salary
      Employee.empCount += 1
   
   def displayCount(self):
     print ("Total Employee %d" % Employee.empCount)

   def displayEmployee(self):
      print ("Name : ", self.name,  ", Salary: ", self.salary)


#This would create first object of Employee class"
emp1 = Employee("Zara", 2000)
#This would create second object of Employee class"
emp2 = Employee("Manni", 5000)
emp1.displayEmployee()
emp2.displayEmployee()
print ("Total Employee %d" % Employee.empCount)
```
When the above code is executed, it produces the following result −
```
Name :  Zara ,Salary:  2000
Name :  Manni ,Salary:  5000
Total Employee 2
```
You can add, remove, or modify attributes of classes and objects at any time −
```python
emp1.salary = 7000  # Add an 'salary' attribute.
emp1.name = 'xyz'  # Modify 'age' attribute.
del emp1.salary  # Delete 'age' attribute.
```
Instead of using the normal statements to access attributes, you can use the following functions −

- The `getattr(obj, name[, default])` − to access the attribute of object.

- The `hasattr(obj,name)` − to check if an attribute exists or not.

- The `setattr(obj,name,value)` − to set an attribute. If attribute does not exist, then it would be created.

- The `delattr(obj, name)` − to delete an attribute.
```
hasattr(emp1, 'salary')    # Returns true if 'salary' attribute exists
getattr(emp1, 'salary')    # Returns value of 'salary' attribute
setattr(emp1, 'salary', 7000) # Set attribute 'salary' at 7000
delattr(emp1, 'salary')    # Delete attribute 'salary'
```
## Built-In Class Attributes
Every Python class keeps following built-in attributes and they can be accessed using dot operator like any other attribute −

`__dict__` − Dictionary containing the class's namespace.

`__doc__` − Class documentation string or none, if undefined.

`__name__` − Class name.

`__module__` − Module name in which the class is defined. This attribute is `"__main__"` in interactive mode.

`__bases__` − A possibly empty tuple containing the base classes, in the order of their occurrence in the base class list.

For the above class let us try to access all these attributes −
```python
#!/usr/bin/python3

class Employee:
   'Common base class for all employees'
   empCount = 0

   def __init__(self, name, salary):
      self.name = name
      self.salary = salary
      Employee.empCount += 1
   
   def displayCount(self):
     print ("Total Employee %d" % Employee.empCount)

   def displayEmployee(self):
      print ("Name : ", self.name,  ", Salary: ", self.salary)

emp1 = Employee("Zara", 2000)
emp2 = Employee("Manni", 5000)
print ("Employee.__doc__:", Employee.__doc__)
print ("Employee.__name__:", Employee.__name__)
print ("Employee.__module__:", Employee.__module__)
print ("Employee.__bases__:", Employee.__bases__)
print ("Employee.__dict__:", Employee.__dict__ )
```
When the above code is executed, it produces the following result −
```
Employee.__doc__: Common base class for all employees
Employee.__name__: Employee
Employee.__module__: __main__
Employee.__bases__: (<class 'object'>,)
Employee.__dict__: {
   'displayCount': <function Employee.displayCount at 0x0160D2B8>, 
   '__module__': '__main__', '__doc__': 'Common base class for all employees', 
   'empCount': 2, '__init__': 
   <function Employee.__init__ at 0x0124F810>, 'displayEmployee': 
   <function Employee.displayEmployee at 0x0160D300>,
   '__weakref__': 
   <attribute '__weakref__' of 'Employee' objects>, '__dict__': 
   <attribute '__dict__' of 'Employee' objects>
}
```
## Destroying Objects (Garbage Collection)
Python deletes unneeded objects (built-in types or class instances) automatically to free the memory space. The process by which Python periodically reclaims blocks of memory that no longer are in use is termed as Garbage Collection.

> Python's garbage collector runs during program execution and is triggered when an object's reference count reaches zero. An object's reference count changes as the number of aliases that point to it changes.

An object's reference count increases when it is assigned a new name or placed in a container (list, tuple, or dictionary). The object's reference count decreases when it is deleted with del, its reference is reassigned, or its reference goes out of scope. When an object's reference count reaches zero, Python collects it automatically.
```
a = 40      # Create object <40>
b = a       # Increase ref. count  of <40> 
c = [b]     # Increase ref. count  of <40> 

del a       # Decrease ref. count  of <40>
b = 100     # Decrease ref. count  of <40> 
c[0] = -1   # Decrease ref. count  of <40> 
```
You normally will not notice when the garbage collector destroys an orphaned instance and reclaims its space. However, a class can implement the special method __del__(), called a destructor, that is invoked when the instance is about to be destroyed. This method might be used to clean up any non-memory resources used by an instance.

**Example**
This `__del__()` destructor prints the class name of an instance that is about to be destroyed −
```python
#!/usr/bin/python3

class Point:
   def __init__( self, x=0, y=0):
      self.x = x
      self.y = y
   def __del__(self):
      class_name = self.__class__.__name__
      print (class_name, "destroyed")

pt1 = Point()
pt2 = pt1
pt3 = pt1
print (id(pt1), id(pt2), id(pt3));   # prints the ids of the obejcts
del pt1
del pt2
del pt3
```
When the above code is executed, it produces the following result −
```
3083401324 3083401324 3083401324
Point destroyed
```
> **Note** − Ideally, you should define your classes in a separate file, then you should import them in your main program file using import statement.

In the above example, assuming definition of a Point class is contained in `point.py` and there is no other executable code in it.
```python
#!/usr/bin/python3
import point
p1 = point.Point()
Class Inheritance
Instead of starting from a scratch, you can create a class by deriving it from a pre-existing class by listing the parent class in parentheses after the new class name.

The child class inherits the attributes of its parent class, and you can use those attributes as if they were defined in the child class. A child class can also override data members and methods from the parent.

Syntax
Derived classes are declared much like their parent class; however, a list of base classes to inherit from is given after the class name −

class SubClassName (ParentClass1[, ParentClass2, ...]):
   'Optional class documentation string'
   class_suite
Example
#!/usr/bin/python3

class Parent:        # define parent class
   parentAttr = 100
   def __init__(self):
      print ("Calling parent constructor")

   def parentMethod(self):
      print ('Calling parent method')

   def setAttr(self, attr):
      Parent.parentAttr = attr

   def getAttr(self):
      print ("Parent attribute :", Parent.parentAttr)

class Child(Parent): # define child class
   def __init__(self):
      print ("Calling child constructor")

   def childMethod(self):
      print ('Calling child method')

c = Child()          # instance of child
c.childMethod()      # child calls its method
c.parentMethod()     # calls parent's method
c.setAttr(200)       # again call parent's method
c.getAttr()          # again call parent's method
```
When the above code is executed, it produces the following result −
```
Calling child constructor
Calling child method
Calling parent method
Parent attribute : 200
```
In a similar way, you can drive a class from multiple parent classes as follows −
```
class A:        # define your class A
.....

class B:         # define your calss B
.....

class C(A, B):   # subclass of A and B
.....
```
You can use `issubclass()` or `isinstance()` functions to check a relationships of two classes and instances.

The `issubclass(sub, sup)` boolean function returns True, if the given subclass sub is indeed a subclass of the superclass sup.

The `isinstance(obj, Class)` boolean function returns True, if obj is an instance of class Class or is an instance of a subclass of Class

## Overriding Methods
You can always override your parent class methods. One reason for overriding parent's methods is that you may want special or different functionality in your subclass.

**Example**
```python
#!/usr/bin/python3

class Parent:        # define parent class
   def myMethod(self):
      print ('Calling parent method')

class Child(Parent): # define child class
   def myMethod(self):
      print ('Calling child method')

c = Child()          # instance of child
c.myMethod()         # child calls overridden method
```
When the above code is executed, it produces the following result −

## Calling child method
### Base Overloading Methods
The following table lists some generic functionality that you can override in your own classes −

Method| Description | Sample Call
----|----|----
`__init__ ( self [,args...] )`|Constructor (with any optional arguments)|Sample Call : obj = className(args)
`__del__( self )`|Destructor, deletes an object|Sample Call : del obj
`__repr__( self )`|Evaluatable string representation|Sample Call : repr(obj)
`__str__( self )`|Printable string representation|Sample Call : str(obj)
`__cmp__ ( self, x )`|Object comparison|Sample Call : cmp(obj, x)

## Overloading Operators
Suppose you have created a Vector class to represent two-dimensional vectors. What happens when you use the plus operator to add them? Most likely Python will yell at you.

You could, however, define the `__add__` method in your class to perform vector addition and then the plus operator would behave as per expectation −

**Example**
``` python
#!/usr/bin/python3

class Vector:
   def __init__(self, a, b):
      self.a = a
      self.b = b

   def __str__(self):
      return 'Vector (%d, %d)' % (self.a, self.b)
   
   def __add__(self,other):
      return Vector(self.a + other.a, self.b + other.b)

v1 = Vector(2,10)
v2 = Vector(5,-2)
print (v1 + v2)
```
When the above code is executed, it produces the following result −
```
Vector(7,8)
```
## Data Hiding
An object's attributes may or may not be visible outside the class definition. You need to name attributes with a double underscore prefix, and those attributes then will not be directly visible to outsiders.

**Example**
``` python
#!/usr/bin/python3

class JustCounter:
   __secretCount = 0
  
   def count(self):
      self.__secretCount += 1
      print (self.__secretCount)

counter = JustCounter()
counter.count()
counter.count()
print (counter.__secretCount)
```
When the above code is executed, it produces the following result −
```
1
2
Traceback (most recent call last):
   File "test.py", line 12, in <module>
      print counter.__secretCount
```
AttributeError: JustCounter instance has no attribute '__secretCount'
Python protects those members by internally changing the name to include the class name. You can access such attributes as object._className__attrName. If you would replace your last line as following, then it works for you −
```
.........................
print (counter._JustCounter__secretCount)
```
When the above code is executed, it produces the following result −
```
1
2
2
```

# Regular Expressions in Python
A regular expression is a special sequence of characters that helps you match or find other strings or sets of strings, using a specialized syntax held in a pattern. Regular expressions are widely used in UNIX world.

The module re provides full support for Perl-like regular expressions in Python. The re module raises the exception re.error if an error occurs while compiling or using a regular expression.

We would cover two important functions, which would be used to handle regular expressions. Nevertheless, a small thing first: There are various characters, which would have special meaning when they are used in regular expression. To avoid any confusion while dealing with regular expressions, we would use Raw Strings as r'expression'.

Basic patterns that match single chars
Expression | Matches
----|----
`a, X, 9, <`|ordinary characters just match themselves exactly.
`. (a period)`|matches any single character except newline '\n'
`\w`|matches a "word" character: a letter or digit or underbar [a-zA-Z0-9_].
`\W`|matches any non-word character.	
`\b`|boundary between word and non-word
`\s`|matches a single whitespace character -- space, newline, return, tab
`\S`|matches any non-whitespace character.
`\t, \n, \r`|tab, newline, return
`\d`|decimal digit [0-9]
`^`|matches start of the string
`$`|match the end of the string
`\`|inhibit the "specialness" of a character.

## Compilation flags
Compilation flags let you modify some aspects of how regular expressions work. Flags are available in the re module under two names, a long name such as IGNORECASE and a short, one-letter form such as I.

Flag | Meaning
----|----
`ASCII, A`|Makes several escapes like \w, \b, \s and \d match only on ASCII characters with the respective property.
`DOTALL, S`|Make, match any character, including newlines
`IGNORECASE, I`|Do case-insensitive matches
`LOCALE, L`|Do a locale-aware match
`MULTILINE, M`|Multi-line matching, affecting ^ and $
`VERBOSE, X (for ‘extended’)`|Enable verbose REs, which can be organized more cleanly and understandably

## The match Function
This function attempts to match RE pattern to string with optional flags.

Here is the syntax for this function −
```
re.match(pattern, string, flags = 0)
```
Here is the description of the parameters −

Parameter | Description
----|----
`pattern`|This is the regular expression to be matched.
`string`|This is the string, which would be searched to match the pattern at the beginning of string.
`flags`|You can specify different flags using bitwise OR (|). These are modifiers, which are listed in the table below.

The re.match function returns a match object on success, None on failure. We usegroup(num) or groups() function of match object to get matched expression.

Match Object Method | Description
----|----
`group(num = 0)`|This method returns entire match (or specific subgroup num)
`groups()`|This method returns all matching subgroups in a tuple (empty if there weren't any)

**Example**
``` python
#!/usr/bin/python3
import re

line = "Cats are smarter than dogs"

matchObj = re.match( r'(.*) are (.*?) .*', line, re.M|re.I)

if matchObj:
   print ("matchObj.group() : ", matchObj.group())
   print ("matchObj.group(1) : ", matchObj.group(1))
   print ("matchObj.group(2) : ", matchObj.group(2))
else:
   print ("No match!!")
```
When the above code is executed, it produces the following result −
```
matchObj.group() :  Cats are smarter than dogs
matchObj.group(1) :  Cats
matchObj.group(2) :  smarter
```
The search Function
This function searches for first occurrence of RE pattern within string with optional flags.

Here is the syntax for this function −
```
re.search(pattern, string, flags = 0)
```
Here is the description of the parameters −

Parameter | Description
----|---
`pattern`|This is the regular expression to be matched.
`string`|This is the string, which would be searched to match the pattern anywhere in the string.
`flags`|You can specify different flags using bitwise OR (|). These are modifiers, which are listed in the table below.

The re.search function returns a match object on success, none on failure. We use `group(num)` or `groups()` function of match object to get the matched expression.

Match Object Method | Description
----|----	
`group(num = 0)`|This method returns entire match (or specific subgroup num)
`groups()`|This method returns all matching subgroups in a tuple (empty if there weren't any)

**Example**
```python

#!/usr/bin/python3
import re

line = "Cats are smarter than dogs";

searchObj = re.search( r'(.*) are (.*?) .*', line, re.M|re.I)

if searchObj:
   print ("searchObj.group() : ", searchObj.group())
   print ("searchObj.group(1) : ", searchObj.group(1))
   print ("searchObj.group(2) : ", searchObj.group(2))
else:
   print ("Nothing found!!")
```
When the above code is executed, it produces the following result −
```
matchObj.group() :  Cats are smarter than dogs
matchObj.group(1) :  Cats
matchObj.group(2) :  smarter
```
## Matching Versus Searching
Python offers two different primitive operations based on regular expressions: match checks for a match only at the beginning of the string, while search checks for a match anywhere in the string (this is what Perl does by default).

Example
```python
#!/usr/bin/python3
import re

line = "Cats are smarter than dogs";

matchObj = re.match( r'dogs', line, re.M|re.I)
if matchObj:
   print ("match --> matchObj.group() : ", matchObj.group())
else:
   print ("No match!!")

searchObj = re.search( r'dogs', line, re.M|re.I)
if searchObj:
   print ("search --> searchObj.group() : ", searchObj.group())
else:
   print ("Nothing found!!")
```
When the above code is executed, it produces the following result −
```
No match!!
search --> matchObj.group() :  dogs
```
## Search and Replace
One of the most important re methods that use regular expressions is sub.

**Syntax**
```
re.sub(pattern, repl, string, max=0)
```
This method replaces all occurrences of the RE pattern in string with repl, substituting all occurrences unless max is provided. This method returns modified string.

**Example**
```python
#!/usr/bin/python3
import re

phone = "2004-959-559 # This is Phone Number"

# Delete Python-style comments
num = re.sub(r'#.*$', "", phone)
print ("Phone Num : ", num)

# Remove anything other than digits
num = re.sub(r'\D', "", phone)    
print ("Phone Num : ", num)
```
When the above code is executed, it produces the following result −
```
Phone Num :  2004-959-559
Phone Num :  2004959559
```
## Regular Expression Modifiers: Option Flags
Regular expression literals may include an optional modifier to control various aspects of matching. The modifiers are specified as an optional flag. You can provide multiple modifiers using exclusive OR (|), as shown previously and may be represented by one of these −

Modifier | Description
----|----
`re.I`|Performs case-insensitive matching.
`re.L`|Interprets words according to the current locale. This interpretation affects the alphabetic group (\w and \W), as well as word boundary behavior (\b and \B).
`re.M`|Makes $ match the end of a line (not just the end of the string) and makes ^ match the start of any line (not just the start of the string).
`re.S`|Makes a period (dot) match any character, including a newline.
`re.U`|Interprets letters according to the Unicode character set. This flag affects the behavior of `\w, \W, \b, \B`.
`re.X`|Permits "cuter" regular expression syntax. It ignores whitespace (except inside a set `[]` or when escaped by a backslash) and treats unescaped # as a comment marker.

## Regular Expression Patterns
Except for the control characters, `(+ ? . * ^ $ ( ) [ ] { } | \)`, all characters match themselves. You can escape a control character by preceding it with a backslash.

The following table lists the regular expression syntax that is available in Python −

Here is the list of regular expression syntax in Python.
## Regular Expression Examples
### Literal characters
Example | Description
----|----
`python`|Match "python".

### Character classes
Example | Description
----|----
`[Pp]ython`|Match "Python" or "python"	
`rub[ye]`|Match "ruby" or "rube"
`[aeiou]`|Match any one lowercase vowel
`[0-9]`|Match any digit; same as [0123456789]
`[a-z]`|Match any lowercase ASCII letter
`[A-Z]`|Match any uppercase ASCII letter
`[a-zA-Z0-9]`|Match any of the above	
`[^aeiou]`|Match anything other than a lowercase vowel
`[^0-9]`|Match anything other than a digit

### Special Character Classes
Example | Description
----|----
`.`|Match any character except newline
`\d`|Match a digit: [0-9]
`\D`|Match a nondigit: [^0-9]
`\s`|Match a whitespace character: [ \t\r\n\f]
`\S`|Match nonwhitespace: [^ \t\r\n\f]
`\w`|Match a single word character: [A-Za-z0-9_]
`\W`|Match a nonword character: [^A-Za-z0-9_]

### Repetition Cases
Example | Description
----|----
`ruby?`|Match "rub" or "ruby": the y is optional
`ruby*`|Match "rub" plus 0 or more ys
`ruby+`|Match "rub" plus 1 or more ys
`\d{3}`|Match exactly 3 digits
`\d{3,}`|Match 3 or more digits
`\d{3,5}`|Match 3, 4, or 5 digits

### Nongreedy repetition
This matches the smallest number of repetitions −

Example | Description
----|----
`<.*>`|Greedy repetition: matches "<python>perl>"
`<.*?>`|Nongreedy: matches `"<python>"` in `"<python>perl>"`

### Grouping with Parentheses
Example | Description
----|----
`\D\d+`|No group: + repeats \d
`(\D\d)+`|Grouped: + repeats \D\d pair
`([Pp]ython(,)?)+`|Match "Python", "Python, python, python", etc.

### Backreferences
This matches a previously matched group again −

Example | Description
----|----
`([Pp])ython&\1ails`|Match python&pails or Python&Pails
`(['"])[^\1]*\1`|Single or double-quoted string. \1 matches whatever the 1st group matched. \2 matches whatever the 2nd group matched, etc.

### Alternatives
Example | Description
----|----
`python|perl`|Match "python" or "perl"
`rub(y|le)`|Match "ruby" or "ruble"
`Python(!+|\?)`|"Python" followed by one or more ! or one ?

### Anchors
This needs to specify match position.

Example | Description
----|----	
`^Python`|Match "Python" at the start of a string or internal line
`Python$`|Match "Python" at the end of a string or line
`\APython`|Match "Python" at the start of a string
`Python\Z`|Match "Python" at the end of a string
`\bPython\b`|Match "Python" at a word boundary
`\brub\B`|\B is nonword boundary: match "rub" in "rube" and "ruby" but not alone
`Python(?=!)`|Match "Python", if followed by an exclamation point.
`Python(?!!)`|Match "Python", if not followed by an exclamation point.

### Special Syntax with Parentheses
Example | Description
----|----
`R(?#comment)`|Matches "R". All the rest is a comment
`R(?i)uby`|Case-insensitive while matching "uby"
`R(?i:uby)`|Same as above
`rub(?:y|le))`|Group only without creating \1 backreference
