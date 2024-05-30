using Compilation.Extensions;
using Compilation.Statements;

namespace Compilation;

internal class Listener : FluqParserBaseListener
{
    internal Action<SetVariable> SetVariable;
    internal Action<FunctionCall> FunctionCall;
    internal Action ProgramEnd;

    public override void EnterFluq_program(FluqParser.Fluq_programContext context)
    {
        context.Validate();

        foreach (var stmtCtx in context.statement())
        {
            switch (stmtCtx)
            {
                case FluqParser.CallContext ctx:
                    FunctionCall?.Invoke(ctx.GetStatement()); 
                    break;
                case FluqParser.Func_declareContext ctx:
                    throw new NotImplementedException();
                    break;
                case FluqParser.Var_assignContext ctx:
                    SetVariable?.Invoke(ctx.GetStatement());
                    break;
                case FluqParser.NewlineContext ctx:
                    break;
            }
        }
    }

    public override void ExitFluq_program(FluqParser.Fluq_programContext context)
    {
        ProgramEnd?.Invoke(); 
    }
}