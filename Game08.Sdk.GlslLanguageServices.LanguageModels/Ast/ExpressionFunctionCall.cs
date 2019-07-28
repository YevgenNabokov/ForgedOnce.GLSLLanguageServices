using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionFunctionCall : Expression
    {
        public Expression Left;

        public List<Expression> Parameters = new List<Expression>();

        public Identifier Identifier;
    }
}
