using FluentAssertions;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using ForgedOnce.GlslLanguageServices.Parser;
using ForgedOnce.GlslLanguageServices.Tests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.LanguageServices.AstBuilder
{
    [TestFixture]
    public class AstBuilderBasicTests
    {
        private readonly string VariableDeclarationInput = @"int a, b, c;";

        private readonly string QualifiedVariableDeclarationInput = @"uniform int a;";

        private readonly string StructVariableDeclarationInput = @"struct { int a; } b;";

        private readonly string FunctionProtoInput = "int DoSomething(const float a, int b);";

        private readonly string PrecisionDeclarationInput = "precision highp float;";

        [Test]
        public void CanParseVariablesInRoot()
        {
            var parser = TestUtils.SetupParser(this.VariableDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            result.Should().BeOfType<Root>();
            var root = result as Root;

            root.Declarations.Should().HaveCount(1);
            var declarationList = root.Declarations[0] as VariableDeclarationList;

            var typeNameSpecifier = declarationList.Type as TypeNameSpecifier;
            typeNameSpecifier.Should().NotBeNull();

            typeNameSpecifier.Identifier.Name.Should().Be("int");

            declarationList.Should().NotBeNull();
            declarationList.Declarations.Should().HaveCount(3);

            declarationList.Declarations[0].Name.Name.Should().Be("a");
            declarationList.Declarations[1].Name.Name.Should().Be("b");
            declarationList.Declarations[2].Name.Name.Should().Be("c");
        }

        [Test]
        public void CanParseQualifiedVariablesInRoot()
        {
            var parser = TestUtils.SetupParser(this.QualifiedVariableDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            result.Should().BeOfType<Root>();
            var root = result as Root;

            root.Declarations.Should().HaveCount(1);
            var declarationList = root.Declarations[0] as VariableDeclarationList;

            var typeNameSpecifier = declarationList.Type as TypeNameSpecifier;
            typeNameSpecifier.Should().NotBeNull();
            typeNameSpecifier.Identifier.Name.Should().Be("int");

            typeNameSpecifier.Qualifier.Storage.Should().Be(StorageQualifier.Uniform);

            declarationList.Should().NotBeNull();
            declarationList.Declarations.Should().HaveCount(1);
            declarationList.Declarations[0].Name.Name.Should().Be("a");
        }

        [Test]
        public void CanParseStructVariablesInRoot()
        {
            var parser = TestUtils.SetupParser(this.StructVariableDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            result.Should().BeOfType<Root>();
            var root = result as Root;

            root.Declarations.Should().HaveCount(1);
            var declarationList = root.Declarations[0] as VariableDeclarationList;

            var structTypeSpecifier = declarationList.Type as StructTypeSpecifier;
            structTypeSpecifier.Members.Should().HaveCount(1);

            var memberType = structTypeSpecifier.Members[0].Type as TypeNameSpecifier;
            memberType.Should().NotBeNull();
            memberType.Identifier.Name.Should().Be("int");

            structTypeSpecifier.Members[0].Identifiers.Should().HaveCount(1);
            structTypeSpecifier.Members[0].Identifiers[0].Name.Should().Be("a");

            declarationList.Declarations[0].Name.Name.Should().Be("b");
        }

        [Test]
        public void CanParseFunctionDefinitionsInRoot()
        {
            var parser = TestUtils.SetupParser(this.FunctionProtoInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            result.Should().BeOfType<Root>();
            var root = result as Root;

            root.Declarations.Should().HaveCount(1);
            var funcDeclaration = root.Declarations[0] as FunctionDeclaration;

            funcDeclaration.Name.Name.Should().Be("DoSomething");

            var typeSpec = funcDeclaration.TypeSpecifier as TypeNameSpecifier;
            typeSpec.Should().NotBeNull();

            typeSpec.Identifier.Name.Should().Be("int");

            funcDeclaration.Parameters.Should().HaveCount(2);

            ((TypeNameSpecifier)funcDeclaration.Parameters[0].TypeSpecifier).Identifier.Name.Should().Be("float");
            funcDeclaration.Parameters[0].Name.Name.Should().Be("a");

            ((TypeNameSpecifier)funcDeclaration.Parameters[1].TypeSpecifier).Identifier.Name.Should().Be("int");
            funcDeclaration.Parameters[1].Name.Name.Should().Be("b");
        }

        [Test]
        public void CanParsePrecisionDeclarationInRoot()
        {
            var parser = TestUtils.SetupParser(this.PrecisionDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            result.Should().BeOfType<Root>();
            var root = result as Root;

            root.Declarations.Should().HaveCount(1);
            var precDeclaration = root.Declarations[0] as PrecisionDeclaration;

            var typeSpec = precDeclaration.Type as TypeNameSpecifier;
            typeSpec.Should().NotBeNull();
            typeSpec.Identifier.Name.Should().Be("float");

            precDeclaration.PrecisionQualifier.Should().Be(PrecisionQualifier.HighP);
        }
    }
}
