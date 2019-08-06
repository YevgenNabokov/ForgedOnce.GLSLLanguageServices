using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementExpression : Statement
    {
        private Expression expression;

        public Expression Expression
        {

            get => expression;

            set
            {
                this.SetParent(this.expression, value);
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
