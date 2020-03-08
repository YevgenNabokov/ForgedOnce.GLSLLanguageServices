using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionFieldSelectionExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection WithName(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection subject, string name)
        {
            subject.Name = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection WithLeft(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }
    }
}