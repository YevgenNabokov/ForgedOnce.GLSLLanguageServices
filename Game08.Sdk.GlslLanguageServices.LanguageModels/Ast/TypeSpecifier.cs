using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class TypeSpecifier : AstNode
    {
        public Identifier Identifier;

        public bool IsArray;

        public Expression ArraySizeExpression;        
    }
}
