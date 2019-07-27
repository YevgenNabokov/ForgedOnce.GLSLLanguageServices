using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementWhile : Statement
    {
        public Expression Condition;

        public Statement Body;
    }
}
