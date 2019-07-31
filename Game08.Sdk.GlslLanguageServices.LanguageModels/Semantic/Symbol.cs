using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic
{
    public class Symbol
    {
        public Scope Parent;

        public string Name;

        public List<AstNode> AstNodes = new List<AstNode>();
    }
}
