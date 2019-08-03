using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionConditional : Expression
    {
        private Expression condition;

        private Expression then;

        private Expression elseField;

        public Expression Condition
        {

            get => condition;

            set
            {
                this.SetParent(this.condition, value);
                this.condition = value;
            }
        }

        public Expression Then
        {

            get => then;

            set
            {
                this.SetParent(this.then, value);
                this.then = value;
            }
        }

        public Expression Else
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
