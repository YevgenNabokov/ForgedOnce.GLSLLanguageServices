using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class PrecisionDeclarationExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration WithType(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier type)
        {
            subject.Type = type;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration WithArraySpecifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration WithPrecisionQualifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionQualifier precisionQualifier)
        {
            subject.PrecisionQualifier = precisionQualifier;
            return subject;
        }
    }
}