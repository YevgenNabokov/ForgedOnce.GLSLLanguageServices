using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class TypeSpecifier : AstNode
    {
        private TypeQualifier qualifier;

        public TypeSpecifier()
        {
            this.Qualifier = new TypeQualifier();
        }

        public abstract string GetPrintableName();

        public TypeQualifier Qualifier
        {

            get => qualifier;

            set
            {
                this.SetAsParentFor(this.qualifier, value);
                this.qualifier = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.qualifier)
            {
                return 0;
            }

            return -1;
        }
    }
}
