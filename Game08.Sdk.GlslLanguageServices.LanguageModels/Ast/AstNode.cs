using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class AstNode
    {
        protected Dictionary<string, string> annotations;

        public const string PrintableUnknownName = "$unnamed$";

        public AstNode Parent;

        public void SetAnnotation(string key, string value)
        {
            if (this.annotations == null)
            {
                this.annotations = new Dictionary<string, string>();
            }

            if (this.annotations.ContainsKey(key))
            {
                this.annotations[key] = value;
            }
            else
            {
                this.annotations.Add(key, value);
            }
        }

        public bool HasAnnotation(string key)
        {
            return this.annotations != null && this.annotations.ContainsKey(key);
        }

        public string GetAnnotation(string key)
        {
            if (this.annotations == null || !this.annotations.ContainsKey(key))
            {
                return null;
            }

            return this.annotations[key];
        }

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
