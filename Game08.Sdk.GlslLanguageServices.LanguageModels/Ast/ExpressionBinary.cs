using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionBinary : Expression
    {
        private Expression left;

        public Operator Operator;

        private Expression right;

        public Expression Left
        {
            get => left;

            set
            {                
                this.SetParent(this.left, value);
                this.left = value;
            }
        }

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
