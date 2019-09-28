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
                this.SetAsParentFor(this.declaration, value);
                this.declaration = value;
            }
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.declaration)
            {
                return 0;
            }

            return -1;
        }
    }
}
