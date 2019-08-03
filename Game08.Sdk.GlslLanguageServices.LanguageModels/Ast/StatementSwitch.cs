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
    }
}
