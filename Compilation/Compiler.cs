using System.Reflection;
using System.Reflection.Emit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Compilation.Extensions;
using Compilation.Statements;
using Lokad.ILPack;

namespace Compilation;

public class Compiler
{
    private FluqParser _parser;
    private TypeBuilder _mainTypeBuilder;
    private MethodBuilder _mainMethodBuilder;
    private AssemblyBuilder _assemblyBuilder;
    private ModuleBuilder _moduleBuilder;
    
    public Compiler(string program)
    {
        var input = new AntlrFileStream(program);
        var lexer = new FluqLexer(input);
        var tokens = new CommonTokenStream(lexer);
        _parser = new FluqParser(tokens)
        {
            BuildParseTree = true
        };

        _mainTypeBuilder = GetMainTypeBuilder(new FileInfo(program).Name);
        _mainMethodBuilder = _mainTypeBuilder.DefineMethod("main", MethodAttributes.Public | MethodAttributes.Static);
    }

    public void Compile()
    {
        var listener = new Listener
        {
            SetVariable = OnSetVariable,
            ProgramEnd = OnProgramEnd
        };
        
        // walk the parse tree
        var tree = _parser.fluq_program();
        var treeWalker = new ParseTreeWalker();
        treeWalker.Walk(listener, tree);

        // generate .dll file
        var assembly = Assembly.GetAssembly(_mainTypeBuilder.CreateType());
        var generator = new AssemblyGenerator();
        generator.GenerateAssembly(assembly, _assemblyBuilder.GetName().Name + ".dll");
    }

    private void OnProgramEnd()
    {
        var il = _mainMethodBuilder.GetILGenerator();
        il.Emit(OpCodes.Ret); 
    }

    private void OnSetVariable(SetVariable statement)
    {
        var il = _mainMethodBuilder.GetILGenerator();
        LocalBuilder local =  il.DeclareLocal(statement.Variable.VarType.ToDotnetType());
        il.Emit(OpCodes.Ldc_I4, (int)statement.Value);
        il.Emit(OpCodes.Stloc, local);
    }

    private TypeBuilder GetMainTypeBuilder(string name)
    {
        var nameWithoutExtension = Path.GetFileNameWithoutExtension(name);
        var assemblyName = new AssemblyName(nameWithoutExtension);
        _assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        _moduleBuilder = _assemblyBuilder.DefineDynamicModule(assemblyName.Name! + "Module");
        return _moduleBuilder.DefineType("MainProgram", TypeAttributes.Public);
    }
}