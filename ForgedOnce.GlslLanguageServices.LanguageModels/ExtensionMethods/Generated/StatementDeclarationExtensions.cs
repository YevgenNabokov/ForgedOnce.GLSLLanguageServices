using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementDeclarationExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementDeclaration WithDeclaration(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementDeclaration subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Declaration declaration)
        {
            subject.Declaration = declaration;
            return subject;
        }
    }
}