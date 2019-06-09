﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.Parser
{
    [TestFixture]
    public class ParserBasicTests
    {        
        [Test]
        [TestCase("10", false, GLSL_ES300Lexer.DecimalLiteral)]
        [TestCase("10u", true, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("10U", true, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0677", false, GLSL_ES300Lexer.OctalLiteral)]
        [TestCase("0677u", true, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0x112f", false, GLSL_ES300Lexer.HexadecimalLiteral)]
        [TestCase("0x112fu", true, GLSL_ES300Lexer.IntegerLiteral)]
        public void CanParseIntLiterals(string payload, bool hasSuffix, int expectedTokenType)
        {
            var parser = TestUtils.SetupParser(payload);
            var context = parser.literal();
            Assert.AreEqual(1, context.children.Count);

            Assert.IsTrue(context.children[0] is ITerminalNode);
            Assert.AreEqual(expectedTokenType, ((ITerminalNode)context.children[0]).Symbol.Type);
        }
    }
}
