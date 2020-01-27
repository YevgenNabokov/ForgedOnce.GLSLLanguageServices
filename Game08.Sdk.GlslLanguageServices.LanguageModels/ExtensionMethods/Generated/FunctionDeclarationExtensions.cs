using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class FunctionDeclarationExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithTypeSpecifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier typeSpecifier)
        {
            subject.TypeSpecifier = typeSpecifier;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithName(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithStatement(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCompound, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCompound> statementBuilder)
        {
            subject.Statement = statementBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCompound());
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithParameter(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter()));
            return subject;
        }
    }
}