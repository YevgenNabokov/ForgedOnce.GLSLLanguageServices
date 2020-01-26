using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.TestResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Tests.Parser
{
    [TestFixture]
    public class ParserBasicTests
    {        
        [Test]
        [TestCase("10", false, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("10u", true, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("10U", true, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0677", false, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0677u", true, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0x112f", false, GLSL_ES300Lexer.IntegerLiteral)]
        [TestCase("0x112fu", true, GLSL_ES300Lexer.IntegerLiteral)]
        public void CanParseIntLiterals(string payload, bool hasSuffix, int expectedTokenType)
        {
            var parser = TestUtils.SetupParser(payload);
            var context = parser.literal();
            Assert.AreEqual(1, context.children.Count);

            Assert.IsTrue(context.children[0] is ITerminalNode);
            Assert.AreEqual(expectedTokenType, ((ITerminalNode)context.children[0]).Symbol.Type);
        }

        [Test]
        public void CanParseStruct()
        {
            string payload = @"struct A 
            {
                int f1;
                float f2;
            }";

            var parser = TestUtils.SetupParser(payload);
            var context = parser.struct_specifier();
            
            Assert.IsNull(context.exception);
        }

        [Test]
        public void CanParseVariableDeclaration()
        {
            var varName = "myVar";
            string payload = DeclarationMaker.SimpleIntVar(varName);
            var parser = TestUtils.SetupParser(payload);
            var context = parser.declaration();

            Assert.IsNull(context.exception);
            var declarators = context.declaratorlist();
            Assert.IsNotNull(declarators);
            Assert.IsNotNull(context.Semicolon());
            Assert.AreEqual(GLSL_ES300Lexer.Semicolon, context.Semicolon().Symbol.Type);
            var declarator = declarators.declarator();
            Assert.IsNotNull(declarator);
            var type = declarator.fully_specified_type();
            Assert.NotNull(type);
            var typeSpec = type.type_specifier_nonarray();
            Assert.NotNull(typeSpec);
            var intT = typeSpec.Int_type();
            Assert.NotNull(intT);

            var id = declarator.Identifier();
            Assert.NotNull(id);
            Assert.AreEqual(varName, id.Symbol.Text);
        }

        [Test]
        public void CanParseExternalDeclarationList()
        {
            var varName = "a";
            string payload = DeclarationMaker.SimpleIntVar(varName);
            var parser = TestUtils.SetupParser(payload);
            var context = parser.external_declaration_list();

            Assert.IsNull(context.exception);
            var declarations = context.external_declaration();
            Assert.IsNotNull(declarations);
            var d = declarations;
            var declaration = d.declaration();
            Assert.NotNull(declaration);
            var dList = declaration.declaratorlist();
            Assert.NotNull(dList);
            var declarator = dList.declarator();
            Assert.NotNull(declarator);
            var type = declarator.fully_specified_type();
            Assert.NotNull(type);
            var typeSpec = type.type_specifier_nonarray();
            Assert.NotNull(typeSpec);
            var intT = typeSpec.Int_type();
            Assert.NotNull(intT);

            var id = declarator.Identifier();
            Assert.NotNull(id);
            Assert.AreEqual(varName, id.Symbol.Text);
        }
    }
}
