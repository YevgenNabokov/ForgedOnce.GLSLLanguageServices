parser grammar GLSL_ES300Parser;

options { tokenVocab = GLSL_ES300Lexer; }

translation_unit
   : external_declaration_list? EOF
   ;

external_declaration_list
   : external_declaration+   
   ;

external_declaration
   : function_definition
   | declaration
   ;

function_definition
   : function_prototype compound_statement
   ;

declaration
   : function_prototype Semicolon
   | declaratorlist Semicolon
   | Precision precision_qualifier type_specifier_noprec Semicolon
   | type_qualifier Identifier LeftBrace struct_declarationlist RightBrace (Identifier (LeftBracket constant_expression RightBracket)?)? Semicolon
   | type_qualifier Semicolon
   ;

declarator
   : fully_specified_type Identifier?
   | fully_specified_type Identifier LeftBracket constant_expression RightBracket (Equal initializer)?
   | fully_specified_type Identifier LeftBracket RightBracket Equal initializer
   | fully_specified_type Identifier Equal initializer
   | Invariant Identifier
   ;

declaratorlist
   : declarator
   | declaratorlist Comma Identifier
   | declaratorlist Comma Identifier LeftBracket constant_expression RightBracket (Equal initializer)?
   | declaratorlist Comma Identifier LeftBracket RightBracket Equal initializer
   | declaratorlist Comma Identifier Equal initializer
   ;

initializer
   : assignment_expression
   ;

assignment_expression
   : conditional_expression
   | unary_expression assignment_operator assignment_expression
   ;

multiplicative_expression
   : unary_expression
   | multiplicative_expression (Mul | Div | Percent) unary_expression
   ;

additive_expression
   : multiplicative_expression
   | additive_expression (Plus | Minus) multiplicative_expression
   ;

shift_expression
   : additive_expression
   | shift_expression (Left | Right) additive_expression
   ;

relational_expression
   : shift_expression
   | relational_expression (Less | Greater | LessOrEqual | GreaterOrEqual) shift_expression
   ;

equality_expression
   : relational_expression
   | equality_expression (Equal | NotEqual) relational_expression
   ;

and_expression
   : equality_expression
   | and_expression Ampersand equality_expression
   ;

exclusive_or_expression
   : and_expression
   | exclusive_or_expression Caret and_expression
   ;

inclusive_or_expression
   : exclusive_or_expression
   | inclusive_or_expression Pipe exclusive_or_expression
   ;

logical_and_expression
   : inclusive_or_expression
   | logical_and_expression And inclusive_or_expression
   ;

logical_xor_expression
   : logical_and_expression
   | logical_xor_expression Xor logical_and_expression
   ;

logical_or_expression
   : logical_xor_expression
   | logical_or_expression Or logical_xor_expression
   ;

conditional_expression
   : logical_or_expression (Question expression Colon  assignment_expression)?
   ;

unary_expression
   : postfix_expression
   | Increment unary_expression
   | Decrement unary_expression
   | unary_operator unary_expression
   ;

field_selection
   : Identifier
   ;

postfix_expression
   : primary_expression
   | postfix_expression LeftBracket integer_expression RightBracket
   | function_call_generic
   | postfix_expression Dot function_call_generic
   | postfix_expression Dot field_selection
   | postfix_expression Increment
   | postfix_expression Decrement   
   ;

function_call_generic
   : function_call_header_with_parameters RightParen
   | function_call_header_no_parameters RightParen
   ;

function_call_header_no_parameters
   : function_call_header Void_type?   
   ;

function_call_header_with_parameters
   : function_call_header assignment_expression
   | function_call_header_with_parameters Comma assignment_expression
   ;

function_call_header
   : function_identifier LeftParen
   ;

function_identifier
   : type_specifier
   | Identifier
   | field_selection
   ;

variable_identifier
   : Identifier
   ;

integer_expression
   : expression
   ;

expression
   : assignment_expression
   | expression Comma assignment_expression
   ;

primary_expression
   : variable_identifier
   | IntegerLiteral
   | FloatingLiteral
   | BoolLiteral
   | LeftParen expression RightParen
   ;

function_prototype
   : function_declarator RightParen
   ;

function_declarator
   : function_header function_parameters?   
   ;

function_header
   : fully_specified_type Identifier LeftParen
   ;

function_parameters
   : parameter_declaration (Comma parameter_declaration)*
   ;

parameter_declaration
   : parameter_type_qualifier? parameter_qualifier? parameter_declarator
   | parameter_type_qualifier? parameter_qualifier? type_specifier_nonarray
   ;

parameter_declarator
   : type_specifier_nonarray Identifier (LeftBracket constant_expression RightBracket)?
   ;

precision_qualifier
   : PrecisionLow
   | PrecisionMedium
   | PrecisionHigh
   ;

parameter_qualifier
   : In
   | Out
   | InOut
   ;

parameter_type_qualifier
   : Const
   ;

compound_statement
   : LeftBrace statementlist? RightBrace
   ;

statementlist
   : statement
   | statementlist statement
   ;

statement
   : compound_statement
   | simple_statement
   ;

simple_statement
   : declaration_statement
   | expression_statement
   | selection_statement
   | switch_statement
   | case_label
   | iteration_statement
   | jump_statement
   ;

jump_statement
   : Continue Semicolon
   | Break Semicolon
   | Return expression? Semicolon
   | Discard Semicolon /* Fragment shader only */
   ;

condition
   : expression
   | fully_specified_type Identifier Equal initializer
   ;

iteration_statement
   : While LeftParen condition RightParen statement
   | Do statement While LeftParen expression RightParen Semicolon
   | For LeftParen for_init_statement for_rest_statement RightParen statement
   ;

for_init_statement
   : expression_statement
   | declaration_statement
   ;

for_rest_statement
   : condition? Semicolon expression?
   ;

case_label
   : Case expression Colon
   | Default Colon
   ;

switch_statement
   : Switch LeftParen expression RightParen LeftBrace statementlist? RightBrace
   ;

selection_statement
   : If LeftParen expression RightParen statement (Else statement)?
   ;

expression_statement
   : expression? Semicolon
   ;

declaration_statement
   : declaration
   ;

constant_expression
   : conditional_expression
   ;

fully_specified_type
   : type_qualifier? type_specifier_nonarray
   ;

literal
   : IntegerLiteral
   | FloatingLiteral
   ;

struct_declaratorlist
   : Identifier
   | struct_declaratorlist Comma Identifier
   ;

struct_declarationlist
   : struct_declaration+
   ;

struct_declaration
   : type_qualifier? type_specifier struct_declaratorlist Semicolon
   ;

struct_specifier
   : Struct Identifier? LeftBrace struct_declarationlist RightBrace
   ;

type_qualifier
   : storage_qualifier
   | layout_qualifier
   | layout_qualifier storage_qualifier
   | interpolation_qualifier
   | invariant_qualifier storage_qualifier
   | invariant_qualifier interpolation_qualifier storage_qualifier
   ;

interpolation_qualifier
   : Smooth
   | Flat
   ;

layout_qualifier_id
   : Identifier (Equal IntegerLiteral)?
   ;

layout_qualifier_idlist
   : layout_qualifier_id
   | layout_qualifier_idlist Comma layout_qualifier_id
   ;

layout_qualifier
   : Layout LeftParen layout_qualifier_idlist RightParen
   ;

invariant_qualifier
   : Invariant
   ;

storage_qualifier
   :  Const
   | In
   | Out
   | Uniform
   | CentroidIn
   | CentroidOut
   ;

unary_operator
   : Plus
   | Minus
   | Bang
   | Tilde
   ;

assignment_operator
   : Equal
   | MulAssign
   | DivAssign
   | ModAssign
   | AddAssign
   | SubAssign
   | LeftAssign
   | RightAssign
   | AndAssign
   | XorAssign
   | OrAssign
   ;

type_specifier
   : precision_qualifier? type_specifier_noprec
   ;

type_specifier_noprec
   : type_specifier_nonarray (LeftBracket constant_expression? RightBracket)?
   ;

type_specifier_nonarray
   : Void_type
   | Bool_type
   | Int_type
   | Uint_type
   | Float_type
   | Vec2_type
   | Vec3_type
   | Vec4_type
   | Bvec2_type
   | Bvec3_type
   | Bvec4_type
   | Ivec2_type
   | Ivec3_type
   | Ivec4_type
   | Uvec2_type
   | Uvec3_type
   | Uvec4_type
   | Mat2_type
   | Mat3_type
   | Mat4_type
   | Mat2x2_type
   | Mat2x3_type
   | Mat2x4_type
   | Mat3x2_type
   | Mat3x3_type
   | Mat3x4_type
   | Mat4x2_type
   | Mat4x3_type
   | Mat4x4_type
   | Sampler2D_type
   | Sampler3D_type
   | SamplerCube_type
   | SamplerCubeShadow_type
   | Sampler2DShadow_type
   | Sampler2DArray_type
   | Sampler2DArrayShadow_type
   | Isampler2D_type
   | Isampler3D_type
   | IsamplerCube_type
   | Isampler2DArray_type
   | Usampler2D_type
   | Usampler3D_type
   | UsamplerCube_type
   | Usampler2DArray_type
   | struct_specifier
   | Identifier
   ;

