using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionFunctionCallExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall WithLeft(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall WithIdentifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall subject, string name)
        {
            subject.Identifier = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall WithParameter(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression parameter)
        {
            subject.Parameters.Add(parameter);
            return subject;
        }
    }
}