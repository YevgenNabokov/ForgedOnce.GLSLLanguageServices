using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using FluentAssertions;
using ForgedOnce.GlslLanguageServices.Tests.LanguageServices.TestResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.Parser
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
            context.children.Should().HaveCount(1);

            context.children[0].Should().BeAssignableTo<ITerminalNode>();
            ((ITerminalNode)context.children[0]).Symbol.Type.Should().Be(expectedTokenType);
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

            context.exception.Should().BeNull();
        }

        [Test]
        public void CanParseVariableDeclaration()
        {
            var varName = "myVar";
            string payload = DeclarationMaker.SimpleIntVar(varName);
            var parser = TestUtils.SetupParser(payload);
            var context = parser.declaration();

            context.exception.Should().BeNull();
            var declarators = context.declaratorlist();

            declarators.Should().NotBeNull();
            context.Semicolon().Should().NotBeNull();
            context.Semicolon().Symbol.Type.Should().Be(GLSL_ES300Lexer.Semicolon);
            var declarator = declarators.declarator();
            declarator.Should().NotBeNull();
            var type = declarator.fully_specified_type();
            type.Should().NotBeNull();
            var typeSpec = type.type_specifier_nonarray();
            typeSpec.Should().NotBeNull();
            var intT = typeSpec.Int_type();
            intT.Should().NotBeNull();

            var id = declarator.Identifier();
            id.Should().NotBeNull();
            id.Symbol.Text.Should().Be(varName);
        }

        [Test]
        public void CanParseExternalDeclarationList()
        {
            var varName = "a";
            string payload = DeclarationMaker.SimpleIntVar(varName);
            var parser = TestUtils.SetupParser(payload);
            var context = parser.external_declaration_list();

            context.exception.Should().BeNull();
            var declarations = context.external_declaration();
            declarations.Should().NotBeNull();
            var d = declarations;
            var declaration = d.declaration();
            declaration.Should().NotBeNull();
            var dList = declaration.declaratorlist();
            dList.Should().NotBeNull();
            var declarator = dList.declarator();
            declarator.Should().NotBeNull();
            var type = declarator.fully_specified_type();
            type.Should().NotBeNull();
            var typeSpec = type.type_specifier_nonarray();
            typeSpec.Should().NotBeNull();
            var intT = typeSpec.Int_type();
            intT.Should().NotBeNull();

            var id = declarator.Identifier();
            id.Should().NotBeNull();
            id.Symbol.Text.Should().Be(varName);
        }
    }
}
