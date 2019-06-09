parser grammar GLSL_ES300Parser;

options { tokenVocab = GLSL_ES300Lexer; }

root
   : declarationlist? EOF
   ;

declaration
   : variabledeclaration
   ;

declarationlist
   : declaration 
   | declarationlist declaration
   ;

variabledeclaration
   : Identifier
   ;

literal
   : IntegerLiteral
   ;
