grammar Profane;

compilation_unit: statement* ;
statement:
    init_statement SMILEY | print_statement SMILEY;


init_statement: DERP ID ASSIGN expr;
print_statement: PRINT (expr)?;

expr: ID | NUMBER | STRING;

DERP: 'derp';
ID: [a-zA-Z_] [a-zA-Z0-9_]*;
ASSIGN: '=';
COMMA: ',';
SMILEY: ':)';
PRINT: 'dump';

fragment INT: [0-9]+;
NUMBER: INT ('.'(INT)?)?;
STRING: '"' (~('\n' | '"'))* '"';