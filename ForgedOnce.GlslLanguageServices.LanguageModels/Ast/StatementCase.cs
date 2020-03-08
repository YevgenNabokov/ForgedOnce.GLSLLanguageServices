using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementCase : Statement
    {
        private Expression expression;

        public Expression Expression
        {

            get => expression;

            set
            {
                this.SetAsParentFor(this.expression, value);
                this.expression = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.expression)
            {
                return 0;
            }

            return -1;
        }
    }
}
