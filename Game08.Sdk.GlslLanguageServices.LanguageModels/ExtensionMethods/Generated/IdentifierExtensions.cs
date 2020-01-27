using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class IdentifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier WithName(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier subject, string name)
        {
            subject.Name = name;
            return subject;
        }
    }
}