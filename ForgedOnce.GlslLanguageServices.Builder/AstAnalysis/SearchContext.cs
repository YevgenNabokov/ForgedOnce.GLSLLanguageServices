using ForgedOnce.GlslLanguageServices.Builder.Interface;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.AstAnalysis
{
    public class SearchContext : ISearchContext
    {
        private readonly Func<AstNode, TraverseInstruction> testFunc;

        protected readonly int? searchDepth;

        public int CurrentDepth = -1;

        public SearchContext(AstNode startNode, Func<AstNode, TraverseInstruction> testFunc, int? searchDepth = null)
        {
            this.StartNode = startNode;
            this.testFunc = testFunc;
            this.searchDepth = searchDepth;
        }

        public AstNode StartNode { get; protected set; }

        public List<AstNode> Result { get; } = new List<AstNode>();

        public void DecreaseDepth()
        {
            this.CurrentDepth--;
        }

        public void IncreaseDepth()
        {
            this.CurrentDepth++;
        }

        public TraverseInstruction TestNode(AstNode node)
        {
            if (this.searchDepth != null && this.CurrentDepth == this.searchDepth)
            {
                return TraverseInstruction.ExitBranch;
            }

            var result = this.testFunc(node);

            if (result.HasFlag(TraverseInstruction.Match))
            {
                this.Result.Add(node);
            }

            return result;
        }
    }
}
