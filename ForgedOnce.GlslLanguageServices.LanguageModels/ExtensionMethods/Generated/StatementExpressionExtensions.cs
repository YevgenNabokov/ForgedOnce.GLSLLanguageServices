using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementExpressionExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementExpression WithExpression(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementExpression subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}