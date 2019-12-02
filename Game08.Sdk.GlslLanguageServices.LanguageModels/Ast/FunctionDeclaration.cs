using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class FunctionDeclaration : Declaration
    {
        private TypeSpecifier typeSpecifier;

        private Identifier name;

        private StatementCompound statement;

        public FunctionDeclaration()
        {
            this.Parameters = new AstNodeCollection<FunctionParameter>(this);
        }

        public TypeSpecifier TypeSpecifier
        {

            get => typeSpecifier;

            set
            {
                this.SetAsParentFor(this.typeSpecifier, value);
                this.typeSpecifier = value;
            }
        }

        public Identifier Name
        {

            get => name;

            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public StatementCompound Statement
        {

            get => statement;

            set
            {
                this.SetAsParentFor(this.statement, value);
                this.statement = value;
            }
        }

        public AstNodeCollection<FunctionParameter> Parameters { get; private set; }

        public override string GetPrintableName()
        {
            return $"Function:{this.Name?.Name ?? PrintableUnknownName}";
        }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.typeSpecifier)
            {
                return 0;
            }

            if (child == this.name)
            {
                return 1;
            }

            if (child is FunctionParameter && this.Parameters.Contains((FunctionParameter)child))
            {
                return 2 + this.Parameters.IndexOf((FunctionParameter)child);
            }

            if (child == this.statement)
            {
                return 1 + this.Parameters.Count + 1;
            }

            return -1;
        }
    }
}
