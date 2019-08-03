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
    }
}
