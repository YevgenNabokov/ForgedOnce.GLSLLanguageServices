using ForgedOnce.GlslLanguageServices.LanguageModels.Printer;
using ForgedOnce.GlslLanguageServices.Parser;
using ForgedOnce.GlslLanguageServices.Tests.LanguageServices.TestResources;
using ForgedOnce.GlslLanguageServices.Tests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.LanguageServices.Printer
{
    [TestFixture]
    public class AstPrinterVisitorAcceptanceTests
    {
        [Test]
        public void CanPrintShaderSource()
        {
            var parser = TestUtils.SetupParser(TestShaderSources.BigShaderText);
            var context = parser.external_declaration_list();
            var builder = new AstBuilderVisitor();
            var tree = builder.Visit(context);

            var subject = new AstPrinterVisitor();
            AstPrinterContext printerContext = new AstPrinterContext();
            
            var result = subject.Print(tree);
        }
    }
}
