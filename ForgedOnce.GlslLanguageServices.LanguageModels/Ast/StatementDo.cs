using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
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
                this.SetAsParentFor(this.body, value);
                this.body = value;
            }
        }

        public Expression Condition
        {

            get => condition;

            set
            {
                this.SetAsParentFor(this.condition, value);
                this.condition = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.body)
            {
                return 0;
            }

            if (child == this.condition)
            {
                return 1;
            }

            return -1;
        }
    }
}
