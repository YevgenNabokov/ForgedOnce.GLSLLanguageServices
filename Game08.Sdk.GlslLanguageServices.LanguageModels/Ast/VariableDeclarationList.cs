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

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == type)
            {
                return 0;
            }

            if (child is VariableDeclaration && this.Declarations.Contains((VariableDeclaration)child))
            {
                return 1 + this.Declarations.IndexOf((VariableDeclaration)child);
            }

            return -1;
        }
    }
}
