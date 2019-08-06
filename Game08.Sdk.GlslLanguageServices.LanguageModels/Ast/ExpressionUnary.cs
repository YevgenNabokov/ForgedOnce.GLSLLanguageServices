using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionUnary : Expression
    {
        public Operator Operator;

        private Expression right;

        public Expression Right
        {

            get => right;

            set
            {
                this.SetParent(this.right, value);
                this.right = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.right)
            {
                return 0;
            }

            return -1;
        }
    }
}
