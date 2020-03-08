using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class VariableDeclarationListExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList WithType(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier type)
        {
            subject.Type = type;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList WithDeclaration(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclarationList subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration> declarationBuilder)
        {
            subject.Declarations.Add(declarationBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.VariableDeclaration()));
            return subject;
        }
    }
}