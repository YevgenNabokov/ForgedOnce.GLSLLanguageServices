using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StructMemberDeclarationExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration WithType(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier type)
        {
            subject.Type = type;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration WithArraySpecifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration WithIdentifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration subject, string name)
        {
            subject.Identifiers.Add(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name});
            return subject;
        }
    }
}