using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionUnaryPostfixExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix WithLeft(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix WithOperator(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Operator @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}