using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic
{
    public class Scope
    {
        public Scope Parent;

        public AstNode AstNode;

        public List<Scope> Scopes = new List<Scope>();

        public Dictionary<string, Symbol> Symbols = new Dictionary<string, Symbol>();
    }
}
