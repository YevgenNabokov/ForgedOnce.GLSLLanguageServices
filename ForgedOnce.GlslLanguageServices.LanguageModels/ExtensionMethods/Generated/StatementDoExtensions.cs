using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementDoExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementDo WithBody(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementDo subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement body)
        {
            subject.Body = body;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementDo WithCondition(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementDo subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }
    }
}