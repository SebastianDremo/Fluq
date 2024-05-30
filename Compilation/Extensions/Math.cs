using static FluqParser;

namespace Compilation.Extensions;

internal static class Math
{
    internal static int Calculate(this MathContext ctx)
    {
        if (ctx.PLUS() is not null)
        {
            return (int)ctx.expression()[0].Evaluate() + (int)ctx.expression()[1].Evaluate();
        }

        return (int) ctx.expression()[0].Evaluate() - (int) ctx.expression()[1].Evaluate();
    }
}