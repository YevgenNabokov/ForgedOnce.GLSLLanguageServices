using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionConditionalExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional WithCondition(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional WithThen(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression then)
        {
            subject.Then = then;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional WithElse(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression @else)
        {
            subject.Else = @else;
            return subject;
        }
    }
}