using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementCaseExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCase WithExpression(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCase subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }
    }
}