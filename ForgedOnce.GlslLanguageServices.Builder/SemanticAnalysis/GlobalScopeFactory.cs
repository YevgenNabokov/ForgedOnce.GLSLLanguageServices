using ForgedOnce.GlslLanguageServices.Builder.Interface;
using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using ForgedOnce.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.SemanticAnalysis
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
