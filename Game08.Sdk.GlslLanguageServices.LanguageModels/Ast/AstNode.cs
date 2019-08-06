using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class AstNode
    {
        public AstNode Parent;

        protected void SetParent(AstNode oldValue, AstNode newValue)
        {
            if (oldValue != null)
            {
                oldValue.Parent = null;
            }

            if (newValue != null)
            {
                newValue.Parent = this;
            }
        }

        public virtual int GetChildIndex(AstNode child)
        {
            return -1;
        }
    }
}
