using ForgedOnce.GlslLanguageServices.Builder.AstAnalysis;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.Interface
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
