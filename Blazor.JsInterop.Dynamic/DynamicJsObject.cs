using System.Dynamic;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Blazor.JsInterop.Dynamic;

public sealed class DynamicJsObject : DynamicObject, IAsyncDisposable
{
    private readonly IJSRuntime _runtime;
    private static bool _initialized;
    private readonly Dictionary<string,object> _properties;
    private const string WrapperIdentifier = "xa6dd4ca4880643aa86eb9d18af009fc3";

    internal IJSObjectReference Reference { get; }

    private DynamicJsObject(IJSRuntime runtime, IJSObjectReference reference, Dictionary<string, object>? dictionary = null)
    {
        _runtime = runtime;
        Reference = reference;
        _properties = dictionary ?? new Dictionary<string, object>();
    }

    public static async Task<dynamic> CreateAsync(IJSRuntime runtime, IJSObjectReference objectReference)
    {
        if (!_initialized)
        {
            await LoadUtilityScript(runtime);
            _initialized = true;
        }
                
            
        return new DynamicJsObject(runtime, objectReference);
    }

    private static Task LoadUtilityScript(IJSRuntime runtime)
    {
        var assembly = typeof(DynamicJsObject).Assembly;
        var fullResourceName = $"{assembly.GetName().Name}.Script.js";
            
        using var stream = assembly.GetManifestResourceStream(fullResourceName);
            
        if (stream == null)
            throw new InvalidOperationException($"Resource {fullResourceName} not found.");
            
        using var reader = new StreamReader(stream);
        var script = reader.ReadToEnd();

        return runtime.InvokeVoidAsync("eval", script).AsTask();
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object result)
    {
        if (args != null) ArgumentInjector.Inject(args);
        result = InvokeAsync(binder.Name, args);
        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        return _properties.TryGetValue(binder.Name, out result);
    }

    private async Task<dynamic?> InvokeAsync(string methodName, object?[]? args)
    {
        // the first arguments should be the js reference and method name. add them to the args.
        args = args == null ? null : new object[] { Reference, methodName }.Concat(args).ToArray();
        Console.WriteLine("invoking: " + methodName);
        
        // get the reference
        var jsObjectReference = await _runtime.InvokeAsync<IJSObjectReference?>(WrapperIdentifier, args);
        if (jsObjectReference == null) return null;
        
        Console.WriteLine("unwrapping: " + methodName);
        // get the actual underlying value
        var unwrapped = (JsonElement?)await jsObjectReference.InvokeAsync<object?>("x04f665b3ad2c47a3a02b181a447bd82f");

        if (!unwrapped.HasValue) return null;
        
        // its not a primitive, get the properties and set them on the underlying result
        if (unwrapped.Value.ValueKind == JsonValueKind.Object)
        {
            var dictionary = unwrapped.Value.Deserialize<Dictionary<string, object>>();
            return new DynamicJsObject(_runtime, jsObjectReference, dictionary);
        }
            
        return unwrapped.Value.ValueKind switch
        {
            // its a primitive so just return the value
            JsonValueKind.False => false,
            JsonValueKind.True => true,
            JsonValueKind.Null => null,
            JsonValueKind.Undefined => null,
            JsonValueKind.Number => unwrapped.Value.GetDouble(),
            JsonValueKind.String => unwrapped.Value.GetString(),
            JsonValueKind.Array => unwrapped.Value.EnumerateArray().Select(x => x).ToArray(),
            JsonValueKind.Object => unwrapped.Value.EnumerateObject().ToDictionary(x => x.Name, x => x.Value),
            _ => throw new IndexOutOfRangeException("Unknown value kind: " + unwrapped.Value.ValueKind)
        };

    }

    public ValueTask DisposeAsync() => Reference.DisposeAsync();
}