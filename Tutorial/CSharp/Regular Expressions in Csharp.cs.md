# Regular Expressions in Csharp

## Regular fundamentals
It all starts with the idea of specifying a grammar for a particular set of strings. All you have to do is find a pattern that matches all of the strings you are interested in, and then use the pattern. The simplest sort of pattern is the string literal that matches itself. So, for example, if you want to process ISBN numbers you might well want to match the string “ISBN:” which is its own regular expression in the sense that the pattern “ISBN:” will match exactly one string of the form “ISBN:”. To actually use this you have to first create a Regex object with the regular expression built into it:

``` csharp
Regex ex1 = new Regex(@"ISBN:");
```

The use of the **@** at the start of the string is optional, but it does make it easier when we start to use the **/** escape character.
Recall that strings starting with **@** are represented **as is** without any additional processing or conversion by C#. 
To actually use the regular expression we need one of the methods offered by the Regex object. 
The Match method applies the expression to a specified string and returns a Match object. 
The Match object contains a range of useful properties and methods that let you track the operation of applying the regular expression to the string. 
For example, if there was a match the Success property is set to true as in:

``` csharp 
MessageBox.Show(ex1.Match(@"ISBN: 978-1871962406").Success.ToString()); 
```
The index property gives the position of the match in the search string:
``` csharp 
MessageBox.Show(ex1.Match(@"ISBN: 978-1871962406").
    Index.ToString());
```
which in this case returns zero to indicate that the match is at the start of the string. 
To return the actual match in the target string you can use the ToString method. 
Of course in this case the result is going to be identical to the regular expression but in general this isn’t the case. Notice that the Match method returns the first match to the regular expression and you can use the NextMatch method which returns another Match object.

## Pattern matching
If this is all there was to regular expressions they wouldn’t be very interesting. 
The reason they are so useful is that you can specify patterns that spell out the regularities in a type of data.

For example following the ISBN: we expect to find a digit – any digit. 
This can be expressed as **ISBN:\d** where **\d** is character class indicator which means **a digit**. 
If you try this out you will discover that you don’t get a match with the example string because there is a space following the colon. However **ISBN:\s\d** does match as **\s** means **any white-space character** and:

``` csharp 
Regex ex1 = new Regex(@"ISBN:\s\d");
MessageBox.Show(
    ex1.Match(@"ISBN: 978-1871962406").
    ToString();
```
displays **ISBN: 9**. There’s a range of useful character classes and you can look them up in the documentation. 
The most useful are: aa5dd6a7065402ca9de1de54ec2685ee There is also the convention that capital letters match the inverse set of characters: 8626db14b952423a391096e21ae61f85 Notice that the inverse sets can behave unexpectedly unless you are very clear about what they mean. 
For example, **\D** also matches white space and hence: displays “ISBN: 9”. There’s a range of useful character classes and you can look them up in the documentation. The most useful are: aa5dd6a7065402ca9de1de54ec2685ee There is also the convention that capital letters match the inverse set of characters: 8626db14b952423a391096e21ae61f85 Notice that the inverse sets can behave unexpectedly unless you are very clear about what they mean. 

For example, \D also matches white space and hence:
``` @"ISBN:\D\d"```
matches ISBN: 9. 

You can also make up your own character group by listing the set of characters between square brackets. So for example, [0-9] is the same as \d. Negating a character set is also possible and [^0-9] matches anything but the digits and is the same thing as \D. There are also character sets that refer to Unicode but these are obvious enough in use not to need additional explanation. 
As well as characters and character sets you can also use location matches or anchors. For example, the ^ (caret) only matches the start of the string, and @”^ISBN:” will only match if the string starts with ISBN: and doesn’t match if the same substring occurs anywhere else. The most useful anchors are: 6e134837b27ec65df47860dbe2a5f7ba So for example:


```@"^\d+$"``` specifies a string consisting of nothing but digits. Compare this to ```@"^\d*$"``` which would also accept a null string. One subtle point only emerges when you consider strings with line breaks. In this case by default the ^ and $ match only the very start and end of the string. If you want them to match line beginnings and endings you have to specify the /m option. It’s also worth knowing about the \G anchor which only matches at the point where the previous match ended – it is only useful when used with the NextMatch method but then it makes all matches contiguous.


## Quantify
Of course we now have the problem that it isn’t unreasonable for an ISBN to be written as ISBN: 9 or ISBN:9 with perhaps even more than one space after the colon. We clearly need a way to specify the number of repeats that are allowed in a matching string. To do this we make use of “quantifiers” following the specification to be repeated. The most commonly used quantifiers are: c7d4d050f977dcfbf7f1585efd211660 In many ways this is the point at which regular expression use starts to become interesting and inevitably more complicated. Things are easy with simple examples not hard to find. For example:
```@"ISBN:\s*\d"```…matches "ISBN:" followed by any number of white-space characters including none at all followed by a digit. Similarly:
`@"ISBN:?\s*\d"`\ …matches "ISBN" followed by an optional colon, any number of white-space characters including none followed by a digit. 
Quantifiers are easy but there is a subtlety that often goes unnoticed. Quantifiers, by default, are “greedy”. That is they match as many entities as they can even when you might think that the regular expression provides a better match a little further on. The only way to really follow this is by the simplest example. Suppose you need a regular expression to parse some HTML tags:

```<div>hello</div>```
If you want to match just a pair of opening and closing tags you might well try the following regular expression:
```Regex ex2= new Regex(@"<div>.*</div>");```
…which seems to say “the string starts with <div> then any number including zero of other characters followed by </div>”. If you try this out on the example given above you will find that it matches:
```cs
MessageBox.Show(
    ex2.Match(@"<div>hello</div>").
    ToString());
```
However if you now try it out against the string:
```<div>hello</div><div>world</div>```
…as in:
```cs
MessageBox.Show(
    ex2.Match(
    @"<div>hello</div><div>world</div>").
    ToString());
```
…you will discover that the match is to the entire string. That is the final </div> in the regular expression is matched to the final </div> in the string even though there is an earlier occurrence of the same substring. This is because the quantifiers are greedy by default and attempt to find the longest possible match. In this case the .* matches everything including the first </div>. So why doesn’t it also match the final </div>? The reason is that if it did the entire regular expression would fail to match anything because there would be no closing </div>. What happens is that the quantifiers continue to match until the regular expression fails, then the regular expression engine backtracks in an effort to find a match. 


> Notice that all of the standard quantifiers are greedy and will match more than you might expect based on what follows in the regular expression. If you don’t want greedy quantifiers the solution is to use “lazy” quantifiers which are formed by following the standard quantifiers by a question mark. 

To see this in action, change the previous regular expression to read:
```cs
Regex ex2= new Regex(@"<div>.*?</div>");
```
With this change in place the result of matching to:
```
@"<div>hello</div><div>world</div>")
```
…is just the first pair of <div> brackets – that is ```<div>hello</div>```. Notice that all of the quantifiers, including ?, have a lazy version and yes you can write ?? to mean a lazy “zero or one” occurrence. 
The distinction between greedy and lazy quantifiers is perhaps the biggest reason for a reasonably well-tested regular expression to go wrong when used against a wider range of example strings. Always remember that a standard greedy quantifier will match as many times as possible while still allowing the regular expression to match, and its lazy version will match as few as possible times to make the regular expression match. 

 

## Grouping and alternatives
Regular strings often have alternative forms. For example the ISBN designator could be simply ISBN: or it could be ISBN-13: or any of many other reasonable variations. You can specify an either/or situation using the vertical bar |, the alternation operator as in x|y which will match an x or a y. For example:
```@"ISBN:|ISBN-13:"```
…matches either ISBN: or ISBN-13:. This is easy enough but what about:

```@"ISBN:|ISBN-13:\s*\d"```
At first glance this seems to match either ISBN: or ISBN-13 followed by any number of white space characters and a single digit – but it doesn’t. The | operator has the lowest priority and the alternative matches are everything the left and everything to the right, i.e. either ISBN: or ISBN-13:\s*\d. To match the white space and digit in both forms of the ISBN suffix we would have to write:

```@"ISBN:\s*\d|ISBN-13:\s*\d"```
Clearly having to repeat everything that is in common on either side of the alternation operator is going to make things difficult and this is where grouping comes in. Anything grouped between parentheses is treated as a single unit – and grouping has a higher priority than the alternation operator. So for example:

```@"(ISBN:|ISBN-13:)\s*\d"```
…matches either form of the ISBN suffix followed by any number of white space characters and a single digit because the brackets limit the range of the alternation operator to the substrings to the left and right within the bracket. 
The greedy/lazy situation also applies to the alternation operator. For example, suppose you try to match the previous un-grouped expression but without the colon:

```@"ISBN|ISBN-13"```
In this case the first pattern, i.e. “ISBN”, will match even if the string is “ISBN-13”. It doesn’t matter that the second expression is a “better” match. No amount of grouping will help with this problem because the shorter match will be tried and succeed first. In this case the solution is to either swap the order of the sub-expressions so that the longer comes first or include something that always marks the end of the target string. For example, in this case if we add the colon then the:
ISBN:
…subexpression cannot possibly match the ISBN-13: string.


## Capture and backreference
Now that we have explored grouping it is time to introduce the most sophisticated and useful aspect of regular expressions – the idea of “capture”. You may think that brackets are just about grouping together items that should be matched as a group, but there is more. A subexpression, i.e. something between brackets, is said to be “captured” if it matches and captured expressions are remembered by the engine during the match. Notice that a capture can occur before the entire expression has finished matching – indeed a capture can occur even if the entire expression eventually fails to match at all. 
The .NET regular expression classes make captures available via the capture property and the CaptureCollection. Each capture group, i.e. each sub-expression surrounded by brackets, can be associated with one or more captured string. To be clear, the expression:
```
@"(<div>)(</div>)"
```

…has two capture groups which by default are numbered from left-to-right with capture group 1 being the (<div>) and capture group 2 being the (</div>). The entire expression can be regarded as capture group 0 as its results are returned first by the .NET framework. If we try out this expression on a suitable string and get the GroupCollection result of the match using the Groups property:
```cs
GroupCollection Grps = ex2.Match(
    @"<div></div><div></div><div></div>")
    .Groups;
//Then, in this case, we have three capture groups – the entire expression returned as Grps[0], the first bracket i.e. capture group 1 is returned as Grps[1] and the final bracket i.e. capture group 2 as Grps[2]. The first group, i.e. the entire expression, is reported as matching only once at the start of the test string – after all we only asked for the first match. Getting the first capture group and displaying its one and only capture demonstrates this:

CaptureCollection Caps =
    Groups[0].Captures;
MessageBox.Show(
    Caps[0].Index.ToString()+
    " "+Caps[0].Length.ToString()+
    " "+Caps[0].ToString());
//…which displays 0 11 <div></div> corresponding to the first match of the complete expression. The second capture group was similarly only captured once at the first <div> and:
CaptureCollection Caps =
    Groups[1].Captures;
MessageBox.Show(
    Caps[0].Index.ToString()+
    " "+Caps[0].Length.ToString()+
    " "+Caps[0].ToString());
//…displays 0 5 <div> to indicate that it was captured by the first <div> in the string. The final capture group was also only captured once by the final </div> and:
CaptureCollection Caps =
    Groups[2].Captures;
MessageBox.Show(
    Caps[0].Index.ToString()+
    " "+Caps[0].Length.ToString()+
    " "+Caps[0].ToString());
//…displays 5 6 </div>. Now consider the same argument over again but this time with the expression:
Regex ex2 =
    new Regex(@"((<div>)(</div>))*");
```
In this case there are four capture groups including the entire expression. Capture group 0 is the expression ((<div>)(</div>))* and this is captured once starting at 0 matching the entire string of three repeats, i.e. length 33. The next capture group is the first, i.e. outer, bracket ((<div>)(</div>)) and it is captured three times, corresponding to the three repeats. If you try:
```cs
CaptureCollection Caps =
    Groups[1].Captures;
for (int i = 0; i <= Caps.Count - 1; i++)
{
    MessageBox.Show(
    	Caps[i].Index.ToString() +
    	" " + Caps[i].Length.ToString() +
    	" " + Caps[i].ToString());
}
```
…you will find the captures are at 0, 11 and 22. The two remaining captures correspond to the <div> at 0, 11 and 22 and the </div> at 5, 16 and 27. Notice that a capture is stored each time the bracket contents match.


 


## Back referencences

So far so good but what can you use captures for? The answer is two-fold – more sophisticated regular expressions and replacements. Let’s start with their use in building more sophisticated regular expressions. Using the default numbering system described above you can refer to a previous capture in the regular expression. That is, if you write \n where n is the number of a capture group the expression will specify that value of the capture group – confused? It’s easy once you have seen it in action. Consider the task of checking that html tags occur in the correct opening and closing pairs. That is, if you find a <div> tag the next closing tag to the right should be a <\div>. You can already write a regular expression to detect this condition but captures and back references make it much easier. If you start the regular expression with a sub expression that captures the string within the brackets then you can check that the same word occurs within the closing bracket using a back reference to the capture group:
```cs
Regex ex2= new Regex(@"<(div)></\1>");
```
Notice the \1 in the final part of the expression tells the regular expression engine to retrieve the last match of the first capture group. If you try this out you will find that it matches <div><\div> but not <div><\pr>, say. You could have done the same thing without using a back reference but it’s easy to extend the expression to cope with additional tags. For example :
```cs
Regex ex2= new Regex(
    @"<(div|pr|span|script)></\1>");
```
…matches correctly closed div, pr, span and script tags. 
If you are still not convinced of the power of capture and back reference try and write a regular expression that detects repeated words without using them. The solution using a back reference is almost trivial:
```cs
Regex ex2= new Regex(@"\b(\w+)\s+\1\b");
```

The first part of the expression simply matches a word by the following process – start at word boundary capture as many word characters as you can, then allow one or more white space characters. Finally check to see if the next word is the same as the capture. The only tricky bit is remembering to put the word boundary at the end. Without it you will match words that repeat as a suffix as in “the theory”. 
As well as anonymous captures you can also create named captures using:
```
(?<name>regex)
```
…or:
```
(?'name'regex)
```
You can then refer the capture by name using the syntax:
```
\<name>
…or:
\'name'
```
Using a named capture our previous duplicate word regular expression can be written as:
```@"\b(?<word>\w+)\s+\<word>\b"```

If you need to process named captures outside of a regular expression, i.e. using the Capture classes, then you still have to use capture numbers and you need to know that named captures are numbered left to right and outer to inner after all the unnamed captures have been numbered. 

If you need to group items together but don’t want to make use of a capture you can use:
```
(?:regex)
```
This works exactly as it would without the ?: but the bracket is left out of the list of capture groups. This can improve the efficiency of a regular expression but this usually isn’t an issue.


 


## Advanced capture
There other capture group constructs but these are far less useful and, because they are even more subtle, have a reputation for introducing bugs. The balancing group is, however, worth knowing about as it gives you the power to balance brackets and other constructs but first we need to know about a few of the other less common groupings – the assertions. There are four of these and the final three are fairly obvious variations on the first. They all serve to impose a condition on the match without affecting what is captured: 
Zero-width positive lookahead assertion

```(?=regex)```
This continues the match only if the regex matches on the immediate right of the current position but doesn’t capture the regex or backtrack if it fails. For example:

```\w+(?=\d)```
…only matches a word ending in a digit but the digit is not included in the match. That is it matches Paris9 but returns Paris as capture 0. In other words you can use it to assert a pattern that must follow a matched subexpression. 
Zero-width negative lookahead assertion

```(?!regex)```
This works like the positive lookahead assertion but the regex has to fail to match on the immediate right. For example:
```\w+(?!\d)```
…only matches a word that doesn’t have a trailing digit. 
Zero-width positive lookbehind assertion

```(?<=regex)```
Again this works like the positive lookahead assertion but it the regex has to match on the immediate left. For example:
```(?<=\d)\w+```
…only matches a word that has a leading digit. 
Zero-width negative lookbehind assertion

```(?<!regex)```
This is just the negation of the Zero-width positive lookbehind assertion. For example:
```(?<!\d)\w+```
…only matches a word that doesn’t have a leading digit. 
Now that we have seen the assertions we can move on to consider the balancing group:

```(?<name1-name2>regex)```

 - This works by deleting the current capture from the capture collection for name2 and storing everything since the last capture in the capture collection for name1. If there is no current capture for name2 then backtracking occurs and if this doesn’t succeed the expression fails. In many cases all you are doing is trying to reduce the capture count for name2 and in this case you can leave out any reference to name1. 
 - This sounds complicated but in practice it isn’t too difficult. For example, let’s write an expression that matches any number of As followed by the same number of Bs:

```cs
Regex ex3 = new Regex(
    @"^(?<COUNT>A)+(?<-COUNT>B)+");
```

This works, up to a point, in that it matches equal number of A and Bs starting from the beginning of the string but it doesn’t reject a string like AABBB which it simply matches to AABB. Each time the first capture group hits an A it adds a capture to the capture set – so in this case there are two captures when the second capture group hits the first B. This reduces A’s capture set to 1 and then to zero when the second B is encountered which causes the match to backtrack to the second B when the third B is encountered and the match succeeds. To make the entire match fail we also have to include the condition that we should now be at the end of the string.
```cs
Regex ex3 = new Regex(
    @"^(?<COUNT>A)+(?<-COUNT>B)+$");
```
This now fails on AABBB but it matches AAABB because in the case the second capture group doesn’t fail before we reach the end of the string. We really need a test that amounts to “at the end of the string/match the count capture group should be null”. 
To do this we need some sort of conditional test on the capture and .NET provides just this:
```
(?(name)regex1|regex2)
```
…will use regex1 if the capture is non-empty and regex2 if it is empty. In fact this conditional is more general than this in that name can be a general regular expression. You can leave regex2 out if you want an “if then” rather than an “if then else”. 
With this our new expression is:
```cs
Regex ex3 = new Regex(
    @"^(?<COUNT>A)+(?<-COUNT>B)+
    (?(COUNT)^.)$");
```
The ^. is doesn’t match any character and so it forces the match to fail if the capture group isn’t empty. A more symmetrical if…then…else form of the same expression is:
```cs
Regex ex3 = new Regex(
    @"^(?<COUNT>A)+(?<-COUNT>B)+
    (?(COUNT)^.|(?=$))");
```
In this case the else part of the conditional asserts that we are at the end of the string. 

## Replacements
So far we have created regular expressions with the idea that we can use them to test that a string meets a specification or to extract a substring. These are the two conventional uses of regular expressions. However you can also use them to perform some very complicated string editing and rearrangements. The whole key to this idea is the notion that you can use the captures as part of the specified replacement string. The only hitch is that the substitution strings use a slightly different syntax to a regular expression. 
The Replace method:
```cs
ex1.Replace(input,substitution)
```
…simply takes every match of the associated regular expression and performs the substitution specified. Notice that it performs the substitution on every match and the result returned is the entire string with the substitutions made. There are other versions of the Replace method but they all work in more or less the same way. For example, if we define the regular expression:
```cs
Regex ex1 = new Regex(@"(ISBN|ISBN-13)");
```
…and apply the following replacement:
```cs
MessageBox.Show(
    ex1.Replace(@"ISBN: 978-1871962406",
    "ISBN-13"));
```

…then the ISBN suffix will be replaced by ISBN-13. Notice that an ISBN-13 suffix will also be replaced by ISBN-13 so making all ISBN strings consistent. Also notice that if there are multiple ISBNs within the string they will all be matched and replaced. There are versions of the method that allow you to restrict the number of matches that are replaced. 
This is easy enough to follow and works well as long as you have defined your regular expression precisely enough. More sophisticated is the use of capture groups within the substitution string. You can use:
```cs
@"$n"
…to refer to capture group n or:
@"${name}"
```

…to refer to a capture group by name. There are a range of other substitution strings but these are fairly obvious in use. 
As an example of how this all works consider the problem of converting a US format date to a UK format date. First we need a regular expression to match the mm/dd/yyyy format:
```cs
Regex ex1 = new Regex(
    @"(?<month>\d{1,2})/
    (?<day>\d{1,2})/
    (?<year>\d{4})");
```
This isn’t a particularly sophisticated regular expression but we have allowed one or two digits for the month and day numbers but insisted on four for the year number. You can write a more interesting and flexible regular expression for use with real data. Notice that we have three named capture groups corresponding to month, day and year. To create a European style date all we have to do assemble the capture groups in the correct order in a substitution string:
```cs
MessageBox.Show(
    ex1.Replace(@" 10/2/2008",
    "${day}/${month}/${year}$"));
```
