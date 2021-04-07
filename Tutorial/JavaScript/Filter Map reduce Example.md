# Filter Map Reduce
```js
//Query
var attribs = Xrm.Page.data.entity.attributes.get();

//Filter
var filterDirty = attribs.filter(function(elem,index,attribs){   
        var name =  elem.getName();
        return (Xrm.Page.getAttribute(name).getIsDirty() === true);
});

//print
filterDirty.map(function(e){
  console.log(e.getName()); 
});
```
