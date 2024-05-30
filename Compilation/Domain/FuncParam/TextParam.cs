namespace Compilation.Domain.FuncParam;

internal class TextParam : IFuncParam
{
    public readonly string Text;

    public TextParam(string text)
    {
        Text = text;
    }
}