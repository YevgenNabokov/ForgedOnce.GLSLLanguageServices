using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionUnaryPostfixExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix WithLeft(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix WithOperator(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnaryPostfix subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Operator @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}