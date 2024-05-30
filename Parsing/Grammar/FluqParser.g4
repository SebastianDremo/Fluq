parser grammar FluqParser;

options {
    tokenVocab = FluqLexer;
}

fluq_program: statement+;

statement: 
var_type ID '=' expression #var_assign
| func_declaration #func_declare
| func_call #call
| NEWLINE #newline
;

func_declaration:
FUNC func_name=ID '(' func_declaration_params? ')' '{' func_body '}';

func_call:
ID'(' func_call_params? ')' 
| built_in_func;

func_body:
statement*;

func_declaration_params:
ID (',' ID)*;

func_call_params: 
expression (',' expression)*;

built_in_func:
print_func #print
;

print_func:
PRINT '(' func_call_params ')';
    
expression: expression (PLUS | MINUS) expression #math
| NUMBER #num
| ID #var
| STRING #str
| OPEN_BRACKET expression CLOSE_BRACKET #bracket_expr
;

var_type:
TEXT #text 
| INT #int
;