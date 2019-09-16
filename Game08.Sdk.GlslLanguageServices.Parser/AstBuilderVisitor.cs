using Antlr4.Runtime.Misc;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Parser
{
    public class AstBuilderVisitor : GLSL_ES300ParserBaseVisitor<AstNode>
    {
        public override AstNode VisitTranslation_unit([NotNull] GLSL_ES300Parser.Translation_unitContext context)
        {            
            var declarations = context.external_declaration_list();
            if (declarations != null)
            {
                return (Root)this.Visit(declarations);
            }

            return new Root();
        }

        public override AstNode VisitExternal_declaration_list([NotNull] GLSL_ES300Parser.External_declaration_listContext context)
        {
            var result = new Root();

            var version = context.shader_version_marker();
            if (version != null)
            {                
                if (version.VersionMarker300ES() != null)
                {
                    result.Version = ShaderVersion.GlslEs300;
                }
            }

            foreach (var exdec in context.external_declaration())
            {
                var dec = exdec.declaration();
                if (dec != null)
                {
                    result.Declarations.Add((Declaration)this.Visit(dec));
                }
                else
                {
                    var func = exdec.function_definition();
                    if (func != null)
                    {
                        result.Declarations.Add((Declaration)this.Visit(func));
                    }
                }
            }

            return result;
        }

        public override AstNode VisitDeclaration([NotNull] GLSL_ES300Parser.DeclarationContext context)
        {
            var declaratorList = context.declaratorlist();
            if (declaratorList != null)
            {
                return this.Visit(declaratorList);
            }

            var functionPrototype = context.function_prototype();
            if (functionPrototype != null)
            {
                return this.Visit(functionPrototype);
            }

            var precisionQualifier = context.precision_qualifier();
            if (precisionQualifier != null)
            {
                PrecisionDeclaration result = new PrecisionDeclaration();

                result.PrecisionQualifier = (PrecisionQualifier)Enum.Parse(typeof(PrecisionQualifier), precisionQualifier.GetText(), true);

                var noPrecTypeSpec = context.type_specifier_noprec();
                var typeSpecifier = (TypeSpecifier)VisitType_specifier_nonarray(noPrecTypeSpec.type_specifier_nonarray());
                result.Type = typeSpecifier;

                if (noPrecTypeSpec.LeftBracket() != null)
                {
                    result.ArraySpecifier = new ArraySpecifier();

                    if (noPrecTypeSpec.constant_expression() != null)
                    {
                        result.ArraySpecifier.ArraySizeExpression = (Expression)this.Visit(noPrecTypeSpec.constant_expression());
                    }
                }

                return result;
            }

            throw new NotSupportedException();
        }

        public override AstNode VisitDeclaratorlist([NotNull] GLSL_ES300Parser.DeclaratorlistContext context)
        {
            VariableDeclarationList declaratorList = new VariableDeclarationList();
            var currentContext = context;
            while (currentContext != null)
            {
                var dec = currentContext.declarator();
                if (dec != null)
                {                    
                    if (dec.fully_specified_type() != null)
                    {
                        declaratorList.Type = (TypeSpecifier)this.Visit(dec.fully_specified_type());
                    }

                    VariableDeclaration declaration = new VariableDeclaration();
                    if (dec.Identifier() != null)
                    {
                        declaration.Name = new Identifier()
                        {
                            Name = dec.Identifier().Symbol.Text
                        };

                        if (dec.LeftBracket() != null)
                        {
                            declaration.ArraySpecifier = new ArraySpecifier();
                            if (dec.constant_expression() != null)
                            {
                                declaration.ArraySpecifier.ArraySizeExpression = (Expression)this.Visit(dec.constant_expression());
                            }
                        }
                        if (dec.initializer() != null)
                        {
                            declaration.Initializer = (Expression)this.Visit(dec.initializer().assignment_expression());
                        }

                        declaratorList.Declarations.Add(declaration);
                    }

                    currentContext = null;                    
                }
                else
                {
                    VariableDeclaration declaration = new VariableDeclaration();
                    if (currentContext.Identifier() != null)
                    {
                        declaration.Name = new Identifier()
                        {
                            Name = currentContext.Identifier().Symbol.Text
                        };
                    }
                    if (currentContext.LeftBracket() != null)
                    {
                        declaration.ArraySpecifier = new ArraySpecifier();
                        if (currentContext.constant_expression() != null)
                        {
                            declaration.ArraySpecifier.ArraySizeExpression = (Expression)this.Visit(currentContext.constant_expression());
                        }
                    }
                    if (currentContext.initializer() != null)
                    {
                        declaration.Initializer = (Expression)this.Visit(currentContext.initializer().assignment_expression());
                    }

                    currentContext = currentContext.declaratorlist();
                    declaratorList.Declarations.Add(declaration);
                }
            }

            declaratorList.Declarations.Reverse();
            return declaratorList;
        }

        public override AstNode VisitFully_specified_type([NotNull] GLSL_ES300Parser.Fully_specified_typeContext context)
        {            
            TypeQualifier resultQualifier = null;
            var qualifier = context.type_qualifier();
            if (qualifier != null)
            {
                resultQualifier = (TypeQualifier)VisitType_qualifier(qualifier);
            }

            var typeSpecifier = (TypeSpecifier)VisitType_specifier_nonarray(context.type_specifier_nonarray());
            typeSpecifier.Qualifier = resultQualifier;
            return typeSpecifier;
        }

        public override AstNode VisitType_specifier_nonarray([NotNull] GLSL_ES300Parser.Type_specifier_nonarrayContext context)
        {
            if (context.struct_specifier() != null)
            {
                var structSpecifier = (StructTypeSpecifier)this.VisitStruct_specifier(context.struct_specifier());
                return structSpecifier;
            }
            else
            {
                TypeNameSpecifier result = new TypeNameSpecifier();
                result.Identifier = new Identifier() { Name = context.GetText() };
                return result;
            }
        }

        public override AstNode VisitType_qualifier(GLSL_ES300Parser.Type_qualifierContext context)
        {
            TypeQualifier result = new TypeQualifier();

            if (context.invariant_qualifier() != null)
            {
                result.Invariant = true;
            }

            if (context.interpolation_qualifier() != null)
            {
                var interp = context.interpolation_qualifier();
                result.Interpolation = (InterpolationQualifier)Enum.Parse(typeof(InterpolationQualifier), interp.GetText(), true);
            }

            if (context.storage_qualifier() != null)
            {
                var stor = context.storage_qualifier();
                result.Storage = (StorageQualifier)Enum.Parse(typeof(StorageQualifier), stor.GetText(), true);
            }

            if (context.layout_qualifier() != null)
            {                
                var layoutIdList = context.layout_qualifier().layout_qualifier_idlist();
                while (layoutIdList != null)
                {
                    if (layoutIdList.layout_qualifier_id() != null)
                    {
                        var idQualifier = new LayoutIdQualifier();
                        var layoutId = layoutIdList.layout_qualifier_id();
                        idQualifier.Identifier = new Identifier()
                        {
                            Name = layoutId.Identifier().Symbol.Text
                        };

                        if (layoutId.IntegerLiteral() != null)
                        {
                            idQualifier.Order = new IntegerLiteral() { LiteralValue = layoutId.IntegerLiteral().GetText() };
                        }

                        result.Layout.Add(idQualifier);
                    }

                    layoutIdList = layoutIdList.layout_qualifier_idlist();
                }
            }

            return result;
        }

        public override AstNode VisitStruct_specifier([NotNull] GLSL_ES300Parser.Struct_specifierContext context)
        {
            var result = new StructTypeSpecifier();

            if (context.Identifier() != null)
            {
                result.Identifier = new Identifier()
                {
                    Name = context.Identifier().Symbol.Text
                };
            }

            var list = context.struct_declarationlist();
            if (list != null)
            {
                foreach (var d in list.struct_declaration())
                {
                    var member = new StructMemberDeclaration();
                    var qualifier = d.type_qualifier() != null ? (TypeQualifier)VisitType_qualifier(d.type_qualifier()) : new TypeQualifier();

                    var typeSpec = d.type_specifier();

                    if (typeSpec.precision_qualifier() != null)
                    {
                        qualifier.Precision = (PrecisionQualifier)Enum.Parse(typeof(PrecisionQualifier), typeSpec.precision_qualifier().GetText(), true);
                    }

                    var noPrecTypeSpec = typeSpec.type_specifier_noprec();
                    var typeSpecifier = (TypeSpecifier)VisitType_specifier_nonarray(noPrecTypeSpec.type_specifier_nonarray());
                    typeSpecifier.Qualifier = qualifier;
                    member.Type = typeSpecifier;

                    if (noPrecTypeSpec.LeftBracket() != null)
                    {
                        member.ArraySpecifier = new ArraySpecifier();

                        if (noPrecTypeSpec.constant_expression() != null)
                        {
                            member.ArraySpecifier.ArraySizeExpression = (Expression)this.Visit(noPrecTypeSpec.constant_expression());
                        }
                    }

                    var currentDeclaratorList = d.struct_declaratorlist();
                    while(currentDeclaratorList != null)
                    {
                        if (currentDeclaratorList.Identifier() != null)
                        {
                            member.Identifiers.Add(new Identifier()
                            {
                                Name = currentDeclaratorList.Identifier().Symbol.Text
                            });
                        }

                        currentDeclaratorList = currentDeclaratorList.struct_declaratorlist();
                    }

                    result.Members.Add(member);
                }
            }

            return result;
        }

        public override AstNode VisitFunction_definition([NotNull] GLSL_ES300Parser.Function_definitionContext context)
        {
            var result = (FunctionDeclaration)this.Visit(context.function_prototype());

            result.Statement = (StatementCompound)this.Visit(context.compound_statement());

            return result;
        }

        public override AstNode VisitFunction_prototype([NotNull] GLSL_ES300Parser.Function_prototypeContext context)
        {
            var result = new FunctionDeclaration();

            var declarator = context.function_declarator();

            var header = declarator.function_header();

            result.Name = new Identifier()
            {
                Name = header.Identifier().Symbol.Text
            };

            result.TypeSpecifier = (TypeSpecifier)VisitFully_specified_type(header.fully_specified_type());

            var parameters = declarator.function_parameters();

            if (parameters != null)
            {
                foreach (var p in parameters.parameter_declaration())
                {
                    var pResult = new FunctionParameter();

                    pResult.IsConst = p.parameter_type_qualifier() != null;

                    var paramQ = p.parameter_qualifier();
                    if (paramQ != null)
                    {
                        pResult.ParameterQualifier = (ParameterQualifier)Enum.Parse(typeof(ParameterQualifier), paramQ.GetText(), true);
                    }

                    var decl = p.parameter_declarator();
                    var typeSpecifier = (TypeSpecifier)VisitType_specifier_nonarray(p.type_specifier_nonarray() ?? decl.type_specifier_nonarray());
                    if (decl != null)
                    {
                        pResult.Name = new Identifier()
                        {
                            Name = decl.Identifier().Symbol.Text
                        };

                        var arraySize = decl.constant_expression();
                        if (arraySize != null)
                        {
                            pResult.ArraySpecifier = new ArraySpecifier()
                            {
                                ArraySizeExpression = (Expression)Visit(arraySize)
                            };
                        }
                    }

                    pResult.TypeSpecifier = typeSpecifier;

                    result.Parameters.Add(pResult);
                }
            }

            return result;
        }

        public override AstNode VisitCompound_statement([NotNull] GLSL_ES300Parser.Compound_statementContext context)
        {
            var result = new StatementCompound();

            result.Statements.AddRange(this.VisitStatementList(context.statementlist()));

            return result;
        }

        public List<Statement> VisitStatementList(GLSL_ES300Parser.StatementlistContext context)
        {
            var result = new List<Statement>();

            if (context != null)
            {
                var currentList = context;

                while (currentList != null)
                {
                    result.Add((Statement)this.Visit(currentList.statement()));
                    currentList = currentList.statementlist();
                }
            }

            result.Reverse();
            return result;
        }

        public override AstNode VisitStatement([NotNull] GLSL_ES300Parser.StatementContext context)
        {
            var compound = context.compound_statement();
            if (compound != null)
            {
                return this.VisitCompound_statement(compound);
            }

            return this.VisitSimple_statement(context.simple_statement());
        }

        public override AstNode VisitSimple_statement([NotNull] GLSL_ES300Parser.Simple_statementContext context)
        {
            var declaration = context.declaration_statement();
            if (declaration != null)
            {
                return this.VisitDeclaration_statement(declaration);
            }

            var expr = context.expression_statement();
            if (expr != null)
            {
                return this.VisitExpression_statement(expr);
            }

            var selection = context.selection_statement();
            if (selection != null)
            {
                return this.VisitSelection_statement(selection);
            }

            var switchStatement = context.switch_statement();
            if (switchStatement != null)
            {
                return this.VisitSwitch_statement(switchStatement);
            }

            var caseLabel = context.case_label();
            if (caseLabel != null)
            {
                return this.VisitCase_label(caseLabel);
            }

            var iteration = context.iteration_statement();
            if (iteration != null)
            {
                return this.VisitIteration_statement(iteration);
            }

            var jump = context.jump_statement();
            if (jump != null)
            {
                return this.VisitJump_statement(jump);
            }

            throw new NotSupportedException($"Statement is not supported: {context.ToString()}");
        }

        public override AstNode VisitJump_statement([NotNull] GLSL_ES300Parser.Jump_statementContext context)
        {
            if (context.Continue() != null)
            {
                return new StatementContinue();
            }

            if (context.Break() != null)
            {
                return new StatementBreak();
            }

            if (context.Return() != null)
            {
                var result = new StatementReturn();
                var expr = context.expression();
                if (expr != null)
                {
                    result.Expression = (Expression)this.Visit(expr);
                }

                return result;
            }

            return new StatementDiscard();
        }

        public override AstNode VisitIteration_statement([NotNull] GLSL_ES300Parser.Iteration_statementContext context)
        {
            if (context.While() != null)
            {
                var w = new StatementWhile();
                if (context.condition().fully_specified_type() != null)
                {
                    throw new NotSupportedException($"Expression is not supported as condition for 'while' loop: {context.condition().GetText()}");
                }

                w.Condition = (Expression)this.Visit(context.condition().expression());
                w.Body = (Statement)this.Visit(context.statement());
                return w;
            }

            if (context.Do() != null)
            {
                var d = new StatementDo();
                d.Body = (Statement)this.Visit(context.statement());
                d.Condition = (Expression)this.Visit(context.expression());
                return d;
            }

            var f = new StatementFor();
            var init = context.for_init_statement();
            f.Init = init.expression_statement() != null ? (Statement)this.Visit(init.expression_statement()) : (Statement)this.Visit(init.declaration_statement());
            var rest = context.for_rest_statement();
            var condition = rest.condition();
            if (condition != null)
            {
                if (condition.fully_specified_type() != null)
                {
                    throw new NotSupportedException($"Expression is not supported as condition for 'for' loop: {condition.GetText()}");
                }

                f.Condition = (Expression)this.Visit(condition.expression());
            }

            var incr = rest.expression();
            if (incr != null)
            {
                f.Increment = (Expression)this.Visit(incr);
            }

            f.Body = (Statement)this.Visit(context.statement());

            return f;
        }

        public override AstNode VisitCase_label([NotNull] GLSL_ES300Parser.Case_labelContext context)
        {
            var expr = context.expression();
            if (expr != null)
            {
                var r = new StatementCase();
                r.Expression = (Expression)this.VisitExpression(expr);
                return r;
            }

            return new StatementDefault();
        }

        public override AstNode VisitSwitch_statement([NotNull] GLSL_ES300Parser.Switch_statementContext context)
        {
            var result = new StatementSwitch();
            result.Expression = (Expression)this.Visit(context.expression());
            result.Statements.AddRange(this.VisitStatementList(context.statementlist()));
            return result;
        }

        public override AstNode VisitSelection_statement([NotNull] GLSL_ES300Parser.Selection_statementContext context)
        {
            var result = new StatementIf();
            result.Condition = (Expression)this.Visit(context.expression());
            var statements = context.statement();
            result.Then = (Statement)this.Visit(statements[0]);

            if (statements.Length > 1)
            {
                result.Else = (Statement)this.Visit(statements[1]);
            }

            return result;
        }

        public override AstNode VisitDeclaration_statement([NotNull] GLSL_ES300Parser.Declaration_statementContext context)
        {
            var result = new StatementDeclaration();
            result.Declaration = (Declaration)this.VisitDeclaration(context.declaration());
            return result;
        }

        public override AstNode VisitExpression_statement([NotNull] GLSL_ES300Parser.Expression_statementContext context)
        {
            var result = new StatementExpression();

            var expr = context.expression();
            if (expr != null)
            {
                result.Expression = (Expression)this.Visit(expr);
            }

            return result;
        }

        public override AstNode VisitExpression([NotNull] GLSL_ES300Parser.ExpressionContext context)
        {
            var expr = context.expression();

            if (expr != null)
            {
                var result = new ExpressionSequence();

                while (expr != null)
                {
                    result.Expressions.Add((Expression)this.Visit(expr.assignment_expression()));
                    expr = expr.expression();
                }

                return result;
            }

            return this.Visit(context.assignment_expression());
        }

        public override AstNode VisitAssignment_expression([NotNull] GLSL_ES300Parser.Assignment_expressionContext context)
        {
            var cond = context.conditional_expression();
            if (cond != null)
            {
                return this.Visit(cond);
            }

            var result = new ExpressionBinary();
            result.Left = (Expression)this.Visit(context.unary_expression());
            result.Right = (Expression)this.Visit(context.assignment_expression());

            var op = context.assignment_operator();
            if (op.Assign() != null)
            {
                result.Operator = Operator.Assign;
            }

            if (op.MulAssign() != null)
            {
                result.Operator = Operator.MulAssign;
            }

            if (op.DivAssign() != null)
            {
                result.Operator = Operator.DivAssign;
            }

            if (op.ModAssign() != null)
            {
                result.Operator = Operator.ModAssign;
            }

            if (op.AddAssign() != null)
            {
                result.Operator = Operator.AddAssign;
            }

            if (op.SubAssign() != null)
            {
                result.Operator = Operator.SubAssign;
            }

            if (op.LeftAssign() != null)
            {
                result.Operator = Operator.LeftAssign;
            }

            if (op.RightAssign() != null)
            {
                result.Operator = Operator.RightAssign;
            }

            if (op.AndAssign() != null)
            {
                result.Operator = Operator.AndAssign;
            }

            if (op.XorAssign() != null)
            {
                result.Operator = Operator.XorAssign;
            }

            if (op.OrAssign() != null)
            {
                result.Operator = Operator.OrAssign;
            }

            return result;
        }

        public override AstNode VisitConditional_expression([NotNull] GLSL_ES300Parser.Conditional_expressionContext context)
        {
            if (context.Question() != null)
            {
                var result = new ExpressionConditional();
                result.Condition = (Expression)this.Visit(context.logical_or_expression());
                result.Then = (Expression)this.Visit(context.expression());
                result.Else = (Expression)this.Visit(context.assignment_expression());
                return result;
            }

            return this.Visit(context.logical_or_expression());
        }

        public override AstNode VisitLogical_or_expression([NotNull] GLSL_ES300Parser.Logical_or_expressionContext context)
        {
            if (context.Or() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.logical_or_expression());
                result.Right = (Expression)this.Visit(context.logical_xor_expression());
                result.Operator = Operator.Or;
                return result;
            }

            return this.Visit(context.logical_xor_expression());
        }

        public override AstNode VisitLogical_xor_expression([NotNull] GLSL_ES300Parser.Logical_xor_expressionContext context)
        {
            if (context.Xor() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.logical_xor_expression());
                result.Right = (Expression)this.Visit(context.logical_and_expression());
                result.Operator = Operator.Xor;
                return result;
            }

            return this.Visit(context.logical_and_expression());
        }

        public override AstNode VisitLogical_and_expression([NotNull] GLSL_ES300Parser.Logical_and_expressionContext context)
        {
            if (context.And() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.logical_and_expression());
                result.Right = (Expression)this.Visit(context.inclusive_or_expression());
                result.Operator = Operator.And;
                return result;
            }

            return this.Visit(context.inclusive_or_expression());
        }

        public override AstNode VisitInclusive_or_expression([NotNull] GLSL_ES300Parser.Inclusive_or_expressionContext context)
        {
            if (context.Pipe() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.inclusive_or_expression());
                result.Right = (Expression)this.Visit(context.exclusive_or_expression());
                result.Operator = Operator.Pipe;
                return result;
            }

            return this.Visit(context.exclusive_or_expression());
        }

        public override AstNode VisitExclusive_or_expression([NotNull] GLSL_ES300Parser.Exclusive_or_expressionContext context)
        {
            if (context.Caret() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.exclusive_or_expression());
                result.Right = (Expression)this.Visit(context.and_expression());
                result.Operator = Operator.Caret;
                return result;
            }

            return this.Visit(context.and_expression());
        }

        public override AstNode VisitAnd_expression([NotNull] GLSL_ES300Parser.And_expressionContext context)
        {
            if (context.Ampersand() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.and_expression());
                result.Right = (Expression)this.Visit(context.equality_expression());
                result.Operator = Operator.Ampersand;
                return result;
            }

            return this.Visit(context.equality_expression());
        }

        public override AstNode VisitEquality_expression([NotNull] GLSL_ES300Parser.Equality_expressionContext context)
        {
            if (context.Equal() != null || context.NotEqual() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.equality_expression());
                result.Right = (Expression)this.Visit(context.relational_expression());
                result.Operator = context.Equal() != null ? Operator.Equal : Operator.NotEqual;
                return result;
            }

            return this.Visit(context.relational_expression());
        }

        public override AstNode VisitRelational_expression([NotNull] GLSL_ES300Parser.Relational_expressionContext context)
        {
            if (context.Less() != null || context.Greater() != null || context.LessOrEqual() != null || context.GreaterOrEqual() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.relational_expression());
                result.Right = (Expression)this.Visit(context.shift_expression());
                if (context.Less() != null)
                {
                    result.Operator = Operator.Less;
                }
                
                if (context.Greater() != null)
                {
                    result.Operator = Operator.Greater;
                }

                if (context.LessOrEqual() != null)
                {
                    result.Operator = Operator.LessOrEqual;
                }

                if (context.GreaterOrEqual() != null)
                {
                    result.Operator = Operator.GreaterOrEqual;
                }

                return result;
            }

            return this.Visit(context.shift_expression());
        }

        public override AstNode VisitShift_expression([NotNull] GLSL_ES300Parser.Shift_expressionContext context)
        {
            if (context.Left() != null || context.Right() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.shift_expression());
                result.Right = (Expression)this.Visit(context.additive_expression());
                result.Operator = context.Left() != null ? Operator.Left : Operator.Right;
                return result;
            }

            return this.Visit(context.additive_expression());
        }

        public override AstNode VisitAdditive_expression([NotNull] GLSL_ES300Parser.Additive_expressionContext context)
        {
            if (context.Plus() != null || context.Minus() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.additive_expression());
                result.Right = (Expression)this.Visit(context.multiplicative_expression());
                result.Operator = context.Plus() != null ? Operator.Plus : Operator.Minus;
                return result;
            }

            return this.Visit(context.multiplicative_expression());
        }

        public override AstNode VisitMultiplicative_expression([NotNull] GLSL_ES300Parser.Multiplicative_expressionContext context)
        {
            if (context.Mul() != null || context.Div() != null || context.Percent() != null)
            {
                var result = new ExpressionBinary();
                result.Left = (Expression)this.Visit(context.multiplicative_expression());
                result.Right = (Expression)this.Visit(context.unary_expression());
                if (context.Mul() != null)
                {
                    result.Operator = Operator.Mul;
                }

                if (context.Div() != null)
                {
                    result.Operator = Operator.Div;
                }

                if (context.Percent() != null)
                {
                    result.Operator = Operator.Percent;
                }
                return result;
            }

            return this.Visit(context.unary_expression());
        }

        public override AstNode VisitUnary_expression([NotNull] GLSL_ES300Parser.Unary_expressionContext context)
        {
            var postfix = context.postfix_expression();
            if (postfix != null)
            {
                return this.VisitPostfix_expression(postfix);
            }

            var result = new ExpressionUnary();
            if (context.Increment() != null)
            {
                result.Operator = Operator.Increment;
            }

            if (context.Decrement() != null)
            {
                result.Operator = Operator.Decrement;
            }

            var unaryOp = context.unary_operator();
            if (unaryOp.Plus() != null)
            {
                result.Operator = Operator.Plus;
            }

            if (unaryOp.Minus() != null)
            {
                result.Operator = Operator.Minus;
            }

            if (unaryOp.Bang() != null)
            {
                result.Operator = Operator.Bang;
            }

            if (unaryOp.Tilde() != null)
            {
                result.Operator = Operator.Tilde;
            }

            result.Right = (Expression)this.Visit(context.unary_expression());

            return result;
        }

        public override AstNode VisitPostfix_expression([NotNull] GLSL_ES300Parser.Postfix_expressionContext context)
        {
            if (context.Increment() != null || context.Decrement() != null)
            {
                var rUnary = new ExpressionUnaryPostfix();
                if (context.Increment() != null)
                {
                    rUnary.Operator = Operator.Increment;
                }
                else
                {
                    rUnary.Operator = Operator.Decrement;
                }

                rUnary.Left = (Expression)this.Visit(context.postfix_expression());
                return rUnary;
            }

            var field = context.field_selection();
            if (field != null)
            {
                return new ExpressionFieldSelection()
                {
                    Name = new Identifier()
                    {
                        Name = field.Identifier().Symbol.Text
                    },
                    Left = (Expression)this.Visit(context.postfix_expression())
                };
            }

            var func = context.function_call_generic();
            if (func != null)
            {
                var rFunc = this.VisitFunctionCall(func);
                if (context.postfix_expression() != null)
                {
                    rFunc.Left = (Expression)this.Visit(context.postfix_expression());
                }

                return rFunc;
            }

            var intExpr = context.integer_expression();
            if (intExpr != null)
            {
                return new ExpressionIndexAccess()
                {
                    Left = (Expression)this.Visit(context.postfix_expression()),
                    Index = (Expression)this.Visit(context.integer_expression())
                };
            }

            return this.Visit(context.primary_expression());
        }

        public override AstNode VisitPrimary_expression([NotNull] GLSL_ES300Parser.Primary_expressionContext context)
        {
            var varId = context.variable_identifier();
            if (varId != null)
            {
                return new ExpressionVariableIdentifier()
                {
                    Identifier = new Identifier()
                    {
                        Name = varId.Identifier().Symbol.Text
                    }
                };
            }

            var intLiteral = context.IntegerLiteral();
            if (intLiteral != null)
            {
                return new IntegerLiteral() { LiteralValue = intLiteral.GetText() };
            }

            var floatLiteral = context.FloatingLiteral();
            if (floatLiteral != null)
            {
                return new FloatLiteral() { LiteralValue = floatLiteral.GetText() };
            }

            var boolLiteral = context.BoolLiteral();
            if (boolLiteral != null)
            {
                return new BooleanLiteral() { LiteralValue = boolLiteral.GetText() };
            }

            var result = new ExpressionParenGroup();
            result.Content = (Expression)this.Visit(context.expression());
            return result;
        }

        private ExpressionFunctionCall VisitFunctionCall(GLSL_ES300Parser.Function_call_genericContext context)
        {
            var result = new ExpressionFunctionCall();

            GLSL_ES300Parser.Function_call_headerContext header = null;
            var headerNoParams = context.function_call_header_no_parameters();
            if (headerNoParams != null)
            {
                header = headerNoParams.function_call_header();
            }

            var headerWithParams = context.function_call_header_with_parameters();
            if (headerWithParams != null)
            {
                while (headerWithParams != null)
                {
                    result.Parameters.Add((Expression)this.Visit(headerWithParams.assignment_expression()));
                    header = headerWithParams.function_call_header();
                    headerWithParams = headerWithParams.function_call_header_with_parameters();
                }

                result.Parameters.Reverse();
            }

            var identifier = header.function_identifier();
            var id = identifier.Identifier();
            if (id != null)
            {
                result.Identifier = new Identifier()
                {
                    Name = id.Symbol.Text
                };
            }

            var field = identifier.field_selection();
            if (field != null)
            {
                result.Identifier = new Identifier()
                {
                    Name = field.Identifier().Symbol.Text
                };
            }

            var type = identifier.type_specifier();
            if (type != null)
            {
                if (type.precision_qualifier() != null)
                {
                    throw new NotSupportedException("Precision qualifier is not supported for type as function identifier.");
                }

                var typeSpec = type.type_specifier_noprec();
                if (typeSpec.LeftBracket() != null)
                {
                    throw new NotSupportedException("Array specifier is not supported for type as function identifier.");
                }

                var typeSpecNonArr = typeSpec.type_specifier_nonarray();
                if (typeSpecNonArr.struct_specifier() != null)
                {
                    throw new NotSupportedException("Struct specifier is not supported for type as function identifier.");
                }

                result.Identifier = new Identifier() { Name = typeSpec.GetText() };
            }

            return result;
        }

        private List<TOut> UnwrapList<TRecursive, TItem, TOut>(Func<TRecursive, TItem> itemGetter, Func<TItem, TOut> itemMapper, Func<TRecursive, TRecursive> nextGetter, TRecursive subject)
        {
            List<TOut> result = new List<TOut>();
            var current = subject;
            while (current != null)
            {
                var item = itemGetter(current);

                if (item != null)
                {
                    result.Add(itemMapper(item));
                }

                current = nextGetter(current);
            }

            return result;
        }
    }
}
