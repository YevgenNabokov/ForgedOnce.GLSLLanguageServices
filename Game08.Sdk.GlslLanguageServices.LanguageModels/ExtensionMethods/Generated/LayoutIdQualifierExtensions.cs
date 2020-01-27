using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class LayoutIdQualifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier WithIdentifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier subject, string name)
        {
            subject.Identifier = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier WithOrder(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral> orderBuilder)
        {
            subject.Order = orderBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.IntegerLiteral());
            return subject;
        }
    }
}