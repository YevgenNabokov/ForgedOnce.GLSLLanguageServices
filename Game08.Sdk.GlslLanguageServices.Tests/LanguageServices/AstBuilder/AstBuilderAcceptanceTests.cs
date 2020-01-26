using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.Parser;
using Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.TestResources;
using Game08.Sdk.GlslLanguageServices.Tests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.AstBuilder
{
    [TestFixture]
    public class AstBuilderAcceptanceTests
    {
        [Test]
        public void CanParseShader()
        {
            var parser = TestUtils.SetupParser(TestShaderSources.BigShaderText);
            var context = parser.external_declaration_list();

            var subject = new AstBuilderVisitor();

            var result = subject.Visit(context);

            Assert.IsTrue(result is Root);
            var root = result as Root;
        }

    }
}
