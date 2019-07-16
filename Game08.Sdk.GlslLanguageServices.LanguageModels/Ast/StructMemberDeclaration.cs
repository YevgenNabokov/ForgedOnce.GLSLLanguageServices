using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StructMemberDeclaration : AstNode
    {
        public TypeSpecifier Type;

        public ArraySpecifier ArraySpecifier;

        public List<Identifier> Identifiers = new List<Identifier>();
    }
}
