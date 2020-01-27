using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionIndexAccessExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess WithLeft(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess WithIndex(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionIndexAccess subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression index)
        {
            subject.Index = index;
            return subject;
        }
    }
}