using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionSequence : Expression
    {
        public List<Expression> Expressions = new List<Expression>();
    }
}
