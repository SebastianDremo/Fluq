using System.Reflection;
using System.Reflection.Emit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Compilation.Domain;
using Compilation.Domain.FuncParam;
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
    private LocalsMap _localsMap;

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
        _localsMap = new LocalsMap();
    }

    public void Compile()
    {
        var listener = new Listener
        {
            SetVariable = OnSetVariable,
            FunctionCall = OnFunctionCall,
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
        var il = _mainMethodBuilder.GetILGenerator(); // it will not work within functions, need to change that in the future
        LocalBuilder localBuilder =  il.DeclareLocal(statement.Variable.VarType.ToDotnetType());
        _localsMap.TrySetLocal(
            _mainMethodBuilder.Name,
            statement.Variable.Name,
            localBuilder,
            out Local local
            );
        
        il.Emit(OpCodes.Ldc_I4, (int)statement.Value); // accepts only i4, no strings or floats
        il.Emit(OpCodes.Stloc, local.Builder);
    }

    private void OnFunctionCall(FunctionCall statement)
    {
        if (statement.FunctionName.Equals("print")) // it cannot work like that, need to move that to some 
        {
            var il = _mainMethodBuilder.GetILGenerator();
            var param = statement.Params[0] as TextParam;
            _localsMap.TryGetLocal(_mainMethodBuilder.Name, param.Text, out Local local);
            il.EmitWriteLine(local.Builder);
        }
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