using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ArraySpecifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier WithArraySizeExpression(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Expression arraySizeExpression)
        {
            subject.ArraySizeExpression = arraySizeExpression;
            return subject;
        }
    }
}