using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementReturnExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementReturn WithExpression(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementReturn subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}