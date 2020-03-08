using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionBinaryExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary WithLeft(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary WithRight(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression right)
        {
            subject.Right = right;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary WithOperator(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Operator @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}