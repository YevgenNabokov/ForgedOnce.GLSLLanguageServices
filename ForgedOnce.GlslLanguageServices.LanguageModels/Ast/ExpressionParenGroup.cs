using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionParenGroup : Expression
    {
        private Expression content;

        public Expression Content
        {

            get => content;

            set
            {
                this.SetAsParentFor(this.content, value);
                this.content = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.content)
            {
                return 0;
            }

            return -1;
        }
    }
}
