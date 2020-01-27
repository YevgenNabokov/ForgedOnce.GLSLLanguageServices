using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class ExpressionVariableIdentifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionVariableIdentifier WithIdentifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ExpressionVariableIdentifier subject, string name)
        {
            subject.Identifier = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }
    }
}