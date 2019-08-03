using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementCase : Statement
    {
        private Expression expression;

        public Expression Expression
        {

            get => expression;

            set
            {
                this.SetParent(this.expression, value);
                this.expression = value;
            }
        }
    }
}
