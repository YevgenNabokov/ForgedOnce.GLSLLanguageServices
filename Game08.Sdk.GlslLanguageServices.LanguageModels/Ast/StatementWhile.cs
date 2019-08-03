using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementWhile : Statement
    {
        private Expression condition;

        private Statement body;

        public Expression Condition
        {

            get => condition;

            set
            {
                this.SetParent(this.condition, value);
                this.condition = value;
            }
        }

        public Statement Body
        {

            get => body;

            set
            {
                this.SetParent(this.body, value);
                this.body = value;
            }
        }
    }
}
