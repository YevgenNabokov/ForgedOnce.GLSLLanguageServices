using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class VariableDeclarationList : Declaration
    {
        public TypeSpecifier Type;

        public List<VariableDeclaration> Declarations = new List<VariableDeclaration>();
    }
}
