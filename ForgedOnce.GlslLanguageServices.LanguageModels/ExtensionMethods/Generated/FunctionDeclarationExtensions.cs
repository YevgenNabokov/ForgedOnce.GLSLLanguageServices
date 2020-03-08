using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class FunctionDeclarationExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithTypeSpecifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier typeSpecifier)
        {
            subject.TypeSpecifier = typeSpecifier;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithName(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, string name)
        {
            subject.Name = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithStatement(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCompound, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCompound> statementBuilder)
        {
            subject.Statement = statementBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCompound());
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration WithParameter(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionDeclaration subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter()));
            return subject;
        }
    }
}