# Failsafe Extension to JS function

This will execute all the function within a failsafe contianer

```js
// FailSafe Extension for all the functions defined
Function.prototype.FailSafe = function () {
    var fn = this;

    try {
        return fn.apply(this, arguments);
    }
    catch (e) {
        /*return handle(e);*/
        //alert(e.message);
        if(window.console != null)
            console.error(fn.name  + "(): " + e.message);
    }
};
