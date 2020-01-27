using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionUnaryExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary WithRight(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression right)
        {
            subject.Right = right;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary WithOperator(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionUnary subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Operator @operator)
        {
            subject.Operator = @operator;
            return subject;
        }
    }
}