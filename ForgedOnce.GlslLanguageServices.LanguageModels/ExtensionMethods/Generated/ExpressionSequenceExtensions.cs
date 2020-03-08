using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionSequenceExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionSequence WithExpression(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionSequence subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expressions.Add(expression);
            return subject;
        }
    }
}