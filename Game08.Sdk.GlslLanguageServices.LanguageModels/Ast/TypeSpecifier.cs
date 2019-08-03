using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class TypeSpecifier : AstNode
    {
        private TypeQualifier qualifier;

        public TypeSpecifier()
        {
            this.Qualifier = new TypeQualifier();
        }

        public TypeQualifier Qualifier
        {

            get => qualifier;

            set
            {
                this.SetParent(this.qualifier, value);
                this.qualifier = value;
            }
        }
    }
}
