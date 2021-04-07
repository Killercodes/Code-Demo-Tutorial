# Custom Eventes in Javascript

A custom event can be created with
```js
var event1 = new Event("onEvent1",{bubbles:true,cancelable:true}); 

```

and can be dispatched with
```js
window.dispatchEvent(event1);
```


tis is how to create and dispatch event 
```js
  function create&DispatchEvent() 
  {
    var event1 = new Event("onEvent1",{bubbles:true,cancelable:true});        
    window.dispatchEvent(event1);        
  }
```

But once all these things are done you need to listen for it with:
```js
window.addEventListener('onEvent1',function(e) {  });
```
