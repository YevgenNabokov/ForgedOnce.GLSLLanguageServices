using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementSwitch : Statement
    {
        public Expression Expression;

        public List<Statement> Statements;
    }
}
