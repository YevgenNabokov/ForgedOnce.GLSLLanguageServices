using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class VariableDeclarationExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration WithArraySpecifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration WithName(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration WithInitializer(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}