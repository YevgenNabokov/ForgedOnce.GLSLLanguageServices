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
        };

        private readonly string[] invalidIdentifiers = new[]
        {
            "1",
            "*"
        };

        private readonly HashSet<int> integerLiteralPartTypes = new HashSet<int>
        {
            GLSL_ES300Lexer.DecimalLiteral,
            GLSL_ES300Lexer.OctalLiteral,
            GLSL_ES300Lexer.HexadecimalLiteral
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
        [TestCase("10", GLSL_ES300Lexer.DecimalLiteral)]
        [TestCase("199999", GLSL_ES300Lexer.DecimalLiteral)]
        [TestCase("06", GLSL_ES300Lexer.OctalLiteral)]
        [TestCase("067777", GLSL_ES300Lexer.OctalLiteral)]
        [TestCase("0x456a", GLSL_ES300Lexer.HexadecimalLiteral)]
        [TestCase("0X456a", GLSL_ES300Lexer.HexadecimalLiteral)]
        [TestCase("0xffffff", GLSL_ES300Lexer.HexadecimalLiteral)]        
        public void CanParseIntegerLiteralParts(string payload, int expectedTokenType)
        {
            var lexer = TestUtils.SetupLexer(payload);
            var tokens = lexer.GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(expectedTokenType, tokens[0].Type);
        }

        [Test]
        public void CanParseSuffix()
        {
            var payload = "10u";
            var lexer = TestUtils.SetupLexer(payload);
            var tokens = lexer.GetAllTokens();

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(GLSL_ES300Lexer.IntegerLiteral, tokens[0].Type);
        }
    }
}
