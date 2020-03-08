using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class TypeNameSpecifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier WithIdentifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier subject, string name)
        {
            subject.Identifier = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier WithQualifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier> qualifierBuilder)
        {
            subject.Qualifier = qualifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier());
            return subject;
        }
    }
}