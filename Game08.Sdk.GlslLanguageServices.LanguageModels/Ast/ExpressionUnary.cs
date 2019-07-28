using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionUnary : Expression
    {
        public Operator Operator;

        public Expression Right;
    }
}
