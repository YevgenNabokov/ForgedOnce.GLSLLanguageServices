﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class TypeSpecifier : AstNode
    {
        public TypeQualifier Qualifier = new TypeQualifier();
    }
}