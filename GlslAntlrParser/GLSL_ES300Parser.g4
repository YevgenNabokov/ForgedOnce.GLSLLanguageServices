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
   | FloatingLiteral
   ;

declarators
   : Identifier
   | declarators Comma Identifier
   ;

memberdeclaration
   : typename declarators Semicolon
   ;

structdefinition
   : typequalifier? Struct Identifier? OpenCurlyBrace memberdeclaration+ CloseCurlyBrace declarators Semicolon
   ;

typequalifier
   : Const
   | In
   | Out
   | Uniform
   | CentroidIn
   | CentroidOut
   ;

typename
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
   | Identifier
   ;

