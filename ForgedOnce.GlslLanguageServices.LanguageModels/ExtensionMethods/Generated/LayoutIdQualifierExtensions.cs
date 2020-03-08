using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class LayoutIdQualifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier WithIdentifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier subject, string name)
        {
            subject.Identifier = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier WithOrder(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral> orderBuilder)
        {
            subject.Order = orderBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral());
            return subject;
        }
    }
}