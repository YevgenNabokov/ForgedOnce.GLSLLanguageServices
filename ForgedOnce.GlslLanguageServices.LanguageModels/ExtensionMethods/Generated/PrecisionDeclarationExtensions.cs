using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class PrecisionDeclarationExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration WithType(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier type)
        {
            subject.Type = type;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration WithArraySpecifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration WithPrecisionQualifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionDeclaration subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionQualifier precisionQualifier)
        {
            subject.PrecisionQualifier = precisionQualifier;
            return subject;
        }
    }
}