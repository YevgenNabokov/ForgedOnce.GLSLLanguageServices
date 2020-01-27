using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementIfExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementIf WithCondition(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementIf subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementIf WithThen(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementIf subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement then)
        {
            subject.Then = then;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementIf WithElse(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementIf subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement @else)
        {
            subject.Else = @else;
            return subject;
        }
    }
}