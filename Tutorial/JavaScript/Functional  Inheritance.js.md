# Functional Inheritance 

This example shows how functional inheritance can be used in javascript without #prototype or #new and take advantage of Javascript's ability with argument & objects

``` javascript


//define an object
var baseObject = function(publicName,privateVar){
    
    var baseContext = { // object literal
        Name:publicName,
        getInfo : function(){
            return this.Name + " you are " + privateVar ; //Any local variable remain private
        }
    };
    return baseContext;
};

// inherit form baseObject
var person = function(name,occupation){
    var that = baseObject(name,occupation); //inherit from base
    that.action = function(){ //extend base with a method
        return "You know nothing " + that.Name ;
    }
    return that;
};

//calls
debugger;
console.clear();

// create instance of the extended class
var man = person("John Snow","Stark"); 
var person1 =  (man.getInfo());
var person1does= (man.action());
man.Name = "Eddard"; // Change the name of person
man.privateVar = "Lord of wintefell"; //will not change as it's private
var person2 = (man.getInfo());
var person2does = (man.action());

//print
console.log(person1);
console.log(person1does);
console.log(person2);
console.log(person2does);

```
