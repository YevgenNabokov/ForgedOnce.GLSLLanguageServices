﻿using Game08.Sdk.GlslLanguageServices.LanguageModels.Printer;
using Game08.Sdk.GlslLanguageServices.Parser;
using Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.TestResources;
using Game08.Sdk.GlslLanguageServices.Tests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.Printer
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