using ForgedOnce.GlslLanguageServices.LanguageModels;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.SyntaxTools
{
    public class CloningAstVisitor : AstVisitor<CloningAstVisitorContext>
    {
        public override void Visit(AstNode node, CloningAstVisitorContext context)
        {
            if (node == null)
            {
                context.Result = null;
            }

            base.Visit(node, context);
        }

        public override void VisitStatementDiscard(StatementDiscard node, CloningAstVisitorContext context)
        {
            context.Result = new StatementDiscard();
        }

        public override void VisitStatementBreak(StatementBreak node, CloningAstVisitorContext context)
        {
            context.Result = new StatementBreak();
        }

        public override void VisitArraySpecifier(ArraySpecifier node, CloningAstVisitorContext context)
        {
            context.Result = new ArraySpecifier()
            {
                ArraySizeExpression = this.CloneNode<Expression>(node.ArraySizeExpression, context)
            };
        }

        public override void VisitBooleanLiteral(BooleanLiteral node, CloningAstVisitorContext context)
        {
            context.Result = new BooleanLiteral() { LiteralValue = node.LiteralValue };
        }

        public override void VisitExpressionBinary(ExpressionBinary node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionBinary()
            {
                Left = this.CloneNode(node.Left, context),
                Right = this.CloneNode(node.Right, context),
                Operator = node.Operator
            };
        }

        public override void VisitExpressionConditional(ExpressionConditional node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionConditional()
            {
                Condition = this.CloneNode(node.Condition, context),
                Then = this.CloneNode(node.Then, context),
                Else = this.CloneNode(node.Else, context)
            };
        }

        public override void VisitExpressionFieldSelection(ExpressionFieldSelection node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionFieldSelection()
            {
                Name = this.CloneNode(node.Name, context),
                Left = this.CloneNode(node.Left, context)
            };
        }

        public override void VisitExpressionFunctionCall(ExpressionFunctionCall node, CloningAstVisitorContext context)
        {
            var result = new ExpressionFunctionCall()
            {
                Left = this.CloneNode(node.Left, context),
                Identifier = this.CloneNode(node.Identifier, context)
            };
            this.CloneNodeCollection(node.Parameters, result.Parameters, context);
            context.Result = result;
        }

        public override void VisitExpressionIndexAccess(ExpressionIndexAccess node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionIndexAccess()
            {
                Index = this.CloneNode(node.Index, context),
                Left = this.CloneNode(node.Left, context)
            };
        }

        public override void VisitExpressionParenGroup(ExpressionParenGroup node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionParenGroup()
            {
                Content = this.CloneNode(node.Content, context)
            };
        }

        public override void VisitExpressionSequence(ExpressionSequence node, CloningAstVisitorContext context)
        {
            var result = new ExpressionSequence();
            this.CloneNodeCollection(node.Expressions, result.Expressions, context);
            context.Result = result;
        }

        public override void VisitExpressionUnary(ExpressionUnary node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionUnary()
            {
                Operator = node.Operator,
                Right = this.CloneNode(node.Right, context)
            };
        }

        public override void VisitExpressionUnaryPostfix(ExpressionUnaryPostfix node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionUnaryPostfix()
            {
                Operator = node.Operator,
                Left = this.CloneNode(node.Left, context)
            };
        }

        public override void VisitExpressionVariableIdentifier(ExpressionVariableIdentifier node, CloningAstVisitorContext context)
        {
            context.Result = new ExpressionVariableIdentifier()
            {
                Identifier = this.CloneNode(node.Identifier, context)
            };
        }

        public override void VisitFloatLiteral(FloatLiteral node, CloningAstVisitorContext context)
        {
            context.Result = new FloatLiteral()
            {
                LiteralValue = node.LiteralValue
            };
        }

        public override void VisitFunctionDeclaration(FunctionDeclaration node, CloningAstVisitorContext context)
        {
            var result = new FunctionDeclaration()
            {
                TypeSpecifier = this.CloneNode(node.TypeSpecifier, context),
                Name = this.CloneNode(node.Name, context),
                Statement = this.CloneNode(node.Statement, context)
            };
            this.CloneNodeCollection(node.Parameters, result.Parameters, context);
            context.Result = result;
        }

        public override void VisitFunctionParameter(FunctionParameter node, CloningAstVisitorContext context)
        {
            context.Result = new FunctionParameter()
            {
                IsConst = node.IsConst,
                ParameterQualifier = node.ParameterQualifier,
                TypeSpecifier = this.CloneNode(node.TypeSpecifier, context),
                ArraySpecifier = this.CloneNode(node.ArraySpecifier, context),
                Name = this.CloneNode(node.Name, context)
            };
        }

        public override void VisitIdentifier(Identifier node, CloningAstVisitorContext context)
        {
            context.Result = new Identifier()
            {
                Name = node.Name
            };
        }

        public override void VisitIntegerLiteral(IntegerLiteral node, CloningAstVisitorContext context)
        {
            context.Result = new IntegerLiteral()
            {
                LiteralValue = node.LiteralValue
            };
        }

        public override void VisitLayoutIdQualifier(LayoutIdQualifier node, CloningAstVisitorContext context)
        {
            context.Result = new LayoutIdQualifier()
            {
                Identifier = this.CloneNode(node.Identifier, context),
                Order = this.CloneNode(node.Order, context)
            };
        }

        public override void VisitPrecisionDeclaration(PrecisionDeclaration node, CloningAstVisitorContext context)
        {
            context.Result = new PrecisionDeclaration()
            {
                Type = this.CloneNode(node.Type, context),
                ArraySpecifier = this.CloneNode(node.ArraySpecifier, context),
                PrecisionQualifier = node.PrecisionQualifier
            };
        }

        public override void VisitRoot(Root node, CloningAstVisitorContext context)
        {
            var result = new Root()
            {
                Version = node.Version,
            };
            this.CloneNodeCollection(node.Declarations, result.Declarations, context);
            context.Result = result;
        }

        public override void VisitStatementCase(StatementCase node, CloningAstVisitorContext context)
        {
            context.Result = new StatementCase()
            {
                Expression = this.CloneNode(node.Expression, context)
            };
        }

        public override void VisitStatementCompound(StatementCompound node, CloningAstVisitorContext context)
        {
            var result = new StatementCompound();
            this.CloneNodeCollection(node.Statements, result.Statements, context);
            context.Result = result;
        }

        public override void VisitStatementContinue(StatementContinue node, CloningAstVisitorContext context)
        {
            context.Result = new StatementContinue();
        }

        public override void VisitStatementDeclaration(StatementDeclaration node, CloningAstVisitorContext context)
        {
            context.Result = new StatementDeclaration()
            {
                Declaration = this.CloneNode(node.Declaration, context)
            };
        }

        public override void VisitStatementDefault(StatementDefault node, CloningAstVisitorContext context)
        {
            context.Result = new StatementDefault();
        }

        public override void VisitStatementDo(StatementDo node, CloningAstVisitorContext context)
        {
            context.Result = new StatementDo()
            {
                Body = this.CloneNode(node.Body, context),
                Condition = this.CloneNode(node.Condition, context)
            };
        }

        public override void VisitStatementExpression(StatementExpression node, CloningAstVisitorContext context)
        {
            context.Result = new StatementExpression()
            {
                Expression = this.CloneNode(node.Expression, context)
            };
        }

        public override void VisitStatementFor(StatementFor node, CloningAstVisitorContext context)
        {
            context.Result = new StatementFor()
            {
                Init = this.CloneNode(node.Init, context),
                Condition = this.CloneNode(node.Condition, context),
                Body = this.CloneNode(node.Body, context),
                Increment = this.CloneNode(node.Increment, context)
            };
        }

        public override void VisitStatementIf(StatementIf node, CloningAstVisitorContext context)
        {
            context.Result = new StatementIf()
            {
                Condition = this.CloneNode(node.Condition, context),
                Then = this.CloneNode(node.Then, context),
                Else = this.CloneNode(node.Else, context)
            };
        }

        public override void VisitStatementReturn(StatementReturn node, CloningAstVisitorContext context)
        {
            context.Result = new StatementReturn()
            {
                Expression = this.CloneNode(node.Expression, context)
            };
        }

        public override void VisitStatementSwitch(StatementSwitch node, CloningAstVisitorContext context)
        {
            var result = new StatementSwitch()
            {
                Expression = this.CloneNode(node.Expression, context)
            };
            this.CloneNodeCollection(node.Statements, result.Statements, context);
            context.Result = result;
        }

        public override void VisitStatementWhile(StatementWhile node, CloningAstVisitorContext context)
        {
            context.Result = new StatementWhile()
            {
                Condition = this.CloneNode(node.Condition, context),
                Body = this.CloneNode(node.Body, context)
            };
        }

        public override void VisitStructMemberDeclaration(StructMemberDeclaration node, CloningAstVisitorContext context)
        {
            var result = new StructMemberDeclaration()
            {
                Type = this.CloneNode(node.Type, context),
                ArraySpecifier = this.CloneNode(node.ArraySpecifier, context)
            };
            this.CloneNodeCollection(node.Identifiers, result.Identifiers, context);
            context.Result = result;
        }

        public override void VisitStructTypeSpecifier(StructTypeSpecifier node, CloningAstVisitorContext context)
        {
            var result = new StructTypeSpecifier()
            {
                Identifier = this.CloneNode(node.Identifier, context),
                Qualifier = this.CloneNode(node.Qualifier, context)
            };
            this.CloneNodeCollection(node.Members, result.Members, context);
            context.Result = result;
        }

        public override void VisitTypeNameSpecifier(TypeNameSpecifier node, CloningAstVisitorContext context)
        {
            context.Result = new TypeNameSpecifier()
            {
                Identifier = this.CloneNode(node.Identifier, context),
                Qualifier = this.CloneNode(node.Qualifier, context)
            };
        }

        public override void VisitTypeQualifier(TypeQualifier node, CloningAstVisitorContext context)
        {
            var result = new TypeQualifier()
            {
                Invariant = node.Invariant,
                Interpolation = node.Interpolation,
                Precision = node.Precision,
                Storage = node.Storage
            };
            this.CloneNodeCollection(node.Layout, result.Layout, context);
            context.Result = result;
        }

        public override void VisitVariableDeclaration(VariableDeclaration node, CloningAstVisitorContext context)
        {
            context.Result = new VariableDeclaration()
            {
                ArraySpecifier = this.CloneNode(node.ArraySpecifier, context),
                Initializer = this.CloneNode(node.Initializer, context),
                Name = this.CloneNode(node.Name, context)
            };
        }

        public override void VisitVariableDeclarationList(VariableDeclarationList node, CloningAstVisitorContext context)
        {
            var result = new VariableDeclarationList()
            {
                Type = this.CloneNode(node.Type, context)
            };
            this.CloneNodeCollection(node.Declarations, result.Declarations, context);
            context.Result = result;
        }

        public TNode CloneNode<TNode>(TNode node) where TNode : AstNode
        {
            return this.CloneNode(node, new CloningAstVisitorContext());
        }

        private TNode CloneNode<TNode>(TNode node, CloningAstVisitorContext context) where TNode: AstNode
        {            
            this.Visit(node, context);
            return context.Result != null ? (TNode)context.Result : null;
        }

        private void CloneNodeCollection<TNode>(AstNodeCollection<TNode> source, AstNodeCollection<TNode> target, CloningAstVisitorContext context) where TNode : AstNode
        {
            foreach (var node in source)
            {
                target.Add(this.CloneNode(node, context));
            }
        }
    }
}
