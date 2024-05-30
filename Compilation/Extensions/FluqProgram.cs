using static FluqParser;

namespace Compilation.Extensions;

internal static class FluqProgram
{
    /// <summary>
    /// Validates given fluq_programContext. 
    /// </summary>
    /// <param name="ctx">Fluq_programContext</param>
    /// <exception cref="InvalidProgramException">If fluq program is not correct, will throw.</exception>
    internal static void Validate(this Fluq_programContext ctx)
    {
        if (ctx.statement() is null || ctx.statement().Length == 0) throw new InvalidProgramException(); // for now it feels like good enough exception
    }
}