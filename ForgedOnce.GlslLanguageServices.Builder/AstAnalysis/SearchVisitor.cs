using ForgedOnce.GlslLanguageServices.Builder.Interface;
using ForgedOnce.GlslLanguageServices.LanguageModels;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.AstAnalysis
{
    public class SearchVisitor : AstVisitor<ISearchContext>
    {
        public List<AstNode> Select(AstNode startNode, Type[] nodeTypes, int? searchDepth)
        {
            var types = nodeTypes != null ? new HashSet<Type>(nodeTypes) : null;

            var context = new SearchContext(startNode, (n) =>
            {
                if (types == null)
                {
                    return TraverseInstruction.Match;
                }

                var nType = n.GetType();
                foreach (var t in types)
                {
                    if (t == nType || t.IsAssignableFrom(nType))
                    {
                        return TraverseInstruction.Match;
                    }
                }

                return TraverseInstruction.Continue;
            }, searchDepth);

            return this.Search(context);
        }

        public List<AstNode> Search(ISearchContext context)
        {
            this.Visit(context.StartNode, context);
            return context.Result;
        }

        public override void Visit(AstNode node, ISearchContext context)
        {
            context.IncreaseDepth();

            var nextStep = context.TestNode(node);

            if (nextStep.HasFlag(TraverseInstruction.ExitBranch))
            {
                context.DecreaseDepth();
                return;
            }

            base.Visit(node, context);

            context.DecreaseDepth();
        }
    }
}
