using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionBinaryExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary WithLeft(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression left)
        {
            subject.Left = left;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary WithRight(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression right)
        {
            subject.Right = right;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary WithOperator(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionBinary subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Operator @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}