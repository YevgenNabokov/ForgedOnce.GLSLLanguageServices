﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class BooleanLiteral : Expression
    {
        private string literalValue;

        public string LiteralValue { get => literalValue; set { this.EnsureIsEditable(); literalValue = value; } }
    }
}
