using FluentAssertions;
using Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.LanguageServices.Builder.AstAnalysis
{
    [TestFixture]
    public class AstHelperTests
    {
        [TestCase("int", "int", true)]
        [TestCase("int", "float", false)]
        [TestCase(null, null, true)]
        [TestCase(null, "int", false)]
        public void CanCompareTypeNameSpecifiers(string name1, string name2, bool expectedResult)
        {
            var result = AstHelper.TypeSpecifiersAreEquivalent(
            new TypeNameSpecifier()
            {
                Identifier = new Identifier() { Name = name1 }
            },
            new TypeNameSpecifier()
            {
                Identifier = new Identifier() { Name = name2 }
            });

            result.Should().Be(expectedResult);
        }

        [TestCase(InterpolationQualifier.Flat, InterpolationQualifier.Smooth, false, false, null, null, null, null, false)]
        [TestCase(null, InterpolationQualifier.Smooth, false, false, null, null, null, null, false)]
        [TestCase(InterpolationQualifier.Smooth, InterpolationQualifier.Smooth, false, false, null, null, null, null, true)]        
        [TestCase(null, null, false, false, null, null, null, null, true)]
        [TestCase(null, null, true, false, null, null, null, null, false)]
        [TestCase(null, null, false, false, PrecisionQualifier.HighP, PrecisionQualifier.LowP, null, null, false)]
        [TestCase(null, null, false, false, PrecisionQualifier.HighP, null, null, null, false)]
        [TestCase(null, null, false, false, PrecisionQualifier.HighP, PrecisionQualifier.HighP, null, null, true)]
        [TestCase(null, null, false, false, null, null, StorageQualifier.In, StorageQualifier.Out, false)]
        [TestCase(null, null, false, false, null, null, StorageQualifier.Out, StorageQualifier.Out, true)]
        [TestCase(null, null, false, false, null, null, StorageQualifier.In, null, false)]
        public void CanCompareQualifier(
            InterpolationQualifier? interpolation1,
            InterpolationQualifier? interpolation2,
            bool invariant1,
            bool invariant2,
            PrecisionQualifier? precision1,
            PrecisionQualifier? precision2,
            StorageQualifier? storage1,
            StorageQualifier? storage2,
            bool expectedResult)
        {
            var result = AstHelper.TypeSpecifiersAreEquivalent(
            new TypeNameSpecifier()
            {
                Identifier = new Identifier() { Name = "int" },
                Qualifier = new TypeQualifier()
                {
                    Interpolation = interpolation1,
                    Invariant = invariant1,
                    Precision = precision1,
                    Storage = storage1
                }
            },
            new TypeNameSpecifier()
            {
                Identifier = new Identifier() { Name = "int" },
                Qualifier = new TypeQualifier()
                {
                    Interpolation = interpolation2,
                    Invariant = invariant2,
                    Precision = precision2,
                    Storage = storage2
                }
            },
            true);

            result.Should().Be(expectedResult);
        }

        [TestCase("v1", "0", "v2", "1", "v1", "0", "v2", "1", true)]
        [TestCase("v2", "1", "v1", "0", "v1", "0", "v2", "1", true)]
        [TestCase("v1", "0", "v2", "8", "v1", "0", "v2", "010", true)]
        [TestCase("v1", "0", "v2", "0xc", "v1", "0", "v2", "12", true)]
        [TestCase("v1", "0", "v2", "0xc", "v1", "0", "v2", "0", false)]
        [TestCase("v1", "0", "v3", "1", "v1", "0", "v2", "1", false)]
        public void CanCompareQualifierLayout(
            string q1m1name,
            string q1m1value,
            string q1m2name,
            string q1m2value,
            string q2m1name,
            string q2m1value,
            string q2m2name,
            string q2m2value,
            bool expectedResult)
        {
            var specifier1 = new TypeNameSpecifier()
            {
                Identifier = new Identifier() { Name = "int" },
                Qualifier = new TypeQualifier()
            };

            specifier1.Qualifier.Layout.Add(new LayoutIdQualifier()
            {
                Identifier = new Identifier() { Name = q1m1name },
                Order = new IntegerLiteral() { LiteralValue = q1m1value }
            });
            specifier1.Qualifier.Layout.Add(new LayoutIdQualifier()
            {
                Identifier = new Identifier() { Name = q1m2name },
                Order = new IntegerLiteral() { LiteralValue = q1m2value }
            });

            var specifier2 = new TypeNameSpecifier()
            {
                Identifier = new Identifier() { Name = "int" },
                Qualifier = new TypeQualifier()
            };

            specifier2.Qualifier.Layout.Add(new LayoutIdQualifier()
            {
                Identifier = new Identifier() { Name = q2m1name },
                Order = new IntegerLiteral() { LiteralValue = q2m1value }
            });
            specifier2.Qualifier.Layout.Add(new LayoutIdQualifier()
            {
                Identifier = new Identifier() { Name = q2m2name },
                Order = new IntegerLiteral() { LiteralValue = q2m2value }
            });

            var result = AstHelper.TypeSpecifiersAreEquivalent(specifier1, specifier2, true);

            result.Should().Be(expectedResult);
        }

        [TestCase("a", "int", "a", "int", true)]
        [TestCase("a", "int", "b", "int", false)]
        [TestCase("a", "int", "a", "float", false)]
        public void CanCompareStructTypeSpecifiers(string s1m1name, string s1m1type, string s2m1name, string s2m1type, bool expectedResult)
        {
            var specifier1 = new StructTypeSpecifier();
            var member1 = new StructMemberDeclaration();
            member1.Identifiers.Add(new Identifier() { Name = s1m1name });
            member1.Type = new TypeNameSpecifier() { Identifier = new Identifier() { Name = s1m1type } };
            specifier1.Members.Add(member1);

            var specifier2 = new StructTypeSpecifier();
            var member2 = new StructMemberDeclaration();
            member2.Identifiers.Add(new Identifier() { Name = s2m1name });
            member2.Type = new TypeNameSpecifier() { Identifier = new Identifier() { Name = s2m1type } };
            specifier2.Members.Add(member2);

            var result = AstHelper.TypeSpecifiersAreEquivalent(specifier1, specifier2);

            result.Should().Be(expectedResult);
        }
    }
}
