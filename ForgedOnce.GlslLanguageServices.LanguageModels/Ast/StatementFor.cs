using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
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
                this.SetAsParentFor(this.init, value);
                this.init = value;
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

        public Expression Increment
        {

            get => increment;

            set
            {
                this.SetAsParentFor(this.increment, value);
                this.increment = value;
            }
        }

        public Statement Body
        {

            get => body;

            set
            {
                this.SetAsParentFor(this.body, value);
                this.body = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.init)
            {
                return 0;
            }

            if (child == this.condition)
            {
                return 1;
            }

            if (child == this.increment)
            {
                return 2;
            }

            if (child == this.body)
            {
                return 3;
            }

            return -1;
        }
    }
}
