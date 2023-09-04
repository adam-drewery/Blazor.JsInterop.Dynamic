using Microsoft.JSInterop;

namespace Blazor.JsInterop.Dynamic;

public class Test
{
    public async Task<string> GetTest(IJSRuntime runtime, IJSObjectReference jsObject)
    {
        var thing = await ScriptObject.CreateAsync(runtime, jsObject);
        var result = await thing.doSomething("yes");
        await result.OtherThing("no");
        var action = () => Console.WriteLine("heh");
        return result.And(action);
    }
}