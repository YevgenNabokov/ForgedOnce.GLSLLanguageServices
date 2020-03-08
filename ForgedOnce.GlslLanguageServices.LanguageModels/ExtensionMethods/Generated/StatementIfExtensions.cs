using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementIfExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementIf WithCondition(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementIf subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementIf WithThen(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementIf subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement then)
        {
            subject.Then = then;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementIf WithElse(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementIf subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement @else)
        {
            subject.Else = @else;
            return subject;
        }
    }
}