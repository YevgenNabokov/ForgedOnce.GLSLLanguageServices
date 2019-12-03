using Antlr4.Runtime;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Parser
{
    public class AstParser
    {
        public Root Parse(string payload)
        {
            ICharStream stream = CharStreams.fromstring(payload);
            GLSL_ES300Lexer lexer = new GLSL_ES300Lexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            GLSL_ES300Parser parser = new GLSL_ES300Parser(tokens);
            parser.BuildParseTree = true;

            var context = parser.translation_unit();
            var subject = new AstBuilderVisitor();
            var result = (Root)subject.Visit(context);
            return result;
        }
    }
}
