using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class TypeQualifierExtensions
    {
        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithLayout(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, Func<ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier> layoutBuilder)
        {
            subject.Layout.Add(layoutBuilder(new ForgedOnce.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier()));
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithInvariant(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, bool invariant)
        {
            subject.Invariant = invariant;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithInterpolation(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.InterpolationQualifier? interpolation)
        {
            subject.Interpolation = interpolation;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithStorage(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.StorageQualifier? storage)
        {
            subject.Storage = storage;
            return subject;
        }

        public static ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithPrecision(this ForgedOnce.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, ForgedOnce.GlslLanguageServices.LanguageModels.Ast.PrecisionQualifier? precision)
        {
            subject.Precision = precision;
            return subject;
        }
    }
}