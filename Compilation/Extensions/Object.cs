using Compilation.Domain.FuncParam;

namespace Compilation.Extensions;

internal static class Object
{
    internal static IEnumerable<IFuncParam> ToFuncParams(this IEnumerable<object> objects)
    {
        foreach (var @object in objects)
        {
            yield return @object.ToFuncParam();
        }     
    }

    private static IFuncParam ToFuncParam(this object @object)
    {
        return @object switch
        {
            int value => new IntParam(value),
            string text => new TextParam(text),
            _ => throw new InvalidOperationException("Cannot convert given object to func parameter.")
        };
    }
}