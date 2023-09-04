using Microsoft.JSInterop;

namespace Blazor.JsInterop.Dynamic;

internal sealed class ActionCallback : Callback
{
    private readonly Action _action;
    
    public ActionCallback(Action action) => _action = action;

    [JSInvokable] public void Callback() => _action.Invoke();
}

internal class ActionCallback<T> : Callback
{
    private readonly Action<T> _action;

    public ActionCallback(Action<T> action) => _action = action;

    [JSInvokable] public void Callback(T arg) => _action.Invoke(arg);
}

internal class ActionCallback<T1, T2> : Callback
{
    private readonly Action<T1, T2> _action;

    public ActionCallback(Action<T1, T2> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2) => _action.Invoke(arg1, arg2);
}

internal class ActionCallback<T1, T2, T3> : Callback
{
    private readonly Action<T1, T2, T3> _action;

    public ActionCallback(Action<T1, T2, T3> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3) => _action.Invoke(arg1, arg2, arg3);
}

internal class ActionCallback<T1, T2, T3, T4> : Callback
{
    private readonly Action<T1, T2, T3, T4> _action;

    public ActionCallback(Action<T1, T2, T3, T4> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4) => _action.Invoke(arg1, arg2, arg3, arg4);
}

internal class ActionCallback<T1, T2, T3, T4, T5> : Callback
{
    private readonly Action<T1, T2, T3, T4, T5> _action;

    public ActionCallback(Action<T1, T2, T3, T4, T5> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => _action.Invoke(arg1, arg2, arg3, arg4, arg5);
}

internal class ActionCallback<T1, T2, T3, T4, T5, T6> : Callback
{
    private readonly Action<T1, T2, T3, T4, T5, T6> _action;

    public ActionCallback(Action<T1, T2, T3, T4, T5, T6> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => _action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
}

internal class ActionCallback<T1, T2, T3, T4, T5, T6, T7> : Callback
{
    private readonly Action<T1, T2, T3, T4, T5, T6, T7> _action;

    public ActionCallback(Action<T1, T2, T3, T4, T5, T6, T7> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => _action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
}

internal class ActionCallback<T1, T2, T3, T4, T5, T6, T7, T8> : Callback
{
    private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> _action;

    public ActionCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => _action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
}

internal class ActionCallback<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Callback
{
    private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> _action;

    public ActionCallback(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) => _action = action;

    [JSInvokable]
    public void Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => _action.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
}