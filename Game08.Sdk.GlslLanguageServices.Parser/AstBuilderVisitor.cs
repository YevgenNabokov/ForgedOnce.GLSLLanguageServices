using Antlr4.Runtime.Misc;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.Parser.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Parser
{
    public class AstBuilderVisitor : GLSL_ES300ParserBaseVisitor<AstNode>
    {
        public override AstNode VisitTranslation_unit([NotNull] GLSL_ES300Parser.Translation_unitContext context)
        {
            var result = new Root();

            var declarations = context.external_declaration();
            if (declarations != null)
            {
                foreach (var exdec in declarations)
                {
                    var dec = exdec.declaration();
                    if (dec != null)
                    {
                        var d = (Declaration)this.Visit(dec);

                        if (d is VarDeclaratorRoot)
                        {
                            result.Declarations.AddRange(this.UnwrapVariableDeclaratorList((VarDeclaratorRoot)d));
                        }
                        else
                        {
                            result.Declarations.Add(d);
                        }
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
            VarDeclarator currentDeclarator = null;
            var currentContext = context;
            while (currentContext != null)
            {
                var dec = currentContext.declarator();
                if (dec != null)
                {
                    currentDeclarator = null;
                    var root = new VarDeclaratorRoot();
                    root.Next = currentDeclarator;
                    if (dec.fully_specified_type() != null)
                    {
                        root.Type = (TypeSpecifier)this.Visit(dec.fully_specified_type());
                    }
                    if (dec.Identifier() != null)
                    {
                        root.Name = new Identifier()
                        {
                            Name = dec.Identifier().Symbol.Text
                        };
                    }
                    if (dec.LeftBracket() != null)
                    {
                        root.IsArray = true;
                        if (dec.constant_expression() != null)
                        {
                            root.ArraySizeExpression = (Expression)this.Visit(dec.constant_expression());
                        }
                    }
                    if (dec.initializer() != null)
                    {
                        root.Initializer = (Expression)this.Visit(dec.initializer().assignment_expression());
                    }

                    return root;
                }
                else
                {
                    var declarator = new VarDeclarator();
                    declarator.Next = currentDeclarator;                    
                    if (currentContext.Identifier() != null)
                    {
                        declarator.Name = new Identifier()
                        {
                            Name = currentContext.Identifier().Symbol.Text
                        };
                    }
                    if (currentContext.LeftBracket() != null)
                    {
                        declarator.IsArray = true;
                        if (currentContext.constant_expression() != null)
                        {
                            declarator.ArraySizeExpression = (Expression)this.Visit(currentContext.constant_expression());
                        }
                    }
                    if (currentContext.initializer() != null)
                    {
                        declarator.Initializer = (Expression)this.Visit(currentContext.initializer().assignment_expression());
                    }

                    currentContext = currentContext.declaratorlist();
                }
            }

            return currentDeclarator;
        }

        private List<VariableDeclaration> UnwrapVariableDeclaratorList(VarDeclaratorRoot declaratorRoot)
        {
            throw new NotImplementedException("Consider not unwrapping the variable declarations.");
        }
    }
}
