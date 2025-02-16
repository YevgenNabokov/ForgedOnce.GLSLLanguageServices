using Antlr4.Runtime;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.Parser
{
    [TestFixture]
    public class ParserTests
    {
        public const string SimpleCppPayload = @"
        void main()
        {
            color = vec4(1.0, 0.0, 0.0, 0.1);
        }";

        public const string SimpleShaderPayload = @"#version 300 es

precision highp float;

out vec4 color;

        void main()
        {
            color = vec4(1.0, 0.0, 0.0, 0.1);
        }";

        public const string NoDeclarationsPayload = @"#version 300 es";

        [Test]
        public void CanParseNoDeclarations()
        {
            ICharStream stream = CharStreams.fromString(NoDeclarationsPayload);
            GLSL_ES300Lexer lexer = new GLSL_ES300Lexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            GLSL_ES300Parser parser = new GLSL_ES300Parser(tokens);
            parser.BuildParseTree = true;

            var context = parser.translation_unit();
            context.exception.Should().BeNull();
        }
    }
}
