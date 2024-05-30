using Compilation.Domain;

namespace Compilation.Statements;

internal class SetVariable
{
    internal readonly Variable Variable;
    internal readonly object Value;

    internal SetVariable(Variable variable, object value)
    {
        Variable = variable;
        Value = value;
    }
}