using Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.SemanticAnalysis
{
    public class GlobalScopeFactory
    {
        public static Scope Construct()
        {
            var result = new Scope();

            result.Symbols.Add("int", new Symbol() { Kind = SymbolKind.Type, Name = "int" });

            return result;
        }
    }
}
