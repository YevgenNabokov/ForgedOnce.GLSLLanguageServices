using Game08.Sdk.GlslLanguageServices.UnitTests.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.LanguageServices.Lexer
{
    [TestFixture]
    public class LexerBasicTests
    {
        private readonly string[] validIdentifiers = new[]
        {
            "a",
            "id",
            "id12",
            "id12_23",
            "id12_a23",
            "_id",
            "Id",
            "Id12",
            "Id12_23",
            "_Id",
            "Id12_a23",
            "es"
        };

        private readonly string[] invalidIdentifiers = new[]
        {
            "1",
            "*"
        };

        [Test]
        public void CanParseIdentifiers()
        {
            foreach (var id in this.validIdentifiers)
            {
                var lexer = TestUtils.SetupLexer(id);

                var tokens = lexer.GetAllTokens();
                Assert.AreEqual(1, tokens.Count);                
                Assert.AreEqual(id, tokens[0].Text);
                Assert.AreEqual(GLSL_ES300Lexer.Identifier, tokens[0].Type);
            }

            foreach (var id in this.invalidIdentifiers)
            {
                var lexer = TestUtils.SetupLexer(id);

                var tokens = lexer.GetAllTokens();
                Assert.IsTrue(tokens.Count == 0 || tokens[0].Type != GLSL_ES300Lexer.Identifier);                
            }
        }

        [Test]
        [TestCase("10", GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("199999", GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("06", GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("067777", GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0x456a", GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0X456a", GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0xffffff", GLSL_ES300Lexer.IntegerLiteral)]        
        public void CanParseIntegerLiterals(string payload, int expectedTokenType)
        {
            var lexer = TestUtils.SetupLexer(payload);
            var tokens = lexer.GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(expectedTokenType, tokens[0].Type);
            Assert.AreEqual(payload, tokens[0].Text);
        }

        [Test]
        public void CanParseIntegerSuffix()
        {
            var payload = "10u";
            var lexer = TestUtils.SetupLexer(payload);
            var tokens = lexer.GetAllTokens();

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(GLSL_ES300Lexer.IntegerLiteral, tokens[0].Type);
            Assert.AreEqual(payload, tokens[0].Text);
        }

        [Test]
        [TestCase("0.1")]
        [TestCase("1.1")]
        [TestCase("123.123")]
        [TestCase(".123")]
        [TestCase("123.")]
        [TestCase("123.")]
        [TestCase("123e-20")]
        [TestCase("123e20")]
        [TestCase("123e+20")]
        [TestCase("123.6e+20")]
        [TestCase("123.6e+20f")]
        [TestCase("123.6e+20F")]
        public void CanParseFloatingLiterals(string payload)
        {
            var lexer = TestUtils.SetupLexer(payload);
            var tokens = lexer.GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(GLSL_ES300Lexer.FloatingLiteral, tokens[0].Type);
            Assert.AreEqual(payload, tokens[0].Text);
        }
    }
}
