grammar Profane;

compilationUnit: statement* EOF;

statement: 
        printstmt
        | assignstmt;

printstmt: 'dump' expr? SMILEY;
assignstmt: 'derp' ID '=' expr SMILEY;

expr: identifier | number | STRING;

identifier: ID;
number: NUMBER;

// Keywords
ID: [a-zA-Z_] [a-zA-Z0-9_]*;
SMILEY: ':)';
WS: [ \n\t\r]+ -> skip;

fragment INT: [0-9]+;
NUMBER: INT ('.'(INT)?)?;
STRING: '"' (~('\n' | '"'))* '"';