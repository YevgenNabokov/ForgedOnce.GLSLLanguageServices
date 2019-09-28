using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionUnaryPostfix : Expression
    {
        public Operator Operator;

        private Expression left;

        public Expression Left
        {

            get => left;

            set
            {
                this.SetAsParentFor(this.left, value);
                this.left = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.left)
            {
                return 0;
            }

            return -1;
        }
    }
}
