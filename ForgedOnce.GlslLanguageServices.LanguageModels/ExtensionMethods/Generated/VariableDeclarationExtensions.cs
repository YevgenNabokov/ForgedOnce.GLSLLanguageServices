using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class VariableDeclarationExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration WithArraySpecifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration WithName(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration subject, string name)
        {
            subject.Name = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration WithInitializer(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}