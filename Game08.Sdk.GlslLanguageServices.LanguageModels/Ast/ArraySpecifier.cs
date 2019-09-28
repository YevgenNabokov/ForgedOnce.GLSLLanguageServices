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
                this.SetAsParentFor(this.arraySizeExpression, value);
                this.arraySizeExpression = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null || child != this.arraySizeExpression)
            {
                return -1;
            }

            return 0;
        }
    }
}
