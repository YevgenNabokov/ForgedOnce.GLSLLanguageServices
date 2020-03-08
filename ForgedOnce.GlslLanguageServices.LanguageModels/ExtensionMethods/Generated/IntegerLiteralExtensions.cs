using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class IntegerLiteralExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral WithLiteralValue(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral subject, string literalValue)
        {
            subject.LiteralValue = literalValue;
            return subject;
        }
    }
}