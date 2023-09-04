using Microsoft.JSInterop;

namespace Blazor.JsInterop.Dynamic;

internal abstract class Callback
{
    public bool IsVoid => GetType().Name.StartsWith("Action");

    public int ArgCount => GetType().GenericTypeArguments.Length;
}

internal sealed class FuncCallback<T> : Callback
{
    private readonly Func<T> _action;
    
    public FuncCallback(Func<T> action) => _action = action;

    [JSInvokable] public T Callback() => _action.Invoke();
}

internal class FuncCallback<T1, T2> : Callback
{
    private readonly Func<T1, T2> _action;

    public FuncCallback(Func<T1, T2> action) => _action = action;

    [JSInvokable] public T2 Callback(T1 arg1) => _action.Invoke(arg1);
}

internal class FuncCallback<T1, T2, T3> : Callback
{
    private readonly Func<T1, T2, T3> _func;

    public FuncCallback(Func<T1, T2, T3> func) => _func = func;

    [JSInvokable]
    public T3 Callback(T1 arg1, T2 arg2) => _func.Invoke(arg1, arg2);
}

internal class FuncCallback<T1, T2, T3, T4> : Callback
{
    private readonly Func<T1, T2, T3, T4> _func;

    public FuncCallback(Func<T1, T2, T3, T4> func) => _func = func;

    [JSInvokable]
    public T4 Callback(T1 arg1, T2 arg2, T3 arg3) => _func.Invoke(arg1, arg2, arg3);
}

internal class FuncCallback<T1, T2, T3, T4, T5> : Callback
{
    private readonly Func<T1, T2, T3, T4, T5> _func;

    public FuncCallback(Func<T1, T2, T3, T4, T5> func) => _func = func;

    [JSInvokable]
    public T5 Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4) => _func.Invoke(arg1, arg2, arg3, arg4);
}

internal class FuncCallback<T1, T2, T3, T4, T5, T6> : Callback
{
    private readonly Func<T1, T2, T3, T4, T5, T6> _func;

    public FuncCallback(Func<T1, T2, T3, T4, T5, T6> func) => _func = func;

    [JSInvokable]
    public T6 Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => _func.Invoke(arg1, arg2, arg3, arg4, arg5);
}

internal class FuncCallback<T1, T2, T3, T4, T5, T6, T7> : Callback
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7> _func;

    public FuncCallback(Func<T1, T2, T3, T4, T5, T6, T7> func) => _func = func;

    [JSInvokable]
    public T7 Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => _func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
}

internal class FuncCallback<T1, T2, T3, T4, T5, T6, T7, T8> : Callback
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8> _func;

    public FuncCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8> func) => _func = func;

    [JSInvokable]
    public T8 Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => _func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
}

internal class FuncCallback<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Callback
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> _func;

    public FuncCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func) => _func = func;

    [JSInvokable]
    public T9 Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => _func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
}

internal class FuncCallback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : Callback
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> _func;

    public FuncCallback(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func) => _func = func;

    [JSInvokable]
    public T10 Callback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => _func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
}