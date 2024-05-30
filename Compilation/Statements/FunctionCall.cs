using Compilation.Domain.FuncParam;

namespace Compilation.Statements;

internal class FunctionCall
{
    public readonly string FunctionName;
    public readonly IFuncParam[] Params;
    
    public FunctionCall(string functionName, IFuncParam[] funcParams)
    {
        FunctionName = functionName;
        Params = funcParams;
    } 
}