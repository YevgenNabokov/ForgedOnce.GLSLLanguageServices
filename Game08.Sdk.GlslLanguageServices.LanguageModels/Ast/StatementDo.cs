using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementDo : Statement
    {
        private Statement body;

        private Expression condition;

        public Statement Body
        {

            get => body;

            set
            {
                this.SetParent(this.body, value);
                this.body = value;
            }
        }

        public Expression Condition
        {

            get => condition;

            set
            {
                this.SetParent(this.condition, value);
                this.condition = value;
            }
        }
    }
}
