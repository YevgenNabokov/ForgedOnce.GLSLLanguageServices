using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementSwitch : Statement
    {
        private Expression expression;

        public StatementSwitch()
        {
            this.Statements = new AstNodeCollection<Statement>(this);
        }

        public Expression Expression
        {

            get => expression;

            set
            {
                this.SetParent(this.expression, value);
                this.expression = value;
            }
        }

        public AstNodeCollection<Statement> Statements { get; private set; }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.expression)
            {
                return 0;
            }

            if (child is Statement && this.Statements.Contains((Statement)child))
            {
                return 1 + this.Statements.IndexOf((Statement)child);
            }

            return -1;
        }
    }
}
