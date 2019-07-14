using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class VariableDeclaration : AstNode
    {
        public ArraySpecifier ArraySpecifier;

        public Identifier Name;

        public Expression Initializer;
    }
}
