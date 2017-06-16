grammar Profane;

compilationUnit: statement* EOF;

statement: 
        printstmt
        | assignstmt
        | ifstmt
		| setstmt;

printstmt	: 'dump' expr? SMILEY;
assignstmt	: 'derp' ID ASSIGN expr SMILEY;
setstmt		:  ID ASSIGN expr SMILEY;

ifstmt  : 
        conditionExpr '???'
        'yep ->'
            statement*
        'kbye';


conditionExpr: expr relop expr;
expr: term | opExpression;
opExpression: term op term;
op: PLUS | ASSIGN | MINUS;
relop: EQUAL | NOTEQUAL | GT | LT | GTEQ | LTEQ;

term: ID | number | STRING;

number: NUMBER;

// Keywords
ID: [a-zA-Z_] [a-zA-Z0-9_]*;
SMILEY: ':)';
WS: [ \n\t\r]+ -> skip;

PLUS    :'+';
EQUAL   : '====';
ASSIGN  : '=';
NOTEQUAL: '!!==';
MINUS   : '-';
GT      : '>';
LT      : '<';
GTEQ    : '>=';
LTEQ    : '<=';

fragment INT: [0-9]+;
NUMBER: INT ('.'(INT)?)?;
STRING: '"' (~('\n' | '"'))* '"';