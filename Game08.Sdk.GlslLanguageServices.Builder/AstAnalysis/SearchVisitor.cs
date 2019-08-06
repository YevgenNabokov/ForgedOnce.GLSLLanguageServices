using Game08.Sdk.GlslLanguageServices.LanguageModels;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis
{
    public class SearchVisitor : AstVisitor<SearchContext>
    {
        public List<AstNode> Select(AstNode startNode, Type[] nodeTypes, int? searchDepth)
        {
            var context = new SearchContext()
            {
                SearchDepth = searchDepth,
                StartNode = startNode,
                SearchNodeTypes = new HashSet<Type>(nodeTypes),
                CurrentDepth = 0
            };

            this.Visit(startNode, context);

            return context.Result;
        }

        public override void Visit(AstNode node, SearchContext context)
        {
            if (context.SearchDepth != null && context.CurrentDepth == context.SearchDepth)
            {
                return;
            }

            if (context.CurrentDepth >= 0 || node == context.StartNode)
            {
                context.CurrentDepth++;
            }            

            if (context.SearchNodeTypes != null)
            {
                var nType = node.GetType();
                foreach (var t in context.SearchNodeTypes)
                {
                    if (t == nType || t.IsAssignableFrom(nType))
                    {
                        context.Result.Add(node);
                    }
                }
            }
            else
            {
                context.Result.Add(node);
            }

            base.Visit(node, context);

            if (context.CurrentDepth >= 0)
            {
                context.CurrentDepth--;
            }
        }
    }
}
