grammar Profane;

compilationUnit: statement* EOF;

statement: 
        printstmt
        | assignstmt;

printstmt: 'dump' expr? SMILEY;
assignstmt: 'derp' ID ASSIGN expr SMILEY;

expr: term | opExpression;
opExpression: term op term;
op: PLUS | EQUAL| ASSIGN | NOTEQUAL | MINUS;

term: ID | number | STRING;

number: NUMBER;

// Keywords
ID: [a-zA-Z_] [a-zA-Z0-9_]*;
SMILEY: ':)';
WS: [ \n\t\r]+ -> skip;

PLUS    :'+';
EQUAL   : '==';
ASSIGN  : '=';
NOTEQUAL: '!=';
MINUS   : '-';

fragment INT: [0-9]+;
NUMBER: INT ('.'(INT)?)?;
STRING: '"' (~('\n' | '"'))* '"';