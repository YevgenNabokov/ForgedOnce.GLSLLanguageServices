using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionUnaryExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary WithRight(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression right)
        {
            subject.Right = right;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary WithOperator(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Operator @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}