using Compilation.Domain;
using static FluqParser;

namespace Compilation.Extensions;

internal static class VarTypeExtensions
{
    internal static VarType GetVarType(this Var_typeContext? ctx)
    {
        if (ctx is null) throw new ArgumentNullException(nameof(ctx));

        return ctx switch
        {
            IntContext intContext => VarType.Int,
            TextContext textContext => VarType.Text,
            _ => throw new ArgumentOutOfRangeException(nameof(ctx))
        };
    }

    internal static Type ToDotnetType(this VarType varType)
    {
        return varType switch
        {
            VarType.Text => typeof(string),
            VarType.Int => typeof(int),
            _ => throw new ArgumentOutOfRangeException(nameof(varType), varType, "Could not convert to dotnet type.")
        };
    }
}