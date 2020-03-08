using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementCaseExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCase WithExpression(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCase subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}