using Antlr4.Runtime;
using Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis;
using Game08.Sdk.GlslLanguageServices.Builder.Interface;
using Game08.Sdk.GlslLanguageServices.Builder.SemanticAnalysis;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder
{
    public class ShaderFile
    {
        private SearchVisitor syntaxTreeSearchVisitor = new SearchVisitor();

        private SemanticContext semanticContext;

        public Root SyntaxTree { get; private set; }

        public static ShaderFile CreateFromText(IGlobalScopeFactory globalScopeFactory, string payload)
        {
            ShaderFile result = new ShaderFile();
            AstParser parser = new AstParser();
            result.SyntaxTree = parser.Parse(payload);

            var globalScope = globalScopeFactory.Construct(result.SyntaxTree.Version);

            SemanticModelBuilderVisitor sBuilder = new SemanticModelBuilderVisitor();
            SemanticModelBuilderContext sContext = new SemanticModelBuilderContext();
            sBuilder.Visit(result.SyntaxTree, sContext);

            result.semanticContext = new SemanticContext(sContext.Result, globalScope);
            result.semanticContext.ResolveSymbolReferences();

            return result;
        }

        public static ShaderFile CreateEmpty(IGlobalScopeFactory globalScopeFactory, ShaderVersion shaderVersion = ShaderVersion.GlslEs300)
        {
            ShaderFile result = new ShaderFile();
            result.SyntaxTree = new Root()
            {
                Version = shaderVersion
            };

            var globalScope = globalScopeFactory.Construct(shaderVersion);

            SemanticModelBuilderVisitor sBuilder = new SemanticModelBuilderVisitor();
            SemanticModelBuilderContext sContext = new SemanticModelBuilderContext();
            sBuilder.Visit(result.SyntaxTree, sContext);

            result.semanticContext = new SemanticContext(sContext.Result, globalScope);

            return result;
        }

        public List<TNode> FindNodes<TNode>() where TNode: AstNode
        {
            List<TNode> result = new List<TNode>();

            foreach (var r in syntaxTreeSearchVisitor.Select(this.SyntaxTree, new[] { typeof(TNode) }, null))
            {
                result.Add((TNode)r);
            }

            return result;
        }
    }
}
