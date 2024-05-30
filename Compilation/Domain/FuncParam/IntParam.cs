namespace Compilation.Domain.FuncParam;

internal class IntParam : IFuncParam
{
    public readonly int Value;

    public IntParam(int value)
    {
        Value = value;
    }
}