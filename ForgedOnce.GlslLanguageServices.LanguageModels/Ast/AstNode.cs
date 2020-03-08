using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public abstract class AstNode
    {
        protected Dictionary<string, string> annotations;

        public const string PrintableUnknownName = "$unnamed$";

        protected AstNode parent;

        private bool isReadonly;

        protected List<AstNode> childNodes = new List<AstNode>();

        public AstNode Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                if (this.parent != null)
                {
                    this.parent.EnsureIsEditable();
                    this.parent.childNodes.Remove(this);
                }
                
                if (value != null)
                {
                    value.EnsureIsEditable();
                    value.childNodes.Add(this);
                }

                this.parent = value;
            }
        }

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

        public void MakeReadonly()
        {
            this.isReadonly = true;
            foreach (var item in this.childNodes)
            {
                item.MakeReadonly();
            }
        }

        protected void EnsureIsEditable()
        {
            if (this.isReadonly)
            {
                throw new InvalidOperationException("Attempt to modify a readonly node.");
            }
        }
    }
}
