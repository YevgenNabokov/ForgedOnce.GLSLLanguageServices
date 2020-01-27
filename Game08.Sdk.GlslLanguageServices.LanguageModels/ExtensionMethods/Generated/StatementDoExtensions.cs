using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementDoExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementDo WithBody(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementDo subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement body)
        {
            subject.Body = body;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementDo WithCondition(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementDo subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }
    }
}