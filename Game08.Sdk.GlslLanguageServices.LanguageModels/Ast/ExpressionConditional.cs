using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionConditional : Expression
    {
        public Expression Condition;

        public Expression Then;

        public Expression Else;
    }
}
