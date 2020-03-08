using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Semantic
{
    public class Scope
    {
        public Scope Parent;

        public bool Isolated;

        public AstNode AstNode;

        public List<Scope> Scopes = new List<Scope>();

        public Dictionary<string, Symbol> Symbols = new Dictionary<string, Symbol>();

        public Dictionary<string, List<SymbolReference>> References = new Dictionary<string, List<SymbolReference>>();
    }
}
