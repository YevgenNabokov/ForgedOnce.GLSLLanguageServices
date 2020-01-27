using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class IntegerLiteralExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral WithLiteralValue(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral subject, string literalValue)
        {
            subject.LiteralValue = literalValue;
            return subject;
        }
    }
}