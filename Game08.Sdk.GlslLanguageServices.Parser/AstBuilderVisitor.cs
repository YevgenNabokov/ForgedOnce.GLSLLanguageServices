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
                return this.Visit(declarations);
            }

            return new Root();
        }

        public override AstNode VisitExternal_declaration_list([NotNull] GLSL_ES300Parser.External_declaration_listContext context)
        {
            var result = new Root();

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
                    }
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
                        idQualifier.Id = new Identifier()
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
