using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class FunctionDeclaration : Declaration
    {
        public TypeSpecifier TypeSpecifier;

        public Identifier Name;

        public List<FunctionParameter> Parameters = new List<FunctionParameter>();

        public StatementCompound Statement;
    }
}
