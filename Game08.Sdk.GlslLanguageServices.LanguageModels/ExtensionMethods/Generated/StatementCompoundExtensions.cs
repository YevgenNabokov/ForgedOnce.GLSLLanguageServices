using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StatementCompoundExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCompound WithStatement(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StatementCompound subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Statement statement)
        {
            subject.Statements.Add(statement);
            return subject;
        }
    }
}