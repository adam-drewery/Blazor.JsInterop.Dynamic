using Microsoft.JSInterop;

namespace Blazor.JsInterop.Dynamic;

public class DynamicJsRuntime
{
    private readonly IJSRuntime _runtime;
    
    public DynamicJsRuntime(IJSRuntime runtime) => _runtime = runtime;
    
    public async Task<dynamic> InvokeAsync(string identifier, params object?[]? args)
    {
        var reference = await _runtime.InvokeAsync<IJSObjectReference>(identifier, args);
        return await DynamicJsObject.CreateAsync(_runtime, reference);
    }
}