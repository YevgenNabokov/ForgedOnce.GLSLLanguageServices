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
                this.SetAsParentFor(this.condition, value);
                this.condition = value;
            }
        }

        public Statement Then
        {

            get => then;

            set
            {
                this.SetAsParentFor(this.then, value);
                this.then = value;
            }
        }

        public Statement Else
        {

            get => elseField;

            set
            {
                this.SetAsParentFor(this.elseField, value);
                this.elseField = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.condition)
            {
                return 0;
            }

            if (child == this.then)
            {
                return 1;
            }

            if (child == this.elseField)
            {
                return 2;
            }

            return -1;
        }
    }
}
