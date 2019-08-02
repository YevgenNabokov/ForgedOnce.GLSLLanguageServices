using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels
{
    public class SemanticModelBuilder : AstVisitor<SemanticModelBuilderContext>
    {
        public override void VisitRoot(Root node, SemanticModelBuilderContext context)
        {
            context.EnterNewScope(node);
            base.VisitRoot(node, context);
            context.ExitScope();
        }

        public override void VisitStatementIf(StatementIf node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Condition, context);
            if (node.Then != null)
            {
                context.EnterNewScope(node.Then, true);
                this.Visit(node.Then, context);
                context.ExitScope();
            }
            
            if (node.Else != null)
            {
                context.EnterNewScope(node.Else, true);
                this.Visit(node.Else, context);
                context.ExitScope();
            }
        }

        public override void VisitStatementDo(StatementDo node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Condition, context);
            if (node.Body != null)
            {
                context.EnterNewScope(node.Body, true);
                this.Visit(node.Body, context);
                context.ExitScope();
            }
        }

        public override void VisitStatementWhile(StatementWhile node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Condition, context);
            if (node.Body != null)
            {
                context.EnterNewScope(node.Body);
                this.Visit(node.Body, context);
                context.ExitScope();
            }
        }

        public override void VisitStatementFor(StatementFor node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Init, context);
            this.Visit(node.Condition, context);
            this.Visit(node.Increment, context);
            if (node.Body != null)
            {
                context.EnterNewScope(node.Body);
                this.Visit(node.Body, context);
                context.ExitScope();
            }
        }

        public override void VisitFunctionDeclaration(FunctionDeclaration node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Name, context);
            this.SafeAddSymbol(node.Name, node.Name, context);
            context.EnterNewScope(node);
            this.Visit(node.TypeSpecifier, context);
            foreach (var p in node.Parameters)
            {
                this.Visit(p, context);
            }

            this.Visit(node.Statement, context);

            context.ExitScope();
        }

        public override void VisitFunctionParameter(FunctionParameter node, SemanticModelBuilderContext context)
        {
            base.VisitFunctionParameter(node, context);
            this.SafeAddSymbol(node.Name, node.Name, context);
        }

        public override void VisitVariableDeclaration(VariableDeclaration node, SemanticModelBuilderContext context)
        {
            base.VisitVariableDeclaration(node, context);
            this.SafeAddSymbol(node.Name, node.Name, context);
        }


        private void SafeAddSymbol(Identifier id, AstNode node, SemanticModelBuilderContext context)
        {
            if (id != null)
            {
                context.AddSymbol(id.Name, node);
            }
        }
    }
}
