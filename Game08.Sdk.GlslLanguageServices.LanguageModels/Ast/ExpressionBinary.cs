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
    }
}
