using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementSwitchExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementSwitch WithExpression(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementSwitch subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementSwitch WithStatement(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementSwitch subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement statement)
        {
            subject.Statements.Add(statement);
            return subject;
        }
    }
}