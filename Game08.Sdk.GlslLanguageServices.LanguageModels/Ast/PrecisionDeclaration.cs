using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class PrecisionDeclaration : Declaration
    {
        public TypeSpecifier Type;

        public ArraySpecifier ArraySpecifier;

        public PrecisionQualifier PrecisionQualifier;
    }
}
