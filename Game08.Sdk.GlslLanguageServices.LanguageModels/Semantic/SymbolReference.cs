﻿using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic
{
    public class SymbolReference
    {
        public AstNode Node;

        public string Name;

        public Symbol Symbol;
    }
}