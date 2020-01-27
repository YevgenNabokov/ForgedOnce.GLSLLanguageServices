using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class TypeSpecifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier WithQualifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier> qualifierBuilder)
        {
            subject.Qualifier = qualifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier());
            return subject;
        }
    }
}