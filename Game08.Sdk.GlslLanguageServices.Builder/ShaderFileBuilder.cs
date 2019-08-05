using Antlr4.Runtime;
using Game08.Sdk.GlslLanguageServices.Builder.Interface;
using Game08.Sdk.GlslLanguageServices.Builder.SemanticAnalysis;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder
{
    public class ShaderFileBuilder
    {
        private SemanticContext semanticContext;

        private Root syntaxTree;

        public static ShaderFileBuilder CreateFromText(IGlobalScopeFactory globalScopeFactory, string payload)
        {
            ShaderFileBuilder result = new ShaderFileBuilder();
            AstParser parser = new AstParser();
            result.syntaxTree = parser.Parse(payload);

            var globalScope = globalScopeFactory.Construct(result.syntaxTree.Version);

            SemanticModelBuilderVisitor sBuilder = new SemanticModelBuilderVisitor();
            SemanticModelBuilderContext sContext = new SemanticModelBuilderContext();
            sBuilder.Visit(result.syntaxTree, sContext);

            result.semanticContext = new SemanticContext(sContext.Result, globalScope);

            return result;
        }

        public static ShaderFileBuilder CreateEmpty(IGlobalScopeFactory globalScopeFactory, ShaderVersion shaderVersion = ShaderVersion.GlslEs300)
        {
            ShaderFileBuilder result = new ShaderFileBuilder();
            result.syntaxTree = new Root()
            {
                Version = shaderVersion
            };

            var globalScope = globalScopeFactory.Construct(shaderVersion);

            SemanticModelBuilderVisitor sBuilder = new SemanticModelBuilderVisitor();
            SemanticModelBuilderContext sContext = new SemanticModelBuilderContext();
            sBuilder.Visit(result.syntaxTree, sContext);

            result.semanticContext = new SemanticContext(sContext.Result, globalScope);

            return result;
        }


    }
}
