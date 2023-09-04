# Blazor.JsInterop.Dynamic
.NET library to simplify javascript interop. Still in its experimental phase.

## Usage:

Given the following simple javascript object:

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
        void CallbackAction() => Console.WriteLine("callback action called");
        void CallbackFunc(string x) => Console.WriteLine("callback func called with argument: " + x);

        // call a method with an "action" parameter
        reference.actionTest("example string 2", (Action?)CallbackAction);

        // call a method with a "function" parameter
        reference.funcTest("example string 2", (Action<string>)CallbackFunc);
    }
}

```
