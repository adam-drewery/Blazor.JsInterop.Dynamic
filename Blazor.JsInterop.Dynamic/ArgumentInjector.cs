using Microsoft.JSInterop;

namespace Blazor.JsInterop.Dynamic;

internal static class ArgumentInjector
{
    public static void Inject(object?[] args)
    {
        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            var argType = arg?.GetType();
            if (argType != null && argType.IsSubclassOf(typeof(Delegate))) // Check if it's a delegate
            {
                Console.WriteLine("injecting delegate: " + argType.Name);
                var isFunc = argType.Name.StartsWith("Func");
                var genericArgs = argType.GetGenericArguments();
                var callbackType = GetCallbackType(genericArgs.Length, isFunc);
                
                if(genericArgs.Any())
                    callbackType = callbackType.MakeGenericType(genericArgs);
                
                var callbackInstance = Activator.CreateInstance(callbackType, arg);
                
                if (callbackInstance == null)
                    throw new InvalidOperationException($"Failed to create callback instance for {argType.Name}");
                
                Console.WriteLine("Callback instance created: " + callbackInstance);
                args[i] = new
                {
                    Identifier = "x35386dab52f3434d8bc774ef426222b5",
                    Reference = DotNetObjectReference.Create(callbackInstance),
                    Params = callbackInstance
                };
            }
            if(arg is DynamicJsObject jsObject)
            {
                Console.WriteLine("injecting object reference: " + jsObject.Reference);
                args[i] = jsObject.Reference;
            }
        }
    }

    private static Type GetCallbackType(int numberOfArgs, bool isFunc)
    {
        var assembly = typeof(ActionCallback).Assembly;
        var callbackTypeName = isFunc 
            ? $"Blazor.JsInterop.Dynamic.FuncCallback\u0060{numberOfArgs}" 
            : numberOfArgs == 0 ? "Blazor.JsInterop.Dynamic.ActionCallback" : $"Blazor.JsInterop.Dynamic.ActionCallback\u0060{numberOfArgs}";

        return assembly.GetType(callbackTypeName) ?? throw new InvalidOperationException($"No callback type found for {callbackTypeName}");
    }
}