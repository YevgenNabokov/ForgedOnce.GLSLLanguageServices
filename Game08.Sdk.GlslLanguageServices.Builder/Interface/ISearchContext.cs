using Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.Interface
{
    public interface ISearchContext
    {
        AstNode StartNode { get; }

        List<AstNode> Result { get; }

        void IncreaseDepth();

        void DecreaseDepth();

        TraverseInstruction TestNode(AstNode node);
    }
}
