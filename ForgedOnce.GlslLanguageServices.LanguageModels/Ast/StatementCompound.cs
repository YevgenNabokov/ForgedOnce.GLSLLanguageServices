using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementCompound : Statement
    {        
        public StatementCompound()
        {
            this.Statements = new AstNodeCollection<Statement>(this);
        }

        public AstNodeCollection<Statement> Statements { get; private set; }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child is Statement && this.Statements.Contains((Statement)child))
            {
                return this.Statements.IndexOf((Statement)child);
            }

            return -1;
        }
    }
}
