using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ArraySpecifier : AstNode
    {
        private Expression arraySizeExpression;

        public Expression ArraySizeExpression
        {
            get => arraySizeExpression;

            set
            {
                this.SetParent(this.arraySizeExpression, value);
                this.arraySizeExpression = value;
            }
        }
    }
}
