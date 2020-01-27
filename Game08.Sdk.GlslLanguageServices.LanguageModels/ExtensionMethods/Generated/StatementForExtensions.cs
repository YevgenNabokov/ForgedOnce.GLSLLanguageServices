using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementForExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor WithInit(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement init)
        {
            subject.Init = init;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor WithCondition(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor WithIncrement(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression increment)
        {
            subject.Increment = increment;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor WithBody(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement body)
        {
            subject.Body = body;
            return subject;
        }
    }
}