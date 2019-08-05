using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.Interface
{
    public interface IGlobalScopeFactory
    {
        Scope Construct(ShaderVersion shaderVersion);
    }
}
