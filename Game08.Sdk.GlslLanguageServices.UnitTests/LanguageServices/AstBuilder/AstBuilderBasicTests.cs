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
    }
}
