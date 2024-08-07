using Compilation.Domain.FuncParam;
using Compilation.Extensions.BuiltInFunctions;
using Compilation.Statements;
using static FluqParser;

namespace Compilation.Extensions;

internal static class Call
{
    internal static FunctionCall GetStatement(this CallContext ctx)
    {
        var callContext = ctx.func_call();
        if (callContext.built_in_func() is not null) return callContext.built_in_func().GetStatement();
        if (callContext is null) throw new NullReferenceException(nameof(callContext));

        var funcName = callContext.func_name.Text;
        var funcParamsContexts = callContext.func_call_params().expression();
        var funcParams = funcParamsContexts.Evaluate().ToFuncParams().ToArray();

        return new FunctionCall(funcName, funcParams);
    }
    
}