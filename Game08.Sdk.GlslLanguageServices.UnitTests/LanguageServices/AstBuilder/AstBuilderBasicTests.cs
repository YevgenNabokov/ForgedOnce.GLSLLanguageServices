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
        private readonly string VariableDeclarationInput = @"int a;";

        [Test]
        public void CanParseVariablesInRoot()
        {
            var parser = TestUtils.SetupParser(this.VariableDeclarationInput);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            Assert.IsTrue(result is Root);


        }
    }
}
