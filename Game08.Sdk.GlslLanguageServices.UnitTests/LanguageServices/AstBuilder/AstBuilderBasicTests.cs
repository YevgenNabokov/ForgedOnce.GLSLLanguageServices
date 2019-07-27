using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.Parser;
using Game08.Sdk.GlslLanguageServices.UnitTests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.LanguageServices.AstBuilder
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

            Assert.IsTrue(result is Root);
            var root = result as Root;

            Assert.AreEqual(1, root.Declarations.Count);
            var declarationList = root.Declarations[0] as VariableDeclarationList;

            var typeNameSpecifier = declarationList.Type as TypeNameSpecifier;
            Assert.IsNotNull(typeNameSpecifier);

            Assert.AreEqual("int", typeNameSpecifier.Identifier.Name);

            Assert.IsNotNull(declarationList);
            Assert.AreEqual(3, declarationList.Declarations.Count);

            Assert.AreEqual("a", declarationList.Declarations[0].Name.Name);
            Assert.AreEqual("b", declarationList.Declarations[1].Name.Name);
            Assert.AreEqual("c", declarationList.Declarations[2].Name.Name);
        }

        [Test]
        public void CanParseQualifiedVariablesInRoot()
        {
            var parser = TestUtils.SetupParser(this.QualifiedVariableDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            Assert.IsTrue(result is Root);
            var root = result as Root;

            Assert.AreEqual(1, root.Declarations.Count);
            var declarationList = root.Declarations[0] as VariableDeclarationList;

            var typeNameSpecifier = declarationList.Type as TypeNameSpecifier;
            Assert.IsNotNull(typeNameSpecifier);
            Assert.AreEqual("int", typeNameSpecifier.Identifier.Name);

            Assert.AreEqual(StorageQualifier.Uniform, typeNameSpecifier.Qualifier.Storage);

            Assert.IsNotNull(declarationList);
            Assert.AreEqual(1, declarationList.Declarations.Count);
            Assert.AreEqual("a", declarationList.Declarations[0].Name.Name);
        }

        [Test]
        public void CanParseStructVariablesInRoot()
        {
            var parser = TestUtils.SetupParser(this.StructVariableDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            Assert.IsTrue(result is Root);
            var root = result as Root;

            Assert.AreEqual(1, root.Declarations.Count);
            var declarationList = root.Declarations[0] as VariableDeclarationList;

            var structTypeSpecifier = declarationList.Type as StructTypeSpecifier;
            Assert.AreEqual(1, structTypeSpecifier.Members.Count);

            var memberType = structTypeSpecifier.Members[0].Type as TypeNameSpecifier;
            Assert.IsNotNull(memberType);
            Assert.AreEqual("int", memberType.Identifier.Name);

            Assert.AreEqual(1, structTypeSpecifier.Members[0].Identifiers.Count);
            Assert.AreEqual("a", structTypeSpecifier.Members[0].Identifiers[0].Name);

            Assert.AreEqual("b", declarationList.Declarations[0].Name.Name);
        }

        [Test]
        public void CanParseFunctionDefinitionsInRoot()
        {
            var parser = TestUtils.SetupParser(this.FunctionProtoInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            Assert.IsTrue(result is Root);
            var root = result as Root;

            Assert.AreEqual(1, root.Declarations.Count);
            var funcDeclaration = root.Declarations[0] as FunctionDeclaration;

            Assert.AreEqual("DoSomething", funcDeclaration.Name.Name);

            var typeSpec = funcDeclaration.TypeSpecifier as TypeNameSpecifier;
            Assert.IsNotNull(typeSpec);

            Assert.AreEqual("int", typeSpec.Identifier.Name);

            Assert.AreEqual(2, funcDeclaration.Parameters.Count);

            Assert.AreEqual("float", ((TypeNameSpecifier)funcDeclaration.Parameters[0].TypeSpecifier).Identifier.Name);
            Assert.AreEqual("a", funcDeclaration.Parameters[0].Name.Name);

            Assert.AreEqual("int", ((TypeNameSpecifier)funcDeclaration.Parameters[1].TypeSpecifier).Identifier.Name);
            Assert.AreEqual("b", funcDeclaration.Parameters[1].Name.Name);
        }

        [Test]
        public void CanParsePrecisionDeclarationInRoot()
        {
            var parser = TestUtils.SetupParser(this.PrecisionDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            Assert.IsTrue(result is Root);
            var root = result as Root;

            Assert.AreEqual(1, root.Declarations.Count);
            var precDeclaration = root.Declarations[0] as PrecisionDeclaration;

            var typeSpec = precDeclaration.Type as TypeNameSpecifier;
            Assert.IsNotNull(typeSpec);
            Assert.AreEqual("float", typeSpec.Identifier.Name);

            Assert.AreEqual(PrecisionQualifier.HighP, precDeclaration.PrecisionQualifier);
        }
    }
}
