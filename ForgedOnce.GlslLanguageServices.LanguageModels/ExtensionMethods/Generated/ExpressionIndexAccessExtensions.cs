using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionIndexAccessExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess WithLeft(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess WithIndex(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression index)
        {
            subject.Index = index;
            return subject;
        }
    }
}