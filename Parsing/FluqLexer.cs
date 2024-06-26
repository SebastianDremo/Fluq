//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/SebastianDremo/Projects/Fluq/Parsing/Grammar/FluqLexer.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class FluqLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		FUNC=1, TEXT=2, INT=3, PRINT=4, PLUS=5, MINUS=6, EQUALS=7, OPEN_BRACKET=8, 
		CLOSE_BRACKET=9, OPEN_CURLY_BRACKET=10, CLOSE_CURLY_BRACKET=11, COMMA=12, 
		DOT=13, ID=14, NUMBER=15, STRING=16, NEWLINE=17, WS=18;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"FUNC", "TEXT", "INT", "PRINT", "PLUS", "MINUS", "EQUALS", "OPEN_BRACKET", 
		"CLOSE_BRACKET", "OPEN_CURLY_BRACKET", "CLOSE_CURLY_BRACKET", "COMMA", 
		"DOT", "ID", "NUMBER", "STRING", "NEWLINE", "WS"
	};


	public FluqLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public FluqLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'FUNC'", "'TEXT'", "'INT'", "'PRINT'", "'+'", "'-'", "'='", "'('", 
		"')'", "'{'", "'}'", "','", "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "FUNC", "TEXT", "INT", "PRINT", "PLUS", "MINUS", "EQUALS", "OPEN_BRACKET", 
		"CLOSE_BRACKET", "OPEN_CURLY_BRACKET", "CLOSE_CURLY_BRACKET", "COMMA", 
		"DOT", "ID", "NUMBER", "STRING", "NEWLINE", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "FluqLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static FluqLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,18,106,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,
		1,1,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,
		7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,1,13,4,13,77,8,13,
		11,13,12,13,78,1,14,4,14,82,8,14,11,14,12,14,83,1,15,1,15,5,15,88,8,15,
		10,15,12,15,91,9,15,1,15,1,15,1,16,3,16,96,8,16,1,16,1,16,1,17,4,17,101,
		8,17,11,17,12,17,102,1,17,1,17,1,89,0,18,1,1,3,2,5,3,7,4,9,5,11,6,13,7,
		15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,1,0,13,
		2,0,70,70,102,102,2,0,85,85,117,117,2,0,78,78,110,110,2,0,67,67,99,99,
		2,0,84,84,116,116,2,0,69,69,101,101,2,0,88,88,120,120,2,0,73,73,105,105,
		2,0,80,80,112,112,2,0,82,82,114,114,3,0,65,90,95,95,97,122,1,0,48,57,2,
		0,9,9,32,32,110,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,
		0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,
		0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,
		1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,1,37,1,0,0,0,3,42,1,0,0,0,5,47,1,0,0,
		0,7,51,1,0,0,0,9,57,1,0,0,0,11,59,1,0,0,0,13,61,1,0,0,0,15,63,1,0,0,0,
		17,65,1,0,0,0,19,67,1,0,0,0,21,69,1,0,0,0,23,71,1,0,0,0,25,73,1,0,0,0,
		27,76,1,0,0,0,29,81,1,0,0,0,31,85,1,0,0,0,33,95,1,0,0,0,35,100,1,0,0,0,
		37,38,7,0,0,0,38,39,7,1,0,0,39,40,7,2,0,0,40,41,7,3,0,0,41,2,1,0,0,0,42,
		43,7,4,0,0,43,44,7,5,0,0,44,45,7,6,0,0,45,46,7,4,0,0,46,4,1,0,0,0,47,48,
		7,7,0,0,48,49,7,2,0,0,49,50,7,4,0,0,50,6,1,0,0,0,51,52,7,8,0,0,52,53,7,
		9,0,0,53,54,7,7,0,0,54,55,7,2,0,0,55,56,7,4,0,0,56,8,1,0,0,0,57,58,5,43,
		0,0,58,10,1,0,0,0,59,60,5,45,0,0,60,12,1,0,0,0,61,62,5,61,0,0,62,14,1,
		0,0,0,63,64,5,40,0,0,64,16,1,0,0,0,65,66,5,41,0,0,66,18,1,0,0,0,67,68,
		5,123,0,0,68,20,1,0,0,0,69,70,5,125,0,0,70,22,1,0,0,0,71,72,5,44,0,0,72,
		24,1,0,0,0,73,74,5,46,0,0,74,26,1,0,0,0,75,77,7,10,0,0,76,75,1,0,0,0,77,
		78,1,0,0,0,78,76,1,0,0,0,78,79,1,0,0,0,79,28,1,0,0,0,80,82,7,11,0,0,81,
		80,1,0,0,0,82,83,1,0,0,0,83,81,1,0,0,0,83,84,1,0,0,0,84,30,1,0,0,0,85,
		89,5,34,0,0,86,88,9,0,0,0,87,86,1,0,0,0,88,91,1,0,0,0,89,90,1,0,0,0,89,
		87,1,0,0,0,90,92,1,0,0,0,91,89,1,0,0,0,92,93,5,34,0,0,93,32,1,0,0,0,94,
		96,5,13,0,0,95,94,1,0,0,0,95,96,1,0,0,0,96,97,1,0,0,0,97,98,5,10,0,0,98,
		34,1,0,0,0,99,101,7,12,0,0,100,99,1,0,0,0,101,102,1,0,0,0,102,100,1,0,
		0,0,102,103,1,0,0,0,103,104,1,0,0,0,104,105,6,17,0,0,105,36,1,0,0,0,6,
		0,78,83,89,95,102,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
