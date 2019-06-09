﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.Parser
{
    public static class TestUtils
    {
        public static GLSL_ES300Parser SetupParser(string input)
        {
            ICharStream stream = CharStreams.fromstring(input);
            GLSL_ES300Lexer lexer = new GLSL_ES300Lexer(stream);            
            ITokenStream tokens = new CommonTokenStream(lexer);
            GLSL_ES300Parser parser = new GLSL_ES300Parser(tokens);
            parser.BuildParseTree = true;
            return parser;
        }

        public static GLSL_ES300Lexer SetupLexer(string input)
        {
            ICharStream stream = CharStreams.fromstring(input);
            GLSL_ES300Lexer lexer = new GLSL_ES300Lexer(stream);
            return lexer;
        }
    }
}
