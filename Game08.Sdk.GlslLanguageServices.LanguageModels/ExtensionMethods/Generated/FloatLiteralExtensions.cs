using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class FloatLiteralExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FloatLiteral WithLiteralValue(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.FloatLiteral subject, string literalValue)
        {
            subject.LiteralValue = literalValue;
            return subject;
        }
    }
}