using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class VariableDeclarationList : Declaration
    {
        private TypeSpecifier type;
        
        public VariableDeclarationList()
        {
            this.Declarations = new AstNodeCollection<VariableDeclaration>(this);
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

        public AstNodeCollection<VariableDeclaration> Declarations { get; private set; }
    }
}
