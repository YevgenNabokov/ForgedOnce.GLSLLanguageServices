using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StructTypeSpecifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier WithIdentifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier subject, string name)
        {
            subject.Identifier = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier WithMember(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration> memberBuilder)
        {
            subject.Members.Add(memberBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration()));
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier WithQualifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructTypeSpecifier subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier> qualifierBuilder)
        {
            subject.Qualifier = qualifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier());
            return subject;
        }
    }
}