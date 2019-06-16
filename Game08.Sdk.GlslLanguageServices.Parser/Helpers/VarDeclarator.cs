using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Parser.Helpers
{
    internal class VarDeclarator : Declaration
    {
        public Identifier Name;

        public bool IsArray;

        public Expression ArraySizeExpression;

        public Expression Initializer;

        public VarDeclarator Next;
    }
}
