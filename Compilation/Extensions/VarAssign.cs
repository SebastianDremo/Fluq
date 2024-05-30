using Compilation.Domain;
using Compilation.Statements;

namespace Compilation.Extensions;

internal static class VarAssign
{
    internal static SetVariable GetStatement(this FluqParser.Var_assignContext ctx)
    {
        var type = ctx.var_type().GetVarType();
        var variableName = ctx.ID().GetText();
        var value = ctx.expression().Evaluate();
        var variable = new Variable(type, variableName);

        return new SetVariable(variable, value);
    }
}