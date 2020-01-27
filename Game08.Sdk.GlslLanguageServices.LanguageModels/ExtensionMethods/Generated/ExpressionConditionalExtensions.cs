using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionConditionalExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional WithCondition(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression condition)
        {
            subject.Condition = condition;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional WithThen(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression then)
        {
            subject.Then = then;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional WithElse(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionConditional subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression @else)
        {
            subject.Else = @else;
            return subject;
        }
    }
}