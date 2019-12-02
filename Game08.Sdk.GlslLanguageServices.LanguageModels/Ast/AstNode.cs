using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class AstNode
    {
        public const string PrintableUnknownName = "$unnamed$";

        public AstNode Parent;

        protected void SetAsParentFor(AstNode oldValue, AstNode newValue)
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

        public bool EqualsOrSubNodeOf(AstNode node)
        {
            if (this == node)
            {
                return true;
            }

            if (this.Parent != null)
            {
                return this.Parent.EqualsOrSubNodeOf(node);
            }

            return false;
        }
    }
}
