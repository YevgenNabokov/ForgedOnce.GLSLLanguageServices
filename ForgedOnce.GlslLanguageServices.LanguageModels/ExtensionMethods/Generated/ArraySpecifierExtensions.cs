using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ArraySpecifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier WithArraySizeExpression(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Expression arraySizeExpression)
        {
            subject.ArraySizeExpression = arraySizeExpression;
            return subject;
        }
    }
}