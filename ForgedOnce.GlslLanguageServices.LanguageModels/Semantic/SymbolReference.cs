using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Semantic
{
    public class SymbolReference
    {
        public AstNode IdentifierNode;

        public AstNode OwnerNode;

        public string Name;

        public Symbol ResolvedSymbol;
    }
}
