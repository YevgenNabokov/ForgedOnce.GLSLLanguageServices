﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionVariableIdentifier : Expression
    {
        private Identifier identifier;

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetAsParentFor(this.identifier, value);
                this.identifier = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.identifier)
            {
                return 0;
            }

            return -1;
        }
    }
}
