using Compilation.Domain.FuncParam;
using Compilation.Statements;

namespace Compilation.Extensions.BuiltInFunctions;

internal static class Print
{
    internal static FunctionCall GetStatement(this FluqParser.PrintContext ctx)
    {
        ArgumentNullException.ThrowIfNull(ctx);
        
        var printFuncContext = ctx.print_func();
        ArgumentNullException.ThrowIfNull(printFuncContext);

        var text = printFuncContext.func_call_params().GetText();

        return new FunctionCall("print", new []{new TextParam(text)});
    }
}