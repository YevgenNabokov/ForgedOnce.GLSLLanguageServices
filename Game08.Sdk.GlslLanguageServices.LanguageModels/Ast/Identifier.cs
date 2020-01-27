using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class Identifier : AstNode
    {
        private string name;

        public string Name { get => name; set { this.EnsureIsEditable(); name = value; } }
    }
}
