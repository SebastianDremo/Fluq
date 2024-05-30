lexer grammar FluqLexer;

options {
     caseInsensitive = true;
}
 
FUNC: 'FUNC';
TEXT: 'TEXT';
INT: 'INT';
PRINT: 'PRINT';

PLUS: '+';
MINUS: '-';
EQUALS: '=';
 
OPEN_BRACKET: '(';
CLOSE_BRACKET: ')';
OPEN_CURLY_BRACKET: '{';
CLOSE_CURLY_BRACKET: '}';

COMMA: ',';
DOT: '.';

ID: [a-z_]+;
NUMBER: [0-9]+;
STRING: '"' .*? '"'; // match anything in " ... " 

NEWLINE: '\r'? '\n';
WS: [ \t]+ -> skip;
