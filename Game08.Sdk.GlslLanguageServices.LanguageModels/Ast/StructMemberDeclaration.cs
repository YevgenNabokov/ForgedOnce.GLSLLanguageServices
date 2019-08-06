using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StructMemberDeclaration : AstNode
    {
        private TypeSpecifier type;

        private ArraySpecifier arraySpecifier;

        public StructMemberDeclaration()
        {
            this.Identifiers = new AstNodeCollection<Identifier>(this);
        }

        public TypeSpecifier Type
        {

            get => type;

            set
            {
                this.SetParent(this.type, value);
                this.type = value;
            }
        }

        public ArraySpecifier ArraySpecifier
        {

            get => arraySpecifier;

            set
            {
                this.SetParent(this.arraySpecifier, value);
                this.arraySpecifier = value;
            }
        }

        public AstNodeCollection<Identifier> Identifiers { get; private set; }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.type)
            {
                return 0;
            }

            if (child == this.arraySpecifier)
            {
                return 1;
            }

            if (child is Identifier && this.Identifiers.Contains((Identifier)child))
            {
                return 2 + this.Identifiers.IndexOf((Identifier)child);
            }

            return -1;
        }
    }
}
