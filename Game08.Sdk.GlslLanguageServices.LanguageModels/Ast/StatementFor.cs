using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementFor : Statement
    {
        private Statement init;

        private Expression condition;

        private Expression increment;

        private Statement body;

        public Statement Init
        {

            get => init;

            set
            {
                this.SetParent(this.init, value);
                this.init = value;
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

        public Expression Increment
        {

            get => increment;

            set
            {
                this.SetParent(this.increment, value);
                this.increment = value;
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
