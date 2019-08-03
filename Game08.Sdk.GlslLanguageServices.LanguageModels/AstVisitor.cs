using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels
{
    public class AstVisitor<TContext>
    {
        public void Visit(AstNode node, TContext context)
        {
            if (node == null)
            {
                return;
            }

            if(node is Root)
            {
                this.VisitRoot(node as Root, context);
                return;
            }

            if (node is VariableDeclarationList)
            {
                this.VisitVariableDeclarationList(node as VariableDeclarationList, context);
                return;
            }

            if (node is VariableDeclaration)
            {
                this.VisitVariableDeclaration(node as VariableDeclaration, context);
                return;
            }

            if (node is Identifier)
            {
                this.VisitIdentifier(node as Identifier, context);
                return;
            }

            if (node is ArraySpecifier)
            {
                this.VisitArraySpecifier(node as ArraySpecifier, context);
                return;
            }

            if (node is TypeQualifier)
            {
                this.VisitTypeQualifier(node as TypeQualifier, context);
                return;
            }

            if (node is LayoutIdQualifier)
            {
                this.VisitLayoutIdQualifier(node as LayoutIdQualifier, context);
                return;
            }

            if (node is IntegerLiteral)
            {
                this.VisitIntegerLiteral(node as IntegerLiteral, context);
                return;
            }

            if (node is FloatLiteral)
            {
                this.VisitFloatLiteral(node as FloatLiteral, context);
                return;
            }

            if (node is BooleanLiteral)
            {
                this.VisitBooleanLiteral(node as BooleanLiteral, context);
                return;
            }

            if (node is ExpressionBinary)
            {
                this.VisitExpressionBinary(node as ExpressionBinary, context);
                return;
            }

            if (node is ExpressionConditional)
            {
                this.VisitExpressionConditional(node as ExpressionConditional, context);
                return;
            }

            if (node is ExpressionFieldSelection)
            {
                this.VisitExpressionFieldSelection(node as ExpressionFieldSelection, context);
                return;
            }

            if (node is ExpressionFunctionCall)
            {
                this.VisitExpressionFunctionCall(node as ExpressionFunctionCall, context);
                return;
            }

            if (node is ExpressionIndexAccess)
            {
                this.VisitExpressionIndexAccess(node as ExpressionIndexAccess, context);
                return;
            }

            if (node is ExpressionParenGroup)
            {
                this.VisitExpressionParenGroup(node as ExpressionParenGroup, context);
                return;
            }

            if (node is ExpressionSequence)
            {
                this.VisitExpressionSequence(node as ExpressionSequence, context);
                return;
            }

            if (node is ExpressionUnary)
            {
                this.VisitExpressionUnary(node as ExpressionUnary, context);
                return;
            }

            if (node is ExpressionUnaryPostfix)
            {
                this.VisitExpressionUnaryPostfix(node as ExpressionUnaryPostfix, context);
                return;
            }

            if (node is ExpressionVariableIdentifier)
            {
                this.VisitExpressionVariableIdentifier(node as ExpressionVariableIdentifier, context);
                return;
            }

            if (node is FunctionDeclaration)
            {
                this.VisitFunctionDeclaration(node as FunctionDeclaration, context);
                return;
            }

            if (node is FunctionParameter)
            {
                this.VisitFunctionParameter(node as FunctionParameter, context);
                return;
            }

            if (node is StatementBreak)
            {
                this.VisitStatementBreak(node as StatementBreak, context);
                return;
            }

            if (node is StatementCase)
            {
                this.VisitStatementCase(node as StatementCase, context);
                return;
            }

            if (node is StatementCompound)
            {
                this.VisitStatementCompound(node as StatementCompound, context);
                return;
            }

            if (node is StatementContinue)
            {
                this.VisitStatementContinue(node as StatementContinue, context);
                return;
            }

            if (node is StatementDeclaration)
            {
                this.VisitStatementDeclaration(node as StatementDeclaration, context);
                return;
            }

            if (node is StatementDefault)
            {
                this.VisitStatementDefault(node as StatementDefault, context);
                return;
            }

            if (node is StatementDiscard)
            {
                this.VisitStatementDiscard(node as StatementDiscard, context);
                return;
            }

            if (node is StatementDo)
            {
                this.VisitStatementDo(node as StatementDo, context);
                return;
            }

            if (node is StatementExpression)
            {
                this.VisitStatementExpression(node as StatementExpression, context);
                return;
            }

            if (node is StatementFor)
            {
                this.VisitStatementFor(node as StatementFor, context);
                return;
            }

            if (node is StatementIf)
            {
                this.VisitStatementIf(node as StatementIf, context);
                return;
            }

            if (node is StatementReturn)
            {
                this.VisitStatementReturn(node as StatementReturn, context);
                return;
            }

            if (node is StatementSwitch)
            {
                this.VisitStatementSwitch(node as StatementSwitch, context);
                return;
            }

            if (node is StatementWhile)
            {
                this.VisitStatementWhile(node as StatementWhile, context);
                return;
            }

            if (node is StructMemberDeclaration)
            {
                this.VisitStructMemberDeclaration(node as StructMemberDeclaration, context);
                return;
            }

            if (node is StructTypeSpecifier)
            {
                this.VisitStructTypeSpecifier(node as StructTypeSpecifier, context);
                return;
            }

            if (node is TypeNameSpecifier)
            {
                this.VisitTypeNameSpecifier(node as TypeNameSpecifier, context);
                return;
            }

            if (node is PrecisionDeclaration)
            {
                this.VisitPrecisionDeclaration(node as PrecisionDeclaration, context);
                return;
            }

            throw new NotImplementedException($"Visitor for {node.GetType()} is not implemented.");
        }
        
        public virtual void VisitPrecisionDeclaration(PrecisionDeclaration node, TContext context)
        {
            this.Visit(node.Type, context);
            this.Visit(node.ArraySpecifier, context);            
        }

        public virtual void VisitTypeNameSpecifier(TypeNameSpecifier node, TContext context)
        {
            this.Visit(node.Identifier, context);
            this.Visit(node.Qualifier, context);
        }

        public virtual void VisitStructTypeSpecifier(StructTypeSpecifier node, TContext context)
        {
            this.Visit(node.Qualifier, context);
            this.Visit(node.Identifier, context);
            foreach (var n in node.Members)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitStructMemberDeclaration(StructMemberDeclaration node, TContext context)
        {
            this.Visit(node.Type, context);
            this.Visit(node.ArraySpecifier, context);
            foreach (var n in node.Identifiers)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitStatementWhile(StatementWhile node, TContext context)
        {
            this.Visit(node.Condition, context);
            this.Visit(node.Body, context);
        }

        public virtual void VisitStatementSwitch(StatementSwitch node, TContext context)
        {
            this.Visit(node.Expression, context);
            foreach (var n in node.Statements)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitStatementReturn(StatementReturn node, TContext context)
        {
            this.Visit(node.Expression, context);
        }

        public virtual void VisitStatementIf(StatementIf node, TContext context)
        {
            this.Visit(node.Condition, context);
            this.Visit(node.Then, context);
            this.Visit(node.Else, context);
        }

        public virtual void VisitStatementFor(StatementFor node, TContext context)
        {
            this.Visit(node.Init, context);
            this.Visit(node.Condition, context);
            this.Visit(node.Increment, context);
            this.Visit(node.Body, context);
        }

        public virtual void VisitStatementExpression(StatementExpression node, TContext context)
        {
            this.Visit(node.Expression, context);
        }

        public virtual void VisitStatementDo(StatementDo node, TContext context)
        {
            this.Visit(node.Condition, context);
            this.Visit(node.Body, context);
        }

        public virtual void VisitStatementDiscard(StatementDiscard node, TContext context)
        {            
        }

        public virtual void VisitStatementDefault(StatementDefault node, TContext context)
        {            
        }

        public virtual void VisitStatementDeclaration(StatementDeclaration node, TContext context)
        {
            this.Visit(node.Declaration, context);
        }

        public virtual void VisitStatementContinue(StatementContinue node, TContext context)
        {            
        }

        public virtual void VisitStatementCompound(StatementCompound node, TContext context)
        {
            foreach (var n in node.Statements)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitStatementCase(StatementCase node, TContext context)
        {
            this.Visit(node.Expression, context);
        }

        public virtual void VisitStatementBreak(StatementBreak node, TContext context)
        {
        }

        public virtual void VisitFunctionParameter(FunctionParameter node, TContext context)
        {
            this.Visit(node.TypeSpecifier, context);
            this.Visit(node.ArraySpecifier, context);
            this.Visit(node.Name, context);            
        }

        public virtual void VisitFunctionDeclaration(FunctionDeclaration node, TContext context)
        {
            this.Visit(node.TypeSpecifier, context);
            this.Visit(node.Name, context);
            this.Visit(node.Statement, context);
            foreach (var p in node.Parameters)
            {
                this.Visit(p, context);
            }
        }

        public virtual void VisitExpressionVariableIdentifier(ExpressionVariableIdentifier node, TContext context)
        {
            this.Visit(node.Identifier, context);
        }

        public virtual void VisitExpressionUnaryPostfix(ExpressionUnaryPostfix node, TContext context)
        {
            this.Visit(node.Left, context);
        }

        public virtual void VisitExpressionUnary(ExpressionUnary node, TContext context)
        {
            this.Visit(node.Right, context);
        }

        public virtual void VisitExpressionSequence(ExpressionSequence node, TContext context)
        {
            foreach (var n in node.Expressions)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitExpressionParenGroup(ExpressionParenGroup node, TContext context)
        {
            this.Visit(node.Content, context);
        }

        public virtual void VisitExpressionIndexAccess(ExpressionIndexAccess node, TContext context)
        {
            this.Visit(node.Left, context);
            this.Visit(node.Index, context);
        }

        public virtual void VisitExpressionFunctionCall(ExpressionFunctionCall node, TContext context)
        {
            this.Visit(node.Left, context);
            this.Visit(node.Identifier, context);
            foreach(var p in node.Parameters)
            {
                this.Visit(p, context);
            }
        }

        public virtual void VisitExpressionFieldSelection(ExpressionFieldSelection node, TContext context)
        {
            this.Visit(node.Left, context);
            this.Visit(node.Name, context);
        }

        public virtual void VisitExpressionConditional(ExpressionConditional node, TContext context)
        {
            this.Visit(node.Condition, context);
            this.Visit(node.Then, context);
            this.Visit(node.Else, context);
        }

        public virtual void VisitExpressionBinary(ExpressionBinary node, TContext context)
        {
            this.Visit(node.Left, context);
            this.Visit(node.Right, context);
        }

        public virtual void VisitBooleanLiteral(BooleanLiteral node, TContext context)
        {
        }

        public virtual void VisitFloatLiteral(FloatLiteral node, TContext context)
        {
        }

        public virtual void VisitIntegerLiteral(IntegerLiteral node, TContext context)
        {
        }

        public virtual void VisitLayoutIdQualifier(LayoutIdQualifier node, TContext context)
        {
            this.Visit(node.Identifier, context);
            this.Visit(node.Order, context);
        }

        public virtual void VisitTypeQualifier(TypeQualifier node, TContext context)
        {
            foreach (var n in node.Layout)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitArraySpecifier(ArraySpecifier node, TContext context)
        {
            this.Visit(node.ArraySizeExpression, context);
        }

        public virtual void VisitIdentifier(Identifier node, TContext context)
        {
        }

        public virtual void VisitRoot(Root node, TContext context)
        {
            foreach(var n in node.Declarations)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitVariableDeclarationList(VariableDeclarationList node, TContext context)
        {
            this.Visit(node.Type, context);
            foreach(var n in node.Declarations)
            {
                this.Visit(n, context);
            }
        }

        public virtual void VisitVariableDeclaration(VariableDeclaration node, TContext context)
        {
            this.Visit(node.Initializer, context);
            this.Visit(node.Name, context);
            this.Visit(node.ArraySpecifier, context);
        }
    }
}
