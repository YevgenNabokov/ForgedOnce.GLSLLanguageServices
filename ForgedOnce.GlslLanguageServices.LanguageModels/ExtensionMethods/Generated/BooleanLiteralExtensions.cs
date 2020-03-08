using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class BooleanLiteralExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.BooleanLiteral WithLiteralValue(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.BooleanLiteral subject, string literalValue)
        {
            subject.LiteralValue = literalValue;
            return subject;
        }
    }
}