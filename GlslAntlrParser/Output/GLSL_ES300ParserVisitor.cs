//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from GLSL_ES300Parser.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GLSL_ES300Parser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IGLSL_ES300ParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.translation_unit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTranslation_unit([NotNull] GLSL_ES300Parser.Translation_unitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.external_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExternal_declaration([NotNull] GLSL_ES300Parser.External_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_definition([NotNull] GLSL_ES300Parser.Function_definitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] GLSL_ES300Parser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarator([NotNull] GLSL_ES300Parser.DeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.declaratorlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaratorlist([NotNull] GLSL_ES300Parser.DeclaratorlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.initializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitializer([NotNull] GLSL_ES300Parser.InitializerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.assignment_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment_expression([NotNull] GLSL_ES300Parser.Assignment_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.multiplicative_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicative_expression([NotNull] GLSL_ES300Parser.Multiplicative_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.additive_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditive_expression([NotNull] GLSL_ES300Parser.Additive_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.shift_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitShift_expression([NotNull] GLSL_ES300Parser.Shift_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.relational_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelational_expression([NotNull] GLSL_ES300Parser.Relational_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.equality_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEquality_expression([NotNull] GLSL_ES300Parser.Equality_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.and_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnd_expression([NotNull] GLSL_ES300Parser.And_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.exclusive_or_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExclusive_or_expression([NotNull] GLSL_ES300Parser.Exclusive_or_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.inclusive_or_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInclusive_or_expression([NotNull] GLSL_ES300Parser.Inclusive_or_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.logical_and_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogical_and_expression([NotNull] GLSL_ES300Parser.Logical_and_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.logical_xor_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogical_xor_expression([NotNull] GLSL_ES300Parser.Logical_xor_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.logical_or_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogical_or_expression([NotNull] GLSL_ES300Parser.Logical_or_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.conditional_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditional_expression([NotNull] GLSL_ES300Parser.Conditional_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.unary_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnary_expression([NotNull] GLSL_ES300Parser.Unary_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.field_selection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitField_selection([NotNull] GLSL_ES300Parser.Field_selectionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.postfix_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostfix_expression([NotNull] GLSL_ES300Parser.Postfix_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_call_generic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_call_generic([NotNull] GLSL_ES300Parser.Function_call_genericContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_call_header_no_parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_call_header_no_parameters([NotNull] GLSL_ES300Parser.Function_call_header_no_parametersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_call_header_with_parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_call_header_with_parameters([NotNull] GLSL_ES300Parser.Function_call_header_with_parametersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_call_header"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_call_header([NotNull] GLSL_ES300Parser.Function_call_headerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_identifier([NotNull] GLSL_ES300Parser.Function_identifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.variable_identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable_identifier([NotNull] GLSL_ES300Parser.Variable_identifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.integer_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInteger_expression([NotNull] GLSL_ES300Parser.Integer_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] GLSL_ES300Parser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.primary_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimary_expression([NotNull] GLSL_ES300Parser.Primary_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_prototype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_prototype([NotNull] GLSL_ES300Parser.Function_prototypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_declarator([NotNull] GLSL_ES300Parser.Function_declaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_header"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_header([NotNull] GLSL_ES300Parser.Function_headerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.function_parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction_parameters([NotNull] GLSL_ES300Parser.Function_parametersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.parameter_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter_declaration([NotNull] GLSL_ES300Parser.Parameter_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.parameter_declarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter_declarator([NotNull] GLSL_ES300Parser.Parameter_declaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.precision_qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrecision_qualifier([NotNull] GLSL_ES300Parser.Precision_qualifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.parameter_qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter_qualifier([NotNull] GLSL_ES300Parser.Parameter_qualifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.parameter_type_qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter_type_qualifier([NotNull] GLSL_ES300Parser.Parameter_type_qualifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.compound_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompound_statement([NotNull] GLSL_ES300Parser.Compound_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.statementlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementlist([NotNull] GLSL_ES300Parser.StatementlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] GLSL_ES300Parser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.simple_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSimple_statement([NotNull] GLSL_ES300Parser.Simple_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.jump_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJump_statement([NotNull] GLSL_ES300Parser.Jump_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition([NotNull] GLSL_ES300Parser.ConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.iteration_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIteration_statement([NotNull] GLSL_ES300Parser.Iteration_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.for_init_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFor_init_statement([NotNull] GLSL_ES300Parser.For_init_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.for_rest_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFor_rest_statement([NotNull] GLSL_ES300Parser.For_rest_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.case_label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCase_label([NotNull] GLSL_ES300Parser.Case_labelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.switch_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitch_statement([NotNull] GLSL_ES300Parser.Switch_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.selection_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelection_statement([NotNull] GLSL_ES300Parser.Selection_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.expression_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression_statement([NotNull] GLSL_ES300Parser.Expression_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.declaration_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration_statement([NotNull] GLSL_ES300Parser.Declaration_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.constant_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant_expression([NotNull] GLSL_ES300Parser.Constant_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.fully_specified_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFully_specified_type([NotNull] GLSL_ES300Parser.Fully_specified_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] GLSL_ES300Parser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.struct_declaratorlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStruct_declaratorlist([NotNull] GLSL_ES300Parser.Struct_declaratorlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.struct_declarationlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStruct_declarationlist([NotNull] GLSL_ES300Parser.Struct_declarationlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.struct_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStruct_declaration([NotNull] GLSL_ES300Parser.Struct_declarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.struct_specifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStruct_specifier([NotNull] GLSL_ES300Parser.Struct_specifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.type_qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_qualifier([NotNull] GLSL_ES300Parser.Type_qualifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.unary_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnary_operator([NotNull] GLSL_ES300Parser.Unary_operatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.assignment_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment_operator([NotNull] GLSL_ES300Parser.Assignment_operatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.type_specifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_specifier([NotNull] GLSL_ES300Parser.Type_specifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.type_specifier_noprec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_specifier_noprec([NotNull] GLSL_ES300Parser.Type_specifier_noprecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GLSL_ES300Parser.type_specifier_nonarray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_specifier_nonarray([NotNull] GLSL_ES300Parser.Type_specifier_nonarrayContext context);
}
