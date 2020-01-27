using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.ExtensionMethods
{
    public static partial class TypeQualifierExtensions
    {
        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithLayout(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, Func<Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier> layoutBuilder)
        {
            subject.Layout.Add(layoutBuilder(new Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.LayoutIdQualifier()));
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithInvariant(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, bool invariant)
        {
            subject.Invariant = invariant;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithInterpolation(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.InterpolationQualifier? interpolation)
        {
            subject.Interpolation = interpolation;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithStorage(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.StorageQualifier? storage)
        {
            subject.Storage = storage;
            return subject;
        }

        public static Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier WithPrecision(this Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.TypeQualifier subject, Game08.Sdk.GlslLanguageServices.LanguageModels.Ast.PrecisionQualifier? precision)
        {
            subject.Precision = precision;
            return subject;
        }
    }
}