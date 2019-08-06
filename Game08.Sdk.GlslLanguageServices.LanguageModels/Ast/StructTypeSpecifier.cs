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

            if (child is StructMemberDeclaration && this.Members.Contains((StructMemberDeclaration)child))
            {
                return 1 + this.Members.IndexOf((StructMemberDeclaration)child);
            }

            return -1;
        }
    }
}
