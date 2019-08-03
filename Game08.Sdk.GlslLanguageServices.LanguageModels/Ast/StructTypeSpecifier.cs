using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StructTypeSpecifier : TypeSpecifier
    {
        private Identifier identifier;
        
        public StructTypeSpecifier()
        {
            this.Members = new AstNodeCollection<StructMemberDeclaration>(this);
        }

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetParent(this.identifier, value);
                this.identifier = value;
            }
        }

        public AstNodeCollection<StructMemberDeclaration> Members { get; private set; }
    }
}
