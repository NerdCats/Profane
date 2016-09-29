script : block* 
  block  : STRING LBRACE command* RBRACE 
  command : STRING property* SEMI
  property : (STRING EQUALS)?  STRING