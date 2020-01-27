using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementExpressionExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementExpression WithExpression(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementExpression subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}