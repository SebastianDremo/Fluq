using Compilation.Extensions;

namespace Compilation.Domain;

internal class Variable
{
    public readonly VarType VarType;
    public readonly string Name;

    public Variable(VarType varType, string name)
    {
        VarType = varType;
        Name = name;
    }
}