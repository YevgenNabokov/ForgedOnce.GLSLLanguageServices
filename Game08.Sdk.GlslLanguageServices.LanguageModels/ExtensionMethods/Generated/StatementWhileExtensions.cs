using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementWhileExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementWhile WithCondition(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementWhile subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementWhile WithBody(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementWhile subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement body)
        {
            subject.Body = body;
            return subject;
        }
    }
}