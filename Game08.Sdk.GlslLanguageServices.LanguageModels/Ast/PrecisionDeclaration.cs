using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class PrecisionDeclaration : Declaration
    {
        private TypeSpecifier type;

        private ArraySpecifier arraySpecifier;

        public PrecisionQualifier PrecisionQualifier;

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

            return -1;
        }
    }
}
