using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementFor : Statement
    {
        public Statement Init;

        public Expression Condition;

        public Expression Increment;

        public Statement Body;
    }
}
