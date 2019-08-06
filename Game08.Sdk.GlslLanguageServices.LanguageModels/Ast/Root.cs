using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class Root : AstNode
    {
        public ShaderVersion Version;

        public Root()
        {
            this.Declarations = new AstNodeCollection<Declaration>(this);
        }

        public AstNodeCollection<Declaration> Declarations { get; private set; }

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
