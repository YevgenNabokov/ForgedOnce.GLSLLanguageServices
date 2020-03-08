using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionBinary : Expression
    {
        private Expression left;

        private Operator @operator;

        private Expression right;

        public Expression Left
        {
            get => left;

            set
            {                
                this.SetAsParentFor(this.left, value);
                this.left = value;
            }
        }

        public Expression Right
        {

            get => right;

            set
            {
                this.SetAsParentFor(this.right, value);
                this.right = value;
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

            if (child == this.right)
            {
                return 1;
            }

            return -1;
        }
    }
}
