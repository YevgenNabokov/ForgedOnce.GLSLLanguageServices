using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionVariableIdentifier : Expression
    {
        private Identifier identifier;

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetParent(this.identifier, value);
                this.identifier = value;
            }
        }
    }
}
