using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class LayoutIdQualifier : AstNode
    {
        private Identifier identifier;

        private IntegerLiteral order;

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetAsParentFor(this.identifier, value);
                this.identifier = value;
            }
        }

        public IntegerLiteral Order
        {

            get => order;

            set
            {
                this.SetAsParentFor(this.order, value);
                this.order = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.identifier)
            {
                return 0;
            }

            if (child == this.order)
            {
                return 1;
            }

            return -1;
        }
    }
}
