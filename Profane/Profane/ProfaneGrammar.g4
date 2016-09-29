grammar ProfaneGrammar;

/*
 * Parser Rules
 */
script : block* 
  block  : STRING LBRACE command* RBRACE 
  command : STRING property* SEMI
  property : (STRING EQUALS)?  STRING

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

// Punctuation     
LBRACE : '{';
RBRACE : '}';
EQUALS : '=';
SEMI : ';';
STRING : ('a'..'z'|'A'..'Z'|'0'..'9'|'_')+ 
                     | ('"' (~'"')* '"');

WS
    :   (' ' | '\r' | '\n') -> channel(HIDDEN)
    ;
