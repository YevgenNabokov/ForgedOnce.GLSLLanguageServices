using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionParenGroup : Expression
    {
        private Expression content;

        public Expression Content
        {

            get => content;

            set
            {
                this.SetParent(this.content, value);
                this.content = value;
            }
        }
    }
}
