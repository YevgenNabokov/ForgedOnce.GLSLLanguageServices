using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementCompoundExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCompound WithStatement(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StatementCompound subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Statement statement)
        {
            subject.Statements.Add(statement);
            return subject;
        }
    }
}