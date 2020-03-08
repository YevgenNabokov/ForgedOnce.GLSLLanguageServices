using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using ForgedOnce.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.Interface
{
    public interface IGlobalScopeFactory
    {
        Scope Construct(ShaderVersion shaderVersion);
    }
}
