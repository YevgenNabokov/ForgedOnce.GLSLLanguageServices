using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class BooleanLiteralExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.BooleanLiteral WithLiteralValue(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.BooleanLiteral subject, string literalValue)
        {
            subject.LiteralValue = literalValue;
            return subject;
        }
    }
}