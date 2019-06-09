﻿using Antlr4.Runtime;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.Parser
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

        [Test]
        public void CanParseSomething()
        {
            ////ICharStream stream = CharStreams.fromstring(SimpleCppPayload);
            ////ITokenSource lexer = new GLSL_ES300Lexer(stream);
            ////ITokenStream tokens = new CommonTokenStream(lexer);
            ////GLSL_ES300Parser parser = new GLSL_ES300Parser(tokens);
            ////parser.BuildParseTree = true;
            ////var context = parser.root();
        }
    }
}
