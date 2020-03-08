using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionParenGroupExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionParenGroup WithContent(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionParenGroup subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression content)
        {
            subject.Content = content;
            return subject;
        }
    }
}