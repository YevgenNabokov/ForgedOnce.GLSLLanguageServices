using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class Identifier : AstNode
    {
        private string name;

        public string Name { get => name; set { this.EnsureIsEditable(); name = value; } }
    }
}
