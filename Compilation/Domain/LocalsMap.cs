using System.Reflection.Emit;

namespace Compilation.Domain;

internal class LocalsMap : Dictionary<string, List<Local>>
{
    /// <summary>
    /// Tries to add local to local map of given function, outs created local from given name and builder. 
    /// </summary>
    /// <returns>True if local is set, false is local is already added.</returns>
    internal bool TrySetLocal(string functionName, string localName,LocalBuilder localBuilder, out Local local)
    {
        int index = -1;
        if (!ContainsKey(functionName))
        {
            Add(functionName, new List<Local>());
            index = 0;
            local = new Local(localName, index, localBuilder);
            this[functionName].Add(local);
            return true;
        }

        index = this[functionName].Count;
        local = new Local(localName, index, localBuilder);
        if (this[functionName].Contains(local)) return false;
        this[functionName].Add(local);
        return true;
    }

    internal bool TryGetLocal(string functionName, string localName, out Local? local)
    {
        if (!ContainsKey(functionName))
        {
            local = null;
            return false;
        }

        local = this[functionName].Find(l => l.Name.Equals(localName));
        return local is not null;
    }
}