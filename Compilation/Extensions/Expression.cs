using static FluqParser;

namespace Compilation.Extensions;

internal static class Expression
{
    internal static object Evaluate(this ExpressionContext ctx) => ctx switch
    {
        MathContext math => math.Calculate(),
        Bracket_exprContext bracketExpr => throw new NotImplementedException(),
        NumContext num => int.Parse(ctx.GetText()),
        StrContext str => ctx.GetText(),
        VarContext var => throw new NotImplementedException(),
        _ => throw new ArgumentOutOfRangeException(nameof(ctx))
    };

    internal static IEnumerable<object> Evaluate(this IEnumerable<ExpressionContext> ctx)
    {
        foreach (var expressionContext in ctx)
        {
            yield return expressionContext.Evaluate();
        } 
    }
}