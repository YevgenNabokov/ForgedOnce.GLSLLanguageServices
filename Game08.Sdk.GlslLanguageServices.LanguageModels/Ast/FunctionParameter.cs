using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class FunctionParameter : AstNode
    {
        public bool IsConst;

        public ParameterQualifier? ParameterQualifier;

        public TypeSpecifier TypeSpecifier;

        public ArraySpecifier ArraySpecifier;

        public Identifier Name;
    }
}
