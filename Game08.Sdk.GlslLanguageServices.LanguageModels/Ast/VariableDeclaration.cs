using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class VariableDeclaration : AstNode
    {
        private ArraySpecifier arraySpecifier;

        private Identifier name;

        private Expression initializer;

        public ArraySpecifier ArraySpecifier
        {

            get => arraySpecifier;

            set
            {
                this.SetParent(this.arraySpecifier, value);
                this.arraySpecifier = value;
            }
        }

        public Identifier Name
        {

            get => name;

            set
            {
                this.SetParent(this.name, value);
                this.name = value;
            }
        }

        public Expression Initializer
        {

            get => initializer;

            set
            {
                this.SetParent(this.initializer, value);
                this.initializer = value;
            }
        }
    }
}
