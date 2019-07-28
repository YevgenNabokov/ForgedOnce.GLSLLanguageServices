using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionFieldSelection : Expression
    {
        public Identifier Name;

        public Expression Left;
    }
}
