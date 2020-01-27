using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class RootExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Root WithDeclaration(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Root subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Declaration declaration)
        {
            subject.Declarations.Add(declaration);
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Root WithVersion(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Root subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ShaderVersion version)
        {
            subject.Version = version;
            return subject;
        }
    }
}