using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class TypeNameSpecifier : TypeSpecifier
    {
        private Identifier identifier;

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetParent(this.identifier, value);
                this.identifier = value;
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

            return -1;
        }
    }
}
