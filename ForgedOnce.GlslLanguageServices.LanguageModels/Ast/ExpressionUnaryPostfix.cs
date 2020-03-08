using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionUnaryPostfix : Expression
    {
        private Operator @operator;

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

        public Operator Operator { get => @operator; set { this.EnsureIsEditable(); @operator = value; } }

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
