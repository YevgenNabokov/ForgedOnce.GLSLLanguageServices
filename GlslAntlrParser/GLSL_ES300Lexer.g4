lexer grammar GLSL_ES300Lexer;

channels { COMMENTS, PREPROCESSOR }

fragment SIGN
   : [-+]
   ;

fragment NONDIGIT
   : [a-zA-Z_]
   ;

fragment DIGIT
   : [0-9]
   ;

fragment NONZERODIGIT
   : [1-9]
   ;

fragment OCTALDIGIT
   : [0-7]
   ;

fragment HEXADECIMALDIGIT
   : [0-9a-fA-F]
   ;

fragment BINARYDIGIT
   : [01]
   ;

fragment IntegerSuffix
   : [uU]
   ;

fragment FloatingSuffix
   : [fF]
   ;

fragment DecimalLiteral
   : NONZERODIGIT DIGIT*
   ;

fragment OctalLiteral
   : '0' OCTALDIGIT*
   ;

fragment HexadecimalLiteral
   : ('0x' | '0X') HEXADECIMALDIGIT*
   ;

fragment ExponentialPart
   : [eE] SIGN? DIGIT+
   ;

fragment FractionalLiteral
   : DIGIT+ '.' DIGIT+
   | DIGIT+ '.'
   | '.' DIGIT+
   ;

FloatingLiteral
   : FractionalLiteral ExponentialPart? FloatingSuffix?
   | DIGIT+ ExponentialPart FloatingSuffix?
   ;

IntegerLiteral
   : DecimalLiteral IntegerSuffix?
   | OctalLiteral IntegerSuffix?
   | HexadecimalLiteral IntegerSuffix?
   ;

BoolLiteral
   : True
   | False
   ;

Whitespace
    :   [ \t]+ -> skip
    ;

Newline
    :   ( '\r' '\n'? | '\n') -> skip
    ;

BlockComment
   : '/*' .*? '*/' -> channel (COMMENTS)
   ;

LineComment
   : '//' ~[\r\n]* -> channel (COMMENTS)
   ;

/* Keywords */

Struct: 'struct' ;
Const: 'const' ;
In: 'in' ;
Out: 'out' ;
InOut: 'inout' ;
Uniform: 'uniform' ;
CentroidIn: 'centroid in' ;
CentroidOut: 'centroid out' ;
Precision: 'precision' ;
PrecisionLow: 'lowp' ;
PrecisionMedium: 'mediump' ;
PrecisionHigh: 'highp' ;
True: 'true' ;
False: 'false' ;
If: 'if' ;
Else: 'else' ;
Switch: 'switch' ;
Case: 'case' ;
Default: 'default' ;
While: 'while' ;
Do: 'do' ;
For: 'for' ;
Continue: 'continue' ;
Break: 'break' ;
Return: 'return' ;
Discard: 'discard' ;
Invariant: 'invariant' ;
Layout: 'layout' ;
Smooth: 'smooth' ;
Flat: 'flat' ;

/* Operators */

Plus: '+' ;
Minus: '-' ;
Mul: '*' ;
Div: '/' ;
Pipe: '|' ;
Percent: '%' ;
Bang: '!' ;
Tilde: '~' ;
Equal: '=' ;
NotEqual: '!=' ;
Ampersand: '&' ;
Caret: '^' ;
Greater: '>' ;
Less: '<' ;
LessOrEqual: '<=' ;
GreaterOrEqual: '>=' ;
Left: '<<' ;
Right: '>>' ;
And: '&&' ;
Or: '||' ;
Xor: '^^' ;
MulAssign: '*=' ;
DivAssign: '/=' ;
ModAssign: '%=' ;
AddAssign: '+=' ;
SubAssign: '-=' ;
LeftAssign: '<<=' ;
RightAssign: '>>=' ;
AndAssign: '&=' ;
XorAssign: '^=' ;
OrAssign: '|=' ;
Increment: '++' ;
Decrement: '--' ;

/* Chars */

Semicolon: ';' ;
Colon: ':' ;
Comma: ',' ;
Dot: '.' ;
LeftBrace: '{' ;
RightBrace: '}' ;
LeftParen: '(' ;
RightParen: ')' ;
LeftBracket: '[' ;
RightBracket: ']' ;
Question: '?' ;

/* Basic types */

Void_type
   : 'void'
   ;

Bool_type
   : 'bool'
   ;

Int_type
   : 'int'
   ;

Uint_type
   : 'uint'
   ;

Float_type
   : 'float'
   ;

Vec2_type
   : 'vec2'
   ;

Vec3_type
   : 'vec3'
   ;

Vec4_type
   : 'vec4'
   ;

Bvec2_type
   : 'bvec2'
   ;

Bvec3_type
   : 'bvec3'
   ;

Bvec4_type
   : 'bvec4'
   ;

Ivec2_type
   : 'ivec2'
   ;

Ivec3_type
   : 'ivec3'
   ;

Ivec4_type
   : 'ivec4'
   ;

Uvec2_type
   : 'uvec2'
   ;

Uvec3_type
   : 'uvec3'
   ;

Uvec4_type
   : 'uvec4'
   ;

Mat2_type
   : 'mat2'
   ;

Mat3_type
   : 'mat3'
   ;

Mat4_type
   : 'mat4'
   ;

Mat2x2_type
   : 'mat2x2'
   ;

Mat2x3_type
   : 'mat2x3'
   ;   

Mat2x4_type
   : 'mat2x4'
   ;

Mat3x2_type
   : 'mat3x2'
   ;

Mat3x3_type
   : 'mat3x3'
   ;   

Mat3x4_type
   : 'mat3x4'
   ;

Mat4x2_type
   : 'mat4x2'
   ;

Mat4x3_type
   : 'mat4x3'
   ;   

Mat4x4_type
   : 'mat4x4'
   ;

Sampler2D_type
   : 'sampler2D'
   ;

Sampler3D_type
   : 'sampler3D'
   ;

SamplerCube_type
   : 'samplerCube'
   ;

SamplerCubeShadow_type
   : 'samplerCubeShadow'
   ;

Sampler2DShadow_type
   : 'sampler2DShadow'
   ;

Sampler2DArray_type
   : 'sampler2DArray'
   ;

Sampler2DArrayShadow_type
   : 'sampler2DArrayShadow'
   ;

Isampler2D_type
   : 'isampler2D'
   ;

Isampler3D_type
   : 'isampler3D'
   ;

IsamplerCube_type
   : 'isamplerCube'
   ;

Isampler2DArray_type
   : 'isampler2DArray'
   ;

Usampler2D_type
   : 'usampler2D'
   ;

Usampler3D_type
   : 'usampler3D'
   ;

UsamplerCube_type
   : 'usamplerCube'
   ;

Usampler2DArray_type
   : 'usampler2DArray'
   ;

IdentifierNonDigit
   : NONDIGIT;

Identifier
   : IdentifierNonDigit (IdentifierNonDigit | DIGIT)*
   ;



