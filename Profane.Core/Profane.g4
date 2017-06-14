grammar Profane;

compilation_unit: statement* ;
statement:
    assign_statement | invoke_statement SMILEY;

assign_statement: DERP ID ASSIGN expr;
invoke_statement: name=ID ((expr COMMA)* expr)?;

expr: ID | NUMBER | STRING;

DERP: 'derp';
ID: [a-zA-Z_] [a-zA-Z0-9_]*;
ASSIGN: '=';
COMMA: ',';
SMILEY: ':)';

fragment INT: [0-9]+;
NUMBER: INT ('.'(INT)?)?;
STRING: '"' (~('\n' | '"'))* '"';


