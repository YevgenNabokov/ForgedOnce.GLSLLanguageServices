using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class FunctionParameterExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithTypeSpecifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier typeSpecifier)
        {
            subject.TypeSpecifier = typeSpecifier;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithArraySpecifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithName(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, string name)
        {
            subject.Name = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithParameterQualifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ParameterQualifier? parameterQualifier)
        {
            subject.ParameterQualifier = parameterQualifier;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithIsConst(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, bool isConst)
        {
            subject.IsConst = isConst;
            return subject;
        }
    }
}