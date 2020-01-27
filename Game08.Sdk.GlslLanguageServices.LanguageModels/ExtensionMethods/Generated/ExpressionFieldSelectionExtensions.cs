using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionFieldSelectionExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection WithName(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection subject, string name)
        {
            subject.Name = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection WithLeft(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionFieldSelection subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }
    }
}