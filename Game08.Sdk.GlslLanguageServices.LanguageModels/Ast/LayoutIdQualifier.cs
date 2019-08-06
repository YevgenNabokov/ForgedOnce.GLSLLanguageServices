using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
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
                this.SetParent(this.identifier, value);
                this.identifier = value;
            }
        }

        public IntegerLiteral Order
        {

            get => order;

            set
            {
                this.SetParent(this.order, value);
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
