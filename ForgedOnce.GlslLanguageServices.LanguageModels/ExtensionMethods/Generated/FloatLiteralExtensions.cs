using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class FloatLiteralExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FloatLiteral WithLiteralValue(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FloatLiteral subject, string literalValue)
        {
            subject.LiteralValue = literalValue;
            return subject;
        }
    }
}