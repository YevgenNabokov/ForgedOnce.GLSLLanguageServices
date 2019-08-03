using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementCompound : Statement
    {        
        public StatementCompound()
        {
            this.Statements = new AstNodeCollection<Statement>(this);
        }

        public AstNodeCollection<Statement> Statements { get; private set; }
    }
}
