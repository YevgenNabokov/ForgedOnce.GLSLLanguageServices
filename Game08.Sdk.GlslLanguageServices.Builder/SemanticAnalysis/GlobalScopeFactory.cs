using Game08.Sdk.GlslLanguageServices.Builder.Interface;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.SemanticAnalysis
{
    public class GlobalScopeFactory : IGlobalScopeFactory
    {
        public Scope Construct(ShaderVersion shaderVersion)
        {
            var result = new Scope();

            result.Symbols.Add("int", new Symbol() { Kind = SymbolKind.Type, Name = "int" });

            return result;
        }
    }
}
