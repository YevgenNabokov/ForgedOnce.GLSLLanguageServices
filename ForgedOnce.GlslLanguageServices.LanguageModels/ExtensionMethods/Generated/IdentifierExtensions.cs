using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class IdentifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier WithName(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier subject, string name)
        {
            subject.Name = name;
            return subject;
        }
    }
}