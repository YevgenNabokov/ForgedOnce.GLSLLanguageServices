using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionSequence : Expression
    {
        public ExpressionSequence()
        {
            this.Expressions = new AstNodeCollection<Expression>(this);
        }

        public AstNodeCollection<Expression> Expressions { get; private set; }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child is Expression && this.Expressions.Contains((Expression)child))
            {
                return this.Expressions.IndexOf((Expression)child);
            }

            return -1;
        }
    }
}
