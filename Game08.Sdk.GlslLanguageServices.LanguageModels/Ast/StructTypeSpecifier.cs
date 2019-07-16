using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StructTypeSpecifier : TypeSpecifier
    {
        public Identifier Identifier;

        public List<StructMemberDeclaration> Members = new List<StructMemberDeclaration>();
    }
}
