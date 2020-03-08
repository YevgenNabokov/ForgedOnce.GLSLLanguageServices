using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class StructMemberDeclarationExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration WithType(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier type)
        {
            subject.Type = type;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration WithArraySpecifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration WithIdentifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StructMemberDeclaration subject, string name)
        {
            subject.Identifiers.Add(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name});
            return subject;
        }
    }
}