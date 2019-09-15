using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Printer
{
    public class AstPrinterVisitor : AstVisitor<AstPrinterContext>
    {
        private readonly Dictionary<StorageQualifier, string> storageQualifierExplicitStringValues = new Dictionary<StorageQualifier, string>()
        {
            { StorageQualifier.CentroidIn, "centroid in" },
            { StorageQualifier.CentroidOut, "centroid out" }
        };

        private readonly Dictionary<Operator, string> operatorStringValues = new Dictionary<Operator, string>()
        {
            { Operator.AddAssign, "+=" },
            { Operator.Ampersand, "&" },
            { Operator.And, "&&" },
            { Operator.AndAssign, "&=" },
            { Operator.Assign, "=" },
            { Operator.Bang, "!" },
            { Operator.Caret, "^" },
            { Operator.Decrement, "--" },
            { Operator.Div, "/" },
            { Operator.DivAssign, "/=" },
            { Operator.Equal, "==" },
            { Operator.Greater, ">" },
            { Operator.GreaterOrEqual, ">=" },
            { Operator.Increment, "++" },
            { Operator.Left, "<<" },
            { Operator.LeftAssign, "<<=" },
            { Operator.Less, "<" },
            { Operator.LessOrEqual, "<=" },
            { Operator.Minus, "-" },
            { Operator.ModAssign, "%=" },
            { Operator.Mul, "*" },
            { Operator.MulAssign, "*=" },
            { Operator.NotEqual, "!=" },
            { Operator.Or, "||" },
            { Operator.OrAssign, "|=" },
            { Operator.Percent, "%" },
            { Operator.Pipe, "|" },
            { Operator.Plus, "+" },
            { Operator.Right, ">>" },
            { Operator.RightAssign, ">>=" },
            { Operator.SubAssign, "-=" },
            { Operator.Tilde, "~" },
            { Operator.Xor, "^^" },
            { Operator.XorAssign, "^=" }
        };

        public string Print(AstNode startNode)
        {
            var context = new AstPrinterContext()
            {                
            };

            this.Visit(startNode, context);

            return context.Output.ToString();
        }

        public override void VisitVariableDeclarationList(VariableDeclarationList node, AstPrinterContext context)
        {
            context.StartNewLine();
            this.Visit(node.Type, context);
            context.Write(" ");
            var i = 0;
            foreach (var n in node.Declarations)
            {
                this.Visit(n, context);
                i++;
                if (i < node.Declarations.Count)
                {
                    context.Write(", ");
                }
            }

            context.Write(";");
        }

        public override void VisitStructTypeSpecifier(StructTypeSpecifier node, AstPrinterContext context)
        {
            context.Write("struct");
            if (node.Qualifier != null)
            {
                context.Write(" ");
                this.Visit(node.Qualifier, context);
            }

            if (node.Qualifier != null)
            {
                context.Write(" ");
                this.Visit(node.Identifier, context);
            }

            context.StartNewLine();
            context.Write("{");
            this.WithIndent(context, () =>
            {
                foreach (var n in node.Members)
                {
                    this.Visit(n, context);
                }
            });

            context.StartNewLine();
            context.Write("}");
        }

        public override void VisitStructMemberDeclaration(StructMemberDeclaration node, AstPrinterContext context)
        {
            context.StartNewLine();
            this.Visit(node.Type, context);
            this.Visit(node.ArraySpecifier, context);
            context.Write(" ");
            var i = 0;
            foreach (var n in node.Identifiers)
            {
                this.Visit(n, context);
                i++;
                if (i < node.Identifiers.Count)
                {
                    context.Write(", ");
                }
            }

            context.Write(";");
        }

        public override void VisitTypeNameSpecifier(TypeNameSpecifier node, AstPrinterContext context)
        {
            if (node.Qualifier != null)
            {
                this.Visit(node.Qualifier, context);
                context.Write(" ");
            }

            this.Visit(node.Identifier, context);
        }

        public override void VisitTypeQualifier(TypeQualifier node, AstPrinterContext context)
        {
            bool printed = false;
            if (node.Invariant)
            {                
                context.Write("invariant");
                printed = true;
            }

            if (node.Interpolation != null)
            {
                if (printed)
                {
                    context.Write(" ");
                }

                context.Write(node.Interpolation.ToString().ToLower());
                printed = true;
            }

            if (node.Layout != null && node.Layout.Count > 0)
            {
                if (printed)
                {
                    context.Write(" ");
                }

                context.Write("layout(");
                foreach (var n in node.Layout)
                {
                    this.Visit(n, context);
                }
                context.Write(")");
                printed = true;
            }

            if (node.Storage != null)
            {
                if (printed)
                {
                    context.Write(" ");
                }

                if (storageQualifierExplicitStringValues.ContainsKey(node.Storage.Value))
                {
                    context.Write(storageQualifierExplicitStringValues[node.Storage.Value]);
                }
                else
                {
                    context.Write(node.Storage.ToString().ToLower());
                }

                printed = true;
            }

            if (node.Precision != null)
            {
                if (printed)
                {
                    context.Write(" ");
                }

                context.Write(node.Precision.ToString().ToLower());
            }
        }

        public override void VisitLayoutIdQualifier(LayoutIdQualifier node, AstPrinterContext context)
        {
            this.Visit(node.Identifier, context);
            if (node.Order != null)
            {
                context.Write(" = ");
                this.Visit(node.Order, context);
            }
        }

        public override void VisitVariableDeclaration(VariableDeclaration node, AstPrinterContext context)
        {
            this.Visit(node.Name, context);
            this.Visit(node.ArraySpecifier, context);
            if (node.Initializer != null)
            {
                context.Write(" = ");
            }

            this.Visit(node.Initializer, context);
        }

        public override void VisitArraySpecifier(ArraySpecifier node, AstPrinterContext context)
        {
            context.Write("[");
            this.Visit(node.ArraySizeExpression, context);
            context.Write("]");
        }

        public override void VisitIdentifier(Identifier node, AstPrinterContext context)
        {
            context.Write(node.Name);
        }

        public override void VisitStatementWhile(StatementWhile node, AstPrinterContext context)
        {
            context.StartNewLine();
            context.Write("while (");
            this.Visit(node.Condition, context);
            context.Write(")");
            context.StartNewLine();
            this.Visit(node.Body, context);
        }

        public override void VisitStatementSwitch(StatementSwitch node, AstPrinterContext context)
        {
            context.StartNewLine();
            context.Write("switch (");
            this.Visit(node.Expression, context);
            context.Write(")");
            context.StartNewLine();
            context.Write("{");
            this.WithIndent(context, () =>
            {
                foreach (var n in node.Statements)
                {
                    this.Visit(n, context);
                }
            });
            context.StartNewLine();
            context.Write("}");
        }

        public override void VisitStatementReturn(StatementReturn node, AstPrinterContext context)
        {
            context.Write("return ");
            this.Visit(node.Expression, context);
            context.Write(";");
        }

        public override void VisitStatementIf(StatementIf node, AstPrinterContext context)
        {
            context.Write("if (");
            this.Visit(node.Condition, context);
            context.Write(")");
            context.StartNewLine();
            this.Visit(node.Then, context);
            if (node.Else != null)
            {
                context.StartNewLine();
                context.Write("else");
                context.StartNewLine();
                this.Visit(node.Else, context);
            }
        }

        public override void VisitStatementFor(StatementFor node, AstPrinterContext context)
        {
            context.Write("for (");
            this.Visit(node.Init, context);
            context.Write("; ");
            this.Visit(node.Condition, context);
            context.Write("; ");
            this.Visit(node.Increment, context);
            context.Write(")");
            context.StartNewLine();
            this.Visit(node.Body, context);
        }

        public override void VisitStatementExpression(StatementExpression node, AstPrinterContext context)
        {
            this.Visit(node.Expression, context);
            context.Write(";");
        }

        public override void VisitStatementDo(StatementDo node, AstPrinterContext context)
        {
            context.Write("do");
            context.StartNewLine();
            this.Visit(node.Body, context);
            context.StartNewLine();
            context.Write("while (");
            this.Visit(node.Condition, context);
            context.Write(");");
        }

        public override void VisitStatementDiscard(StatementDiscard node, AstPrinterContext context)
        {
            context.Write("discard;");
        }

        public override void VisitStatementDefault(StatementDefault node, AstPrinterContext context)
        {
            context.StartNewLine();
            context.Write("default: ");
        }

        public override void VisitStatementDeclaration(StatementDeclaration node, AstPrinterContext context)
        {
            this.Visit(node.Declaration, context);
        }

        public override void VisitStatementContinue(StatementContinue node, AstPrinterContext context)
        {
            context.Write("continue;");
        }

        public override void VisitStatementCompound(StatementCompound node, AstPrinterContext context)
        {
            context.Write("{");
            this.WithIndent(context, () =>
            {
                foreach (var n in node.Statements)
                {
                    context.StartNewLine();
                    this.Visit(n, context);
                }
            });

            context.StartNewLine();
            context.Write("}");
        }

        public override void VisitStatementCase(StatementCase node, AstPrinterContext context)
        {
            context.StartNewLine();
            context.Write("case ");
            this.Visit(node.Expression, context);
            context.Write(": ");
        }

        public override void VisitStatementBreak(StatementBreak node, AstPrinterContext context)
        {
            context.Write("break;");
        }

        public override void VisitPrecisionDeclaration(PrecisionDeclaration node, AstPrinterContext context)
        {
            context.Write("precision ");
            context.Write(node.PrecisionQualifier.ToString().ToLower());
            this.Visit(node.Type, context);
            this.Visit(node.ArraySpecifier, context);
            context.Write(";");
        }

        public override void VisitIntegerLiteral(IntegerLiteral node, AstPrinterContext context)
        {
            context.Write(node.LiteralValue);
        }

        public override void VisitFunctionDeclaration(FunctionDeclaration node, AstPrinterContext context)
        {
            if (node.TypeSpecifier != null)
            {
                this.Visit(node.TypeSpecifier, context);
                context.Write(" ");
            }

            this.Visit(node.Name, context);
            context.Write("(");
            var i = 0;
            foreach (var p in node.Parameters)
            {
                this.Visit(p, context);
                i++;
                if (i < node.Parameters.Count)
                {
                    context.Write(", ");
                }
            }

            context.Write(")");
            context.StartNewLine();
            this.Visit(node.Statement, context);
        }

        public override void VisitFunctionParameter(FunctionParameter node, AstPrinterContext context)
        {
            if (node.TypeSpecifier != null)
            {
                this.Visit(node.TypeSpecifier, context);
                context.Write(" ");
            }

            this.Visit(node.Name, context);
            this.Visit(node.ArraySpecifier, context);
        }

        public override void VisitFloatLiteral(FloatLiteral node, AstPrinterContext context)
        {
            context.Write(node.LiteralValue);
        }

        public override void VisitExpressionVariableIdentifier(ExpressionVariableIdentifier node, AstPrinterContext context)
        {
            base.VisitExpressionVariableIdentifier(node, context);
        }

        public override void VisitExpressionUnaryPostfix(ExpressionUnaryPostfix node, AstPrinterContext context)
        {
            this.Visit(node.Left, context);
            context.Write(this.GetOperatorString(node.Operator));
        }

        public override void VisitExpressionUnary(ExpressionUnary node, AstPrinterContext context)
        {
            context.Write(this.GetOperatorString(node.Operator));
            this.Visit(node.Right, context);
        }

        public override void VisitExpressionSequence(ExpressionSequence node, AstPrinterContext context)
        {
            var i = 0;
            foreach (var n in node.Expressions)
            {
                this.Visit(n, context);
                i++;
                if (i < node.Expressions.Count)
                {
                    context.Write(", ");
                }
            }
        }

        public override void VisitExpressionParenGroup(ExpressionParenGroup node, AstPrinterContext context)
        {
            context.Write("(");
            this.Visit(node.Content, context);
            context.Write(")");
        }

        public override void VisitExpressionIndexAccess(ExpressionIndexAccess node, AstPrinterContext context)
        {
            this.Visit(node.Left, context);
            context.Write("[");
            this.Visit(node.Index, context);
            context.Write("]");
        }

        public override void VisitExpressionFunctionCall(ExpressionFunctionCall node, AstPrinterContext context)
        {
            if (node.Left != null)
            {
                this.Visit(node.Left, context);
                context.Write(".");
            }
            
            this.Visit(node.Identifier, context);
            context.Write("(");
            var i = 0;
            foreach (var p in node.Parameters)
            {
                this.Visit(p, context);
                i++;
                if (i < node.Parameters.Count)
                {
                    context.Write(", ");
                }
            }

            context.Write(")");
        }

        public override void VisitExpressionFieldSelection(ExpressionFieldSelection node, AstPrinterContext context)
        {
            this.Visit(node.Left, context);
            context.Write(".");
            this.Visit(node.Name, context);
        }

        public override void VisitExpressionConditional(ExpressionConditional node, AstPrinterContext context)
        {
            this.Visit(node.Condition, context);
            if (node.Then != null || node.Else != null)
            {
                context.Write(" ? ");
                this.Visit(node.Then, context);
                context.Write(" : ");
                this.Visit(node.Else, context);
            }
        }

        public override void VisitExpressionBinary(ExpressionBinary node, AstPrinterContext context)
        {
            this.Visit(node.Left, context);
            context.Write(" ");
            context.Write(this.GetOperatorString(node.Operator));
            context.Write(" ");
            this.Visit(node.Right, context);
        }

        public override void VisitBooleanLiteral(BooleanLiteral node, AstPrinterContext context)
        {
            context.Write(node.LiteralValue);
        }

        public override void VisitRoot(Root node, AstPrinterContext context)
        {
            var i = 0;
            foreach (var n in node.Declarations)
            {
                this.Visit(n, context);
                i++;
                if (i < node.Declarations.Count)
                {
                    context.StartNewLine();
                    context.StartNewLine();
                }
            }
        }

        private void WithIndent(AstPrinterContext context, Action action)
        {
            context.IncreaseNextLineIndent();
            action();
            context.DecreaseNextLineIndent();
        }

        private string GetOperatorString(Operator op)
        {
            if (this.operatorStringValues.ContainsKey(op))
            {
                return this.operatorStringValues[op];
            }

            throw new InvalidOperationException($"No string value found for operator {op}.");
        }
    }
}
