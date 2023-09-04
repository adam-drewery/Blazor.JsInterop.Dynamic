# Blazor.JsInterop.Dynamic
.NET library to simplify javascript interop. Still in its experimental phase.

## Usage:

Given the following simple javascript function, which creates an object:

```js
window.createTestObject = (testArg) => {
  alert("I've invoked a javascript global method from .NET with this parameter: " + testArg);
  return {
    actionTest: (testArg, testAction) => {
      alert("I've invoked a javascript instance method from .NET with this parameter: " + testArg);
      testAction();
    },
    funcTest: (testArg, testFunc) => {
      alert("I've invoked a javascript instance method from .NET with this parameter: " + testArg);
      testFunc(testArg);
    },
    returnObjectTest: (testArg) => {
      alert("I've invoked a javascript instance method from .NET with this parameter: " + testArg);
      return {
        someValue: 123,
        actionTest: (testArg, testAction) => {
          alert("I've invoked a javascript instance method from .NET with this parameter: " + testArg);
          testAction();
          }
      };
    }
  }
}
```

the object can be created and interacted with like so:

```csharp

@inject Blazor.JsInterop.Dynamic.DynamicJsRuntime Runtime

@code {

    private async Task ShowDialog()
    {
        // create the object using the "createTestObject" global function.
        var reference = await JsRuntime.InvokeAsync("createTestObject", "example string  1");

        // these can be passed as arguments to a javascript function and the callbacks will work correctly
        var callbackAction = () => Console.WriteLine("callback action called");
        var callbackFunc = (string x) => Console.WriteLine("callback func called with argument: " + x);

        // call a method with an "action" parameter
        reference.actionTest("example string 2", callbackAction);

        // call a method with a "function" parameter
        reference.funcTest("example string 2", callbackFunc);

        // calling a method that returns a javascript object, will return another reference here
        var otherReference = await reference.returnObjectTest("example string 4");

        // we can call methods on this new object too
        await otherReference.actionTest("example string 5", callbackAction);

        // and just like the first object, we can access properties
        // note: these values are currently populated on object creation and won't update if the underlying object's property values change.
        var someValue = otherReference.someValue;
        Console.WriteLine("property on returned object: " + someValue);
    }
}

```
