using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using ForgedOnce.GlslLanguageServices.Parser;
using ForgedOnce.GlslLanguageServices.Tests.LanguageServices.TestResources;
using ForgedOnce.GlslLanguageServices.Tests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.LanguageServices.AstBuilder
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
