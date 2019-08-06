using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis
{
    public class SearchContext
    {
        public List<AstNode> Result = new List<AstNode>();

        public HashSet<Type> SearchNodeTypes;

        public AstNode StartNode;

        public int? SearchDepth;

        public int CurrentDepth = -1;
    }
}
