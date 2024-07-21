using System.Reflection.Emit;

namespace Compilation.Domain;

/// <summary>
/// LocalBuilder does not have every info we need so I've created this record to also hold name and index of local variable.
/// </summary>
internal record Local(string Name,int index, LocalBuilder Builder); 