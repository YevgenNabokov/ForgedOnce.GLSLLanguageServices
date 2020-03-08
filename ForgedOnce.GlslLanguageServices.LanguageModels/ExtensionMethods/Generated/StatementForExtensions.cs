using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementForExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor WithInit(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement init)
        {
            subject.Init = init;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor WithCondition(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor WithIncrement(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression increment)
        {
            subject.Increment = increment;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor WithBody(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementFor subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement body)
        {
            subject.Body = body;
            return subject;
        }
    }
}