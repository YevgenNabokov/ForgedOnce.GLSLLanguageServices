﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementDo : Statement
    {
        public Statement Body;

        public Expression Condition;
    }
}