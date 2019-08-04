using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic
{
    public class Model
    {
        public Dictionary<AstNode, Symbol> NodeSymbols = new Dictionary<AstNode, Symbol>();

        public Scope RootScope;
    }
}
