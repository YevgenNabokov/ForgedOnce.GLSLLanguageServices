using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class VariableDeclarationListExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList WithType(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier type)
        {
            subject.Type = type;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList WithDeclaration(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration> declarationBuilder)
        {
            subject.Declarations.Add(declarationBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration()));
            return subject;
        }
    }
}