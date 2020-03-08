using ForgedOnce.GlslLanguageServices.LanguageModels;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using ForgedOnce.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.SemanticAnalysis
{
    public class SemanticModelBuilderVisitor : AstVisitor<SemanticModelBuilderContext>
    {
        public override void VisitRoot(Root node, SemanticModelBuilderContext context)
        {
            context.EnterNewScope(node);
            base.VisitRoot(node, context);
            context.ExitScope();
        }

        public override void VisitStructTypeSpecifier(StructTypeSpecifier node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Qualifier, context);
            this.Visit(node.Identifier, context);
            this.SafeAddSymbol(node.Identifier, node.Identifier, context, SymbolKind.Type);

            context.EnterNewScope(node, true);
            foreach (var n in node.Members)
            {
                this.Visit(n, context);
            }

            context.ExitScope();
        }

        public override void VisitStructMemberDeclaration(StructMemberDeclaration node, SemanticModelBuilderContext context)
        {
            this.Visit(node.Type, context);
            this.Visit(node.ArraySpecifier, context);
            foreach (var n in node.Identifiers)
            {
                this.SafeAddSymbol(n, n, context, SymbolKind.TypeMember | SymbolKind.Variable);
                this.Visit(n, context);
            }
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
            this.SafeAddSymbol(node.Name, node.Name, context, SymbolKind.Function);
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
            this.SafeAddSymbol(node.Name, node.Name, context, SymbolKind.Variable | SymbolKind.FunctionParameter);
        }

        public override void VisitVariableDeclaration(VariableDeclaration node, SemanticModelBuilderContext context)
        {
            base.VisitVariableDeclaration(node, context);
            this.SafeAddSymbol(node.Name, node.Name, context, SymbolKind.Variable);
        }

        public override void VisitExpressionFieldSelection(ExpressionFieldSelection node, SemanticModelBuilderContext context)
        {
            this.SafeAddSymbolReference(node.Name, node, context);
            base.VisitExpressionFieldSelection(node, context);
        }

        public override void VisitExpressionFunctionCall(ExpressionFunctionCall node, SemanticModelBuilderContext context)
        {
            this.SafeAddSymbolReference(node.Identifier, node, context);
            base.VisitExpressionFunctionCall(node, context);
        }

        public override void VisitExpressionVariableIdentifier(ExpressionVariableIdentifier node, SemanticModelBuilderContext context)
        {
            this.SafeAddSymbolReference(node.Identifier, node, context);
            base.VisitExpressionVariableIdentifier(node, context);
        }

        public override void VisitLayoutIdQualifier(LayoutIdQualifier node, SemanticModelBuilderContext context)
        {
            this.SafeAddSymbolReference(node.Identifier, node, context);
            base.VisitLayoutIdQualifier(node, context);
        }

        public override void VisitTypeNameSpecifier(TypeNameSpecifier node, SemanticModelBuilderContext context)
        {
            this.SafeAddSymbolReference(node.Identifier, node, context);
            base.VisitTypeNameSpecifier(node, context);
        }

        private void SafeAddSymbol(Identifier id, AstNode node, SemanticModelBuilderContext context, SymbolKind kind)
        {
            if (id != null)
            {
                context.AddSymbol(id.Name, node, kind);
            }
        }

        private void SafeAddSymbolReference(Identifier id, AstNode ownerNode, SemanticModelBuilderContext context)
        {
            if (id != null)
            {
                context.AddSymbolReference(id, ownerNode);
            }
        }
    }
}
