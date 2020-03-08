using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class TypeSpecifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier WithQualifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier> qualifierBuilder)
        {
            subject.Qualifier = qualifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier());
            return subject;
        }
    }
}