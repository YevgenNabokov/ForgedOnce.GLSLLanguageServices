using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionIndexAccess : Expression
    {
        private Expression left;

        private Expression index;

        public Expression Left
        {

            get => left;

            set
            {
                this.SetParent(this.left, value);
                this.left = value;
            }
        }

        public Expression Index
        {

            get => index;

            set
            {
                this.SetParent(this.index, value);
                this.index = value;
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

            if (child == this.Index)
            {
                return 1;
            }

            return -1;
        }
    }
}
