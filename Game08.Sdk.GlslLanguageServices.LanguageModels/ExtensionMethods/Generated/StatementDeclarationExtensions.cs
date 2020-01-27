using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementDeclarationExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementDeclaration WithDeclaration(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementDeclaration subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Declaration declaration)
        {
            subject.Declaration = declaration;
            return subject;
        }
    }
}