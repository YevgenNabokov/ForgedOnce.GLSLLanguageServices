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
                resultQualifier = this.ParseQualifier(qualifier);
            }

            var nonArraySpecifier = context.type_specifier_nonarray();
            if (nonArraySpecifier.struct_specifier() != null)
            {
                var structSpecifier = (StructTypeSpecifier)this.VisitStruct_specifier(nonArraySpecifier.struct_specifier());
                structSpecifier.Qualifier = resultQualifier;
                return structSpecifier;
            }
            else
            {
                TypeNameSpecifier result = new TypeNameSpecifier();
                result.Qualifier = resultQualifier;
                result.Identifier = new Identifier() { Name = nonArraySpecifier.GetText() };
                return result;
            }
        }

        public TypeQualifier ParseQualifier(GLSL_ES300Parser.Type_qualifierContext context)
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
                        idQualifier.Id = (Identifier)this.Visit(layoutId.Identifier());
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
    }
}
