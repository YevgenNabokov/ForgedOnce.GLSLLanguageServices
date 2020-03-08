using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class Root : AstNode
    {
        private ShaderVersion version;

        public Root()
        {
            this.Declarations = new AstNodeCollection<Declaration>(this);
        }

        public AstNodeCollection<Declaration> Declarations { get; private set; }
        public ShaderVersion Version { get => version; set { this.EnsureIsEditable(); version = value; } }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child is Declaration && this.Declarations.Contains((Declaration)child))
            {
                return this.Declarations.IndexOf((Declaration)child);
            }

            return -1;
        }
    }
}
