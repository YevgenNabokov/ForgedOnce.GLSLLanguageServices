using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionParenGroupExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionParenGroup WithContent(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionParenGroup subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression content)
        {
            subject.Content = content;
            return subject;
        }
    }
}