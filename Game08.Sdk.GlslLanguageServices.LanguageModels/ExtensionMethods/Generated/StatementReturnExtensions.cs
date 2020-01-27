using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementReturnExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementReturn WithExpression(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementReturn subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}