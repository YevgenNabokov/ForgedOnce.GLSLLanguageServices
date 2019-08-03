using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class StatementDeclaration : Statement
    {
        private Declaration declaration;

        public Declaration Declaration
        {

            get => declaration;

            set
            {
                this.SetParent(this.declaration, value);
                this.declaration = value;
            }
        }
    }
}
