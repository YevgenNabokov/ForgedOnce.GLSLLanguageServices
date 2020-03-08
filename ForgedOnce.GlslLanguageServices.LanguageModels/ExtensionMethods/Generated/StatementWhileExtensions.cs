using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementWhileExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementWhile WithCondition(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementWhile subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementWhile WithBody(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementWhile subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement body)
        {
            subject.Body = body;
            return subject;
        }
    }
}