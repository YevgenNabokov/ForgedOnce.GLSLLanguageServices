using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementIf : Statement
    {
        private Expression condition;

        private Statement then;

        private Statement elseField;

        public Expression Condition
        {

            get => condition;

            set
            {
                this.SetParent(this.condition, value);
                this.condition = value;
            }
        }

        public Statement Then
        {

            get => then;

            set
            {
                this.SetParent(this.then, value);
                this.then = value;
            }
        }

        public Statement Else
        {

            get => elseField;

            set
            {
                this.SetParent(this.elseField, value);
                this.elseField = value;
            }
        }
    }
}
