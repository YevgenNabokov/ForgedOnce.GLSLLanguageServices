using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class VariableDeclarationList : Declaration
    {
        private TypeSpecifier type;
        
        public VariableDeclarationList()
        {
            this.Declarations = new AstNodeCollection<VariableDeclaration>(this);
        }

        public TypeSpecifier Type
        {

            get => type;

            set
            {
                this.SetAsParentFor(this.type, value);
                this.type = value;
            }
        }

        public AstNodeCollection<VariableDeclaration> Declarations { get; private set; }

        public override string GetPrintableName()
        {
            List<string> vars = new List<string>();
            foreach (var d in this.Declarations)
            {
                if (d.Name?.Name != null)
                {
                    vars.Add(d.Name?.Name);
                }
            }

            var varsJoined = string.Join(",", vars);
            varsJoined = varsJoined != string.Empty ? varsJoined : PrintableUnknownName;
            return $"VariableList:{varsJoined}";
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == type)
            {
                return 0;
            }

            if (child is VariableDeclaration && this.Declarations.Contains((VariableDeclaration)child))
            {
                return 1 + this.Declarations.IndexOf((VariableDeclaration)child);
            }

            return -1;
        }
    }
}
