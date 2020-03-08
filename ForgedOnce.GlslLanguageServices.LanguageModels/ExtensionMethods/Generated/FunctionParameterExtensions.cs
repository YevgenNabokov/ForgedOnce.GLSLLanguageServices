using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class FunctionParameterExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithTypeSpecifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeSpecifier typeSpecifier)
        {
            subject.TypeSpecifier = typeSpecifier;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithArraySpecifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier> arraySpecifierBuilder)
        {
            subject.ArraySpecifier = arraySpecifierBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ArraySpecifier());
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithName(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, string name)
        {
            subject.Name = new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithParameterQualifier(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.ParameterQualifier? parameterQualifier)
        {
            subject.ParameterQualifier = parameterQualifier;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter WithIsConst(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.FunctionParameter subject, bool isConst)
        {
            subject.IsConst = isConst;
            return subject;
        }
    }
}