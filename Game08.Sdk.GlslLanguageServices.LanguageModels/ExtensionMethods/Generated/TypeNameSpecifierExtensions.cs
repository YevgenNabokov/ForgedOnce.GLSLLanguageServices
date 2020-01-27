using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class TypeNameSpecifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier WithIdentifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier subject, string name)
        {
            subject.Identifier = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier WithQualifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeNameSpecifier subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier> qualifierBuilder)
        {
            subject.Qualifier = qualifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier());
            return subject;
        }
    }
}