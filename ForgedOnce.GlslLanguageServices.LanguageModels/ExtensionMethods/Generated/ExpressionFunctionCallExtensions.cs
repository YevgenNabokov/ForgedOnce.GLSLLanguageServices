using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionFunctionCallExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall WithLeft(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall WithIdentifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall subject, string name)
        {
            subject.Identifier = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall WithParameter(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFunctionCall subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression parameter)
        {
            subject.Parameters.Add(parameter);
            return subject;
        }
    }
}