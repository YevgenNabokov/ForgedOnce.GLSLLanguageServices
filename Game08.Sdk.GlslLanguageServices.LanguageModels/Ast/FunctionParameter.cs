using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class FunctionParameter : AstNode
    {
        public bool IsConst;

        public ParameterQualifier? ParameterQualifier;

        private TypeSpecifier typeSpecifier;

        private ArraySpecifier arraySpecifier;

        private Identifier name;

        public TypeSpecifier TypeSpecifier
        {

            get => typeSpecifier;

            set
            {
                this.SetParent(this.typeSpecifier, value);
                this.typeSpecifier = value;
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

        public Identifier Name
        {

            get => name;

            set
            {
                this.SetParent(this.name, value);
                this.name = value;
            }
        }
    }
}
