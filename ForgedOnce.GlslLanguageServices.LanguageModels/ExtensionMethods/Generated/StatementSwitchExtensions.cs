using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementSwitchExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementSwitch WithExpression(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementSwitch subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression expression)
        {
            subject.Expression = expression;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementSwitch WithStatement(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementSwitch subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement statement)
        {
            subject.Statements.Add(statement);
            return subject;
        }
    }
}