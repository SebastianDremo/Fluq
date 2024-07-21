using Compilation.Statements;

namespace Compilation.Extensions.BuiltInFunctions;

internal static class BuiltInFunc
{
    internal static FunctionCall GetStatement(this FluqParser.Built_in_funcContext ctx)
    {
        return ctx switch
        {
            FluqParser.PrintContext printContext => printContext.GetStatement(),
            _ => throw new ArgumentOutOfRangeException(nameof(ctx))
        };
    }
}