using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionSequenceExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionSequence WithExpression(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionSequence subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expressions.Add(expression);
            return subject;
        }
    }
}