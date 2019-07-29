﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class Root : AstNode
    {
        public ShaderVersion Version;

        public List<Declaration> Declarations = new List<Declaration>();
    }
}
