using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Parser.Helpers
{
    internal class VarDeclaratorRoot : VarDeclarator
    {
        public TypeSpecifier Type;
    }
}
