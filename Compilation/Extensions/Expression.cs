using static FluqParser;

namespace Compilation.Extensions;

internal static class Expression
{
    internal static object Evaluate(this ExpressionContext ctx) => ctx switch
    {
        MathContext math => (object) math.Calculate(),
        Bracket_exprContext bracketExpr => throw new NotImplementedException(),
        NumContext num => int.Parse(ctx.GetText()),
        StrContext str => throw new NotImplementedException(),
        VarContext var => throw new NotImplementedException(),
        _ => throw new ArgumentOutOfRangeException(nameof(ctx))
    };
}