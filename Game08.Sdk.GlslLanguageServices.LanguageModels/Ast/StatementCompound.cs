﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementCompound : Statement
    {
        public List<Statement> Statements = new List<Statement>();
    }
}