using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionFieldSelection : Expression
    {
        private Identifier name;

        private Expression left;

        public Identifier Name
        {

            get => name;

            set
            {
                this.SetParent(this.name, value);
                this.name = value;
            }
        }

        public Expression Left
        {

            get => left;

            set
            {
                this.SetParent(this.left, value);
                this.left = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.left)
            {
                return 0;
            }

            if (child == this.name)
            {
                return 1;
            }

            return -1;
        }
    }
}
