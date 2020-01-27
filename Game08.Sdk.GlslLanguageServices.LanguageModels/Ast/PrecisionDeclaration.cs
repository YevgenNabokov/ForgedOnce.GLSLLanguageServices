using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class PrecisionDeclaration : Declaration
    {
        private TypeSpecifier type;

        private ArraySpecifier arraySpecifier;

        private PrecisionQualifier precisionQualifier;

        public TypeSpecifier Type
        {

            get => type;

            set
            {
                this.SetAsParentFor(this.type, value);
                this.type = value;
            }
        }

        public ArraySpecifier ArraySpecifier
        {

            get => arraySpecifier;

            set
            {
                this.SetAsParentFor(this.arraySpecifier, value);
                this.arraySpecifier = value;
            }
        }

        public PrecisionQualifier PrecisionQualifier { get => precisionQualifier; set { this.EnsureIsEditable(); precisionQualifier = value; } }

        public override string GetPrintableName()
        {
            var typeName = this.Type != null ? this.Type.GetPrintableName() : PrintableUnknownName;
            return $"Precision:{typeName}";
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
