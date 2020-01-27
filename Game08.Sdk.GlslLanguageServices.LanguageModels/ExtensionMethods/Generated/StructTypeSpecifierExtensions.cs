using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StructTypeSpecifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier WithIdentifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier subject, string name)
        {
            subject.Identifier = new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier WithMember(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration> memberBuilder)
        {
            subject.Members.Add(memberBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration()));
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier WithQualifier(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier> qualifierBuilder)
        {
            subject.Qualifier = qualifierBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier());
            return subject;
        }
    }
}