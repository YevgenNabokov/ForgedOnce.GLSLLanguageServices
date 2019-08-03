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
    }
}
