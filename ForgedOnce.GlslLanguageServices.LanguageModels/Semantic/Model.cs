using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Semantic
{
    public class Model
    {
        public Dictionary<AstNode, Symbol> NodeSymbols = new Dictionary<AstNode, Symbol>();

        public Scope RootScope;
    }
}
