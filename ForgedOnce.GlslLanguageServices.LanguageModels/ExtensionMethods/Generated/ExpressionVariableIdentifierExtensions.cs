using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionVariableIdentifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionVariableIdentifier WithIdentifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionVariableIdentifier subject, string name)
        {
            subject.Identifier = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }
    }
}