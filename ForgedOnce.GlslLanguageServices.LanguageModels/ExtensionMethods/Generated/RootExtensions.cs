using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class RootExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Root WithDeclaration(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Root subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Declaration declaration)
        {
            subject.Declarations.Add(declaration);
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Root WithVersion(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Root subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ShaderVersion version)
        {
            subject.Version = version;
            return subject;
        }
    }
}